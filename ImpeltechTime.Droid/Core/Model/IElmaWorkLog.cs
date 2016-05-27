using System;
using System.Runtime.Serialization;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaWorkLog : IElmaEntity, ISerializable
    {
        DateTime? StartDate { get; set; }
        TimeSpan? WorkTime { get; set; }
        string Comment { get; set; }
    }
}