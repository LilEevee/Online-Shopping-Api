using MediatR;
using Online.Shopping.Application.Abstractions.Data;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Application.Products.Delete
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if(product == null)
            {
                // TODO: ADD EXCEPTION HANDLING
                throw new ArgumentException();
            }

            _productRepository.Remove(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
