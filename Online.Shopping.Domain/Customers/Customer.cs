namespace Online.Shopping.Domain.Customers
{
    public class Customer : Entity<CustomerId>
    {
        public Customer(CustomerId customerId, string email, string name) : base(customerId)
        {
            Email = email;
            Name = name;
        }

        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
    }
}
