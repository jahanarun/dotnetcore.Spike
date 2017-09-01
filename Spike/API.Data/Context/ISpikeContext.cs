using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public interface ISpikeContext
    {
        DbSet<People> Peoples { get; set; }
    }
}