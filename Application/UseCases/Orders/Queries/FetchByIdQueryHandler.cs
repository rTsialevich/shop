using Domain.Entities;
using Domain.Repositories;
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

    public sealed class FetchByIdQueryHandler : IRequestHandler<FetchByIdQuery, Order?>
    {
        private readonly IOrderRepository _orderRepository;

        public FetchByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order?> Handle(FetchByIdQuery request, CancellationToken cancellationToken)
            => _orderRepository.FetchByIdAsync(request.Id);
    }
}