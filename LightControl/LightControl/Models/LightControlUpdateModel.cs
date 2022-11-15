using System.Text.Json.Serialization;

namespace LightControl.Models;

public class LightControlUpdateModel
{
    [JsonPropertyName("pattern")]
    public string? Pattern { get; set; }

    [JsonPropertyName("colour")]
    public int? Colour { get; set; }
    
    [JsonPropertyName("speed")]
    public int? Speed { get; set; }
    
    public override string ToString()
    {
        return string.Format("{{ \"pattern\": \"{0}\", \"colour\": \"{1}\" }}", Pattern, Colour);
    }
}