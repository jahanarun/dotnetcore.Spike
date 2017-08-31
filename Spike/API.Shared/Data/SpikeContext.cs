using System;
using API.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace API.Shared.Data
{
    public class SpikeContext : DbContext, ISpikeContext
    {
        public SpikeContext(DbContextOptions<SpikeContext> options)
            : base(options)
        {
            
        }

        public DbSet<People> Peoples { get; set; }
    }
}
