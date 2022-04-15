using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3O.Challenge.Domain.Cache {
    public class SimpleCache<TKey, TValue> : ISimpleCache<TKey, TValue>
        where TKey : struct
        where TValue : class {
        private static readonly Lazy<Dictionary<TKey, TValue>> Instance = new(() => new Dictionary<TKey, TValue>());

        public Task AddAsync(TKey key, TValue value) {
            Instance.Value.TryAdd(key, value);
            
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TKey key) {
            Instance.Value.Remove(key, out TValue value);
            
            return Task.CompletedTask;
        }

        public Task<TValue> GetAsync(TKey key) {
            return Task.FromResult(Instance.Value.ContainsKey(key) ? Instance.Value[key] : default);
        }

        public Task<IEnumerable<TValue>> GetAllAsync() {
            IEnumerable<TValue> values = Instance.Value.Values.ToList();
            
            return Task.FromResult(values);
        }

        public Task UpdateAsync(TKey key, TValue value) {
            if (Instance.Value.ContainsKey(key)) {
                Instance.Value[key] = value;
            }

            return Task.CompletedTask;
        }
    }
}