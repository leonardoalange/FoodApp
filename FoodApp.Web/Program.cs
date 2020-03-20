using FoodApp.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HBSIS.Padawan.Web
{
    public class Program
    {
        protected Program()
        {

        }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
