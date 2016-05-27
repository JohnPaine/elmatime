using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ImpeltechTime.Droid.Core.Model
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum TaskLoggingState
    {
        NotLogging,
        Logging,
        Paused
    }

    public interface IElmaTask : IElmaEntity, ISerializable
    {
        TaskPriority Priority { get; set; }
        TaskLoggingState LoggingState { get; set; }
        
        List<IElmaWorkLog> WorkLogs { get; set; }
        IElmaWorkLog UnaccountedWorkLog { get; set; }
        void AddWorkingTime (DateTime startDate, TimeSpan factWorktime, string comment);
        void AddUnaccountedTime (TimeSpan? unaccounted);

        string Subject { get; set; }
        string Description { get; set; }
        string Comment { get; set; }

        DateTime? StartDateTime { get; set; }
        DateTime? EndDateTime { get; set; }

        TimeSpan? PlannedWorkTime { get; }
        TimeSpan? FactWorkTime { get; }
        TimeSpan? UnaccountedWorkTime { get; set; }
    }
}