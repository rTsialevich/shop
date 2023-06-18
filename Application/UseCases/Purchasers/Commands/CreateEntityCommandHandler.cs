using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Purchasers.Commands
{
    public sealed class CreatePurchaserCommand : IRequest<int>
    {
    }

    public sealed class CreateEntityCommandHandler : IRequestHandler<CreatePurchaserCommand, int>
    {
        private readonly IPurchaserRepository _purchaserRepository;

        public CreateEntityCommandHandler(IPurchaserRepository purchaserRepository)
        {
            _purchaserRepository = purchaserRepository;
        }

        public async Task<int> Handle(CreatePurchaserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(0);
            //TODO:
            //var entity = new Order
            //{

            //};

            //_orderRepository.Create(entity);
            //await _orderRepository.SaveChangesAsync();

            //return entity.Id;
        }
    }
}
