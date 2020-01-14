using System;
using System.Collections.Generic;

namespace dddbits.Basetypes
{
    public abstract class TinyType<T> : IEquatable<TinyType<T>>
    {
        protected TinyType(T value)
        {
            Value = value;
        }

        public T Value { get; }
        
        public override string ToString() => GetType().Name + " [" + Value + "]";

        public bool Equals(TinyType<T> other)
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
            return Equals((TinyType<T>) obj);
        }

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Value);
        
        public static bool operator ==(TinyType<T> left, TinyType<T> right) => Equals(left, right);

        public static bool operator !=(TinyType<T> left, TinyType<T> right) => !Equals(left, right);
    }
}