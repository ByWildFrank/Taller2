using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeEntidades;
using BeanDesktop.CapaDeEntidades;

namespace CapaDeDatos
{
    public class CD_Venta
    {

        // Registrar venta (ya explicado antes, TVP TipoDetalleVenta)
        public int Registrar(Venta objVenta, DataTable detalleVenta, out string mensaje)
        {
            int idVentaGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())

                using (SqlCommand cmd = new SqlCommand("SP_RegistrarVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", objVenta.IdUsuario);
                    cmd.Parameters.AddWithValue("@TipoDocumento", objVenta.TipoDocumento);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", objVenta.NumeroDocumento);

                    // ✅ CAMBIO: Enviamos el nuevo parámetro IdCliente
                    cmd.Parameters.AddWithValue("@IdCliente", objVenta.IdCliente);

                    // ❌ CAMBIO: Eliminamos los parámetros viejos
                    // cmd.Parameters.AddWithValue("@DocumentoCliente", objVenta.DocumentoCliente);
                    // cmd.Parameters.AddWithValue("@NombreCliente", objVenta.NombreCliente);

                    cmd.Parameters.AddWithValue("@MontoPago", objVenta.MontoPago);
                    cmd.Parameters.AddWithValue("@MontoCambio", objVenta.MontoCambio);
                    cmd.Parameters.AddWithValue("@MontoTotal", objVenta.MontoTotal);
                    cmd.Parameters.AddWithValue("@DescuentoAplicado", objVenta.DescuentoAplicado);

                    // Detalle: parámetro estructurado (TVP). Asegurate de tener el tipo dbo.TipoDetalleVenta en la BD
                    var detalleParam = cmd.Parameters.AddWithValue("@DetalleVenta", detalleVenta ?? new DataTable());
                    detalleParam.SqlDbType = SqlDbType.Structured;
                    detalleParam.TypeName = "dbo.TipoDetalleVenta";

                    cmd.Parameters.Add("@IdVentaResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idVentaGenerado = Convert.ToInt32(cmd.Parameters["@IdVentaResultado"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                idVentaGenerado = 0;
                mensaje = ex.Message;
            }

            return idVentaGenerado;
        }

        // Obtener venta por NumeroDocumento (devuelve la primera coincidencia)
        public Venta ObtenerPorNumeroDocumento(string numeroDocumento)
        {
            Venta venta = null;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    // ✅ CAMBIO: Modificamos la consulta para unir VENTA con CLIENTE
                    string query = @"
                SELECT TOP 1 
                    v.IdVenta, v.IdUsuario, v.TipoDocumento, v.NumeroDocumento, v.MontoPago, 
                    v.MontoCambio, v.MontoTotal, v.FechaRegistro, v.DescuentoAplicado,
                    
                    v.IdCliente,
                    c.NombreCompleto,
                    c.Documento AS DocumentoCliente
                FROM VENTA v
                LEFT JOIN CLIENTE c ON v.IdCliente = c.IdCliente -- El JOIN para obtener los datos
                WHERE v.NumeroDocumento = @NumeroDocumento
                ORDER BY v.IdVenta DESC"; // Por si hay números duplicados, trae la más reciente

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                venta = new Venta
                                {
                                    IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    TipoDocumento = dr["TipoDocumento"].ToString(),
                                    NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                    MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                    MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                    MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                    DescuentoAplicado = Convert.ToDecimal(dr["DescuentoAplicado"]),
                                    FechaRegistro = dr["FechaRegistro"].ToString(),
                                    IdCliente = Convert.ToInt32(dr["IdCliente"])
                                };

                                // ✅ ¡AQUÍ ESTÁ LA MAGIA!
                                // Si se encontró un cliente (IdCliente no es NULL),
                                // creamos el objeto oCliente y lo llenamos.
                                if (dr["IdCliente"] != DBNull.Value)
                                {
                                    venta.oCliente = new Cliente()
                                    {
                                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                        NombreCompleto = dr["NombreCompleto"].ToString(),
                                        Documento = dr["DocumentoCliente"].ToString()
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error
                venta = null;
            }
            return venta;
        }

        // Listar detalle por IdVenta
        public List<Detalle_Venta> ListarDetallePorVenta(int idVenta)
        {
            var lista = new List<Detalle_Venta>();
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    // ✅ CAMBIO: Usar el nuevo SP
                    SqlCommand cmd = new SqlCommand("SP_ObtenerDetalleVenta", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Detalle_Venta
                            {
                                IdDetalleVenta = Convert.ToInt32(dr["IdDetalleVenta"]),
                                NombreProducto = dr["NombreProducto"].ToString(), // ✅ Usar la nueva propiedad
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error
            }
            return lista;
        }

        public DataTable Listar()
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, Descripcion, PrecioVenta, Stock, IdCategoria FROM PRODUCTO", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, Descripcion, PrecioVenta, Stock, IdCategoria FROM PRODUCTO WHERE Descripcion LIKE @nombre", cn);
                da.SelectCommand.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ListarPorCategoria(int idCategoria)
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, Descripcion, PrecioVenta, Stock, IdCategoria FROM PRODUCTO WHERE IdCategoria = @idCategoria", cn);
                da.SelectCommand.Parameters.AddWithValue("@idCategoria", idCategoria);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public List<VentaInfo> ListarVentas()
        {
            var lista = new List<VentaInfo>();
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarVentas", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new VentaInfo // ✅ CORRECCIÓN: Usar VentaInfo
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]).ToString("dd/MM/yyyy"),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                NombreUsuario = dr["NombreUsuario"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error
            }
            return lista;
        }

        public Venta ObtenerPorId(int idVenta)
        {
            Venta venta = null;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    string query = @"
                SELECT v.IdVenta, v.IdUsuario, v.TipoDocumento, v.NumeroDocumento,
                       v.MontoPago, v.MontoCambio, v.MontoTotal, v.FechaRegistro, v.DescuentoAplicado,
                       v.IdCliente, c.NombreCompleto, c.Documento AS DocumentoCliente
                FROM VENTA v
                LEFT JOIN CLIENTE c ON v.IdCliente = c.IdCliente
                WHERE v.IdVenta = @IdVenta";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                venta = new Venta
                                {
                                    IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    TipoDocumento = dr["TipoDocumento"].ToString(),
                                    NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                    MontoPago = Convert.ToDecimal(dr["MontoPago"]),
                                    MontoCambio = Convert.ToDecimal(dr["MontoCambio"]),
                                    MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                    DescuentoAplicado = Convert.ToDecimal(dr["DescuentoAplicado"]),
                                    FechaRegistro = dr["FechaRegistro"].ToString(),
                                    IdCliente = Convert.ToInt32(dr["IdCliente"])
                                };

                                if (dr["IdCliente"] != DBNull.Value)
                                {
                                    venta.oCliente = new Cliente
                                    {
                                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                        NombreCompleto = dr["NombreCompleto"].ToString(),
                                        Documento = dr["DocumentoCliente"].ToString()
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch { venta = null; }

            return venta;
        }
        public string ObtenerUltimoNumeroDocumento(string tipoDocumento)
        {
            string ultimoNumero = null;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    string query = "SELECT TOP 1 NumeroDocumento FROM VENTA " +
                                   "WHERE TipoDocumento = @TipoDocumento " +
                                   "ORDER BY IdVenta DESC";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                    cn.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        ultimoNumero = result.ToString();
                    }
                }
            }
            catch { ultimoNumero = null; }
            return ultimoNumero;
        }

    }
}
