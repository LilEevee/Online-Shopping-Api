using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;
using Online.Shopping.Domain.Shared;

namespace Online.Shopping.Application.Products.Create
{
    internal sealed class CreateProductCommandCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(new ProductId(Guid.NewGuid()), request.Name, request.Description ,new Price(request.Currency, request.Price), request.Sku, request.Image);

            _productRepository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateProductResponse(product.Id.Value);
        }
    }
}
