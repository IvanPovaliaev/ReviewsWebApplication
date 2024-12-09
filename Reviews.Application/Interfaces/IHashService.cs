namespace Reviews.Application.Interfaces
{
    public interface IHashService
    {
        /// <summary>
        /// Generates a hash for input size with target or random salt
        /// </summary>
        /// <returns>hash string</returns>
        /// <param name="input">Target string</param>
        /// <param name="inputSalt">Target salt</param>
        string GenerateHash(string input, byte[]? inputSalt = null);

        /// <summary>
        /// Checks if the target string matches the target hash.
        /// </summary>
        /// <returns>true if matched; otherwise false </returns>
        /// <param name="input">Target string</param>
        /// <param name="hash">Target hash</param>
        bool IsEquals(string input, string hash);
    }
}
