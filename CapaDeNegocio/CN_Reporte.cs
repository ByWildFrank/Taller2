using BeanDesktop.CapaDeDatos;
using BeanDesktop.CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Reporte
    {
       private  CD_Reporte objcd_reporte = new CD_Reporte();

        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            return objcd_reporte.Venta(fechainicio, fechafin);
        }

        // --- NUEVOS MÉTODOS PARA KPIS ---

        public decimal ObtenerGananciasDelMes()
        {
            return objcd_reporte.ObtenerGananciasDelMes();
        }

        public string ObtenerSegmentoDominante()
        {
            return objcd_reporte.ObtenerSegmentoDominante();
        }

        public int ObtenerProductosBajoStock()
        {
            return objcd_reporte.ObtenerProductosBajoStock();
        }

        public decimal ObtenerTicketPromedioDelMes()
        {
            return objcd_reporte.ObtenerTicketPromedioDelMes();
        }
        public Dictionary<string, int> ObtenerClientesPorSegmento()
        {
            return objcd_reporte.ObtenerClientesPorSegmento();
        }
        public Dictionary<string, decimal> ObtenerVentasPorProducto()
        {
            return objcd_reporte.ObtenerVentasPorProducto();
        }
        public Dictionary<string, decimal> ObtenerGananciasMensuales()
        {
            return objcd_reporte.ObtenerGananciasMensuales();
        }
        public DashboardKPIs ObtenerDatosDashboard()
        {
            return objcd_reporte.ObtenerDatosDashboard();
        }
        public Dictionary<string, decimal> ObtenerVentasPorVendedor(DateTime fechaInicio, DateTime fechaFin)
        {
            return objcd_reporte.ObtenerVentasPorVendedor(fechaInicio, fechaFin);
        }
        public DashboardKPIs ObtenerDatosDashboard(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return objcd_reporte.ObtenerDatosDashboard(fechaInicio, fechaFin);
        }

        public Dictionary<string, int> ObtenerClientesPorSegmento(DateTime? fechaFin = null)
        {
            return objcd_reporte.ObtenerClientesPorSegmento(fechaFin);
        }

        public Dictionary<string, decimal> ObtenerVentasPorProducto(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return objcd_reporte.ObtenerVentasPorProducto(fechaInicio, fechaFin);
        }

        public Dictionary<string, decimal> ObtenerGananciasMensuales(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            return objcd_reporte.ObtenerGananciasMensuales(fechaInicio, fechaFin);
        }
    }
}