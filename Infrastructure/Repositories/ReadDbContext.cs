using Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{ 
    public sealed class ReadDbContext : BaseDbContext, IReadDbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options)
            : base(options)
        {
        }
    }
}
