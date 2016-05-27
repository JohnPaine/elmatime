using System;

namespace WsdlExample
{
    public interface IEntity
    {
        long Id { get; }
        string TypeUid { get; }
        Guid Uid { get; }
    }
}