using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToleranciaFalhas.domain.Entities
{
    public class ItemCarrinho
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public Cliente? Cliente { get; set; }

    }
}
