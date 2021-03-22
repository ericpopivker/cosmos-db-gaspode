using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Serilog;

using PandaTech.Infrastructure.Helpers;

namespace CosmosDbGaspode.Core
{
    public static class Config
    {
        public static CosmosDbOptions CosmosDbOptions =>
           new CosmosDbOptions
           {
                Account = "https://localhost:8081",
                Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                DatabaseName = "cosmos-db-gaspode",
                ContainerName = "Customers"
           };

        public static string TempDir
        {
            get { return _configuration.GetSection("TempDir").Value; }
        }

        public static string LogDir
        {
            get { return TempDir + "\\logs"; }
        }


        private static IConfiguration _configuration;
        public static void Setup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public static void WriteEnvInfoToLog()
        {
            Log.Information($"Environment: {EnvHelper.GetEnvironment().ToString()}");
        }
    };
}
