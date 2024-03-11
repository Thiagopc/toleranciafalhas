using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;
using ToleranciaFalhas.domain.Interfaces.Repositories;
using ToleranciaFalhas.domain.Interfaces.Services;

namespace ToleranciaFalhas.domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IBaseRepository<Cliente> _repository;

        public ClienteService(IBaseRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> Save(Cliente cliente)
        {

            this._repository.Add(cliente);
            await this._repository.CommitAsync();
            return cliente;
        }

        public async Task<Cliente> GetById(int id)
        => await this._repository.GetItem(id);


        public async Task<List<Cliente>> ListarAsync(CancellationToken token = default)
        => await this._repository.ListAsync(token);



    }
}
