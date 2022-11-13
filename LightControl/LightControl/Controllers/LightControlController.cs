using LightControl.Models;
using LightControl.Services;
using Microsoft.AspNetCore.Mvc;
namespace LightControl.Controllers;

[ApiController]
[Route("[controller]")]
public class LightControlController : ControllerBase
{

    private readonly ILightControl _lightControl;

    public LightControlController(ILightControl lightControl)
    {
        _lightControl = lightControl;
    }

    [HttpGet]
    public LightControlUpdateModel Get()
    {
        return _lightControl.GetData();
    }
}