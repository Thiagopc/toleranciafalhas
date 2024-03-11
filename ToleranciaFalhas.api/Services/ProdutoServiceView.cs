using AutoMapper;
using System.Text.Encodings.Web;
using System.Text.Json;
using ToleranciaFalhas.api.Dto.Request;
using ToleranciaFalhas.api.Dto.Response;
using ToleranciaFalhas.domain.Entities;
using ToleranciaFalhas.domain.Interfaces.Factory;
using ToleranciaFalhas.domain.Interfaces.Services;
using ToleranciaFalhas.infra.Policies;

namespace ToleranciaFalhas.api.Services
{
    public class ProdutoServiceView
    {

        private readonly IProdutoService _produtoService;
        private readonly IMapper _map;
        private readonly IConnectionDbReaderFactory _factory;

        public ProdutoServiceView(IProdutoService produtoService, IMapper map, IConnectionDbReaderFactory _factory)
        {
            this._produtoService = produtoService;
            this._map = map;
            this._factory = _factory;
        }

        public async Task Save(ProdutoCreateRequest produto)
        {
            var produtoEntity = this._map.Map<Produto>(produto);
            //await this._produtoService.Save(produtoEntity);



            var fallbackStatus = false;
            var policyRead = PolicyManager<Produto>.ObterPoliticaDeFallbackComTimeoutWrite(async (cancellationToken) =>
            {
                var fallback = this._factory.Create<Produto>();
                var produtoSqs = this._map.Map<ProdutoSqsRequest>(produtoEntity);
                produtoSqs.MessageGroupId = "10";
                fallbackStatus = true;
                await fallback.Save(JsonSerializer.Serialize(produtoSqs));                
            }, 500);


            await policyRead.ExecuteAsync(async ct => {
                throw new Exception("tewst");
                 await this._produtoService.Save(produtoEntity, ct);
            }, CancellationToken.None);


            //var produtos = this._map.Map<List<ProdutoPropertieResponse>>(response);
            //return new ProdutoResponse
            //{
            //    Fallback = fallbackStatus,
            //    Produtos = produtos
            //};
        }

        public async Task<ProdutoResponse> List()
        {
            var fallbackStatus = false;
            var policyRead = PolicyManager<Produto>.ObterPoliticaDeFallbackComTimeoutRead(async (cancellationToken) =>
            {
                var fallback = this._factory.Create<Produto>();
                fallbackStatus = true;
                return await fallback.List("produto");
            }, 2000);


            var response = await policyRead.ExecuteAsync(async ct => {
                return await this._produtoService.List(ct);
            }, CancellationToken.None);

            
            var produtos = this._map.Map<List<ProdutoPropertieResponse>>(response);
            return new ProdutoResponse
            {
                Fallback = fallbackStatus,
                Produtos = produtos
            };
        }


    }
}
