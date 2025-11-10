using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CapaDeEntidades;

namespace CapaDeDatos
{
    public class CD_Clientes
    {

        // Listar todos los clientes
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection cn = Conexion.GetConnection())
            {
                // ✅ CAMBIO: Hacemos JOIN con la nueva tabla SEGMENTO_CONFIG
                string query = @"
            SELECT 
                c.IdCliente, c.Documento, c.NombreCompleto, c.Correo, 
                c.Telefono, c.Estado, c.FechaRegistro,
                ISNULL(cs.Segmento, 'Sin Datos') AS Segmento, 
                ISNULL(sc.DescuentoPorcent, 0) AS DescuentoPorcent
            FROM CLIENTE c
            LEFT JOIN CLIENTE_SEGMENTO cs ON c.IdCliente = cs.IdCliente
            LEFT JOIN SEGMENTO_CONFIG sc ON cs.Segmento = sc.Segmento";

                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
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
                            // ✅ Llenamos las propiedades (tu clase Cliente ya las tiene)
                            Segmento = dr["Segmento"].ToString(),
                            DescuentoPorcent = Convert.ToDecimal(dr["DescuentoPorcent"])
                        });
                    }
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
                using SqlConnection cn = Conexion.GetConnection();
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
                using (SqlConnection cn = Conexion.GetConnection())
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
                using (SqlConnection cn = Conexion.GetConnection())
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
        public Cliente ObtenerPorDocumento(string documento)
        {
            Cliente cliente = null;
            using (SqlConnection cn = Conexion.GetConnection())
            {
                string query = "SELECT IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado FROM Cliente WHERE Documento = @documento";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@documento", documento);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        cliente = new Cliente()
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            // ... Llenar las demás propiedades
                        };
                    }
                }
            }
            return cliente;
        }
    }
}
