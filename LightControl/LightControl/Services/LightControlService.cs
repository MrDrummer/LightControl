using LightControl.Models;

namespace LightControl.Services;

public interface ILightControl
{
    LightControlUpdateModel SetData(LightControlUpdateModel newData);
    LightControlUpdateModel GetData();
}

public class LightControlService : ILightControl
{
    private LightControlUpdateModel _data { get; set; }

    public LightControlService()
    {
        _data = new()
        {
            Pattern = "solid",
            Colour = 0
        };
    }

    public LightControlUpdateModel GetData()
    {
        return _data;
    }
    public LightControlUpdateModel SetData(LightControlUpdateModel newData)
    {
        return _data = newData;
    }
}