namespace DbContextInEfMigrations.Models;

public class User
{
    public int Id { get; private set; }

    public string FullName { get; init; }

    public User(string fullName)
    {
        FullName = fullName;
    }
}