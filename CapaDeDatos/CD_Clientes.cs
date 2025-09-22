using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeEntidades;

namespace CapaDeDatos
{
    public class CD_Clientes
    {
        private string connectionString = "Server=Franco-Laptop\\SQLEXPRESS;Database=DB_BEAN;Trusted_Connection=True;TrustServerCertificate=True;";

        // Listar todos los clientes
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado, FechaRegistro FROM Cliente";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Cliente()
                    {
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        Documento = dr["Documento"].ToString(),
                        NombreCompleto = dr["NombreCompleto"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        FechaRegistro = dr["FechaRegistro"].ToString()
                    });
                }
            }
            return lista;
        }

        // Registrar un cliente
        public int Registrar(Cliente obj, out string mensaje)
        {
            int idClienteGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);

                    SqlParameter outputId = new SqlParameter("@IdClienteResultado", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter outputMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputId);
                    cmd.Parameters.Add(outputMensaje);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idClienteGenerado = Convert.ToInt32(outputId.Value);
                    mensaje = outputMensaje.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClienteGenerado = 0;
                mensaje = ex.Message;
            }

            return idClienteGenerado;
        }

        // Editar un cliente
        public bool Editar(Cliente obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Cliente 
                                     SET Documento = @Documento, 
                                         NombreCompleto = @NombreCompleto, 
                                         Correo = @Correo, 
                                         Telefono = @Telefono, 
                                         Estado = @Estado
                                     WHERE IdCliente = @IdCliente";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);

                    cn.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;
        }

        // Eliminar un cliente
        public bool Eliminar(Cliente obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE IdCliente = @IdCliente", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);

                    cn.Open();
                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;
        }
    }
}
