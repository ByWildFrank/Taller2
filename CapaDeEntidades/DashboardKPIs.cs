using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeEntidades
{
    public class DashboardKPIs
    {
        public decimal GananciasMesActual { get; set; }
        public decimal GananciasMesAnterior { get; set; }
        public decimal TicketPromedioActual { get; set; }
        public decimal TicketPromedioAnterior { get; set; }
        public int NuevosClientesActual { get; set; }
        public int NuevosClientesAnterior { get; set; }
        public int ProductosBajoStock { get; set; }
        public string SegmentoDominante { get; set; }
    }
}
