using MessagePack;

namespace HelloWorldServer.Object;
[MessagePackObject]
public class User(string username, string lastname, string password)
{
    [Key(0)]
    private string _username = username;
    [Key(1)]
    private string _lastname = lastname;
    [Key(2)]
    private string _password = password;

    [Key(0)]
    public string Username
    {
        get => _username;
        set => _username = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    [Key(1)]
    public string Lastname
    {
        get => _lastname;
        set => _lastname = value ?? throw new ArgumentNullException(nameof(value));
    }

    [Key(2)]
    public string Password
    {
        get => _password;
        set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return $"{nameof(_username)}: {_username}, {nameof(_lastname)}: {_lastname},  {nameof(_password)}: {_password}";
    }
}