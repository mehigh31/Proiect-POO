namespace ConsoleApp1;

public static class AuthenticationService
{
    private static List<User> Users = new List<User>();

    public static User? Login(string email, string password)
    {
        return Users.FirstOrDefault(user => user.Email == email && user.Password == password);
    }

    public static void Register(User user)
    {
        Users.Add(user);
    }

    public static void InitializeUsers()
    {
        Register(new Organizator(1, "Alex", "Popescu", "alex.popescu@evenimente.com", "1234"));
        Register(new Client(2, "Daniela", "Olaru", "danielaol@gmail.com", "daniela11"));
        Register(new Client(3, "Cristi", "Radu", "cristi32@gmail.com", "raducucris"));
        Register(new Client(4,"Ionut","Pop","ionut23@gmail.com","fanta23"));
    }
}