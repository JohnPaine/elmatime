using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
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

namespace ImpeltechTime.Droid
{
    [Activity (Label = "TaskListActivity")]
    public class TaskListActivity : Activity
    {
        private readonly Dictionary<int, TaskAdapter> _taskAdapters = new Dictionary<int, TaskAdapter> ();
        private DateTime _currentDate;
        private TextView _currentDateTextView;
        private Button _nextDateButton;
        private Button _previousDateButton;
        private Button _menuButton;
        private TextView _plannedWorklogTextView;
        private TextView _sentWorklogTextView;
        private ListView _tasksListView;
        private TaskTimer _timer;
        private Chronometer _chronometer;
        private IElmaTaskProvider _taskProvider;

        private event EventHandler OnCreateHandler;

        protected override void OnCreate (Bundle savedInstanceState) {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.TaskList);

            Log.Info ("TaskListActivity", "Starting");

            var creds = Intent.GetStringArrayExtra ("cred");
            if (null == creds || creds.Length != 2) {
                Log.Error("TaskListActivity", "Error getting credentials! Finishing...");
                Finish();
                return;
            }

            Log.Info ("TaskListActivity", $"creds[0]={creds[0]}, creds[1]={creds[1]}");

            var userProvider = App.Container.Resolve (typeof (ElmaUserProvider), "ElmaUserProvider") as ElmaUserProvider;
            var user = userProvider?.LoginUser (creds[0], creds[1]);
            if (null == user) {
                Log.Error("TaskListActivity", "Error getting user instance! Returning to Login activity!");
                var intent = new Intent (this, typeof (LoginActivity));
                intent.PutExtra ("user_invalid", true);
                StartActivity (intent);
                Finish ();
                return;
            }
            SetupViews ();
            // TODO: check correctness!!!
            // this is probably a bad architecture sign, passing arguments for di container to resolve an instance...
            // but I just don't know for now how to make it right.
            // _taskProvider = App.Container.Resolve<ElmaTaskProvider> (new OrderedParametersOverride(new object[] {user, _timer}));
            _taskProvider =
                App.Container.Resolve<ElmaTaskProvider> (new ParameterOverrides {{"user", user}, {"timer", _timer}});

            _taskProvider.OnTasksChangedEvent += delegate {
                _tasksListView.InvalidateViews ();
            };

            OnCreateHandler += async (sender, e) => { await ChangeCurrentDate (DateTime.Now); };

            OnCreateHandler?.Invoke (this, EventArgs.Empty);

            Log.Info("TaskListActivity", "All OK");
        }

        private void SetupViews () {
            FindViews ();
            SetupTimer ();

            _previousDateButton.Click += async (sender, e) => { await ChangeCurrentDate (_currentDate.AddDays (-1)); };
            _nextDateButton.Click += async (sender, e) => { await ChangeCurrentDate (_currentDate.AddDays (1)); };
        }

        private void FindViews () {
            _tasksListView = FindViewById<ListView> (Resource.Id.tasksListView);
            _previousDateButton = FindViewById<Button> (Resource.Id.previousDateButton);
            _nextDateButton = FindViewById<Button> (Resource.Id.nextDateButton);
            _menuButton = FindViewById<Button> (Resource.Id.menuButton);
            _menuButton.Click += (s, arg) => {
                var menu = new PopupMenu (this, _menuButton);

                menu.Inflate (Resource.Layout.main_menu);

                menu.MenuItemClick += (s1, arg1) => {
                    // TODO: replace hardcoded text checking with Id checking!!!
                    if (arg1.Item.TitleFormatted.ToString () == "Logout") {
                        Log.Error("TaskListActivity", "Logging out!");
                        var intent = new Intent(this, typeof(LoginActivity));
                        intent.PutExtra("user_invalid", true);
                        StartActivity(intent);
                        Finish();
                    }
                };

                menu.Show ();
            };
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

        private void SetupTimer () {
            _chronometer.ChronometerTick += delegate {
                var time = SystemClock.ElapsedRealtime () - _chronometer.Base;
                var h = (int)(time / 3600000);
                var m = (int)(time - h * 3600000) / 60000;
                var s = (int)(time - h * 3600000 - m * 60000) / 1000;
                var hh = h < 10 ? "0" + h : h + "";
                var mm = m < 10 ? "0" + m : m + "";
                var ss = s < 10 ? "0" + s : s + "";
                _chronometer.Text = hh + ":" + mm + ":" + ss;
            };

            _timer = new TaskTimer (_chronometer);

        }

        private async Task<bool> ChangeCurrentDate (DateTime date) {
            _currentDate = date;
            _currentDateTextView.Text = date.Date.ToShortDateString ();
            return await ChangeTaskListForDate (date);
        }

        private async Task<bool> ChangeTaskListForDate (DateTime date) {
            var tasks = await _taskProvider.GetTasksForDate (date);
            if (null == tasks) {
                new AlertDialog.Builder (this).SetTitle ("Error")
                                                .SetMessage ("Error getting tasks for date!")
                                                .Show ();
                return false;
            }
            var elmaTasks = tasks as IList<IElmaTask> ?? tasks.ToList ();
            var adapter = new TaskAdapter (this, date, _taskProvider);

            _tasksListView.Adapter = adapter;
            UpdateWorklogTimeDisplays (elmaTasks);

            return true;
        }
    }
}