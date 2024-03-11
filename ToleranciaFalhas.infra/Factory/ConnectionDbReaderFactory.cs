using Microsoft.Extensions.Configuration;
using ToleranciaFalhas.domain.Interfaces.Event;
using ToleranciaFalhas.domain.Interfaces.Factory;
using ToleranciaFalhas.domain.Interfaces.Repositories;
using ToleranciaFalhas.infra.Repositories.Db.Dapper;

namespace ToleranciaFalhas.infra.Factory
{
    public class ConnectionDbReaderFactory : IConnectionDbReaderFactory
    {
        //private readonly string _connectionString;
        private readonly ISqsEvent _sqs;
        
        public ConnectionDbReaderFactory(ISqsEvent sqs) { 
            this._sqs = sqs;
        }

        public IBaseReadRepository<T> Create<T>() where T : class
        {
            return new ConnectionDbReader<T>(this._sqs);
        }
    }
}
