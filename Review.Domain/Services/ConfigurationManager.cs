using Microsoft.Extensions.Configuration;

namespace Review.Domain.Services
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting
        {
            get;
        }

        static ConfigurationManager()
        {
            var directory = Directory.GetCurrentDirectory();

            AppSetting = new ConfigurationBuilder().SetBasePath(directory)
                                                   .AddJsonFile("appsettings.json")
                                                   .Build();
        }
    }
}
