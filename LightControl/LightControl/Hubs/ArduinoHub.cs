using LightControl.Models;
using Microsoft.AspNetCore.SignalR;

namespace LightControl.Hubs
{
    public class ArduinoHub : Hub
    {
        public async Task SendMessage(LightControlUpdateModel message)
        {
            Console.WriteLine(message.pattern);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}