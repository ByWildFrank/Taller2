using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeEntidades
{
    public class VentaInfo
    {
        public int IdVenta { get; set; }
        public string FechaRegistro { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCliente { get; set; }
        public string NombreUsuario { get; set; }
        public decimal MontoTotal { get; set; }
    }
}