using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToleranciaFalhas.domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public int IdCliente { get; set; }

    }
}
