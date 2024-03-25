using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Utility
{
    internal static class DatabaseConnectivity
    {
        private static IConfiguration _iconfiguration;

        static DatabaseConnectivity()
        {
            GetAppSettings();
        }

        public static void GetAppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
