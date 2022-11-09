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
            Console.WriteLine(message.pattern);
            await Clients.All.SendAsync("ReceiveMessage", message);

            _lightControl.SetData(message);
        }
    }
}