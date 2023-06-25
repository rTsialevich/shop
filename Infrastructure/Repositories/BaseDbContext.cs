using Domain.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class BaseDbContext : DbContext
    {
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public Task<List<T>> FetchAllAsync<T>() where T : DbEntity
           => Set<T>().ToListAsync();

        public IEnumerable<T> FetchCollectionByPrediction<T>(Func<T, bool> predicate) where T : DbEntity
            => Set<T>().Where(predicate);

        public Task<T?> FetchItemByPredictionAsync<T>(Expression<Func<T, bool>> predicate) where T : DbEntity
            => Set<T>().FirstOrDefaultAsync(predicate);

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);
    }
}