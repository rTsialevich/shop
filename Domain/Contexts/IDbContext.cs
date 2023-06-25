using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Contexts
{
    public interface IDbContext
    {
        Task<List<T>> FetchAllAsync<T>() where T : DbEntity;

        IEnumerable<T> FetchCollectionByPrediction<T>(Func<T, bool> predicate) where T : DbEntity;

        Task<T?> FetchItemByPredictionAsync<T>(Expression<Func<T, bool>> predicate) where T : DbEntity;
    }
}
