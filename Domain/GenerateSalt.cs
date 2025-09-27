using System.Security.Cryptography;
using System.Text;

namespace Domain.GenerateSalt
{
    public static class PasswordHelper
    {
        public static byte[] GenerateSalt(int size = 16)
        {
            var salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public static byte[] HashPassword(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var passwordWithSalt = passwordBytes.Concat(salt).ToArray();
                return sha256.ComputeHash(passwordWithSalt);
            }
        }
    }
}
