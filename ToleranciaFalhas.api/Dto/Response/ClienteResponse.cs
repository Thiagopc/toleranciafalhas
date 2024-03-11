namespace ToleranciaFalhas.api.Dto.Response
{
    public class ClientePropertiesResponse
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }        

    }

    public class ClienteResponse
    {
        public List<ClientePropertiesResponse> Clientes { get; set; }
        public bool Fallback { get; set; }
    }
}
