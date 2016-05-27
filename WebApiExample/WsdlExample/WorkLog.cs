using System;

namespace WsdlExample
{
    class WorkLog : IEntity
    {
        public WorkLog (long id, Guid uid) {
            Id = id;
            TypeUid = "e51a53b7-087a-4d31-8033-4d130676d0da";
            Uid = uid;
        }

        public long Id { get; }
        public string TypeUid { get; }
        public Guid Uid { get; }
    }
}