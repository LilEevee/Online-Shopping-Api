using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Persistence.Repositories
{
    internal sealed class CustomerRepository : Repository<Customer, CustomerId>, ICustomerRepository
    {
        public CustomerRepository(OnlineShoppingDbContext onlineShoppingDbContext) : base(onlineShoppingDbContext)
        {
        }
    }
}
