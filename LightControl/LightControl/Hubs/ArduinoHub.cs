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
            await Clients.All.SendAsync("ReceiveMessage", message);

            // _lightControl.SetData(newMessage);
        }
    }
}