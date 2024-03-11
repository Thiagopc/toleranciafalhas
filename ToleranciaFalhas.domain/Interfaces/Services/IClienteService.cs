using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.domain.Interfaces.Services
{
    public interface IClienteService
    {
        public Task<Cliente> Save(Cliente cliente);
        public Task<List<Cliente>> ListarAsync(CancellationToken token = default);
        public Task<Cliente> GetById(int id);
    }
}
