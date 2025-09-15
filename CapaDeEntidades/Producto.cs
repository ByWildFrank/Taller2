using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string codigo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public Categoria oCategoria { get; set; }
        public int stock { get; set; }
        public decimal PrecioFabricacion { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }

    }
}
