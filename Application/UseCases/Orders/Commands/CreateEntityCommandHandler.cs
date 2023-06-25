using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Orders.Commands
{
    public sealed class CreateOrderCommand : IRequest<int>
    {
    }

    public sealed class CreateEntityCommandHandler : CommandWithResultHandler<CreateOrderCommand, int>
    {
        public CreateEntityCommandHandler(IWriteDbContext context) : base(context) { }

        public override async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
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
