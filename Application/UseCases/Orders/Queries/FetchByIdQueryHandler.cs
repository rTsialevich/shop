using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Orders.Queries
{
    public sealed class FetchByIdQuery : IRequest<Order?> 
    {
        public FetchByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }

    public sealed class FetchByIdQueryHandler : QueryHandler<FetchByIdQuery, Order?>
    {
        public FetchByIdQueryHandler(IReadDbContext context) : base(context) { }

        public override Task<Order?> Handle(FetchByIdQuery request, CancellationToken cancellationToken)
            => _context.FetchItemByPredictionAsync<Order>(p => p.Id == request.Id);
    }
}