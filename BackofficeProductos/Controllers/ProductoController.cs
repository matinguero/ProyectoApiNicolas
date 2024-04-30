using BackofficeProductos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BackofficeProductos.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {

            //EN LUGAR DE IR A UNA BASE DE DATOS VOY A BUSCAR AL SERVICIO API REST EL LISTADO DE PRODUCTOS

            //ENDPOINT DE APIREST
            Uri url = new Uri(String.Format("https://localhost:44349/api/Productos/GetProductos"));

            //CREO EL REQUEST CON SUS CARACTERISTICAS
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";


            //CREO EL OBJETO RESPONSE QUE OBTIENE LA RESPUESTA DEL REQUEST
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


            //ME GUARDO EN UN STRING EL JSON COMPLETO
            string resultadojson;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultadojson = streamReader.ReadToEnd();
            }


            //Intancio un objeto de lista de productos
            List<Models.Producto> ListaProductos = new List<Models.Producto>();

            //Hago la conversion desde el json A UNA COLECCION DE OBJETOS (Producto)
            ListaProductos = JsonConvert.DeserializeObject<List<Producto>>(resultadojson.ToString());

            //Retorno a la vista 
            return View(ListaProductos);


        }





        public ActionResult Categorias(int idProducto)
        {

            List<Models.Categorias> ListaCategorias = new List<Models.Categorias>();


            //ENDPOINT DE APIREST
            Uri url = new Uri(String.Format("https://localhost:44349/api/Productos/GetCategorias?producto_id=" + idProducto.ToString()));



            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";



            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }




            //CONVERSION CORRECTA
            ListaCategorias = JsonConvert.DeserializeObject<List<Categorias>>(result.ToString());

            ViewBag.IDProducto = idProducto.ToString();




            ////DEBERIA TRAER LA LISTA DE CATEGORIAS DISPONIBLES



            //List<Models.Categorias> ListaTodasCategorias = new List<Models.Categorias>();


            ////ENDPOINT DE APIREST
            //Uri url2 = new Uri(String.Format("https://localhost:44353/api/CategoriasDisponibles?ProductoID=" + idProducto.ToString()));



            //HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url2);
            //httpWebRequest2.ContentType = "application/json";
            //httpWebRequest2.Method = "GET";
            //httpWebRequest2.Accept = "application/json";



            //HttpWebResponse httpResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
            //string result2;
            //using (var streamReader2 = new StreamReader(httpResponse2.GetResponseStream()))
            //{
            //    result2 = streamReader2.ReadToEnd();
            //}

            //ListaTodasCategorias = JsonConvert.DeserializeObject<List<Categorias>>(result2.ToString());

            //ViewData["Categorias"] = ListaTodasCategorias;


            //if (ListaTodasCategorias.Count == 0)
            //{
            //    ViewBag.ErrorCategorias = "No hay más categorías disponibles";
            //}
            //else
            //{
            //    ViewBag.ErrorCategorias = "";
            //}





            return View(ListaCategorias);




        }


    }
}
