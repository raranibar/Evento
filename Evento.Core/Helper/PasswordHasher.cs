using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Evento.Core.Helper
{
    public class PasswordHasher
    {
        private static int length = 24;
        private static int iterations = 1000;

        public static string GenerateSalt()
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return Convert.ToBase64String(bytes);
        }

        public static string GenerateHash(string password, string salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), iterations))
            {
                return Convert.ToBase64String(deriveBytes.GetBytes(length));
            }
        }
        public static bool ValidatePassword(string password, string correctHash, string correctSalt)
        {
            var salt = Convert.FromBase64String(correctSalt);
            var hash = Convert.FromBase64String(correctHash);

            var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
        private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        public static string GenerarPassword(int longitud)
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int lonCaracteres = caracteres.Length;
            char letra;
           
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitud; i++)
            {
                letra = caracteres[rdn.Next(lonCaracteres)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }
    }
}
