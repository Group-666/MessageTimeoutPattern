using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using MessageTimeoutPattern.MessageBroker.Utilities;

namespace MessageTimeoutPattern.MessageBroker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MessageBrokerHost.Start();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
