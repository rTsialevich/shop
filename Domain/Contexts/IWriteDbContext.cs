using Domain.Entities;

namespace Domain.Contexts
{
    public interface IWriteDbContext : IDbContext
    {
        public Task CreateAsync<T>(T entity) where T : DbEntity;
        public Task CreateRangeAsync<T>(params T[] entities) where T : DbEntity;

        public void Update<T>(T entity) where T : class;
        public void UpdateRange<T>(params T[] entities) where T : DbEntity;

        public void Delete<T>(T entity) where T : DbEntity;
        public void DeleteRange<T>(params T[] entities) where T : DbEntity;

        public Task<int> SaveChangesAsync(CancellationToken token);
    }
}
