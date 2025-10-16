using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }

        // ✅ CAMBIO: Agregamos el IdCliente
        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        // ❌ CAMBIO: Eliminamos estas propiedades
        // public string DocumentoCliente { get; set; }
        // public string NombreCliente { get; set; }

        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public string FechaRegistro { get; set; }

        public Cliente oCliente { get; set; } 
    }
}
