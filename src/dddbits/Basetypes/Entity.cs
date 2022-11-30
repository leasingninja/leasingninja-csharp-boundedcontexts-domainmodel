using System;
using System.Collections.Generic;

namespace dddbits.Basetypes
{
    public abstract class Entity<TIdentity>
    {
        protected Entity(TIdentity identity)
        {
            if (identity == null) {
                throw new ArgumentException("identity must not be null");
            }

            Identity = identity;
        }

        public TIdentity Identity { get; }

        public override string ToString()
        {
            return GetType().Name + " [id=" + Identity + "]";
        }

        protected bool Equals(Entity<TIdentity> other)
        {
            return EqualityComparer<TIdentity>.Default.Equals(Identity, other.Identity);
        }

        public sealed override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity<TIdentity>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TIdentity>.Default.GetHashCode(Identity);
        }

    }
}
