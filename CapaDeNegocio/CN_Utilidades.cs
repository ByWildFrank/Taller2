using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeanDesktop.CapaDeDatos;
using CapaDeDatos;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Utilidades
    {
        private CD_Utilidades objCD_Utilidades = new CD_Utilidades();

        public bool CrearBackup(string rutaArchivo, out string mensaje)
        {
            return objCD_Utilidades.CrearBackup(rutaArchivo, out mensaje);
        }
        public string GenerarScript(bool incluirDatos)
        {
            try
            {
                var con = Conexion.GetConnection();
                ServerConnection serverConnection = new ServerConnection(con);
                Server server = new Server(serverConnection);
                Database db = server.Databases[con.Database];

                var sb = new StringBuilder();
                Scripter scripter = new Scripter(server);

                // --- Opciones de Scripting (versión moderna) ---
                scripter.Options.ScriptData = incluirDatos; // La opción principal
                scripter.Options.ScriptSchema = true;
                scripter.Options.ScriptDrops = false;
                scripter.Options.Indexes = true;
                scripter.Options.Triggers = true;
                scripter.Options.DriAll = true; // Incluir todas las dependencias (claves, etc.)
                // ❌ CAMBIO: Se elimina la opción obsoleta 'ScriptAnsiPadding'

                // ✅ CAMBIO: En lugar de "scriptear" uno por uno, creamos una lista de objetos
                var listaDeObjetos = new List<Urn>();

                // 1. Añadir todas las tablas de usuario a la lista
                foreach (Table tabla in db.Tables)
                {
                    if (!tabla.IsSystemObject)
                    {
                        listaDeObjetos.Add(tabla.Urn);
                    }
                }

                // 2. Añadir todos los Stored Procedures a la lista
                foreach (StoredProcedure sp in db.StoredProcedures)
                {
                    if (!sp.IsSystemObject)
                    {
                        listaDeObjetos.Add(sp.Urn);
                    }
                }
                // 3. (Opcional) Añadir las Vistas
                foreach (Microsoft.SqlServer.Management.Smo.View vista in db.Views)
                {
                    if (!vista.IsSystemObject)
                    {
                        listaDeObjetos.Add(vista.Urn);
                    }
                }

                // ✅ CAMBIO: Se llama al método scripter.Script() una sola vez con la lista completa
                var scriptCollection = scripter.Script(listaDeObjetos.ToArray());
                foreach (string linea in scriptCollection)
                {
                    sb.AppendLine(linea);
                    sb.AppendLine("GO");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                return $"-- ERROR AL GENERAR SCRIPT: \n-- {ex.Message}";
            }
        }
        public DataTable ListarSegmentosConfig()
        {
            return objCD_Utilidades.ListarSegmentosConfig(); // Asumiendo que objCD_Utilidades está instanciado
        }

        public bool ActualizarSegmentoConfig(string segmento, decimal descuento, out string mensaje) // ✅ CAMBIO: Añadir out string mensaje
        {
            mensaje = string.Empty; // Inicializamos

            // Tu regla de negocio (la cambié a 100% por si acaso)
            if (descuento < 0 || descuento > 100)
            {
                mensaje = "El descuento debe ser un porcentaje entre 0 y 100.";
                return false;
            }

            // ✅ CAMBIO: Pasamos la variable 'mensaje' a la capa de datos
            return objCD_Utilidades.ActualizarSegmentoConfig(segmento, descuento, out mensaje);
        }
    }
}