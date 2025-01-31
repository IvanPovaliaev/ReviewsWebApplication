﻿namespace ReviewsWebApplication.Helpers
{
    public class JwtOptions
    {
        public string SecretKey { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public int ExpiresMinutes { get; init; }
    }
}
