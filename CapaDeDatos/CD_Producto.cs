using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeEntidades;

namespace CapaDeDatos
{
    public class CD_Producto
    {

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                string query = @"SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, 
                                        P.IdCategoria, P.Stock, P.PrecioFabricacion, 
                                        P.PrecioVenta, P.Estado, P.FechaRegistro,
                                        C.Descripcion AS CategoriaDescripcion
                                 FROM PRODUCTO P
                                 LEFT JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                string query = @"SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, 
                                        P.IdCategoria, P.Stock, P.PrecioFabricacion, 
                                        P.PrecioVenta, P.Estado, P.FechaRegistro,
                                        C.Descripcion AS CategoriaDescripcion
                                 FROM PRODUCTO P
                                 LEFT JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria
                                 WHERE P.Nombre LIKE @nombre";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ListarPorCategoria(int idCategoria)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                string query = @"SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, 
                                        P.IdCategoria, P.Stock, P.PrecioFabricacion, 
                                        P.PrecioVenta, P.Estado, P.FechaRegistro,
                                        C.Descripcion AS CategoriaDescripcion
                                 FROM PRODUCTO P
                                 LEFT JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria
                                 WHERE P.IdCategoria = @idCategoria";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@idCategoria", idCategoria);
                da.Fill(dt);
            }
            return dt;
        }

        public bool Insertar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    string query = @"INSERT INTO PRODUCTO(Codigo, Nombre, Descripcion, IdCategoria, Stock, 
                                                        PrecioFabricacion, PrecioVenta, Estado, FechaRegistro)
                                     VALUES(@Codigo, @Nombre, @Descripcion, @IdCategoria, @Stock, 
                                            @PrecioFabricacion, @PrecioVenta, @Estado, GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Stock", obj.stock);
                    cmd.Parameters.AddWithValue("@PrecioFabricacion", obj.PrecioFabricacion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);

                    cn.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                resultado = false;
            }

            return resultado;
        }

        public bool Actualizar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    string query = @"UPDATE PRODUCTO
                                     SET Codigo = @Codigo,
                                         Nombre = @Nombre,
                                         Descripcion = @Descripcion,
                                         IdCategoria = @IdCategoria,
                                         Stock = @Stock,
                                         PrecioFabricacion = @PrecioFabricacion,
                                         PrecioVenta = @PrecioVenta,
                                         Estado = @Estado
                                     WHERE IdProducto = @IdProducto";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("@Codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Stock", obj.stock);
                    cmd.Parameters.AddWithValue("@PrecioFabricacion", obj.PrecioFabricacion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);

                    cn.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                resultado = false;
            }

            return resultado;
        }

        public bool Eliminar(int idProducto, out string mensaje)
        {
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    string query = @"DELETE FROM PRODUCTO WHERE IdProducto = @IdProducto";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    cn.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                resultado = false;
            }

            return resultado;
        }
    }
}
