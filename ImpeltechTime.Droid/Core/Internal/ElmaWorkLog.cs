using System;
using System.Runtime.Serialization;
using ImpeltechTime.Droid.Core.Model;

namespace ImpeltechTime.Droid.Core.Internal
{
    public class ElmaWorkLog : IElmaWorkLog
    {
        public const string WorkLogTypeUid = "e51a53b7-087a-4d31-8033-4d130676d0da";
//        public const string WorkLogTypeUid = "2ec4f892-0d70-4ded-b554-494f61d78a66";

        public ElmaWorkLog (long id, Guid uid) {
            Id = id;
            TypeUid = WorkLogTypeUid;
            Uid = uid;
        }

        public long Id { get; }
        public string TypeUid { get; }
        public Guid Uid { get; set; }
        public void GetObjectData (SerializationInfo info, StreamingContext context) {
            throw new NotImplementedException ();
        }

        public DateTime? StartDate { get; set; }
        public TimeSpan? WorkTime { get; set; }
        public string Comment { get; set; }

//        public void AddTimeToLog (DateTime timeToLog) {
//            WorkTime += TimeSpan(timeToLog);
//        }

        /// <summary>
        /// If LogTime returns false, WorkTime remains till serialization
        /// or until next attempt to log time.
        /// Otherwise, WorkTime is cleared with StartDate
        /// </summary>
        /// <returns>
        /// true if succesfully logged to server. Otherwise, returns false
        /// </returns>
        public bool LogTime () {
            throw new NotImplementedException ();
        }
    }
}