using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Application.Products.Update;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Delete
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand deleteProductCommand, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(deleteProductCommand.ProductId);

            if (product == null)
                throw new ProductNotFoundException(deleteProductCommand.ProductId);

            _productRepository.Remove(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteProductResponse(product.Id.Value, product.Name, product.Description, product.Price.Currency, product.Price.Amount, product.Sku);
        }
    }
}
