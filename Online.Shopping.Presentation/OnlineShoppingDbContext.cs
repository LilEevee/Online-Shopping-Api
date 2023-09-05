using MediatR;
using Microsoft.EntityFrameworkCore;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain;
using Online.Shopping.Domain.Customers;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Persistence
{
    public class OnlineShoppingDbContext : DbContext, IOnlineShoppingDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public OnlineShoppingDbContext(DbContextOptions dbContextOptions, IPublisher publisher)
    :       base(dbContextOptions)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineShoppingDbContext).Assembly);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var domainEvents = ChangeTracker.Entries<IEntity>()
                    .Select(e => e.Entity)
                    .Where(e => e.GetDomainEvents().Any())
                    .SelectMany(e =>
                    {
                        var domainEvents = e.GetDomainEvents();
                        e.ClearDomainEvents();
                        return domainEvents;
                    }).ToList();

                var result = await base.SaveChangesAsync(cancellationToken);

                foreach (var domainEvent in domainEvents)
                {
                    await _publisher.Publish(domainEvent, cancellationToken);
                }
            }
            catch (Exception exc)
            {

            }

            return 1;
        }
    }
}
