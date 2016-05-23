using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaUser : IElmaEntity, ISerializable
    {
        string AccountName { get; set; }
        // TODO: find out, why passwords may vary?
        string InitialPass { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }


//        Task<IEnumerable<IElmaTask>> GetAllTasks ();
//        Task<IEnumerable<IElmaTask>> GetTasksForDate (DateTime dateTime);
//        Task<IElmaTask> TaskById (long id);
//        Task<IElmaTask> TaskByUid (Guid uid);
    }
}