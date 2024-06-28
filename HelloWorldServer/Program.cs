using HelloWorldServer.HandleClient;

namespace HelloWorldServer
{
    internal static class Program
    {
        public static void Main()
        {
            Server server = new Server(new ObjectHandleClient());
            server.Start();
        }
    }
}