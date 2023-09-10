using Online.Shopping.Application.Carts.AddLineItem;
using Online.Shopping.Application.Carts.Create;
using Online.Shopping.Application.Carts.Get;
using Online.Shopping.Application.Carts.RemoveLineItem;
using Online.Shopping.Application.Customers.Create;
using Online.Shopping.Application.Products.Create;
using Online.Shopping.Application.Products.Delete;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Customers;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Tests
{
    public class CartIntegrationTests : BaseIntegrationTest
    {
        public CartIntegrationTests(IntegrationTestFactory integrationTestFactory) : base(integrationTestFactory)
        {
        }

        #region Positive Testing

        [Fact]
        public async Task CreateCart_ShouldReturnCartId_IfSuccessful()
        {
            // Given
            var createCustomerCommand = new CreateCustomerCommand("Evert", "Botha", "@.@.com");
            var createCustomerResponse = await Sender.Send(createCustomerCommand);

            var createCartCommand = new CreateCartCommand(createCustomerResponse.CustomerId);

            // When
            var createCartResponse = await Sender.Send(createCartCommand);

            // Then 
            Assert.NotNull(createCartResponse);
            Assert.IsType<CreateCartResponse>(createCartResponse);
        }

        [Fact]
        public async Task AddLineItemToCart_ShouldReturnLineItems_IfSuccessful()
        {
            // Given - a cart, user, product
            var createCustomerResponse = await Sender.Send(new CreateCustomerCommand("Evert", "Botha", "@.@.com"));
            var createCartResponse = await Sender.Send(new CreateCartCommand(createCustomerResponse.CustomerId));
            var createProductResponse = await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5));
            var addLineItemCommand = new AddLineItemCommand(new CartId(createCartResponse.CartId), new ProductId(createProductResponse.ProductId), 5);

            // When
            var addlineItemResult = await Sender.Send(addLineItemCommand);

            // Then
            Assert.NotNull(addlineItemResult);
            Assert.IsType<AddLineItemResponse>(addlineItemResult);
        }

        [Fact]
        public async Task RemovelineItemFromCart_ShouldReturnLineItemsRemaining_IfSuccessful()
        {
            // Given - a cart, user, product
            var createCustomerResponse = await Sender.Send(new CreateCustomerCommand("Evert", "Botha", "@.@.com"));
            var createCartResponse = await Sender.Send(new CreateCartCommand(createCustomerResponse.CustomerId));
            // creating products
            var createProductResponseOne = await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5));
            var createProductResponseTwo = await Sender.Send(new CreateProductCommand("Blu52 Big Easy Multi Functional Floater", "Probably the best that there is", "$", 200m, 10));
            // adding line items
            var addLineItemCommandOne = new AddLineItemCommand(new CartId(createCartResponse.CartId), new ProductId(createProductResponseOne.ProductId), 5);
            var addlineItemResult = await Sender.Send(addLineItemCommandOne);
            var lineItemId = addlineItemResult.LineItemId.FirstOrDefault();
            var addLineItemCommandTwo = new AddLineItemCommand(new CartId(createCartResponse.CartId), new ProductId(createProductResponseTwo.ProductId), 5);
            var addlineItemResultTwo = await Sender.Send(addLineItemCommandTwo);
            var lastLineItem = addlineItemResultTwo.LineItemId.Last();

            // creating remove line items command
            var removeLineItemsCommand = new RemoveLineItemCommand(new CartId(createCartResponse.CartId), lineItemId.LineItemId);
            
            // When
            var removeLineItemResult = await Sender.Send(removeLineItemsCommand);

            // Then
            Assert.NotNull(removeLineItemResult);
            Assert.IsType<RemoveLineItemResponse>(removeLineItemResult);
            Assert.True(removeLineItemResult.LineItemId.FirstOrDefault().LineItemId == lastLineItem.LineItemId);
        }

        [Fact]
        public async Task GetCart_ShouldReturnCartWithLineItems_IfSuccessful()
        {
            // Given - a cart, user, product
            var createCustomerResponse = await Sender.Send(new CreateCustomerCommand("Evert", "Botha", "@.@.com"));
            var createCartResponse = await Sender.Send(new CreateCartCommand(createCustomerResponse.CustomerId));
            // creating product
            var createProductResponse = await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5));
            // adding line items
            var addLineItemCommand = new AddLineItemCommand(new CartId(createCartResponse.CartId), new ProductId(createProductResponse.ProductId), 5);
            var addlineItemResult = await Sender.Send(addLineItemCommand);

            var getCartQuery = new GetCartQuery(createCartResponse.CartId);

            // When
            var getCartQueryResponse = await Sender.Send(getCartQuery);

            // Then
            Assert.NotNull(getCartQueryResponse);
            Assert.IsType<CartResponse>(getCartQueryResponse);
            Assert.True(getCartQueryResponse.CartId == createCartResponse.CartId);
        }

        #endregion

        #region Negative Testing

        [Fact]
        public async Task CreateCartForCustomerThatDoesNotExist_ShouldFailWithCustomerNotFoundException_IfSuccessful()
        {
            // Given
            var createCartCommand = new CreateCartCommand(Guid.NewGuid());

            // When
            Task Action() => Sender.Send(createCartCommand);

            // Then
            await Assert.ThrowsAsync<CustomerNotFoundException>(Action);
        }

        [Fact]
        public async Task AddLineItemToCartThatDoesNotExist_ShouldFailWithCartNotFoundException_IfSuccessful()
        {
            // Given
            var addLineItemCommand = new AddLineItemCommand(new CartId(Guid.NewGuid()), new ProductId(Guid.NewGuid()), 5);

            // When
            Task Action() => Sender.Send(addLineItemCommand);

            // Then
            await Assert.ThrowsAsync<CartNotFoundException>(Action);
        }

        [Fact]
        public async Task GetCartShouldFailIfCartDoesNotExist_ShouldFailWithCartNotFoundException_IfSuccessful()
        {
            // Given
            var getCartQuery = new GetCartQuery(Guid.NewGuid());

            // When
            Task Action() => Sender.Send(getCartQuery);

            // Then
            await Assert.ThrowsAsync<CartNotFoundException>(Action);
        }

        [Fact]
        public async Task AddLineItemToCartIfProductDoesNotExist_ShouldFailWithProductNotFoundException_IfSuccessful()
        {
            // Given
            var createCustomerResponse = await Sender.Send(new CreateCustomerCommand("Evert", "Botha", "@.@.com"));
            var createCartResponse = await Sender.Send(new CreateCartCommand(createCustomerResponse.CustomerId));

            var addLineItemCommand = new AddLineItemCommand(new CartId(createCartResponse.CartId), new ProductId(Guid.NewGuid()), 5);

            // When
            Task Action() => Sender.Send(addLineItemCommand);

            // Then
            await Assert.ThrowsAsync<ProductNotFoundException>(Action);
        }

        #endregion
    }
}
