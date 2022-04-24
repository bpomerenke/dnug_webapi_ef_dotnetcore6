using Microsoft.EntityFrameworkCore;

namespace DonorApi.Models;

public interface IDonorDbContext
{
    DbSet<Donor> Donors { get; set; }
}
public class DonorDbContext : DbContext, IDonorDbContext
{
    public DonorDbContext(DbContextOptions<DonorDbContext> options) : base(options)
    {
        
    }
    
    public virtual DbSet<Donor> Donors { get; set; }
}