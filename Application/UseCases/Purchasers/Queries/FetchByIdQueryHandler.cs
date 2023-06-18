using Domain.Entities;
using Domain.Repositories;
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

    public sealed class FetchByIdQueryHandler : IRequestHandler<FetchByIdQuery, Purchaser?>
    {
        private readonly IPurchaserRepository _purchaserRepository;

        public FetchByIdQueryHandler(IPurchaserRepository purchaserRepository)
        {
            _purchaserRepository = purchaserRepository;
        }

        public Task<Purchaser?> Handle(FetchByIdQuery request, CancellationToken cancellationToken)
            => _purchaserRepository.FetchByIdAsync(request.Id);
    }
}
