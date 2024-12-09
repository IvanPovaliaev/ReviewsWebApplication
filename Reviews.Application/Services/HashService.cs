﻿using Konscious.Security.Cryptography;
using Reviews.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Reviews.Application.Services
{
    /// <summary>
    /// Service used to work with hash based on the Argon2 algorithm
    /// </summary>
    public class HashService : IHashService
    {
        private const int ActiveCores = 2;
        private const int ActiveMemorySize = 1024 * 16;
        private const int IterationsNumber = 4;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        /// <summary>
        /// Generates a hash for input size with target or random salt
        /// </summary>
        /// <returns>hash string</returns>
        /// <param name="input">Target string</param>
        /// <param name="inputSalt">Target salt</param>
        public string GenerateHash(string input, byte[]? inputSalt = null)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var salt = inputSalt ?? GenerateSalt(SaltSize);

            var argon2 = new Argon2id(inputBytes)
            {
                Salt = salt,
                DegreeOfParallelism = ActiveCores,
                MemorySize = ActiveMemorySize,
                Iterations = IterationsNumber
            };

            var hash = argon2.GetBytes(HashSize);
            var hashString = Convert.ToBase64String(hash);
            var saltString = Convert.ToBase64String(salt);

            var hashWithSalt = $"{hashString}:{saltString}";

            return hashWithSalt;
        }

        /// <summary>
        /// Checks if the target string matches the target hash.
        /// </summary>
        /// <returns>true if matched; otherwise false </returns>
        /// <param name="input">Target string</param>
        /// <param name="hash">Target hash</param>
        public bool IsEquals(string input, string hash)
        {
            var salt = Convert.FromBase64String(hash.Split(':')[1]);
            var inputHash = GenerateHash(input, salt);

            return inputHash.Equals(hash);
        }

        /// <summary>
        /// Generates a random salt
        /// </summary>
        /// <returns>byte array for salt</returns>
        /// <param name="size">Target salt size in bytes</param>
        private byte[] GenerateSalt(int size)
        {
            var salt = new byte[size];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }
    }
}
