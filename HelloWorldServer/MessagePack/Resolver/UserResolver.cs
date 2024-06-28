using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

using HelloWorldServer.Object;
using HelloWorldServer.MessagePack.Formatter;

namespace HelloWorldServer.MessagePack.Resolver;
public class UserResolver : IFormatterResolver
{
    public IMessagePackFormatter<T> GetFormatter<T>()
    {
        if (typeof(T) == typeof(User))
        {
            return new UserFormatter() as IMessagePackFormatter<T>;
        }

        return StandardResolver.Instance.GetFormatter<T>();
    }
}