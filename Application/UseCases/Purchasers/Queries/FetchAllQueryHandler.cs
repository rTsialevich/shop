using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Purchasers.Queries
{
    public sealed class FetchAllQuery : IRequest<IEnumerable<Purchaser>> { }
    public sealed class FetchAllQueryHandler : IRequestHandler<FetchAllQuery, IEnumerable<Purchaser>>
    {
        private readonly IPurchaserRepository _purchaserRepository;

        public FetchAllQueryHandler(IPurchaserRepository purchaserRepository)
        {
            _purchaserRepository = purchaserRepository;
        }

        public Task<IEnumerable<Purchaser>> Handle(FetchAllQuery request, CancellationToken cancellationToken)
            => _purchaserRepository.FetchAllAsync();
    }
}
