using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    class SpikeContextDesignFactory : IDesignTimeDbContextFactory<SpikeContext>
    {
        public SpikeContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<SpikeContext>();
            var connectionString = configuration.GetConnectionString("TempConnection");

            builder.UseNpgsql(connectionString);
            return new SpikeContext(builder.Options);

        }
    }
}
