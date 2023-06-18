using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly RepositoryDbContext _dbContext;
        public OrderRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;
        public async Task<IEnumerable<Order>> FetchAllAsync() =>
            await _dbContext.Orders.Include(x => x.Products).ToListAsync();
        public Task<Order?> FetchByIdAsync(int id) => _dbContext.Orders.Include(x => x.Products).FirstOrDefaultAsync(pr => pr.Id == id);
        public void Create(Order entity) => _dbContext.Orders.Add(entity);
        public void Update(Order entity) => _dbContext.Orders.Update(entity);
        public void Delete(Order entity) => _dbContext.Orders.Remove(entity);
        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
