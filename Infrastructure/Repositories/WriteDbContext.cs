using Domain.Contexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class WriteDbContext : BaseDbContext, IWriteDbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options)
            : base(options)
        {
        }

        public async Task CreateAsync<T>(T entity) where T : DbEntity
        {
            await Set<T>().AddAsync(entity);
        }

        public Task CreateRangeAsync<T>(params T[] entities) where T : DbEntity
           => Set<T>().AddRangeAsync(entities);

        public void Update<T>(T entity) where T : class
            => Set<T>().Update(entity);
        public void UpdateRange<T>(params T[] entities) where T : DbEntity
            => Set<T>().UpdateRange(entities);

        public void Delete<T>(T entity) where T : DbEntity
            => Set<T>().Remove(entity);
        public void DeleteRange<T>(params T[] entities) where T : DbEntity
           => Set<T>().RemoveRange(entities);
    }
}
