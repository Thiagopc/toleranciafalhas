using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Interfaces.Repositories;

namespace ToleranciaFalhas.domain.Interfaces.Factory
{
    public interface IConnectionDbReaderFactory
    {
        IBaseReadRepository<T> Create<T>() where T: class;
    }
}
