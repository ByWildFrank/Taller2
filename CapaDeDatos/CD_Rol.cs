using BeanDesktop.CapaDeEntidades;
using CapaDeDatos;
using CapaDeEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oconeccion = Conexion.GetConnection())

            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol, Descripcion FROM ROL");
            


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconeccion);
                    cmd.CommandType = CommandType.Text;

                    oconeccion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();
                }

                return lista;
            }
        }
    }
}
