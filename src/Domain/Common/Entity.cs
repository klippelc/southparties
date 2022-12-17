using Common;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public abstract class Entity<TKey> : ControlFields, IEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }

        [Required, Index(IsUnique = true)]
        [StringLength(AppConstants.HasMaxLength48)]
        public string DomainKey { get; set; }

        public override bool Equals(object obj) => Equals(obj as Entity<TKey>);

        // TODO: 01. Whats this doing? 
        public virtual bool Equals(Entity<TKey> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();

                return thisType.IsAssignableFrom(otherType) ||
                        otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        // TODO: 02. Whats this doing? 
        private static bool IsTransient(Entity<TKey> obj) => obj != null && Equals(obj.Id, default(TKey));

        // TODO: 03. Whats this doing? 
        private Type GetUnproxiedType() => GetType();

        // TODO: 04. Whats this doing? 
        public override string ToString() => JsonConvert.SerializeObject(this);

        // TODO: 05. Whats this doing? 
        public override int GetHashCode() => Id.GetHashCode();

        // TODO: 06. Whats this doing? 
        public static bool operator ==(Entity<TKey> x, Entity<TKey> y) => Equals(x, y);

        // TODO: 07. Whats this doing? 
        public static bool operator !=(Entity<TKey> x, Entity<TKey> y) => !(x == y);
    }
}
