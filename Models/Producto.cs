using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoApiNicolas.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string Descripcion { get; set; }

        public string Nombre { get; set; }

        public string Foto { get; set; }

        public decimal Precio { get; set; }

        public int stock { get; set; }

        public int activo { get; set; }



        public static IEnumerable<Producto> ObtenerProductos(int iCategoria, ref string sResult)
        {

            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spObtenerTodosLosProductos", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@id_categoria", iCategoria);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);


                List<Models.Producto> ListaProductos = new List<Models.Producto>();

                foreach (DataRow row in dt.Rows)
                {
                    var Producto = new Producto();
                    Producto.id = int.Parse(row["id"].ToString());
                    Producto.Descripcion = row["descripcion"].ToString();
                    Producto.Nombre = row["nombre"].ToString();
                    Producto.Precio = decimal.Parse(row["PrecioEnPesos"].ToString());
                    //Producto.id_categoria = int.Parse(row["Categoria_id"].ToString());
                    //Producto.Categoria = row["Categoria"].ToString();


                    ListaProductos.Add(Producto);
                }


                sResult = "";
                return ListaProductos;
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }


        public static IEnumerable<Producto> ObtenerProductos(ref string sResult)
        {

            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spBOObtenerProductos", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                //MyDataAdapter.SelectCommand.Parameters.AddWithValue("@id_categoria", iCategoria);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);


                List<Models.Producto> ListaProductos = new List<Models.Producto>();

                foreach (DataRow row in dt.Rows)
                {
                    var Producto = new Producto();
                    Producto.id = int.Parse(row["id"].ToString());
                    Producto.Descripcion = row["descripcion"].ToString();
                    Producto.Nombre = row["nombre"].ToString();
                    Producto.Precio = decimal.Parse(row["PrecioEnPesos"].ToString());
                    //Producto.id_categoria = int.Parse(row["Categoria_id"].ToString());
                    //Producto.Categoria = row["Categoria"].ToString();


                    ListaProductos.Add(Producto);
                }


                sResult = "";
                return ListaProductos;
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }


        public static Producto ObtenerProducto(int iProductoid, ref string sResult)
        {

            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spBOObtenerProducto", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@producto_id", iProductoid);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);


                var Producto = new Producto();
                foreach (DataRow row in dt.Rows)
                {

                    Producto.id = int.Parse(row["id"].ToString());
                    Producto.Descripcion = row["descripcion"].ToString();
                    Producto.Nombre = row["nombre"].ToString();
                    Producto.Precio = decimal.Parse(row["PrecioEnPesos"].ToString());
                    //Producto.id_categoria = int.Parse(row["Categoria_id"].ToString());
                    //Producto.Categoria = row["Categoria"].ToString();

                }


                sResult = "";
                return Producto;
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }


        public static string InsertarProducto(Models.Producto nuevoProducto, ref int iProductoID)
        {
            string sRet = "";

            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spInsertarProducto", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;




                MySqlCommand.Parameters.AddWithValue("@descripcion", nuevoProducto.Descripcion);
                MySqlCommand.Parameters.AddWithValue("@nombre", nuevoProducto.Nombre);
                MySqlCommand.Parameters.AddWithValue("@precio", nuevoProducto.Precio);
                MySqlCommand.Parameters.AddWithValue("@stock", nuevoProducto.stock);
                MySqlCommand.Parameters.AddWithValue("@activo", nuevoProducto.activo);
                //MySqlCommand.Parameters.AddWithValue("@precio", nuevoProducto.PrecioDolar);
                //MySqlCommand.Parameters.AddWithValue("@id_categoria", nuevoProducto.id_categoria);
                //MySqlCommand.Parameters.AddWithValue("@Stock", nuevoProducto.Stock);

                //TO-DO: CLASE 82 TERMINADA
                // Agrego los Parámetros al SPROC (OUT)

                SqlParameter pariProductoID = new SqlParameter("@producto_id", SqlDbType.Int);
                pariProductoID.Direction = ParameterDirection.Output;

                MySqlCommand.Parameters.Add(pariProductoID);



                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();

                //OBTENGO LOS VALORES DE LOS PARAMETROS DE SALIDA
                iProductoID = int.Parse(pariProductoID.Value.ToString());

                MyConnection.Close();
                MyConnection.Dispose();


                sRet = "";

            }
            catch (Exception ex)
            {
                sRet = ex.Message;

            }



            return sRet;
        }



        //TO-DO 12:23
        public static string ModificarProducto(Models.Producto nuevoProducto)
        {
            string sRet = "";

            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spActualizarProducto", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;



                MySqlCommand.Parameters.AddWithValue("@producto_id", nuevoProducto.id);
                MySqlCommand.Parameters.AddWithValue("@descripcion", nuevoProducto.Descripcion);
                MySqlCommand.Parameters.AddWithValue("@nombre", nuevoProducto.Nombre);
                MySqlCommand.Parameters.AddWithValue("@precio", nuevoProducto.Precio);
                MySqlCommand.Parameters.AddWithValue("@stock", nuevoProducto.stock);
                MySqlCommand.Parameters.AddWithValue("@activo", nuevoProducto.activo);
                //MySqlCommand.Parameters.AddWithValue("@precio", nuevoProducto.PrecioDolar);
                //MySqlCommand.Parameters.AddWithValue("@id_categoria", nuevoProducto.id_categoria);
                //MySqlCommand.Parameters.AddWithValue("@Stock", nuevoProducto.Stock);



                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();
                MyConnection.Close();
                MyConnection.Dispose();


                sRet = "";

            }
            catch (Exception ex)
            {
                sRet = ex.Message;

            }



            return sRet;
        }


        public static string InsertarCategoriaProducto(int id_producto, int id_categoria)
        {
            string sRet = "";

            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spInsertarCategoriaProducto", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;




                MySqlCommand.Parameters.AddWithValue("@id_producto", id_producto);
                MySqlCommand.Parameters.AddWithValue("@id_categoria", id_categoria);




                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();
                MyConnection.Close();
                MyConnection.Dispose();


                sRet = "";

            }
            catch (Exception ex)
            {
                sRet = ex.Message;

            }



            return sRet;
        }

        public static string EliminarCategoriaProducto(int id_producto, int id_categoria)
        {
            string sRet = "";

            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spEliminarCategoriaProducto", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;




                MySqlCommand.Parameters.AddWithValue("@id_producto", id_producto);
                MySqlCommand.Parameters.AddWithValue("@id_categoria", id_categoria);




                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();
                MyConnection.Close();
                MyConnection.Dispose();


                sRet = "";

            }
            catch (Exception ex)
            {
                sRet = ex.Message;

            }



            return sRet;
        }
        public static string EliminarProducto(int id_producto)
        {
            string sRet = "";

            SqlConnection MyConnection = default(SqlConnection);
            SqlCommand MySqlCommand = default(SqlCommand);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MySqlCommand = new SqlCommand("spEliminarProducto", MyConnection);
                MySqlCommand.CommandType = CommandType.StoredProcedure;




                MySqlCommand.Parameters.AddWithValue("@id_producto", id_producto);


                MyConnection.Open();
                MySqlCommand.ExecuteNonQuery();
                MyConnection.Close();
                MyConnection.Dispose();


                sRet = "";

            }
            catch (Exception ex)
            {
                sRet = ex.Message;

            }



            return sRet;
        }


    }
}