using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using ImpeltechTime.Droid.Core.Internal;
using ImpeltechTime.Droid.Core.Model;
using ImpeltechTime.Droid.Core.Model.Providers;
using ImpeltechTime.Droid.Utility;

namespace ImpeltechTime.Droid.Core.Providers
{
    public class ElmaTaskProvider : IElmaTaskProvider
    {
        private readonly IElmaUser _user;
        private readonly IElmaWcfService _wcfService;
        private readonly TaskTimer _timer;

        private List<IElmaTask> _allTasks = new List<IElmaTask> ();
        // TODO: decide when to update!!!
        // I think updates will be needed after app wakes up from the background
        public bool UpdateNeeded { get; set; }

        public ElmaTaskProvider (IElmaServiceProvider elmaServiceProvider, IElmaUser user, TaskTimer timer) {
            _wcfService = elmaServiceProvider.ElmaWcfService;
            _user = user;
            _timer = timer;
            UpdateNeeded = true;
        }

        public IEnumerable<IElmaTask> GetAllTasks () {
            if (!UpdateNeeded)
                return _allTasks;
            _allTasks = _wcfService.GetTasksForUser(_user).ToList ();
            UpdateNeeded = false;
            return _allTasks;
        }

        public IEnumerable<IElmaTask> GetTasksForDate (DateTime dateTime) {
            return (from task in GetAllTasks ()
                    where task.StartDateTime < dateTime && task.EndDateTime > dateTime
                    select task).ToList ();
        }

        public IElmaTask TaskById (long id) {
            return (from task in GetAllTasks ()
                    where task.Id == id
                    select task).FirstOrDefault ();
        }

        public IElmaTask TaskByUid (Guid uid) {
            return (from task in GetAllTasks ()
                    where task.Uid == uid
                    select task).FirstOrDefault ();
        }

        public bool StartTaskExecution(IElmaTask task, bool emitChanged = true) {
            foreach (var t in GetAllTasks().Where (t => t.Id != task.Id)) {
                PauseTaskExecution(t, false);
            }

            task.LoggingState = TaskLoggingState.Logging;
            _timer.StartTimer (task);
            if (emitChanged)
                OnTasksChangedEvent?.Invoke (this, EventArgs.Empty);

            return true;
        }

        public bool PauseTaskExecution(IElmaTask task, bool emitChanged = true) {
            if (task.LoggingState != TaskLoggingState.Logging)
                return false;

            task.LoggingState = TaskLoggingState.Paused;
            _timer.StopTimer ();
            if (emitChanged)
                OnTasksChangedEvent?.Invoke(this, EventArgs.Empty);

            return true;
        }

        public bool SendTaskWorklog (IElmaTask task) {
            if (task.LoggingState == TaskLoggingState.NotLogging)
                return false;

            task.LoggingState = TaskLoggingState.NotLogging;
            _timer.StopTimer ();

            // TODO: DateTime.Now probably have to be changed to UtcNow
            // TODO: add form for changing StartDate and Comment
            if (null == task.UnaccountedWorkLog) {
                task.UnaccountedWorkLog = new ElmaWorkLog (0, Guid.Empty) {
                    StartDate = DateTime.Now,
                    Comment = "Sent from mobile app",
                    WorkTime = task.UnaccountedWorkTime
                };
            }
            else {
                if (null == task.UnaccountedWorkLog.WorkTime)
                    task.UnaccountedWorkLog.WorkTime = new TimeSpan();
                if (task.UnaccountedWorkTime != null)
                    task.UnaccountedWorkLog.WorkTime += task.UnaccountedWorkTime.Value;
            }

            if (_wcfService.SendWorkLogAsync (_user, task) == false) {
                // TODO: add some message for user about that and change green cloud to red cross or smth..
                OnTasksChangedEvent?.Invoke(this, EventArgs.Empty);


                return false;
            }

            task.UnaccountedWorkTime = null;
            task.UnaccountedWorkLog = null;

            OnTasksChangedEvent?.Invoke(this, EventArgs.Empty);

            return true;
        }

        public event EventHandler OnTasksChangedEvent;
    }
}