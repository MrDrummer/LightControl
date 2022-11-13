namespace LightControl.Models;

public class LightControlUpdateModel
{
    public string? pattern { get; set; }

    public int? colour { get; set; }
    
    public override string ToString()
    {
        return string.Format("{{ \"pattern\": \"{0}\", \"colour\": \"{1}\" }}", pattern, colour);
    }
}