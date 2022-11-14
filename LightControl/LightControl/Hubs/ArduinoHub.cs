using LightControl.Models;
using LightControl.Services;
using Microsoft.AspNetCore.SignalR;

namespace LightControl.Hubs
{
    public class ArduinoHub : Hub
    {
        private readonly ILightControl _lightControl;
        private readonly SerialService _serial;

        public ArduinoHub(ILightControl lightControl, SerialService serial)
        {
            _lightControl = lightControl;
            _serial = serial;
        }
        
        public async Task SendMessage(LightControlUpdateModel message)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("message : {0}", message);

            var defaults = _lightControl.GetData();
            Console.WriteLine("defaults : {0}", defaults);

            var colour = message.Colour > 0
                ? message.Colour
                : defaults?.Colour > 0
                    ? defaults.Colour
                    : 0;
            
            Console.WriteLine("colour : {0}", colour);
            
            var newMessage = new LightControlUpdateModel
            {
                Pattern = message.Pattern ?? defaults?.Pattern ?? "twinkle",
                Colour = colour,
                Speed = message.Speed ?? defaults?.Speed
            };
            Console.WriteLine("newMessage : {0}", newMessage);
            
            // Send `message` for the change
            // Send `newMessage` for the new config
            await Clients.All.SendAsync("ReceiveMessage", newMessage);

            // TODO: Do data merge in SetData - send partial
            _lightControl.SetData(newMessage);
            _serial.SendData(new SerialModel
            {
                Colour = newMessage.Colour.ToString(),
                Pattern = newMessage.Pattern,
                Speed = newMessage.Speed.ToString()
            });
        }
    }
}