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
    }
}
