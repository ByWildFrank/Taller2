using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeDatos;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Producto
    {
        private string connectionString ="Server=Franco-Laptop\\SQLEXPRESS;Database=DB_BEAN;Trusted_Connection=True;Encrypt=False;";

        private CD_Producto objProducto = new CD_Producto();

        // Listar todos los productos
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = @"SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, P.IdCategoria, 
                                        P.Stock, P.PrecioFabricacion, P.PrecioVenta, P.Estado, P.FechaRegistro,
                                        C.Descripcion AS CategoriaDescripcion
                                 FROM PRODUCTO P
                                 LEFT JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria";

                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

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
                        FechaRegistro = dr["FechaRegistro"].ToString(),
                        oCategoria = new Categoria
                        {
                            IdCategoria = dr["IdCategoria"] != DBNull.Value ? Convert.ToInt32(dr["IdCategoria"]) : 0,
                            Descripcion = dr["CategoriaDescripcion"].ToString()
                        }
                    });
                }
            }

            return lista;
        }

        // Guardar o actualizar producto
        public string Guardar(Producto obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd;
                    cn.Open();

                    if (obj.IdProducto == 0) // Insert
                    {
                        cmd = new SqlCommand(@"INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioFabricacion, PrecioVenta, Estado)
                                               VALUES (@Codigo, @Nombre, @Descripcion, @IdCategoria, @Stock, @PrecioFabricacion, @PrecioVenta, @Estado)", cn);
                    }
                    else // Update
                    {
                        cmd = new SqlCommand(@"UPDATE PRODUCTO SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion,
                                               IdCategoria=@IdCategoria, Stock=@Stock, PrecioFabricacion=@PrecioFabricacion, 
                                               PrecioVenta=@PrecioVenta, Estado=@Estado WHERE IdProducto=@IdProducto", cn);
                        cmd.Parameters.AddWithValue("@IdProducto", obj.IdProducto);
                    }

                    cmd.Parameters.AddWithValue("@Codigo", obj.codigo ?? "");
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre ?? "");
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@IdCategoria", obj.oCategoria?.IdCategoria ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Stock", obj.stock);
                    cmd.Parameters.AddWithValue("@PrecioFabricacion", obj.PrecioFabricacion);
                    cmd.Parameters.AddWithValue("@PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);

                    cmd.ExecuteNonQuery();
                }

                return "Producto guardado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Obtener producto por Id
        public Producto ObtenerPorId(int idProducto)
        {
            Producto obj = null;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = @"SELECT P.IdProducto, P.Codigo, P.Nombre, P.Descripcion, P.IdCategoria, 
                                        P.Stock, P.PrecioFabricacion, P.PrecioVenta, P.Estado, P.FechaRegistro,
                                        C.Descripcion AS CategoriaDescripcion
                                 FROM PRODUCTO P
                                 LEFT JOIN CATEGORIA C ON P.IdCategoria = C.IdCategoria
                                 WHERE P.IdProducto=@IdProducto";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj = new Producto
                    {
                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                        codigo = dr["Codigo"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        stock = Convert.ToInt32(dr["Stock"]),
                        PrecioFabricacion = Convert.ToDecimal(dr["PrecioFabricacion"]),
                        PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        FechaRegistro = dr["FechaRegistro"].ToString(),
                        oCategoria = new Categoria
                        {
                            IdCategoria = dr["IdCategoria"] != DBNull.Value ? Convert.ToInt32(dr["IdCategoria"]) : 0,
                            Descripcion = dr["CategoriaDescripcion"].ToString()
                        }
                    };
                }
            }

            return obj;
        }

        // Eliminar producto
        public string Eliminar(int idProducto)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM PRODUCTO WHERE IdProducto=@IdProducto", cn);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            return objProducto.BuscarPorNombre(nombre);
        }

        public DataTable ListarPorCategoria(int idCategoria)
        {
            return objProducto.ListarPorCategoria(idCategoria);
        }


    }
}
