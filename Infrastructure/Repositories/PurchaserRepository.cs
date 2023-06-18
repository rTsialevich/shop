using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class PurchaserRepository : IPurchaserRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public PurchaserRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
        public async Task<IEnumerable<Purchaser>> FetchAllAsync() =>
            await _dbContext.Purchasers.Include(x => x.Orders).ToListAsync();
        public Task<Purchaser?> FetchByIdAsync(int id) => _dbContext.Purchasers.Include(x => x.Orders).FirstOrDefaultAsync(pr => pr.Id == id);
        public Task<Purchaser?> FetchByNameAsync(string name) => _dbContext.Purchasers.Include(x => x.Orders).FirstOrDefaultAsync(pr => pr.Name.Equals(name));
        public void Create(Purchaser entity) => _dbContext.Purchasers.Add(entity);
        public void Update(Purchaser entity) => _dbContext.Purchasers.Update(entity);
        public void Delete(Purchaser entity) => _dbContext.Purchasers.Remove(entity);
        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
