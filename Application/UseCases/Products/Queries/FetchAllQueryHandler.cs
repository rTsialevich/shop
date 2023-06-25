using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public sealed class FetchAllQuery : IRequest<List<Product>> { }

    public sealed class FetchAllQueryHandler : QueryHandler<FetchAllQuery, List<Product>>
    {
        public FetchAllQueryHandler(IReadDbContext context) : base(context) { }

        public override Task<List<Product>> Handle(FetchAllQuery request, CancellationToken cancellationToken)
            => _context.FetchAllAsync<Product>();
    }
}
