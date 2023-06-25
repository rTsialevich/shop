using Domain.Contexts;
using MediatR;

namespace Application.UseCases
{
    public abstract class CommandHandler<T> : IRequestHandler<T> where T : IRequest
    {
        protected readonly IWriteDbContext _context;
        public CommandHandler(IWriteDbContext context)
        {
            _context = context;
        }

        public abstract Task Handle(T request, CancellationToken cancellationToken);
    }
}
