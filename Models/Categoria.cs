using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoApiNicolas.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string Descripcion { get; set; }


        public static IEnumerable<Categoria> ObtenerCategorias(ref string sResult)
        {

            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spObtenerCategorias", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                //MyDataAdapter.SelectCommand.Parameters.AddWithValue("@id_categoria", iCategoria);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);


                List<Models.Categoria> ListaCategorias = new List<Models.Categoria>();

                foreach (DataRow row in dt.Rows)
                {
                    var Categoria = new Categoria();
                    Categoria.id = int.Parse(row["id"].ToString());
                    Categoria.Descripcion = row["nombre"].ToString();



                    ListaCategorias.Add(Categoria);
                }


                sResult = "";
                return ListaCategorias;
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }


        public static IEnumerable<Categoria> ObtenerCategoriasPorProducto(int producto_id, ref string sResult)
        {

            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spBOObtenerCategorias", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@producto_id", producto_id);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);


                List<Models.Categoria> ListaCategorias = new List<Models.Categoria>();

                foreach (DataRow row in dt.Rows)
                {
                    var Categoria = new Categoria();
                    Categoria.id = int.Parse(row["id"].ToString());
                    Categoria.Descripcion = row["nombre"].ToString();



                    ListaCategorias.Add(Categoria);
                }


                sResult = "";
                return ListaCategorias;
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }


        public static IEnumerable<Categoria> ObtenerCategoriasDisoniblesPorProducto(int producto_id, ref string sResult)
        {

            SqlConnection MyConnection = default(SqlConnection);
            SqlDataAdapter MyDataAdapter = default(SqlDataAdapter);

            try
            {
                MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
                MyDataAdapter = new SqlDataAdapter("spBOObtenerCategoriasDisponiblesProducto", MyConnection);
                MyDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@id_producto", producto_id);


                DataTable dt = new DataTable();
                MyDataAdapter.Fill(dt);


                List<Models.Categoria> ListaCategorias = new List<Models.Categoria>();

                foreach (DataRow row in dt.Rows)
                {
                    var Categoria = new Categoria();
                    Categoria.id = int.Parse(row["CategoriaID"].ToString());
                    Categoria.Descripcion = row["CategoriaNombre"].ToString();



                    ListaCategorias.Add(Categoria);
                }


                sResult = "";
                return ListaCategorias;
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                return null;
            }

        }
    }
}