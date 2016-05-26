using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Java.Security;

namespace ImpeltechTime.Droid.Core.Model.Providers
{
    public interface IElmaTaskProvider
    {
        Task<IEnumerable<IElmaTask>> GetAllTasks();
        Task<IEnumerable<IElmaTask>> GetTasksForDate(DateTime dateTime);
        Task<IElmaTask> TaskById(long id);
        Task<IElmaTask> TaskByUid(Guid uid);

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