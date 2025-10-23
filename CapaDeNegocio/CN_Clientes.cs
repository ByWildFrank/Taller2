using CapaDeEntidades;
using CapaDeDatos;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Cliente
    {
        private CD_Clientes objCD = new CD_Clientes();

        public List<Cliente> Listar()
        {
            return objCD.Listar();
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                mensaje = "El documento es obligatorio";
                return 0;
            }
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                mensaje = "El nombre completo es obligatorio";
                return 0;
            }
            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo es obligatorio";
                return 0;
            }

            return objCD.Registrar(obj, out mensaje);
        }

        public bool Editar(Cliente obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("@Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("@NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.Add("@Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Respuesta"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(Cliente obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.Parameters.Add("@Respuesta", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Respuesta"].Value);
                    mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
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
            return objCD.ObtenerPorDocumento(documento);
        }
        public List<Cliente> ListarActivos()
        {
            return new CD_Clientes().Listar().Where(c => c.Estado == true).ToList();
        }
    }
}
