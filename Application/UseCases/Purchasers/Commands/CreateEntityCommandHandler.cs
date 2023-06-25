using Domain.Contexts;
using MediatR;

namespace Application.UseCases.Purchasers.Commands
{
    public sealed class CreatePurchaserCommand : IRequest<int>
    {
    }

    public sealed class CreateEntityCommandHandler : CommandWithResultHandler<CreatePurchaserCommand, int>
    {
        public CreateEntityCommandHandler(IWriteDbContext context) : base(context) { }

        public override async Task<int> Handle(CreatePurchaserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(0);
            //TODO
            //var entity = new Order
            //{

            //};

            //_orderRepository.Create(entity);
            //await _orderRepository.SaveChangesAsync();

            //return entity.Id;
        }
    }
}
