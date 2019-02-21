using CommonModels.OptionsModels;
using DBRepository.Factories;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Groove.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Groove
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                                  {
                                      options.RequireHttpsMetadata = false;
                                      options.TokenValidationParameters = new TokenValidationParameters
                                                                          {
                                                                              ValidateIssuer = true,
                                                                              ValidIssuer = AuthOptions.ISSUER,
                                                                              ValidateAudience = true,
                                                                              ValidAudience = AuthOptions.AUDIENCE,
                                                                              ValidateLifetime = true,
                                                                              IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                                                                              ValidateIssuerSigningKey = true,
                                                                          };
                                  });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
            services.AddScoped<IIdentityRepository>(provider => new IdentityRepository(Configuration.GetConnectionString("DefaultConnection"), provider.GetService<IRepositoryContextFactory>()));
            services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/build");
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes => routes.MapRoute(
                           name: "default",
                           template: "{controller}/{action=Index}/{id?}"));

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
