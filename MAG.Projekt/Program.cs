using MAG.Database;
using MAG.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MAG.Projekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            var serviceProvider = webHost.Services.CreateScope().ServiceProvider;
            var identitySeeder = new Seeder(
                serviceProvider.GetService<UserManager<ApplicationUser>>(),
                serviceProvider.GetService<RoleManager<IdentityRole<long>>>(),
                serviceProvider.GetService<IdentityContext>());

            identitySeeder.Seed().Wait();
            GameSeeder.Seed(serviceProvider.GetService<GameDbContext>());

            webHost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
