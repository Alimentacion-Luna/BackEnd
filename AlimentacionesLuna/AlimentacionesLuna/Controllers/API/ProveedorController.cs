﻿using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlimentacionesLuna.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        public static Proveedor p = new Proveedor
        {
            Id_Proveedor = 0,
            Nombre = "",
            Telefono = "",
            Correo = ""
        };

        public static Producto productoEjemplo = new Producto
        {
            IdProducto = 0,
            Tipo = "algo",
            Impuesto = 0,
            Nombre = "algo"
        };


        // GET: api/<ProveedorController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult resultado;

            List<Proveedor> listaProveedores = new List<Proveedor>();
            listaProveedores.Add(p);

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

        //// GET api/<ProveedorController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    IActionResult resultado;
        //    Proveedor personita = null;
        //    try
        //    {
        //        if(p.Id_Proveedor == id)
        //        {
        //            personita = p;
        //        }
        //        if(personita != null)
        //        {
        //            resultado = Ok(personita);
        //        }
        //        else
        //        {
        //            resultado = NoContent();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        resultado = BadRequest("Ha ocurrido un error al pedir el proveedor por ID");
        //    }

        //    return resultado;
        //}

        

        // GET api/<ProveedorController>/5
        [HttpGet("{id}/productos")]
        public IActionResult Get(int idProveedor)
        {
            IActionResult productos;
            List<Producto> listaProductoPorID = new List<Producto>();
            listaProductoPorID.Add(productoEjemplo);

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
