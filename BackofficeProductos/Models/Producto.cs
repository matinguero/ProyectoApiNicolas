using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackofficeProductos.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public object Foto { get; set; }
        public decimal Precio { get; set; }
        public int stock { get; set; }
        public int activo { get; set; }
        public string DescripcionActivo { get; set; }
    }
}