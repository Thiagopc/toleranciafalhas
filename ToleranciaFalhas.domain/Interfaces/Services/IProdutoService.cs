using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.domain.Interfaces.Services
{
    public interface IProdutoService
    {
        public Task Save(Produto produto, CancellationToken token = default);
        public Task<List<Produto>> List(CancellationToken token = default);
        public Task<Produto> GetById(int id);
    }
}
