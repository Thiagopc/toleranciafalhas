using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Wrap;
using ToleranciaFalhas.api.Dto.Request;
using ToleranciaFalhas.api.Dto.Response;
using ToleranciaFalhas.domain.Entities;
using ToleranciaFalhas.domain.Interfaces.Factory;
using ToleranciaFalhas.domain.Interfaces.Services;
using ToleranciaFalhas.infra.Policies;

namespace ToleranciaFalhas.api.Services
{
    public class ClienteServiceView
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _map;
        private readonly IConnectionDbReaderFactory _factory;    

        public ClienteServiceView(IMapper map, IClienteService clienteservice, IConnectionDbReaderFactory factory)
        {
            this._map = map;
            this._clienteService = clienteservice;
            this._factory = factory;
        }


        public async Task<ClientePropertiesResponse> Create(CreateClienteRequest cliente)
        {
            var clienteEntity = this._map.Map<Cliente>(cliente);
            return this._map.Map<ClientePropertiesResponse>(await this._clienteService.Save(clienteEntity));
        }


        public async Task<ClienteResponse> List()
        {
            var fallbackStatus = false; 
            var policyRead = PolicyManager<Cliente>.ObterPoliticaDeFallbackComTimeoutRead(async (cancellationToken) =>
            {
                var fallback = this._factory.Create<Cliente>();
                fallbackStatus = true;
                return await fallback.List("cliente");
            }, 2000);



           var response = await policyRead.ExecuteAsync(async ct => {             
                return await this._clienteService.ListarAsync(ct);            
            }, CancellationToken.None) ;
            


            var lista = this._map.Map<List<ClientePropertiesResponse>>(response);
            return new ClienteResponse
            {
                Clientes = lista,
                Fallback = fallbackStatus
            };
        }

        
       


    }
}
