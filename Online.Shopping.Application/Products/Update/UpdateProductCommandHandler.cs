using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId.id);

            if (product == null)
            {
                // TODO : Implement error handling
                throw new ArgumentException();
            }

            product.Update(request.Name, request.Price, request.Sku);

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
