using DAL;
using ENT;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlimentacionesLuna.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;

            List<PedidoDTO> listaPedidos = Manejadora.getPedidos();

            try
            {
                if (listaPedidos.Count != 0)
                {
                    resultado = Ok(listaPedidos);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception e)
            {
                resultado = BadRequest("No se ha podido obtener la lista de Pedidos");
            }
            return resultado;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado;

            PedidoDTO pedido = Manejadora.getPedidoPorID(id);

            try
            {
                if (pedido != null)
                {
                    resultado = Ok(pedido);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception e)
            {
                resultado = BadRequest("Problema al intentar recoger el pedido");
            }

            return resultado;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] PedidoDTO nuevoPedido)
        {
            IActionResult resultado;
            bool ins = false;
            try
            {
                if (nuevoPedido != null)
                {
                    ins = Manejadora.InsPedido(nuevoPedido);
                    ins = true;
                    resultado = Ok(ins);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception e)
            {
                resultado = BadRequest("Error al intentar insertar el pedido");
            }

            return resultado;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string nuevoEstado)
        {
            IActionResult resultado = BadRequest();

            bool updated = Manejadora.UpdatePedido(id, nuevoEstado);

            try
            {
                if (updated != false)
                {
                    PedidoDTO pedido = Manejadora.getPedidoPorID(id);
                    resultado = Ok(pedido);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception e)
            {
                resultado = BadRequest("Error al intentar editar el pedido");
            }

            return resultado;
        }
    }
}
