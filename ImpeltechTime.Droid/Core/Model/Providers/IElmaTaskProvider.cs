using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Java.Security;

namespace ImpeltechTime.Droid.Core.Model.Providers
{
    public interface IElmaTaskProvider
    {
        IEnumerable<IElmaTask> GetAllTasks();
        IEnumerable<IElmaTask> GetTasksForDate(DateTime dateTime);
        IElmaTask TaskById(long id);
        IElmaTask TaskByUid(Guid uid);

        bool UpdateNeeded { get; set; }

        /// <summary>
        /// Starts task execution and pauses previously executing task if there were any
        /// </summary>
        /// <param name="task"></param>
        /// <param name="emitChanged"></param>
        /// <returns>true on success, otherwise false</returns>
        bool StartTaskExecution(IElmaTask task, bool emitChanged = true);

        /// <summary>
        /// Pauses task execution if it was in executing state
        /// </summary>
        /// <param name="task"></param>
        /// <param name="emitChanged"></param>
        /// <returns>true on success, otherwise false</returns>
        bool PauseTaskExecution(IElmaTask task, bool emitChanged = true);

        /// <summary>
        /// Stops task execution if it was in executing state and adds timer time to unaccounted time
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool SendTaskWorklog(IElmaTask task);

        event EventHandler OnTasksChangedEvent;
    }
}