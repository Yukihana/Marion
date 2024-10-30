using Microsoft.AspNetCore.Mvc;

namespace Marion.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class GreetingsController : ControllerBase
{
    [HttpGet]
    [ApiVersion("1.0")]
    public IActionResult GetV1()
    {
        return Ok("Hello, V1!");
    }

    [HttpGet]
    [ApiVersion("2.0")]
    public IActionResult GetV2()
    {
        return Ok("Hello, V2!");
    }
}