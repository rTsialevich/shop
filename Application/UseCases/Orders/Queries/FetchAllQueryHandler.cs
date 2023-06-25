using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Orders.Queries
{
    public sealed class FetchAllQuery : IRequest<List<Order>> { }

    public sealed class FetchAllQueryHandler : QueryHandler<FetchAllQuery, List<Order>>
    {
        public FetchAllQueryHandler(IReadDbContext context) : base(context) { }

        public override Task<List<Order>> Handle(FetchAllQuery request, CancellationToken cancellationToken)
            => _context.FetchAllAsync<Order>();
    }
}
