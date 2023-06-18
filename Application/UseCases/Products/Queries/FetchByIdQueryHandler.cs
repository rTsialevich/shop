using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public sealed class FetchByIdQuery : IRequest<Product?>
    {
        public FetchByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }

    public sealed class FetchByIdQueryHandler : IRequestHandler<FetchByIdQuery, Product?>
    {
        private readonly IProductRepository _productRepository;

        public FetchByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product?> Handle(FetchByIdQuery request, CancellationToken cancellationToken)
            => _productRepository.FetchByIdAsync(request.Id);
    }
}
