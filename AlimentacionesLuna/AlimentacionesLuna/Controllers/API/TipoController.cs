using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlimentacionesLuna.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        // GET: api/<TipoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;
            List<Tipo> tipos = Manejadora.getTipos();

            try
            {
                if (tipos.Count > 0) 
                {
                    resultado = Ok(tipos);
                }
                else
                {
                    resultado = NoContent();
                }
            }
            catch (Exception ex) 
            {
                resultado = BadRequest("Error al recoger los tipos");
            }

            return resultado;
        }

    }
}
