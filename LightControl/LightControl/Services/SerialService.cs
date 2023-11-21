using System.IO.Ports;
using LightControl.Models;

namespace LightControl.Services;


public interface ISerialService
{
    void SendData(SerialModel data);
}

public class SerialService : ISerialService, IDisposable
{
    private SerialPort _serialPort;

    public SerialService()
    {
        _serialPort = new SerialPort();
        _serialPort.PortName = "COM5";
        _serialPort.BaudRate = 9600;
        _serialPort.Open();
    }

    // TODO: Require SerialMessageType
    public void SendData(SerialModel data)
    {
        Console.WriteLine("Sending serial data : {0}", data);
        _serialPort.WriteLine($"{SerialMessageType.Pattern} {data.Pattern}");
        _serialPort.WriteLine($"{SerialMessageType.Colour} {data.Colour}");
        _serialPort.WriteLine($"{SerialMessageType.Speed} {data.Speed}");
    }

    public void Dispose()
    {
        _serialPort.Close();
        _serialPort.Dispose();
    }
}