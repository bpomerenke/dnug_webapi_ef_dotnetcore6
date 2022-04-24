using DonorApi.Models;
using Microsoft.Extensions.Logging;

namespace DataLoader;

public interface IDataLoader
{
    Task Load();
}
public class DataLoader : IDataLoader
{
    private readonly ILogger<DataLoader> _logger;
    private readonly IDonorDbContext _donorDbContext;

    public DataLoader(ILogger<DataLoader> logger, IDonorDbContext donorDbContext)
    {
        _logger = logger;
        _donorDbContext = donorDbContext;
    }
    public async Task Load()
    {
        _logger.LogInformation("Loading Data...");

        _donorDbContext.Donors.Add(new Donor
        {
            Name = "Billy Jean",
            PhoneNumber = "222-222-2222"
        });
        
        await _donorDbContext.SaveChangesAsync();
    }
}