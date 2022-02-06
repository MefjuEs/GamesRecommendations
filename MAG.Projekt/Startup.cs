using MAG.AppServices;
using MAG.Database;
using MAG.Identity;
using MAG.Projekt.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;

namespace MAG.Projekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appConfig = new AppConfig();
            ConfigurationBinder.Bind(this.Configuration, appConfig);

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/ClientApp";
            });

            #region GamesDatabase
            services.AddDbContext<GameDbContext>(options =>
            {
                options.UseSqlServer(appConfig.ConnectionStrings.GamesDatabase);
            });
            #endregion

            #region IdentityConfig
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(appConfig.ConnectionStrings.Identity);
            });

            services.AddIdentity<ApplicationUser, IdentityRole<long>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.SignIn.RequireConfirmedEmail = false;
            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();
            #endregion

            #region Services
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(x => {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            services.AddSingleton<IAppContext, WebAppContext>();
            this.AddAppConfigAccessor(services);
            #endregion
        }

        private void AddAppConfigAccessor(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSingleton(x =>
            {
                var config = x.GetRequiredService<IConfiguration>();
                var appConfig = new AppConfig();
                config.Bind(appConfig);
                return appConfig;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var appConfig = app.ApplicationServices.GetRequiredService<AppConfig>();

            if (env.IsDevelopment())
            {
                app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            }
            else
            {
                app.UseCors(options => options.WithOrigins(appConfig.Host.Url).AllowAnyHeader().AllowAnyOrigin());
            }

            app.UseDeveloperExceptionPage();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}