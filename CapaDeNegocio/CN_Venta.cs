using BeanDesktop.CapaDeDatos; // si tu proyecto usa esa ruta; si no, ajustar el namespace
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

        public List<DetalleVenta> ListarDetallePorVenta(int idVenta)
        {
            if (idVenta <= 0) return new List<DetalleVenta>();
            return objCD.ListarDetallePorVenta(idVenta);
        }
    }
}
