using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace FeedAggregaror
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options =>
                options.ValidateScopes = false)
                .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning))
                .UseStartup<Startup>();
    }
}
