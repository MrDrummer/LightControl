using LightControl.Models;
using LightControl.Services;
using Microsoft.AspNetCore.Mvc;
namespace LightControl.Controllers;

[ApiController]
[Route("[controller]")]
public class LightControlController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ILightControl _lightControl;

    public LightControlController(ILogger<WeatherForecastController> logger, ILightControl lightControl)
    {
        _logger = logger;
        _lightControl = lightControl;
    }

    [HttpGet]
    public LightControlUpdateModel Get()
    {
        return _lightControl.GetData();
    }
}