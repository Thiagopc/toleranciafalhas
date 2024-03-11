using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.api.Dto.Request
{
    public class ProdutoSqsRequest 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string UrlImg { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string MessageGroupId { get; set; }
    }
}
