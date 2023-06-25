using Application.UseCases.Purchasers.Commands;
using Application.UseCases.Purchasers.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PurchaserController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public Task<List<Purchaser>> Get()
            => _mediator.Send(new FetchAllQuery());

        [HttpGet("{id}")]
        public Task<Purchaser?> Get(int id)
            => _mediator.Send(new FetchByIdQuery(id));

        //[HttpPut("{id}")]
        //public Task<Order?> Put(int id, [FromBody] UpdateOrderCommand entity)
        //{
        //    entity.PurchaserId = id;
        //    return _mediator.Send(entity);
        //}

        [HttpDelete("{id}")]
        public Task Delete(int id)
            => _mediator.Send(new DeleteByIdCommand(id));

        [HttpPost]
        public Task Post([FromBody] CreatePurchaserCommand entity)
            => _mediator.Send(entity);
    }
}
