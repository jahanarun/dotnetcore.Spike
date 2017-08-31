using API.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Data
{
    public interface ISpikeContext
    {
        DbSet<People> Peoples { get; set; }
    }
}