using System;
using System.Runtime.Serialization;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaWorkLog : IElmaEntity, ISerializable
    {
        DateTime? StartDate { get; set; }
        TimeSpan? WorkTime { get; }
        string Comment { get; set; }

//        void AddTimeToLog (DateTime timeToLog);

        /// <summary>
        /// If LogTime returns false, WorkTime remains till serialization
        /// or until next attempt to log time.
        /// Otherwise, WorkTime is cleared with StartDate
        /// </summary>
        /// <returns>
        /// true if succesfully logged to server. Otherwise, returns false
        /// </returns>
        bool LogTime ();
    }
}