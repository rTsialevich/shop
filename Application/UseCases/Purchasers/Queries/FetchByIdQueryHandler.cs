using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Purchasers.Queries
{
    public sealed class FetchByIdQuery : IRequest<Purchaser?>
    {
        public FetchByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }

    public sealed class FetchByIdQueryHandler : QueryHandler<FetchByIdQuery, Purchaser?>
    {
        public FetchByIdQueryHandler(IReadDbContext context) : base(context) { }

        public override Task<Purchaser?> Handle(FetchByIdQuery request, CancellationToken cancellationToken)
            => _context.FetchItemByPredictionAsync<Purchaser>(p => p.Id == request.Id);
    }
}
