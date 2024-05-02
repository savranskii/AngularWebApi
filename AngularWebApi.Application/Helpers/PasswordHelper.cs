using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AngularWebApi.Application.Helpers;

public static class PasswordHelper
{
    public static string SaltPassword(string password, string salt)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            Encoding.ASCII.GetBytes(salt),
            KeyDerivationPrf.HMACSHA256,
            100000,
            256 / 8));
    }
}