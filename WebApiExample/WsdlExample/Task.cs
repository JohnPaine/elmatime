using System;

namespace WsdlExample
{
    public class Task : IEntity
    {
        public Task (long id, Guid uid) {
            Id = id;
            // TaskBase Uid
            TypeUid = "f532ef81-20e1-467d-89a4-940c57a609bc";
            Uid = uid;
        }

        public long Id { get; }
        public string TypeUid { get; }
        public Guid Uid { get; }
    }
}