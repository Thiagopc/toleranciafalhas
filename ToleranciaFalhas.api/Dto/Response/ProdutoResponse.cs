namespace ToleranciaFalhas.api.Dto.Response
{


    public class ProdutoPropertieResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string UrlImg { get; set; }
    }

    public class ProdutoResponse
    {
        public List<ProdutoPropertieResponse> Produtos { get; set; }
        public bool Fallback { get; set; }
    }
}
