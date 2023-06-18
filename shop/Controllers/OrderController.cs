using Application.UseCases.Orders.Queries;
using Application.UseCases.Orders.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public Task<IEnumerable<Order>> Get()
            => _mediator.Send(new FetchAllQuery());

        [HttpGet("{id}")]
        public Task<Order?> Get(int id)
            => _mediator.Send(new FetchByIdQuery(id));

        //[HttpPut("{id}")]
        //public Task<Order?> Put(int id, [FromBody] UpdateOrderCommand entity)
        //{
        //    entity.Id = id;
        //    return _mediator.Send(entity);
        //}

        [HttpDelete("{id}")]
        public Task Delete(int id)
            => _mediator.Send(new DeleteByIdCommand(id));

        [HttpPost]
        public Task Post([FromBody] CreateOrderCommand entity)
            => _mediator.Send(entity);
    }
}
