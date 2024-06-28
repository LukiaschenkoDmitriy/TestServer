using System.Net;
using System.Net.Sockets;
using HelloWorldServer.HandleClient;

namespace HelloWorldServer;
public class Server(IHandleClient handleClient)
{
    private static readonly IPAddress IpAddress = IPAddress.Any;
    private const int Port = 34652;

    public void Start()
    {
        TcpListener listener = new TcpListener(IpAddress, Port);
        listener.Start();
        
        Console.WriteLine($"Сервер запущено на {IpAddress}:{Port}");
        Console.WriteLine(handleClient.GetDescription());

        while (true) handleClient.Execute(listener.AcceptTcpClient());
        
        // ReSharper disable once FunctionNeverReturns
    }
}