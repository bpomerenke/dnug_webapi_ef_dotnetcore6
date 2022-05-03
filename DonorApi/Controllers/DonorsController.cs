using AutoMapper;
using DonorApi.Contracts;
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
    private readonly IMapper _mapper;

    public DonorsController(ILogger<DonorsController> logger, IDonorDbContext donorDbContext, IMapper mapper)
    {
        _logger = logger;
        _donorDbContext = donorDbContext;
        _mapper = mapper;
    }

    [HttpGet("")]
    public IEnumerable<DonorDto> Get()
    {
        _logger.LogInformation("Fetching donors...");
        var donors = _donorDbContext.Donors.Include(d => d.Designations).ToList();

        return _mapper.Map<List<DonorDto>>(donors);
    }
}
