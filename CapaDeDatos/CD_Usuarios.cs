using CapaDeEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaDeDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oconeccion = Conexion.GetConnection())

            {
                try
                {
                    string query = @"
    SELECT u.IdUsuario, u.Documento, u.NombreCompleto, u.Clave, u.Correo,
           u.IdRol, r.Descripcion AS RolDescripcion,
           u.Estado, u.FechaRegistro
    FROM USUARIO u
    INNER JOIN ROL r ON u.IdRol = r.IdRol";
                    SqlCommand cmd = new SqlCommand(query, oconeccion);
                    cmd.CommandType = CommandType.Text;
                    oconeccion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                oRol = new Rol()
                                {
                                    IdRol = Convert.ToInt32(dr["IdRol"]),
                                    Descripcion = dr["RolDescripcion"].ToString()
                                },
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }

                return lista;
            }
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int idUsuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconeccion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconeccion);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconeccion.Open();
                    cmd.ExecuteNonQuery();
                    idUsuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idUsuariogenerado = 0;
                Mensaje = ex.Message;
            }

            return idUsuariogenerado;
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconeccion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconeccion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconeccion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconeccion = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconeccion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconeccion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public Usuario ValidarUsuario(string documento, string clave)
        {
            Usuario usuario = null;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    // ✅ LA CORRECCIÓN: CAST(@clave AS VARCHAR(100))
                    string query = @"
                SELECT u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.IdRol, r.Descripcion as RolDescripcion, u.Estado 
                FROM USUARIO u
                INNER JOIN ROL r ON u.IdRol = r.IdRol
                WHERE u.Documento = @documento 
                AND u.Clave = HASHBYTES('SHA2_512', CAST(@clave AS VARCHAR(100)))"; // <-- ¡EL CAMBIO ESTÁ AQUÍ!

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@documento", documento);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["RolDescripcion"].ToString() }
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                usuario = null;
                // Aquí deberías loggear el 'ex.Message'
            }
            return usuario;
        }
    }
}