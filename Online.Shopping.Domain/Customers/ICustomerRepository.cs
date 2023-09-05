namespace Online.Shopping.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(CustomerId customerId);
        void Add(Customer customer);
    }
}
