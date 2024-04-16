using ProyectoApiNicolas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoApiNicolas.Controllers
{
    public class ProductosController : ApiController
    {

        [HttpGet]
        [Route("api/ObtenerProductos")]
        public IEnumerable<Models.Producto> ObtenerProductos()
        {
            string sRet = "";
            List<Models.Producto> ListaProductos = (List<Producto>)Producto.ObtenerProductos(-1, ref sRet);

            return ListaProductos;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/ObtenerProducto")]
        public Models.Producto ObtenerProducto(int id)
        {

            string sRet = "";
            Models.Producto Producto = (Producto)Producto.ObtenerProducto(id,-1, ref sRet);

            return Producto;

            //Models.Producto producto = new Models.Producto();
            //producto.id = 1;
            //producto.Nombre = "Producto Prueba";
            //return producto;
        }

        [HttpGet]
        [Route("api/ObtenerCategoria")]
        public Models.Categoria ObtenerCategorias()
        {

            string sRet = "";
            List<Models.Categoria> ListaCategorias = (List<Categoria>)Categoria.ObtenerCategorias(ref sRet);

            return ListaCategorias;
            
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}