namespace Online.Shopping.Domain
{
    public interface IEntity
    {
        IReadOnlyCollection<DomainEvent> GetDomainEvents();

        void ClearDomainEvents();
    }
}
