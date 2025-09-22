using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop
{
    public static class Config
    {
        private static IConfigurationRoot configuration;

        static Config()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();
        }

        public static string GetConnectionString(string name = "DefaultConnection")
        {
            return configuration.GetConnectionString(name);
        }
    }
}