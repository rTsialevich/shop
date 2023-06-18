using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public sealed class CreateProductCommand : IRequest<int>
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }

    public sealed class CreateEntityCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public CreateEntityCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //TODO: mapping
            var entity = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };

            _productRepository.Create(entity);
            await _productRepository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
