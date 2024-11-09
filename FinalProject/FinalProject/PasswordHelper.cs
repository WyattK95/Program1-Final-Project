using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public static class PasswordHelper
    {
        public static byte[] GenerateSalt(int size = 16)
        {
            byte[] salt = new byte[size];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        public static byte[] HashPassword(string password, byte[] salt, int iterations = 100000)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // Generate a 256-bit hash
            }
        }

        public static bool VerifyPassword(string enteredPassword, byte[] storedHash, byte[] storedSalt, int iterations = 100000)
        {
            byte[] hash = HashPassword(enteredPassword, storedSalt, iterations);
            // Use constant-time comparison to prevent timing attacks
            return CryptographicOperations.FixedTimeEquals(hash, storedHash);
        }
    }
}
