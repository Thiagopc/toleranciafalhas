using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToleranciaFalhas.domain.Interfaces.Repositories
{
    public interface IBaseReadRepository<T> where T : class
    {
        Task<List<T>> List(string tablename);
        Task Save(string content);
    }
}
