using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Orders.Queries
{
    public sealed class FetchAllQuery : IRequest<IEnumerable<Order>> { }
    public sealed class FetchAllQueryHandler : IRequestHandler<FetchAllQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public FetchAllQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> Handle(FetchAllQuery request, CancellationToken cancellationToken)
            => _orderRepository.FetchAllAsync();
    }
}
