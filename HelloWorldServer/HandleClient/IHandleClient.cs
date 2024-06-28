using System.Net.Sockets;

namespace HelloWorldServer.HandleClient;
public interface IHandleClient
{
    public void Execute(TcpClient client);
    public string GetDescription();
}