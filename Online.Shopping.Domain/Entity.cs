using System.ComponentModel.DataAnnotations.Schema;

namespace Online.Shopping.Domain
{
    public abstract class Entity<EntityId> : IEntity
    {
        private readonly List<DomainEvent> _domainEvents = new();
        public EntityId Id { get; init; }

        protected Entity(EntityId id)
        {
            Id = id;
        }

        protected Entity()
        {

        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public IReadOnlyCollection<DomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
