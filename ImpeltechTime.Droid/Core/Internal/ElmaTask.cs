using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ImpeltechTime.Droid.Core.Model;

namespace ImpeltechTime.Droid.Core.Internal
{
    public class ElmaTask : IElmaTask
    {
        public const string TaskTypeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";        

        public ElmaTask (long id, Guid uid) {
            Id = id;
            TypeUid = TaskTypeUid;
            Uid = uid;

            Priority = TaskPriority.Low;
            LoggingState = TaskLoggingState.NotLogging;
        }

        public long Id { get; }
        public string TypeUid { get; }
        public Guid Uid { get; set; }
        public void GetObjectData (SerializationInfo info, StreamingContext context) {
            throw new NotImplementedException ();
        }

        public TaskPriority Priority { get; set; }
        public TaskLoggingState LoggingState { get; set; }
        public List<IElmaWorkLog> WorkLogs { get; set; }
        public void AddWorkingTime (DateTime startDate, TimeSpan factWorktime, string comment) {
            throw new NotImplementedException ();
        }

        public void AddUnaccountedTime (TimeSpan? unaccounted) {
            if (null == unaccounted)
                return;
            if (null == UnaccountedWorkTime)
                UnaccountedWorkTime = new TimeSpan();
            UnaccountedWorkTime += unaccounted;
        }

        public string Subject { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public TimeSpan? PlannedWorkTime { get; set; }

        public TimeSpan? FactWorkTime {
            get {
                if (WorkLogs.Count == 0)
                    return null;
                var summary = new TimeSpan();
                return WorkLogs.Where (workLog => workLog.WorkTime != null).Aggregate (summary, (current, workLog) => current + workLog.WorkTime.Value);
            }
        }

        public TimeSpan? UnaccountedWorkTime { get; private set; }
    }
}