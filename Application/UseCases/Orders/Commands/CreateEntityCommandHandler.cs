using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Orders.Commands
{
    public sealed class CreateOrderCommand : IRequest<int>
    {
    }

    public sealed class CreateEntityCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateEntityCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
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
