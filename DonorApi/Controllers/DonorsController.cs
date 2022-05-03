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
    public IEnumerable<DonorDto> GetAll()
    {
        _logger.LogInformation("Fetching donors...");
        var donors = _donorDbContext.Donors.Include(d => d.Designations).ToList();

        return _mapper.Map<List<DonorDto>>(donors);
    }

    [HttpGet("{id}")]
    public ActionResult<DonorDto> Get(int id)
    {
        var donor = _donorDbContext.Donors.Include(x=>x.Designations).FirstOrDefault(x => x.Id == id);
        if (donor == null)
        {
            return BadRequest("Invalid Donor");
        }

        return _mapper.Map<DonorDto>(donor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DonorDto>> Update(int id, DonorDto donorDto)
    {
        var donor = _donorDbContext.Donors.Include(x => x.Pledges).FirstOrDefault(x => x.Id == id);

        if (donor == null)
        {
            return BadRequest("Invalid Donor");
        }

        if (donorDto.Result == 3)
        {
            donor.Pledges.Add(new Pledge{ Amount = donorDto.Amount, Date = DateTimeOffset.UtcNow});
        }

        donor.CurrentDriveStatus = donorDto.Result;
        await _donorDbContext.SaveChangesAsync();

        return _mapper.Map<DonorDto>(donor);
    }
}
