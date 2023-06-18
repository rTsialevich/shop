using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public sealed class FetchAllQuery : IRequest<IEnumerable<Product>> { }
    public sealed class FetchAllQueryHandler : IRequestHandler<FetchAllQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public FetchAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> Handle(FetchAllQuery request, CancellationToken cancellationToken)
            => _productRepository.FetchAllAsync();
    }
}
