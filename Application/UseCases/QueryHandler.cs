using Domain.Contexts;
using MediatR;

namespace Application.UseCases
{
    public abstract class QueryHandler<T1, T2> : IRequestHandler<T1, T2> where T1 : IRequest<T2>
    {
        protected readonly IReadDbContext _context;
        public QueryHandler(IReadDbContext context)
        {
            _context = context;
        }

        public abstract Task<T2> Handle(T1 request, CancellationToken cancellationToken);
    }
}
