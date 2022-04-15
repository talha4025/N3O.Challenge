using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace N3O.Challenge.Web {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}