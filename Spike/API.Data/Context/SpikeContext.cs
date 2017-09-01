using System;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace API.Data.Context
{
    public class SpikeContext : DbContext, ISpikeContext
    {
        public SpikeContext(DbContextOptions<SpikeContext> options)
            : base(options)
        {
            
        }

        public DbSet<People> Peoples { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("User Id=dev;Password=dev;Host=localhost;Port=5432;Database=postgres;Pooling=true");
        //    //base.OnConfiguring(optionsBuilder);
        //}
    }
}
