using Microsoft.AspNetCore.Mvc;

namespace DonorApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DonorsController : ControllerBase
{
    private readonly ILogger<DonorsController> _logger;

    public DonorsController(ILogger<DonorsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IEnumerable<string> Get()
    {
        _logger.LogInformation("Hello World");
        return new List<string>{ "hello", "world" };
    }
}
