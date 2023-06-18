using Domain.Repositories;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public sealed class DeleteByIdCommand : IRequest
    {
        public DeleteByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }
    public sealed class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteByIdCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _productRepository.FetchByIdAsync(request.Id);
            if (entity != null)
            {
                _productRepository.Delete(entity);
                await _productRepository.SaveChangesAsync();
            }
        }
    }
}
