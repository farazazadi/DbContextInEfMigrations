namespace DbContextInEfMigrations.Models;

public class User
{
    public int Id { get; private set; }

    public string FullName { get; init; }
    public string Password { get; private set; }

    public User(string fullName)
    {
        FullName = fullName;
    }


    public void SetPassword(string password)
        => Password = password;
}