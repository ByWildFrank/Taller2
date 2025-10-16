using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeEntidades
{
    public class ReporteVenta
    {
        public string FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento{ get;set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public string UsuarioRegistro { get; set; }
        public string CodigoProducto { get;set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal GananciaBruta { get; set; }
        public decimal CostoUnitario { get; set; }



    } 
}
