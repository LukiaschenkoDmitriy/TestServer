using MessagePack;
using MessagePack.Formatters;
using HelloWorldServer.Object;

namespace HelloWorldServer.MessagePack.Formatter;
public class UserFormatter : IMessagePackFormatter<User>
{
    public void Serialize(ref MessagePackWriter writer, User value, MessagePackSerializerOptions option)
    {
        writer.Write(value.Username);
        writer.Write(value.Lastname);
        writer.Write(value.Password);
    }

    public User Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        string username = reader.ReadString();
        string lastname = reader.ReadString();
        string password = reader.ReadString();

        return new User(username, lastname, password);
    }
}