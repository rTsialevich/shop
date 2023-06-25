using Application.UseCases.Products.Commands;
using Application.UseCases.Products.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public Task<List<Product>> Get()
            => _mediator.Send(new FetchAllQuery());

        [HttpGet("{id}")]
        public Task<Product?> Get(int id)
            => _mediator.Send(new FetchByIdQuery(id));

        [HttpPut("{id}/set-price")]
        public async Task SetPrice(int id, [FromBody] UpdatePriceCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
            => _mediator.Send(new DeleteByIdCommand(id));

        [HttpPost]
        public Task Post([FromBody] CreateProductCommand entity)
            => _mediator.Send(entity);
    }
}