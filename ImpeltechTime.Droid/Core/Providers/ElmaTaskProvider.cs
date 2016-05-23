using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
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
        // I think updates will be needed after app sleep in background or so...
        public bool UpdateNeeded { get; set; }

        public ElmaTaskProvider (IElmaServiceProvider elmaServiceProvider, IElmaUser user, TaskTimer timer) {
            _wcfService = elmaServiceProvider.ElmaWcfService;
            _user = user;
            _timer = timer;
            UpdateNeeded = true;
        }

        public async Task<IEnumerable<IElmaTask>> GetAllTasks () {
            if (!UpdateNeeded)
                return _allTasks;
            _allTasks = (List<IElmaTask>) await _wcfService.GetTasksForUser (_user);
            UpdateNeeded = false;
            return _allTasks;
        }

        public async Task<IEnumerable<IElmaTask>> GetTasksForDate (DateTime dateTime) {
            return (from task in await GetAllTasks ()
                    where task.StartDateTime < dateTime && task.EndDateTime > dateTime
                    select task).ToList ();
        }

        public async Task<IElmaTask> TaskById (long id) {
            return (from task in await GetAllTasks ()
                    where task.Id == id
                    select task).FirstOrDefault ();
        }

        public async Task<IElmaTask> TaskByUid (Guid uid) {
            return (from task in await GetAllTasks ()
                    where task.Uid == uid
                    select task).FirstOrDefault ();
        }

        public bool StartTaskExecution(IElmaTask task, bool emitChanged = true) {
            foreach (var t in GetAllTasks().Result.Where (t => t.Id != task.Id)) {
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

            _timer.StopTimer (task);
            task.LoggingState = TaskLoggingState.Paused;
            if (emitChanged)
                OnTasksChangedEvent?.Invoke(this, EventArgs.Empty);

            return true;
        }

        public bool StopTaskExecution(IElmaTask task) {
            if (task.LoggingState == TaskLoggingState.NotLogging)
                return false;

            task.LoggingState = TaskLoggingState.NotLogging;

            // TODO: implement sending!
            // here we stop timer and send worklog

            OnTasksChangedEvent?.Invoke(this, EventArgs.Empty);

            return true;
        }

        public event EventHandler OnTasksChangedEvent;
    }
}