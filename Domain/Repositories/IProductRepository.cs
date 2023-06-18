using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FetchAllAsync();
        Task<Product?> FetchByIdAsync(int id);
        Task<Product?> FetchByNameAsync(string name);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Task SaveChangesAsync();
    }
}
