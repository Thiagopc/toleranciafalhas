using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToleranciaFalhas.domain.Entities
{
    public class ItemVenda
    {
        
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public decimal ValorItem { get; set; }
        public int Quantidade { get; set; }
    }
}
