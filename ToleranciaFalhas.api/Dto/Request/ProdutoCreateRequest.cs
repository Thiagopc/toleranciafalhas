namespace ToleranciaFalhas.api.Dto.Request
{
    public class ProdutoCreateRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string UrlImg { get; set; }
    }
}
