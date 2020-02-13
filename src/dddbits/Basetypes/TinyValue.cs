using System;
using System.Collections.Generic;

namespace dddbits.Basetypes
{
    public abstract class TinyValue<T> : IEquatable<TinyValue<T>>
    {
        protected TinyValue(T value)
        {
            Value = value;
        }

        public T Value { get; }
        
        public override string ToString() => GetType().Name + " [" + Value + "]";

        public bool Equals(TinyValue<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != this.GetType()) return false;
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TinyValue<T>) obj);
        }

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value);
        
        public static bool operator ==(TinyValue<T> left, TinyValue<T> right) => Equals(left, right);

        public static bool operator !=(TinyValue<T> left, TinyValue<T> right) => !Equals(left, right);
    }
}