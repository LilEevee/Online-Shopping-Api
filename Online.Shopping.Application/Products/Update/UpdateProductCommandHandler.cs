using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;
using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(updateProductCommand.ProductId);

            if (product == null)
                throw new ProductNotFoundException(updateProductCommand.ProductId);

            product.Update(updateProductCommand.Name, updateProductCommand.Description, new Price( updateProductCommand.Currency, updateProductCommand.Price), updateProductCommand.Sku, updateProductCommand.Image);

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateProductResponse(product.Id.Value, product.Name, product.Description, product.Price.Currency, product.Price.Amount, product.Sku, product.Image);
        }
    }
}
