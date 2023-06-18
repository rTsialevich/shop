using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Orders.Commands
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
        private readonly IOrderRepository _orderRepository;

        public DeleteByIdCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _orderRepository.FetchByIdAsync(request.Id);
            if (entity != null)
            {
                _orderRepository.Delete(entity);
                await _orderRepository.SaveChangesAsync();
            }
            
            return Unit.Value;
        }
    }
}
