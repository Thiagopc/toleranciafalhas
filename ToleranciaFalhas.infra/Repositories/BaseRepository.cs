using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Interfaces.Repositories;
using ToleranciaFalhas.infra.Repositories.Db;
using ToleranciaFalhas.infra.Repositories.Db.Dapper;

namespace ToleranciaFalhas.infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly ConnectionDb _conn;
        //private readonly ConnectionDbReader _connread;

        public BaseRepository(ConnectionDb connection)
        {
            this._conn = connection;
        }


        public void Add(T item)
        {
            this._conn.Add(item);
        }



        public async Task<T?> GetItem(params object[] keys)
         => await this._conn.Set<T>()
                .FindAsync(keys);


        public Task<List<T>> ListAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> ListAsync(CancellationToken token = default)
                => await this._conn.Set<T>().ToListAsync(token);






        public void Update(T item)
        {
            this._conn.Update(item);
        }


        public async Task CommitAsync(CancellationToken token = default)
            => await this._conn.SaveChangesAsync(token);



        public async Task DeleteAsync(T entity)
        => this._conn.Remove(entity);

    }
}
