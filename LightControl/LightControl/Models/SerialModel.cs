namespace LightControl.Models;

public class SerialModel
{
    public string? Pattern { get; set; }
    public string? Colour { get; set; }
    public string? Speed { get; set; }
    
    public override string ToString()
    {
        return string.Format("{{ \"pattern\": \"{0}\", \"colour\": \"{1}\", \"speed\": \"{2}\" }}", Pattern, Colour, Speed);
    }
}

public enum SerialMessageType {
    Pattern,
    Colour,
    Speed
}


