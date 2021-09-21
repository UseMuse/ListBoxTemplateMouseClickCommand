using System;

namespace Interfaces
{
    public interface ICloneable<T> : ICloneable
    {
        new T Clone();
    }

}
