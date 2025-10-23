using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidades
{
    public class Detalle_Venta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }        // 🔹 Agregado
        public int IdProducto { get; set; }     // 🔹 Agregado
        public Producto oProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public string FechaRegistro { get; set; }
        public string NombreProducto { get; set; }

    }
}
