using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlimentacionesLuna.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        // GET: api/<ProveedorController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;

            List<Proveedor> listaProveedores = Manejadora.getProveedores();

            try
            {
                if (listaProveedores.Count != 0)
                {
                    resultado = Ok(listaProveedores);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception e)
            {
                resultado = BadRequest("Ha ocurrido un error al pedir la lista de proveedores");
            }

            
            return resultado;
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult resultado;
            Proveedor personita = Manejadora.getProveedorID(id);
            try
            {

                if (personita != null)
                {
                    resultado = Ok(personita);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception e)
            {
                resultado = BadRequest("Ha ocurrido un error al pedir el proveedor por ID");
            }

            return resultado;
        }



        // GET api/<ProveedorController>/5
        [HttpGet("{idProveedor}/productos")]
        public IActionResult GetProductos(int idProveedor)
        {
            IActionResult productos;
            List<Producto> listaProductoPorID = Manejadora.getListaProductosPorIDProveedor(idProveedor);

            try
            {
                if (listaProductoPorID.Count != 0)
                {
                    productos = Ok(listaProductoPorID);
                }else
                {
                    productos = NoContent();
                }

            }
            catch (Exception e)
            {
                productos = BadRequest("Ha ocurrido un error al pedir la lista de productos por ID de proveedor");
            }

            return productos;
        }

        // POST api/<ProveedorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
