using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Products.Commands
{
    public sealed class UpdatePriceCommand : IRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }

    public sealed class UpdatePriceCommandHandler : CommandHandler<UpdatePriceCommand>
    {
        public UpdatePriceCommandHandler(IWriteDbContext context) : base(context) { }

        public override async Task Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FetchItemByPredictionAsync<Product>(p => p.Id == request.Id);
            if (entity != null)
            {
                entity.Price = request.Price;

                _context.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
