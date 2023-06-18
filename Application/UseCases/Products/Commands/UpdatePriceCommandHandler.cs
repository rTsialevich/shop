using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public sealed class UpdatePriceCommand : IRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }

    public sealed class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdatePriceCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.FetchByIdAsync(request.Id);

            if (entity != null)
            {
                entity.Price = request.Price;
                _productRepository.Update(entity);
                await _productRepository.SaveChangesAsync();
            }
        }
    }
}
