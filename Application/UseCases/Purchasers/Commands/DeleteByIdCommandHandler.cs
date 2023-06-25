using Domain.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Purchasers.Commands
{
    public sealed class DeleteByIdCommand : IRequest
    {
        public DeleteByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; init; }
    }

    public sealed class DeleteByIdCommandHandler : CommandHandler<DeleteByIdCommand>
    {
        public DeleteByIdCommandHandler(IWriteDbContext context) : base(context) { }

        public override async Task Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FetchItemByPredictionAsync<Purchaser>(p => p.Id == request.Id);
            if (entity != null)
            {
                _context.Delete(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
