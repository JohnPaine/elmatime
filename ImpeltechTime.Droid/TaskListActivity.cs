using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using ImpeltechTime.Droid.Adapters;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Model.Providers;
using ImpeltechTime.Droid.Core.Providers;
using ImpeltechTime.Droid.Utility;
using Microsoft.Practices.Unity;
using Timer = System.Timers.Timer;

namespace ImpeltechTime.Droid
{
    [Activity (Label = "TaskListActivity", Theme = "@style/CustomActionBarTheme")]
    public class TaskListActivity : Activity
    {
        private readonly Dictionary<int, TaskAdapter> _taskAdapters = new Dictionary<int, TaskAdapter> ();

        // Views
        private Chronometer _chronometer;
        private DateTime _currentDate;
        private TextView _currentDateTextView;
        private Button _menuButton;
        private Button _nextDateButton;
        private TextView _plannedWorklogTextView;
        private Button _previousDateButton;
        private Button _sendAllWorklogsButton;
        private TextView _sentWorklogTextView;
        private TaskTimer _taskExecutionTimer;
        private ListView _tasksListView;

        // Providers
        private IElmaTaskProvider _taskProvider;
        
        // Instances
        private IElmaUser _user;

        private static async Task<IElmaUser> LoginAsync (string name, string pass) {
            return await Task.Run (() => {
                var userProvider =
                    App.Container.Resolve(typeof(ElmaUserProvider), "ElmaUserProvider") as ElmaUserProvider;
                var user = userProvider?.LoginUser(name, pass);
                if (null == user)
                    Log.Error("TaskListActivity", "Error getting user instance! Returning to Login activity!");
                return user;
            });
        }

        private async Task<IEnumerable<IElmaTask>> GetTaskListAsync() {
            return await Task.Run(() => _taskProvider.GetTasksForDate(_currentDate));
        }

        private async Task CurrentDateChanged () {
            var tasks = await GetTaskListAsync();

            var elmaTasks = tasks as IList<IElmaTask> ?? tasks;
            var adapter = new TaskAdapter(this, _currentDate, _taskProvider);

            _tasksListView.Adapter = adapter;
            _currentDateTextView.Text = _currentDate.Date.ToShortDateString();
            UpdateWorklogTimeDisplays(elmaTasks);
        }

        private async Task GetInstances (string name, string pass) {
            _user = await LoginAsync(name, pass);
            if (null == _user) {
                Log.Error("TaskListActivity, GetInstances", "Authorization failed - login/pass invalid or connection is lost!");
                var intent = new Intent(this, typeof(LoginActivity));
                intent.PutExtra("user_invalid", true);
                StartActivity(intent);
                Finish();
            }

            _taskProvider =
                App.Container.Resolve<ElmaTaskProvider>(new ParameterOverrides {
                    {"user", _user},
                    {"timer", _taskExecutionTimer}
                });
            _taskProvider.OnTasksChangedEvent += delegate { _tasksListView.InvalidateViews(); };
        }

        protected override async void OnCreate (Bundle savedInstanceState) {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.TaskList);

            // TODO: show some "loading sign" while tasks are being updated

            Log.Info ("TaskListActivity", "Starting");
            Log.Info ("DEBUG TaskListActivity OnCreate", $"ThreadID - {Thread.CurrentThread.ManagedThreadId}");

            var creds = Intent.GetStringArrayExtra ("cred");
            if (null == creds || creds.Length != 2) {
                Log.Error ("TaskListActivity", "Error getting credentials! Finishing...");
                Finish ();
                return;
            }

            Log.Info ("TaskListActivity", $"c={creds[0]}, creds[1]={creds[1]}");

            SetupViews ();

            await GetInstances (creds[0], creds[1]);

            _currentDate = DateTime.Now;
            await CurrentDateChanged ();

            Log.Info ("TaskListActivity", "All OK");
        }

        private void SetupViews () {
            FindViews ();
            SetupTimers ();
            SetupMenu ();
            SetupButtons ();

            _previousDateButton.Click += async delegate {
                _currentDate = _currentDate.AddDays (-1);
                await CurrentDateChanged();
            };
            _nextDateButton.Click += async delegate {
                _currentDate = _currentDate.AddDays (1);
                await CurrentDateChanged();
            };
        }

        private void FindViews () {
            _tasksListView = FindViewById<ListView> (Resource.Id.tasksListView);
            _previousDateButton = FindViewById<Button> (Resource.Id.previousDateButton);
            _nextDateButton = FindViewById<Button> (Resource.Id.nextDateButton);
            _menuButton = FindViewById<Button> (Resource.Id.menuButton);
            _sendAllWorklogsButton = FindViewById<Button> (Resource.Id.sendAllWorklogButton);
            _chronometer = FindViewById<Chronometer> (Resource.Id.timerChronometer);
            _currentDateTextView = FindViewById<TextView> (Resource.Id.currentDateTextView);
            _plannedWorklogTextView = FindViewById<TextView> (Resource.Id.plannedWorklogTextView);
            _sentWorklogTextView = FindViewById<TextView> (Resource.Id.sentWorklogTextView);
        }

        private void UpdateWorklogTimeDisplays (IEnumerable<IElmaTask> tasks) {
            int planned = 0, sent = 0;
            foreach (var task in tasks) {
                if (task.PlannedWorkTime != null)
                    planned += task.PlannedWorkTime.Value.Hours;
                if (task.FactWorkTime != null)
                    sent += task.FactWorkTime.Value.Hours;
            }
            _plannedWorklogTextView.Text = $"{planned} hours planned";
            _sentWorklogTextView.Text = $"{sent} hours sent";
        }

        private void SetupButtons () {
            // TODO: implement sending worklogs for tasks of current date or for all at once??
            _sendAllWorklogsButton.Click += delegate {
                var tasks = _taskProvider.GetTasksForDate (_currentDate);
                if (null == tasks)
                    return;
                // TODO: add some sign for user about sending and change @sendStatusImageButton image on success or fail
                foreach (var task in tasks)
                    _taskProvider.SendTaskWorklog (task);
            };
        }

        private void SetupMenu () {
            _menuButton.Click += (s, arg) => {
                var menu = new PopupMenu (this, _menuButton);

                menu.Inflate (Resource.Layout.main_menu);

                menu.MenuItemClick += async (s1, arg1) => {
                    switch (arg1.Item.ItemId) {
                        case Resource.Id.logoutItem: {
                            Log.Error ("TaskListActivity", "Logging out!");
                            var intent = new Intent (this, typeof (LoginActivity));
                            intent.PutExtra ("user_invalid", true);
                            StartActivity (intent);
                            Finish ();
                        }
                            break;
                        case Resource.Id.reloadTasksItem: {
                            Log.Error("TaskListActivity", "Reloadding tasks!");
                            _taskProvider.UpdateNeeded = true;
                            await CurrentDateChanged ();
                        }
                            break;
                    }
                };

                menu.Show ();
            };
        }

        private void SetupTimers () {
            _chronometer.ChronometerTick += delegate {
                var time = SystemClock.ElapsedRealtime () - _chronometer.Base;
                var h = (int) (time/3600000);
                var m = (int) (time - h*3600000)/60000;
                var s = (int) (time - h*3600000 - m*60000)/1000;
                var hh = h < 10 ? "0" + h : h + "";
                var mm = m < 10 ? "0" + m : m + "";
                var ss = s < 10 ? "0" + s : s + "";
                _chronometer.Text = hh + ":" + mm + ":" + ss;
            };

            _taskExecutionTimer = new TaskTimer (_chronometer);
        }
    }
}