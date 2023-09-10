using Online.Shopping.Application.Products.Create;
using Online.Shopping.Application.Products.Delete;
using Online.Shopping.Application.Products.Get;
using Online.Shopping.Application.Products.Update;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Tests
{
    public class ProductIntegrationTests : BaseIntegrationTest
    {
        public ProductIntegrationTests(IntegrationTestFactory integrationTestFactory) : base(integrationTestFactory)
        {
        }

        #region Positive Testing

        [Fact]
        public async Task CreateProduct_ShouldReturnProductId_IfSuccessful()
        {
            // Given
            var createProductCommand = new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]);

            // When
            var createProductResponse = await Sender.Send(createProductCommand);

            // Then 
            Assert.NotNull(createProductResponse);
            Assert.IsType<CreateProductResponse>(createProductResponse);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnProduct_IfSuccessful()
        {
            // Given
            var createProductCommand = new CreateProductCommand("Blu52 Big Easy Multi Functional Floater", "Probably the best that there is", "$", 200m, 10, new byte[3]);
            var createProductResponse = await Sender.Send(createProductCommand);
            var getProductByIdCommand = new GetProductQueryById(new ProductId(createProductResponse.ProductId));

            // When
            var product = await Sender.Send(getProductByIdCommand);

            // Then
            Assert.NotNull(product);
            Assert.IsType<ProductResponse>(product);
        }

        [Fact]
        public async Task GetProductsbyPaging_ShouldReturnListOfProducts_IfSuccessful()
        {
            var pageSize = 5;
            // Given - We seed some records into the table
            #region there be nasy things here :(
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            await Sender.Send(new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]));
            #endregion
            var getProductQuery = new GetProductsQuery("pool", 1, pageSize);

            // When
            var getProductsResult = await Sender.Send(getProductQuery);

            // Then
            Assert.NotNull(getProductsResult);
            Assert.IsType<PagedList<ProductResponse>>(getProductsResult);
            Assert.True(getProductsResult.Items.Count == pageSize);
        }

        [Fact]
        public async Task UpdateProduct_ShouldReturnUpdatedProduct_IfSuccessful()
        {
            // Given - we create the product and set the update command
            var createProductCommand = new CreateProductCommand("Poolbrite Month Mate Floater", "Bad at cleaning the pool", "$", 10m, 5, new byte[3]);
            var createProductResponse = await Sender.Send(createProductCommand);

            var updateProductCommand = new UpdateProductCommand(new ProductId(createProductResponse.ProductId), "Blu52 Big Easy Multi Functional Floater", "Probably the best that there is", "$", 200m, 10, new byte[3]);

            // When
            var updateProductResponse = await Sender.Send(updateProductCommand);

            // Then
            Assert.NotNull(updateProductResponse);
            Assert.IsType<UpdateProductResponse>(updateProductResponse);
            Assert.True(updateProductCommand.Price == updateProductResponse.Price);
            Assert.True(updateProductCommand.Description == updateProductResponse.Description);
            Assert.True(updateProductCommand.Name == updateProductResponse.Name);
            Assert.True(updateProductCommand.Currency == updateProductResponse.Currency);
            Assert.True(updateProductCommand.Sku == updateProductResponse.Sku);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnProductId_IfSuccessful()
        {
            // Given
            var createProductCommand = new CreateProductCommand("Hth Floater", "looks coolish", "$", 150m, 10, new byte[3]);
            var createProductResponse = await Sender.Send(createProductCommand);

            var deleteProductCommand = new DeleteProductCommand(new ProductId(createProductResponse.ProductId));

            // When
            var deleteProductResponse = await Sender.Send(deleteProductCommand);

            // Then
            Assert.NotNull(deleteProductResponse);
            Assert.IsType<DeleteProductResponse>(deleteProductResponse);
        }

        #endregion

        #region Negative Testing

        [Fact]
        public async Task DeleteProductThatDoesNotExist_ShouldFailWithProductNotFoundException_IfSuccessful()
        {
            // Given
            var deleteProductCommand = new DeleteProductCommand(new ProductId(Guid.NewGuid()));

            // When
            Task Action() => Sender.Send(deleteProductCommand);

            // Then
            await Assert.ThrowsAsync<ProductNotFoundException>(Action);
        }

        [Fact]
        public async Task UpdateProductThatDoesNotExist_ShouldFailWithProductNotFoundException_IfSuccessful()
        {
            // Given
            var updateProductCommand = new UpdateProductCommand(new ProductId(Guid.NewGuid()), "Blu52 Big Easy Multi Functional Floater", "Probably the best that there is", "$", 200m, 10, new byte[3]);

            // When
            Task Action() => Sender.Send(updateProductCommand);

            // Then
            await Assert.ThrowsAsync<ProductNotFoundException>(Action);
        }

        [Fact]
        public async Task GetProductByIdThatDoesNotExist_ShouldFailWithProductNotFoundException_IfSuccessful()
        {
            // Given
            var getProductByIdCommand = new GetProductQueryById(new ProductId(Guid.NewGuid()));

            // When
            Task Action() => Sender.Send(getProductByIdCommand);

            // Then
            await Assert.ThrowsAsync<ProductNotFoundException>(Action);
        }

        #endregion

    }
}
