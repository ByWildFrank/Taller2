using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeEntidades;
using System.Collections.Generic;

namespace CapaDeDatos
{
    public class CD_Producto
    {
        // El método Listar debe devolver List<Producto>, no DataTable
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    string query = @"SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, 
                                        P.IdCategoria, C.Descripcion AS CategoriaDescripcion, P.Stock, 
                                        P.PrecioFabricacion, P.PrecioVenta, P.Estado
                                    FROM PRODUCTO P
                                    LEFT JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                stock = Convert.ToInt32(dr["Stock"]),
                                PrecioFabricacion = Convert.ToDecimal(dr["PrecioFabricacion"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = dr["IdCategoria"] != DBNull.Value ? Convert.ToInt32(dr["IdCategoria"]) : 0,
                                    Descripcion = dr["CategoriaDescripcion"].ToString()
                                }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar error
                }
            }
            return lista;
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            int idProductoGenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Stock", obj.stock);
                    cmd.Parameters.AddWithValue("@PrecioFabricacion", obj.PrecioFabricacion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.Add("@IdProductoResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["@IdProductoResultado"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) { mensaje = ex.Message; }
            return idProductoGenerado;
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("@Codigo", obj.codigo);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@Stock", obj.stock);
                    cmd.Parameters.AddWithValue("@PrecioFabricacion", obj.PrecioFabricacion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.Add("@Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Respuesta"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) { resultado = false; mensaje = ex.Message; }
            return resultado;
        }

        public bool Eliminar(int idProducto, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Parameters.Add("@Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Respuesta"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex) { resultado = false; mensaje = ex.Message; }
            return resultado;
        }
    }
}