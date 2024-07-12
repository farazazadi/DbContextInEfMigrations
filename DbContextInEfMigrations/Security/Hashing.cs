using System.Security.Cryptography;
using System.Text;

namespace DbContextInEfMigrations.Security;

public static class Hashing
{
    private const string Salt = "M0?G£B@O3O)w6gIO_D].'eJ91u%8Dr87CxVd64Px*I9+L!rNd*";

    public static string GetHash(this string input)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(input, nameof(input));

        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(input + Salt));

        return Convert.ToHexString(hash);
    }
}