using System.Collections.Generic;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Cache {
    public interface ISimpleCache<TKey, TValue>
        where TKey : struct
        where TValue : class {
        Task AddAsync(TKey key, TValue value);

        Task DeleteAsync(TKey key);

        Task<TValue> GetAsync(TKey key);

        Task<IEnumerable<TValue>> GetAllAsync();

        Task UpdateAsync(TKey key, TValue value);
    }
}