using Online.Shopping.Domain.Customers;
using Online.Shopping.Domain.Products;
using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Domain.Carts
{
    public class Cart : Entity<CartId>
    {
        private readonly List<LineItem> _lineItems = new();
        
        private Cart() { }

        public CustomerId CustomerId { get; private set; }
        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

        public static Cart Create(CustomerId customerId)
        {
            var cart = new Cart
            {
                Id = new CartId(Guid.NewGuid()),
                CustomerId = customerId
            };

            cart.Raise(new CartCreatedDomainEvent(Guid.NewGuid(), cart.Id));

            return cart;
        }

        public void AddLineItem(ProductId productId, int quantity)
        {
            var lineItem = new LineItem(
                new LineItemId(Guid.NewGuid()),
                Id,
                productId,
                quantity);

            _lineItems.Add(lineItem);

            Raise(new LineItemAddedDomainEvent(Guid.NewGuid(), Id, lineItem.LineItemId));
        }

        public void RemoveLineItem(LineItemId lineItemId)
        {
            if (HasOneLineItem())
            {
                return;
            }

            var lineItem = _lineItems.FirstOrDefault(li => li.LineItemId == lineItemId);

            if (lineItem is null)
            {
                return;
            }

            _lineItems.Remove(lineItem);

            Raise(new LineItemRemovedDomainEvent(Guid.NewGuid(), Id, lineItem.LineItemId));
        }

        private bool HasOneLineItem() => _lineItems.Count == 1;
    }
}
