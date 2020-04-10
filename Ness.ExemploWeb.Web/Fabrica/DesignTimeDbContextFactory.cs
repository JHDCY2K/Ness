using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ness.ExemploWeb.Dados;

namespace Ness.ExemploWeb.Web
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContextoExemploNess>
    {
        public ContextoExemploNess CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ContextoExemploNess>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new ContextoExemploNess(builder.Options);
        }
    }
}
