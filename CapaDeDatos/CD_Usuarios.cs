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
                    string query = "select IdUsuario, Documento, NombreCompleto, Clave, Correo, IdRol, Estado, FechaRegistro FROM USUARIO";
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
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
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
    }
}
