using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToleranciaFalhas.api.Dto.Request;
using ToleranciaFalhas.api.Dto.Response;
using ToleranciaFalhas.api.Services;
using ToleranciaFalhas.domain.Entities;
using ToleranciaFalhas.domain.Interfaces.Services;

namespace ToleranciaFalhas.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteServiceView _clienteservice;        

        public ClienteController(ClienteServiceView clienteservice)
        {
            _clienteservice = clienteservice;            
        }


        [HttpPost]
        public async Task<IActionResult> Save(CreateClienteRequest clientecreaterequest)
        {
            var clienteResponse = await this._clienteservice.Create(clientecreaterequest);
            return StatusCode(201, clienteResponse);
        }


        

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {

            return Ok(await this._clienteservice.List());
        }

    }
}
