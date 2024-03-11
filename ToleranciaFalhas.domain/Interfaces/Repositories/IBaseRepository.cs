using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToleranciaFalhas.domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<T> GetItem(params object[] keys);
        public void Add(T item);
        public void Update(T item);
        public Task DeleteAsync(T entity);
        public Task<List<T>> ListAsync(int page, int pageSize);
        Task<List<T>> ListAsync(CancellationToken token = default);
        public Task CommitAsync(CancellationToken token = default);
    }
}
