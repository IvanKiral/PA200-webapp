using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace PA200_webapp.Utils;

public static class PasswordHash
{
    public static string MakePasswordHash(string password)
    {
        var salt = GenerateSalt(16);

        var bytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

        var saltConverted = Convert.ToBase64String(salt);

        return $"{ saltConverted }:{ Convert.ToBase64String(bytes) }";
    }
    
    private static byte[] GenerateSalt(int length)
    {
        var salt = new byte[length];

        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(salt);
        }

        return salt;
    }

    public static bool ComparePasswords(string password, string hashedPassword)
    {
        try
        {
            var parts = hashedPassword.Split(':');

            var salt = Convert.FromBase64String(parts[0]);

            var bytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

            var x = Convert.ToBase64String(bytes);

            return parts[1].Equals(x);
        }
        catch
        {
            return false;
        }            
    }
}