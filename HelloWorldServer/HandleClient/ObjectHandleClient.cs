using MessagePack;
using System.Net.Sockets;
using HelloWorldServer.Object;

namespace HelloWorldServer.HandleClient;
public class ObjectHandleClient: IHandleClient
{
    public void Execute(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        
        Console.WriteLine("Кліент підключений");
        
        User user = new User("Ivan", "Zozo", "123123");
        byte[] responseBuffer = MessagePackSerializer.Serialize(user);
        
        stream.Write(responseBuffer, 0, responseBuffer.Length);
        
        User dataReceived = MessagePackSerializer.Deserialize<User>(responseBuffer);
            
        Console.WriteLine($"Отримано: {dataReceived}");

        client.Close();
    }

    public string GetDescription()
    {
        return "Сервер налаштований на відправлення-отримання об'єктів";
    }
}