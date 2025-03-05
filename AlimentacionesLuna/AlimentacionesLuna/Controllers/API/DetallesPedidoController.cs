using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlimentacionesLuna.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidoController : ControllerBase
    {
        public static DetallesPedido pedidoEjemplo = new DetallesPedido
        {
            IdPedido = 1,
            PrecioCantidad = 0.0f,
            PrecioUnitario = 0.0f,
            Descuento = 0,
            Impuesto = 0,



        };

        // GET api/<DetallesPedidoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado = BadRequest();

            if (pedidoEjemplo != null)
            {
                if(pedidoEjemplo.IdPedido == id)
                {
                    resultado = Ok(pedidoEjemplo);
                }
            }

            return resultado;
        }

    }
}
