using Bogus;
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

        for (int i = 0; i < 4; i++)
        {
            _donorDbContext.Donors.Add(FakeDonor());
        }
        
        await _donorDbContext.SaveChangesAsync();
        
        _logger.LogInformation("Total donors: {Count}", _donorDbContext.Donors.Count());
    }

    private Faker<Donor> FakeDonor()
    {
        return new Faker<Donor>()
            .RuleFor(d => d.Name, f => f.Name.FullName())
            .RuleFor(d => d.PhoneNumber, f => f.Phone.PhoneNumber("###-###-####"));
    }
}