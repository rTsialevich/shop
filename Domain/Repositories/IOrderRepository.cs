using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> FetchAllAsync();
        Task<Order?> FetchByIdAsync(int id);
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        Task SaveChangesAsync();
    }
}
