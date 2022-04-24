using Microsoft.EntityFrameworkCore;

namespace DonorApi.Models;

public interface IDonorDbContext
{
    
}
public class DonorDbContext : DbContext, IDonorDbContext
{
    public DonorDbContext(DbContextOptions<DonorDbContext> options) : base(options)
    {
        
    }
}