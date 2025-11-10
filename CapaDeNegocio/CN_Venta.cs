using BeanDesktop.CapaDeDatos;
using BeanDesktop.CapaDeEntidades;
using CapaDeDatos;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Venta
    {
        private CD_Venta objCD = new CD_Venta();

        public int Registrar(Venta objVenta, DataTable detalleVenta, out string mensaje)
        {
            mensaje = string.Empty;

            if (detalleVenta == null || detalleVenta.Rows.Count == 0)
            {
                mensaje = "Debe agregar al menos un producto a la venta.";
                return 0;
            }

            return objCD.Registrar(objVenta, detalleVenta, out mensaje);
        }

        public Venta ObtenerPorNumeroDocumento(string numeroDocumento)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento)) return null;
            return objCD.ObtenerPorNumeroDocumento(numeroDocumento);
        }

        public List<Detalle_Venta> ListarDetallePorVenta(int idVenta)
        {
            if (idVenta <= 0) return new List<Detalle_Venta>();
            return objCD.ListarDetallePorVenta(idVenta);
        }
        public List<VentaInfo> ListarVentas()
        {
            return objCD.ListarVentas();
        }

        public Venta ObtenerPorId(int idVenta)
        {
            if (idVenta <= 0) return null;
            return objCD.ObtenerPorId(idVenta);
        }
        public string GenerarSiguienteNumeroDocumento(string tipoDocumento)
        {
            string ultimoNumero = objCD.ObtenerUltimoNumeroDocumento(tipoDocumento);
            string prefijo = (tipoDocumento == "Boleta") ? "B001-" : "F001-";
            int nuevoCorrelativo = 1;

            if (!string.IsNullOrEmpty(ultimoNumero))
            {
                try
                {
                    // Intentamos extraer el número (ej: de "B001-0015" extrae 15)
                    int ultimoCorrelativo = int.Parse(ultimoNumero.Split('-')[1]);
                    nuevoCorrelativo = ultimoCorrelativo + 1;
                }
                catch
                {
                    nuevoCorrelativo = 1; // Si falla el parseo, resetea
                }
            }

            // Formatea el nuevo número con 4 dígitos (ej: 16 -> "0016")
            return prefijo + nuevoCorrelativo.ToString("D4");
        }
    }
}
