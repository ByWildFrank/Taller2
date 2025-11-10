using CapaDeDatos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace BeanDesktop.CapaDeDatos
{
    public class CD_Utilidades
    {
        public bool CrearBackup(string rutaArchivo, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_CrearBackup", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;

                    cmd.Parameters.AddWithValue("@RutaArchivo", rutaArchivo);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
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
        public DataTable ListarSegmentosConfig()
        {
            DataTable dt = new DataTable();
            // ✅ CAMBIO: El 'using' se encarga de la conexión
            using (SqlConnection cn = Conexion.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarSegmentosConfig", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Usamos un SqlDataAdapter que maneja el Open/Close
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt); // Llenamos la tabla
                }
                catch (Exception ex)
                {
                    // ✅ CAMBIO: Lanzamos el error para que el formulario lo vea
                    // En lugar de devolver una tabla vacía, le decimos al formulario QUÉ falló.
                    throw new Exception("Error al listar segmentos desde la base de datos: " + ex.Message);
                }
            }
            return dt; // Si todo fue bien, devuelve la tabla llena
        }

        public bool ActualizarSegmentoConfig(string segmento, decimal descuento, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_ActualizarSegmentoConfig", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Segmento", segmento);
                    cmd.Parameters.AddWithValue("@DescuentoPorcent", descuento);

                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // ✅ CAMBIO CLAVE:
                    // Con SET NOCOUNT ON, ExecuteNonQuery() devuelve -1 para éxito.
                    // Si devolviera 0, significa que no se encontró la fila.
                    if (filasAfectadas != 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        // Esto pasa si el WHERE Segmento = @Segmento no encontró nada
                        mensaje = "No se encontró el segmento para actualizar. No se aplicaron cambios.";
                        resultado = false;
                    }
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