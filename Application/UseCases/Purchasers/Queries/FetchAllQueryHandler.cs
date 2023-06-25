using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Purchasers.Queries
{
    public sealed class FetchAllQuery : IRequest<List<Purchaser>> { }

    public sealed class FetchAllQueryHandler : QueryHandler<FetchAllQuery, List<Purchaser>>
    {
        public FetchAllQueryHandler(IReadDbContext context) : base(context) { }

        public override Task<List<Purchaser>> Handle(FetchAllQuery request, CancellationToken cancellationToken)
            => _context.FetchAllAsync<Purchaser>();
    }
}
