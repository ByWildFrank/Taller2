using BeanDesktop.CapaDeEntidades;
using CapaDeDatos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeDatos
{
    internal class CD_Reporte
    {
        public List<ReporteVenta> Venta(string fechaInicio, string fechaFin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();
            try
            {
                using (SqlConnection oconeccion = Conexion.GetConnection())
                {
                    oconeccion.Open();
                    using (var comando = new SqlCommand("SP_ReporteVentas", oconeccion))
                    {
                        comando.Parameters.AddWithValue("FechaInicio", fechaInicio);
                        comando.Parameters.AddWithValue("FechaFin", fechaFin);
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        using (var lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                lista.Add(new ReporteVenta()
                                {
                                    FechaRegistro = lector["FechaRegistro"].ToString(),
                                    HoraRegistro = lector["HoraRegistro"].ToString(),
                                    TipoDocumento = lector["TipoDocumento"].ToString(),
                                    NumeroDocumento = lector["NumeroDocumento"].ToString(),
                                    DocumentoCliente = lector["DocumentoCliente"].ToString(),
                                    NombreCliente = lector["NombreCliente"].ToString(),
                                    MontoTotal = Convert.ToDecimal(lector["MontoTotal"]),
                                    MontoPago = Convert.ToDecimal(lector["MontoPago"]),
                                    MontoCambio = Convert.ToDecimal(lector["MontoCambio"]),
                                    DescuentoAplicado = Convert.ToDecimal(lector["DescuentoAplicado"]),
                                    UsuarioRegistro = lector["UsuarioRegistro"].ToString(),
                                    CodigoProducto = lector["CodigoProducto"].ToString(),
                                    NombreProducto = lector["NombreProducto"].ToString(),
                                    Categoria = lector["Categoria"].ToString(),
                                    PrecioVenta = Convert.ToDecimal(lector["PrecioVenta"]),
                                    Cantidad = Convert.ToInt32(lector["Cantidad"]),
                                    Subtotal = Convert.ToDecimal(lector["Subtotal"]),
                                    CostoUnitario = Convert.ToDecimal(lector["CostoUnitario"]),
                                    GananciaBruta = Convert.ToDecimal(lector["GananciaBruta"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lista = new List<ReporteVenta>();
            }
            return lista;
        }
    }
}
