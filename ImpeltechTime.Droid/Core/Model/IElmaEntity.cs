using System;

namespace ImpeltechTime.Droid.Core.Model
{
    public interface IElmaEntity
    {
        long Id { get; }
        string TypeUid { get; }
        Guid Uid { get; set; }
    }
}