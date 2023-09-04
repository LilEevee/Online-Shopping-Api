using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Create
{
    internal sealed class CreateProductCommandCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.ProductId, request.Name, request.Price, request.Sku);

            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
