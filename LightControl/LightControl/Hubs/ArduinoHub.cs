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
            Console.WriteLine("message : {0}", message);

            var defaults = _lightControl.GetData();
            Console.WriteLine("defaults : {0}", defaults);
            Console.WriteLine("message.colour : {0}", message.Colour);
            Console.WriteLine("defaults.colour : {0}", defaults?.Colour);

            var colour = message.Colour > 0
                ? message.Colour
                : defaults?.Colour > 0
                    ? defaults.Colour
                    : 0;
            
            Console.WriteLine("colour : {0}", colour);
            
            var newMessage = new LightControlUpdateModel
            {
                Pattern = message.Pattern ?? defaults?.Pattern ?? "twinkle",
                Colour = colour
            };
            Console.WriteLine("newMessage : {0}", newMessage);
            
            // Send `message` for the change
            // Send `newMessage` for the new config
            await Clients.All.SendAsync("ReceiveMessage", newMessage);

            _lightControl.SetData(newMessage);
        }
    }
}