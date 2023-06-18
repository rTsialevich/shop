using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public ProductRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
        public async Task<IEnumerable<Product>> FetchAllAsync() =>
            await _dbContext.Products.ToListAsync();
        public Task<Product?> FetchByIdAsync(int id) => _dbContext.Products.Include(pr => pr.Orders).FirstOrDefaultAsync(pr => pr.Id == id);
        public Task<Product?> FetchByNameAsync(string name) => _dbContext.Products.Include(pr => pr.Orders).FirstOrDefaultAsync(pr => pr.Name.Equals(name));
        public void Create(Product entity) => _dbContext.Products.Add(entity);
        public void Update(Product entity) => _dbContext.Products.Update(entity);
        public void Delete(Product entity) => _dbContext.Products.Remove(entity);
        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
