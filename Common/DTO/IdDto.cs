using System;
using System.Collections.Generic;

namespace DTO
{
    public class IdDto<T> : IEquatable<IdDto<T>>
    {
        public T Id { get; }
        private readonly int hashCode;

        public IdDto(T id)
        {
            Id = id;
            hashCode = id?.GetHashCode() ?? -1537948245;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IdDto<T>);
        }

        public bool Equals(IdDto<T> other)
        {
            return other != null &&
                   EqualityComparer<T>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode() => hashCode;
    }
}
