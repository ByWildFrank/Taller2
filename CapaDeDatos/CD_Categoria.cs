using CapaDeEntidades;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CapaDeDatos
{
    public class CD_Categoria
    {
        // Cadena de conexión corregida: confiamos en el certificado local
        private string connectionString = "Server=Franco-Laptop\\SQLEXPRESS;Database=DB_BEAN;Trusted_Connection=True;Encrypt=False;";

        // Listar todas las categorías
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdCategoria, Descripcion, Estado, FechaRegistro FROM Categoria";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Categoria
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        FechaRegistro = dr["FechaRegistro"].ToString()
                    });
                }
            }

            return lista;
        }

        // Obtener una categoría por Id
        public Categoria ObtenerPorId(int idCategoria)
        {
            Categoria oCategoria = null;

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdCategoria, Descripcion, Estado, FechaRegistro FROM Categoria WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Id", idCategoria);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    oCategoria = new Categoria
                    {
                        IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                        Descripcion = dr["Descripcion"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        FechaRegistro = dr["FechaRegistro"].ToString()
                    };
                }
            }

            return oCategoria;
        }

        // Insertar una nueva categoría
        public string Insertar(Categoria oCategoria)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Categoria (Descripcion, Estado, FechaRegistro) VALUES (@Descripcion, @Estado, @FechaRegistro)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Descripcion", oCategoria.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", oCategoria.Estado);
                cmd.Parameters.AddWithValue("@FechaRegistro", oCategoria.FechaRegistro);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Categoría registrada correctamente";
        }

        // Actualizar una categoría existente
        public string Actualizar(Categoria oCategoria)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Categoria SET Descripcion = @Descripcion, Estado = @Estado, FechaRegistro = @FechaRegistro WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Descripcion", oCategoria.Descripcion);
                cmd.Parameters.AddWithValue("@Estado", oCategoria.Estado);
                cmd.Parameters.AddWithValue("@FechaRegistro", oCategoria.FechaRegistro);
                cmd.Parameters.AddWithValue("@Id", oCategoria.IdCategoria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Categoría actualizada correctamente";
        }

        // Eliminar una categoría
        public string Eliminar(int idCategoria)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Categoria WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Id", idCategoria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            return "Categoría eliminada correctamente";
        }
    }
}
