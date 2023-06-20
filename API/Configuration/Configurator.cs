using Microsoft.Extensions.Configuration;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace Core.Configuration
{
    public class Configuration
    {
        public static ApiConfiguration Api => BindConfiguration<ApiConfiguration>();
        private static IConfigurationRoot configurationRoot;

        static Configuration()
        {
            configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static T BindConfiguration<T>() where T : IConfiguration, new()
        {
            var config = new T();
            configurationRoot.GetSection(config.SectionName).Bind(config);
            return config;
        }

        public static string GetValue(string key)
        {
            return configurationRoot[key];
        }
    }
}
