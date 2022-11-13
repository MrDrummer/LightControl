using LightControl.Models;

namespace LightControl.Services;

public interface ILightControl
{
    LightControlUpdateModel SetData(LightControlUpdateModel newData);
    LightControlUpdateModel GetData();
}

public class LightControlService : ILightControl
{
    private LightControlUpdateModel data { get; set; }

    public LightControlUpdateModel GetData()
    {
        return data;
    }
    public LightControlUpdateModel SetData(LightControlUpdateModel newData)
    {
        return data = newData;
    }
}