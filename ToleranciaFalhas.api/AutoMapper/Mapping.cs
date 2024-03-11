using AutoMapper;
using ToleranciaFalhas.api.Dto.Request;
using ToleranciaFalhas.api.Dto.Response;
using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.api.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping() {


            #region Cliente
            CreateMap<Cliente, ClientePropertiesResponse>();        
            CreateMap<CreateClienteRequest, Cliente>();
            #endregion

            #region Produto
            CreateMap<Produto, ProdutoPropertieResponse>();            
            CreateMap<Produto, ProdutoSqsRequest>();            
            CreateMap<ProdutoCreateRequest, Produto>();
            #endregion


            //CreateMap<List<CreateClienteRequest>, List<Cliente>>();        

        }
    }
}
