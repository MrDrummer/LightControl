using System.IO.Ports;
using LightControl.Models;

namespace LightControl.Services;


public interface ISerialService
{
    SerialModel SendData(SerialModel data);
}

public class SerialService : ISerialService
{
    static SerialPort _serialPort;

    public SerialService()
    {
        _serialPort = new SerialPort();
        _serialPort.PortName = "COM3";
        _serialPort.BaudRate = 9600;
        _serialPort.Open();
    }

    // TODO: Require SerialMessageType
    public SerialModel SendData(SerialModel data)
    {
        _serialPort.WriteLine($"{SerialMessageType.Pattern} {data.Pattern}");
        _serialPort.WriteLine($"{SerialMessageType.Colour} {data.Colour}");
        _serialPort.WriteLine($"{SerialMessageType.Speed} {data.Speed}");
    }
}