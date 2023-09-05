using Microsoft.EntityFrameworkCore;
using Online.Shopping.Domain;

namespace Online.Shopping.Persistence.Repositories
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

        public virtual Task<Entity?> GetByIdAsync(EntityId id)
        {
            return _OnlineShoppingDbContext.Set<Entity>()
                .SingleOrDefaultAsync(p => p.Id == id);
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