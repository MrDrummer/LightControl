using LightControl.Models;
using LightControl.Services;
using Microsoft.AspNetCore.SignalR;

namespace LightControl.Hubs
{
    public class ArduinoHub : Hub
    {
        private readonly ILightControl _lightControl;

        public ArduinoHub(ILightControl lightControl)
        {
            _lightControl = lightControl;
        }
        
        public async Task SendMessage(LightControlUpdateModel message)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Pattern : {0}", message.pattern);
            Console.WriteLine("Colour : {0}", message.colour);

            LightControlUpdateModel defaults = _lightControl.GetData();

            int colour = message.colour > 0 ? message.colour : defaults.colour;
            
            LightControlUpdateModel newMessage = new LightControlUpdateModel
            {
                pattern = message.pattern ?? defaults.pattern ?? "twinkle",
                colour = colour
            };
            // Console.WriteLine("defaults : {0}", defaults);
            Console.WriteLine("newMessage : {0}", newMessage);
            
            // Send `message` for the change
            // Send `newMessage` for the new config
            await Clients.All.SendAsync("ReceiveMessage", message);

            _lightControl.SetData(newMessage);
        }
    }
}