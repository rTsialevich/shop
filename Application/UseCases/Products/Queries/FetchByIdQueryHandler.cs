using Domain.Contexts;
using Domain.Entities;
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

    public sealed class FetchByIdQueryHandler : QueryHandler<FetchByIdQuery, Product?>
    {
        public FetchByIdQueryHandler(IReadDbContext context) : base(context) { }

        public override Task<Product?> Handle(FetchByIdQuery request, CancellationToken cancellationToken)
            => _context.FetchItemByPredictionAsync<Product>(p => p.Id == request.Id);
    }
}
