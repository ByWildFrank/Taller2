using BeanDesktop.CapaDeEntidades;
using CapaDeDatos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        // 💸 KPI 1: Ganancias del Mes
        public decimal ObtenerGananciasDelMes()
        {
            decimal ganancias = 0;
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    string query = @"
                    SELECT ISNULL(SUM((dv.PrecioVenta - p.PrecioFabricacion) * dv.Cantidad), 0)
                    FROM DETALLE_VENTA dv
                    JOIN VENTA v ON dv.IdVenta = v.IdVenta
                    JOIN PRODUCTO p ON dv.IdProducto = p.IdProducto
                    WHERE MONTH(v.FechaRegistro) = MONTH(GETDATE()) AND YEAR(v.FechaRegistro) = YEAR(GETDATE());";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    // ExecuteScalar es ideal para obtener un solo valor.
                    ganancias = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                catch
                {
                    ganancias = 0; // En caso de error, devolvemos 0.
                }
            }
            return ganancias;
        }

        // 🎯 KPI 2: Segmento Dominante
        public string ObtenerSegmentoDominante()
        {
            string segmento = "N/A";
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    string query = @"
                    SELECT TOP 1 Segmento 
                    FROM CLIENTE_SEGMENTO 
                    GROUP BY Segmento 
                    ORDER BY COUNT(IdCliente) DESC;";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        segmento = result.ToString();
                    }
                }
                catch
                {
                    segmento = "Error";
                }
            }
            return segmento;
        }

        // ⚠️ KPI 3: Productos en Bajo Stock
        public int ObtenerProductosBajoStock()
        {
            int cantidad = 0;
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    // Definimos "Bajo Stock" como menos de 10 unidades.
                    string query = "SELECT COUNT(IdProducto) FROM PRODUCTO WHERE Stock < 10 AND Estado = 1;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    cantidad = 0;
                }
            }
            return cantidad;
        }

        // 🛒 KPI 4: Ticket Promedio del Mes
        public decimal ObtenerTicketPromedioDelMes()
        {
            decimal ticketPromedio = 0;
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    string query = @"
                    SELECT ISNULL(AVG(MontoTotal), 0) 
                    FROM VENTA 
                    WHERE MONTH(FechaRegistro) = MONTH(GETDATE()) AND YEAR(FechaRegistro) = YEAR(GETDATE());";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    ticketPromedio = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                catch
                {
                    ticketPromedio = 0;
                }
            }
            return ticketPromedio;
        }

        public Dictionary<string, int> ObtenerClientesPorSegmento()
        {
            var resultado = new Dictionary<string, int>();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ReporteClientesPorSegmento", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            resultado.Add(dr["Segmento"].ToString(), Convert.ToInt32(dr["Total"]));
                        }
                    }
                }
                catch
                {
                    // En caso de error, devolvemos un diccionario vacío.
                    resultado = new Dictionary<string, int>();
                }
            }
            return resultado;
        }
        public Dictionary<string, decimal> ObtenerVentasPorProducto()
        {
            var resultado = new Dictionary<string, decimal>();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ReporteVentasPorProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            resultado.Add(dr["Nombre"].ToString(), Convert.ToDecimal(dr["TotalVendido"]));
                        }
                    }
                }
                catch { /* Opcional: Manejo de errores */ }
            }
            return resultado;
        }
        public Dictionary<string, decimal> ObtenerGananciasMensuales()
        {
            // Usamos SortedDictionary para que los meses queden ordenados automáticamente
            var resultado = new SortedDictionary<string, decimal>();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ReporteGananciasMensuales", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            resultado.Add(dr["AnioMes"].ToString(), Convert.ToDecimal(dr["GananciaTotal"]));
                        }
                    }
                }
                catch { /* Opcional: Manejo de errores */ }
            }
            // Convertimos a Dictionary normal para mantener la consistencia del tipo de retorno
            return resultado.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
        public DashboardKPIs ObtenerDatosDashboard()
        {
            DashboardKPIs kpis = new DashboardKPIs();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ReporteKPIsDashboard", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            kpis.GananciasMesActual = Convert.ToDecimal(dr["GananciasMesActual"]);
                            kpis.GananciasMesAnterior = Convert.ToDecimal(dr["GananciasMesAnterior"]);
                            kpis.TicketPromedioActual = Convert.ToDecimal(dr["TicketPromedioActual"]);
                            kpis.TicketPromedioAnterior = Convert.ToDecimal(dr["TicketPromedioAnterior"]);
                            kpis.NuevosClientesActual = Convert.ToInt32(dr["NuevosClientesActual"]);
                            kpis.NuevosClientesAnterior = Convert.ToInt32(dr["NuevosClientesAnterior"]);
                            kpis.ProductosBajoStock = Convert.ToInt32(dr["ProductosBajoStock"]);
                            kpis.SegmentoDominante = dr["SegmentoDominante"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Puedes loggear el error aquí si quieres
                    return new DashboardKPIs(); // Devuelve un objeto vacío en caso de error
                }
            }
            return kpis;
        }
    }

}