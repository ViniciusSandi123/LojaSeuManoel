using Loja.DTOs.Request;
using Loja.DTOs.Response;
using Loja.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly EmbalarService _embalarService;
        public PedidoController (EmbalarService embalarService)
        {
            _embalarService = embalarService;
        }

        [HttpPost]
        public ActionResult<PedidoResponseDto> Embalar([FromBody] PedidoRequestDto pedido)
        {
            try
            {
                var resultado = _embalarService.Embalar(1, pedido);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new {erro = ex.Message});
            }
        }
    }
}
