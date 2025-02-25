using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlimentacionesLuna.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        public static Pedido pedidoEjemplo = new Pedido
        {
            IdProducto = 0,
            IdProveedor = 0,
            FechaPedido = new DateTime(),
            PrecioTotal = 0.0f,
            Estado = ""

        };
        

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;

            List<Pedido> listaPedidos = new List<Pedido>();
            listaPedidos.Add(pedidoEjemplo);

            try
            {
                if(listaPedidos.Count != 0)
                {
                    resultado = Ok(listaPedidos);
                }else
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

            Pedido ejemplo = null;
            try
            {
                if(pedidoEjemplo.IdProducto == id)
                {
                    ejemplo = pedidoEjemplo;
                }
                if(ejemplo != null)
                {
                    resultado = Ok();
                }
                else{
                    resultado = NoContent();
                }
            }catch(Exception e){
    
                resultado = BadRequest("No se ha podido sacar el pedido por ID de producto");
            
            }


            return resultado;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {


        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {


        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
