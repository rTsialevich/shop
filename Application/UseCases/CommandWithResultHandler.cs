using Domain.Contexts;
using MediatR;

namespace Application.UseCases
{
    public abstract class CommandWithResultHandler<T1, T2> : IRequestHandler<T1, T2> where T1 : IRequest<T2>
    {
        protected readonly IWriteDbContext _context;
        public CommandWithResultHandler(IWriteDbContext context)
        {
            _context = context;
        }

        public abstract Task<T2> Handle(T1 request, CancellationToken cancellationToken);
    }
}
