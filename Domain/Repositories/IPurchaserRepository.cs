using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPurchaserRepository
    {
        Task<IEnumerable<Purchaser>> FetchAllAsync();
        Task<Purchaser?> FetchByIdAsync(int id);
        Task<Purchaser?> FetchByNameAsync(string name);
        void Create(Purchaser entity);
        void Update(Purchaser entity);
        void Delete(Purchaser entity);
        Task SaveChangesAsync();
    }
}
