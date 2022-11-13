namespace LightControl.Models;

public class LightControlUpdateModel
{
    public string? Pattern { get; set; }

    public int? Colour { get; set; }
    
    public override string ToString()
    {
        return string.Format("{{ \"pattern\": \"{0}\", \"colour\": \"{1}\" }}", Pattern, Colour);
    }
}