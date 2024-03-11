using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToleranciaFalhas.api.Dto.Request;
using ToleranciaFalhas.api.Services;
using ToleranciaFalhas.domain.Entities;

namespace ToleranciaFalhas.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoServiceView _produtoservice;
        public ProdutoController(ProdutoServiceView produtoservice) {
            this._produtoservice = produtoservice;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutoCreateRequest request)
        {
            await this._produtoservice.Save(request);
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await this._produtoservice.List());
        }


    }
}
