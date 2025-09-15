using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace CapaDeDatos
{
    public static class Conexion
    {
        private static readonly string connectionString;

        static Conexion()
        {
            // Construye la configuración desde el appsettings.json en la carpeta del exe
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            // Obtiene la cadena de conexión
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        // Devuelve la conexión lista para usar
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
