using ProyectoApiNicolas.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoApiNicolas.Controllers
{
    public class ProductosController : ApiController
    {
        [HttpGet]
        public IEnumerable<Models.Producto> GetProductos()
        {
            string sRet = "";
            List<Models.Producto> ListaProductos = (List<Producto>)Producto.ObtenerProductos(ref sRet);

            return ListaProductos;
        }





        /// <summary>
        /// ALGO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>
        [HttpGet]
        public Models.Producto GetProducto(int id)
        {
            string sRet = "";
            Models.Producto Producto = (Producto)Producto.ObtenerProducto(id, ref sRet);

            return Producto;
        }



        [HttpGet]
        public IEnumerable<Models.Categoria> GetCategorias()
        {
            string sRet = "";
            List<Models.Categoria> ListaCategorias = (List<Categoria>)Categoria.ObtenerCategorias(ref sRet);

            return ListaCategorias;
        }


        [HttpGet]
        public IEnumerable<Models.Categoria> GetCategorias(int producto_id)
        {
            string sRet = "";
            List<Models.Categoria> ListaCategorias = (List<Categoria>)Categoria.ObtenerCategoriasPorProducto(producto_id, ref sRet);

            return ListaCategorias;
        }


        [HttpGet]
        public IEnumerable<Models.Categoria> GetCategoriasDisponibles(int producto_id)
        {
            string sRet = "";
            List<Models.Categoria> ListaCategorias = (List<Categoria>)Categoria.ObtenerCategoriasDisoniblesPorProducto(producto_id, ref sRet);

            return ListaCategorias;
        }


        //TODO: Modificar Metodo de INSERTAR PRODUCTO
        [HttpPost]
        public IHttpActionResult InsertarProducto([FromBody] Models.Producto NuevoProducto)
        {
            //CODIGO PARA INSERTAR UN PRODUCTO

            string sRet = "";
            int iProductoID = 0;

            sRet = Models.Producto.InsertarProducto(NuevoProducto, ref iProductoID);


            //Si salio todo ok, le agrego el ID que obtuvo al objeto original
            if (sRet == "")
            {
                NuevoProducto.id = iProductoID;
            }
            else
            {
                return BadRequest("Error al insertar el producto: " + sRet);
            }


            return Ok(NuevoProducto);
        }


        [HttpPut]
        public IHttpActionResult ModificarProducto([FromBody] Models.Producto NuevoProducto)
        {
            //CODIGO PARA MODIFICAR UN PRODUCTO

            string sRet = "";

            sRet = Models.Producto.ModificarProducto(NuevoProducto);


            //Si salio todo ok, le agrego el ID que obtuvo al objeto original
            if (sRet != "")
            {
                return BadRequest("Error al modificar el producto: " + sRet);
            }


            return Ok(NuevoProducto);
        }




        [HttpPost]
        public IHttpActionResult InsertarCategoriaProducto(int id_producto, int id_categoria)
        {
            //CODIGO PARA INSERTAR UNA CATEGORIA A UN PRODUCTO

            string sRet = "";
            sRet = Models.Producto.InsertarCategoriaProducto(id_producto, id_categoria);


            //Si salio todo ok
            if (sRet == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error al insertar categoria al producto: " + sRet);
            }


        }



        //TODO: Agregar Método de AGREGAR CATEGORIA A UN PRODUCTO

        public IHttpActionResult EliminarCategoriaProducto(int id_producto, int id_categoria)
        {
            //CODIGO PARA INSERTAR UNA CATEGORIA A UN PRODUCTO

            string sRet = "";
            sRet = Models.Producto.EliminarCategoriaProducto(id_producto, id_categoria);


            //Si salio todo ok
            if (sRet == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error al eliminar categoria al producto: " + sRet);
            }


        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id_producto)
        {
            //CODIGO PARA INSERTAR UNA CATEGORIA A UN PRODUCTO

            string sRet = "";
            sRet = Models.Producto.EliminarProducto(id_producto);


            //Si salio todo ok
            if (sRet == "")
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error al eliminar producto: " + sRet);
            }


        }




        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}