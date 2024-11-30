using Microsoft.Extensions.Configuration;

namespace Reviews.Application.Helpers
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }

        static ConfigurationManager()
        {
            var directory = Directory.GetCurrentDirectory();

            AppSetting = new ConfigurationBuilder().SetBasePath(directory)
                                                   .AddJsonFile("appsettings.json")
                                                   .Build();
        }
    }
}
