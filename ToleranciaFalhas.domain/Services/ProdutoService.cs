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
    public class ProdutoService : IProdutoService
    {
        private readonly IBaseRepository<Produto> _repository;
        public ProdutoService(IBaseRepository<Produto> repository)
        {
            this._repository = repository;
        }
       

        public async Task<Produto> GetById(int id)
        {
            return await this._repository.GetItem(id);
        }

        public async Task<List<Produto>> List(CancellationToken token = default)
        {
            return await  this._repository.ListAsync(token);
        }

        public async Task Save(Produto produto, CancellationToken token = default)
        {
            this._repository.Add(produto);
            await this._repository.CommitAsync(token);
        }
    }
}
