using Online.Shopping.Domain;
using Online.Shopping.Persistence;

namespace Online.Shopping.Presentation.Persistence
{
    internal abstract class Repository<Entity,EntityId> 
        where Entity : Entity<EntityId>
        where EntityId : class
    {
        protected readonly OnlineShoppingDbContext _OnlineShoppingDbContext;

        protected Repository(OnlineShoppingDbContext onlineShoppingDbContext)
        {
            _OnlineShoppingDbContext = onlineShoppingDbContext;
        }

        public void Add(Entity entity)
        {
            _OnlineShoppingDbContext.Set<Entity>().Add(entity);
        }

        public void Update(Entity entity)
        {
            _OnlineShoppingDbContext.Set<Entity>().Update(entity);
        }

        public void Remove(Entity entity)
        {
            _OnlineShoppingDbContext.Set<Entity>().Remove(entity);
        }
    }
}