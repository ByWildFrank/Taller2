using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeEntidades;

namespace CapaDeDatos
{
    public class CD_Venta
    {
        private string connectionString = "Server=Franco-Laptop\\SQLEXPRESS;Database=DB_BEAN;Trusted_Connection=True;TrustServerCertificate=True;";

        // Registrar venta (ya explicado antes, TVP TipoDetalleVenta)
        public int Registrar(Venta objVenta, DataTable detalleVenta, out string mensaje)
        {
            int idVentaGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SP_RegistrarVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", objVenta.IdUsuario);
                    cmd.Parameters.AddWithValue("@TipoDocumento", (object)objVenta.TipoDocumento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumeroDocumento", (object)objVenta.NumeroDocumento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DocumentoCliente", (object)objVenta.DocumentoCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NombreCliente", (object)objVenta.NombreCliente ?? DBNull.Value);
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
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TOP 1 IdVenta, IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente,
                                       MontoPago, MontoCambio, MontoTotal, FechaRegistro, DescuentoAplicado
                        FROM VENTA
                        WHERE NumeroDocumento = @NumeroDocumento
                        ORDER BY IdVenta DESC"; // si hay varios, tomar la más reciente

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@NumeroDocumento", numeroDocumento ?? "");
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                venta = new Venta
                                {
                                    IdVenta = dr["IdVenta"] != DBNull.Value ? Convert.ToInt32(dr["IdVenta"]) : 0,
                                    IdUsuario = dr["IdUsuario"] != DBNull.Value ? Convert.ToInt32(dr["IdUsuario"]) : 0,
                                    TipoDocumento = dr["TipoDocumento"] != DBNull.Value ? dr["TipoDocumento"].ToString() : "",
                                    NumeroDocumento = dr["NumeroDocumento"] != DBNull.Value ? dr["NumeroDocumento"].ToString() : "",
                                    DocumentoCliente = dr["DocumentoCliente"] != DBNull.Value ? dr["DocumentoCliente"].ToString() : "",
                                    NombreCliente = dr["NombreCliente"] != DBNull.Value ? dr["NombreCliente"].ToString() : "",
                                    MontoPago = dr["MontoPago"] != DBNull.Value ? Convert.ToDecimal(dr["MontoPago"]) : 0m,
                                    MontoCambio = dr["MontoCambio"] != DBNull.Value ? Convert.ToDecimal(dr["MontoCambio"]) : 0m,
                                    MontoTotal = dr["MontoTotal"] != DBNull.Value ? Convert.ToDecimal(dr["MontoTotal"]) : 0m,
                                    DescuentoAplicado = dr["DescuentoAplicado"] != DBNull.Value ? Convert.ToDecimal(dr["DescuentoAplicado"]) : 0m,
                                    FechaRegistro = dr["FechaRegistro"] != DBNull.Value ? dr["FechaRegistro"].ToString() : ""
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                // si quieres, loguear el error
                venta = null;
            }

            return venta;
        }

        // Listar detalle por IdVenta
        public List<DetalleVenta> ListarDetallePorVenta(int idVenta)
        {
            var lista = new List<DetalleVenta>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT IdDetalleVenta, IdVenta, IdProducto, PrecioVenta, Cantidad, SubTotal, FechaRegistro
                        FROM DETALLE_VENTA
                        WHERE IdVenta = @IdVenta
                        ORDER BY IdDetalleVenta";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new DetalleVenta
                                {
                                    IdDetalleVenta = dr["IdDetalleVenta"] != DBNull.Value ? Convert.ToInt32(dr["IdDetalleVenta"]) : 0,
                                    IdVenta = dr["IdVenta"] != DBNull.Value ? Convert.ToInt32(dr["IdVenta"]) : 0,
                                    IdProducto = dr["IdProducto"] != DBNull.Value ? Convert.ToInt32(dr["IdProducto"]) : 0,
                                    PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(dr["PrecioVenta"]) : 0m,
                                    Cantidad = dr["Cantidad"] != DBNull.Value ? Convert.ToInt32(dr["Cantidad"]) : 0,
                                    SubTotal = dr["SubTotal"] != DBNull.Value ? Convert.ToDecimal(dr["SubTotal"]) : 0m,
                                    FechaRegistro = dr["FechaRegistro"] != DBNull.Value ? dr["FechaRegistro"].ToString() : ""
                                });
                            }
                        }
                    }
                }
            }
            catch
            {
                // si querés loguear
                lista = new List<DetalleVenta>();
            }

            return lista;
        }

        public DataTable Listar()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, Descripcion, PrecioVenta, Stock, IdCategoria FROM PRODUCTO", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, Descripcion, PrecioVenta, Stock, IdCategoria FROM PRODUCTO WHERE Descripcion LIKE @nombre", con);
                da.SelectCommand.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ListarPorCategoria(int idCategoria)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT IdProducto, Descripcion, PrecioVenta, Stock, IdCategoria FROM PRODUCTO WHERE IdCategoria = @idCategoria", con);
                da.SelectCommand.Parameters.AddWithValue("@idCategoria", idCategoria);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
