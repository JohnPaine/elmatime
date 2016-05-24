using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Model.Providers;

namespace ImpeltechTime.Droid.Adapters
{
    public class TaskAdapter : BaseAdapter<IElmaTask>
    {
        private readonly Activity _context;
        private readonly DateTime _date;
        private readonly IElmaTaskProvider _taskProvider;
        private TextView _remainingTimeTextView;
        private Button _taskLoggingStateButton;
        private List<IElmaTask> _tasks;

        private TextView _taskSubjectTextView;
        private TextView _tillDateTextView;
        private TextView _unaccountedWorkTimeTextView;

        private RelativeLayout _unaccountedLayout;

        public TaskAdapter (Activity context, DateTime date, IElmaTaskProvider taskProvider) {
            _context = context;
            _taskProvider = taskProvider;
            _date = date;
            _tasks = _taskProvider.GetTasksForDate (_date).Result.ToList ();
        }

        public override int Count => _tasks.Count;

        public override IElmaTask this [int position] => _tasks[position];

        public override long GetItemId (int position) {
            return position;
        }

        private void FindViews (View convertView) {
            _taskSubjectTextView = convertView.FindViewById<TextView> (Resource.Id.taskSubjectTextView);
            _tillDateTextView = convertView.FindViewById<TextView> (Resource.Id.tillDateTextView);
            _remainingTimeTextView = convertView.FindViewById<TextView> (Resource.Id.remainingTimeTextView);
            _unaccountedWorkTimeTextView = convertView.FindViewById<TextView> (Resource.Id.unaccountedWorkTimeTextView);
            _taskLoggingStateButton = convertView.FindViewById<Button> (Resource.Id.taskLoggingStateButton);
            _unaccountedLayout = convertView.FindViewById<RelativeLayout> (Resource.Id.unaccountedTimeLayout);
        }

        public override View GetView (int position, View convertView, ViewGroup parent) {
            _tasks = _taskProvider.GetTasksForDate (_date).Result.ToList ();
            var task = _tasks[position];
            var loggingState = task.LoggingState;
            var image = loggingState == TaskLoggingState.Logging
                            ? Android.Resource.Drawable.IcMediaPause
                            : Android.Resource.Drawable.IcMediaPlay;

            var init = false;
            if (null == convertView) {
                convertView = _context.LayoutInflater.Inflate (Resource.Layout.TaskRowView, null);
                init = true;
            }

            FindViews (convertView);

            _taskSubjectTextView.Text = task.Subject;
            _tillDateTextView.Text = $"Till {task.EndDateTime}";

            double? hours = null;
            if (task.PlannedWorkTime != null)
                hours = task.FactWorkTime == null
                            ? task.PlannedWorkTime.Value.TotalHours
                            : (task.PlannedWorkTime.Value - task.FactWorkTime.Value).TotalHours;
            if (null != hours) {
                _remainingTimeTextView.Visibility = ViewStates.Visible;
                _remainingTimeTextView.Text = $"{(int) hours} hours remaining";
            }
            else
                _remainingTimeTextView.Visibility = ViewStates.Invisible;

            // TODO: replace seconds with hours and minutes
            if (task.UnaccountedWorkTime?.TotalSeconds != null) {
                _unaccountedLayout.Visibility = ViewStates.Visible;
                _unaccountedWorkTimeTextView.Text = ((int) task.UnaccountedWorkTime?.TotalSeconds).ToString ();
            }
            else
                _unaccountedLayout.Visibility = ViewStates.Invisible;
            _taskLoggingStateButton.SetBackgroundResource (image);

            if (init) {
                _taskLoggingStateButton.Click += delegate {
                    if (task.LoggingState == TaskLoggingState.NotLogging || task.LoggingState == TaskLoggingState.Paused) {
                        _taskProvider.StartTaskExecution (task);
                        _taskLoggingStateButton.SetBackgroundResource (Android.Resource.Drawable.IcMediaPause);
                    }
                    else {
                        _taskProvider.PauseTaskExecution (task);
                        _taskLoggingStateButton.SetBackgroundResource (Android.Resource.Drawable.IcMediaPlay);
                    }
                };
            }

            return convertView;
        }
    }
}