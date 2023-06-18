using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Purchasers.Commands
{
    public sealed class DeleteByIdCommand : IRequest
    {
        public DeleteByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }
    public sealed class DeleteByIdCommandHandler
    {
        private readonly IPurchaserRepository _purchaserRepository;

        public DeleteByIdCommandHandler(IPurchaserRepository purchaserRepository)
        {
            _purchaserRepository = purchaserRepository;
        }

        public async Task<Unit> Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _purchaserRepository.FetchByIdAsync(request.Id);
            if (entity != null)
            {
                _purchaserRepository.Delete(entity);
                await _purchaserRepository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
