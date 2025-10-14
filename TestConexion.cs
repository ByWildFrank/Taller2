using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDeDatos
{
    public static class TestConexion
    {
        public static bool ProbarConexion()
        {
            try
            {
                using (SqlConnection cn = Conexion.GetConnection())
                {
                    cn.Open();
                    MessageBox.Show(
                        "✅ Conexión establecida correctamente.\nBase de datos: " + cn.Database,
                        "Conexión Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "❌ Error al conectar con la base de datos:\n\n" + ex.Message,
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}