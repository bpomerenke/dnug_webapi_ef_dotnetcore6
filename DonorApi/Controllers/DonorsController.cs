using DonorApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DonorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DonorsController : ControllerBase
{
    private readonly ILogger<DonorsController> _logger;
    private readonly IDonorDbContext _donorDbContext;

    public DonorsController(ILogger<DonorsController> logger, IDonorDbContext donorDbContext)
    {
        _logger = logger;
        _donorDbContext = donorDbContext;
    }

    [HttpGet("")]
    public IEnumerable<Donor> Get()
    {
        _logger.LogInformation("Fetching donors...");
        return _donorDbContext.Donors.Include(d => d.Designations).ToList();
    }
}
