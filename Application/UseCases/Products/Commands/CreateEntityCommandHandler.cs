using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public sealed class CreateProductCommand : IRequest<int>
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }

    public sealed class CreateEntityCommandHandler : CommandWithResultHandler<CreateProductCommand, int>
    {
        public CreateEntityCommandHandler(IWriteDbContext context) : base(context) { }

        public override async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //TODO: mapping
            var entity = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };

            await _context.CreateAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
