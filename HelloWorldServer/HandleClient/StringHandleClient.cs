using System.Text;
using System.Net.Sockets;

namespace HelloWorldServer.HandleClient;

public class StringHandleClient: IHandleClient
{
    public void Execute(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
    
        Console.WriteLine("Клієнт підключений");

        byte[] buffer = new byte[client.ReceiveBufferSize];
        StringBuilder dataReceived = new StringBuilder();

        int bytesRead;
        do
        {
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            dataReceived.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
        } while (!dataReceived.ToString().EndsWith("\r\n"));

        string receivedString = dataReceived.ToString().TrimEnd('\r', '\n');
        Console.WriteLine($"Отримано: {receivedString}");
        
        string responseMessage = "Hello. It's me! Linux Server!";
        byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
        stream.Write(responseBuffer, 0, responseBuffer.Length);

        client.Close();
    }


    public string GetDescription()
    {
        return "Сервер налаштований на відправлення-отримання повідомлень типу 'string'";
    }
}