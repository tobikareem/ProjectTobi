using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ProjectTobi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                 {
                     // clear all host
                     config.Sources.Clear();

                     // get the environment names
                     var env = hostContext.HostingEnvironment;

                     // set up the json files to be overwritten calls
                     config.AddJsonFile("appsettings.json", true, true);
                     config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                     // add environment variables
                     config.AddEnvironmentVariables();

                     // add command line configuration if argument is not null
                     if (args != null)
                     {
                         config.AddCommandLine(args);
                     }
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
