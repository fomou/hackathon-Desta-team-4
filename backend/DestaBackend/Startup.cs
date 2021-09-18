using DestaNationConnect.DataAccessLayer;
using DestaNationConnect.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure DB
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("DestaNationConnectDatabase");

            services.AddDbContext<DestaNationConnectContext>(options => options.UseSqlServer(connectionString));

            services.AddControllers();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DestaNationConnect.API", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddCors();

            services.AddSignalR();

            services.AddAuthentication(auth =>
            {
                auth.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = _env.IsProduction();
                jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.GetIssuer(),
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.GetAudience(),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateLifetime = true
                    };
            })
            .AddFacebook(fb =>
            {
                IConfigurationSection settings = Configuration.GetSection("Authentication:Facebook");
                fb.AppId = settings["AppId"];
                fb.AppSecret = settings["AppSecret"];
                fb.SaveTokens = true;
            })
            .AddGoogle(gg =>
                {
                    IConfigurationSection settings = Configuration.GetSection("Authentication:Google");
                    gg.ClientId = settings["ClientId"];
                    gg.ClientSecret = settings["ClientSecret"];
                    gg.SaveTokens = true;
            })
            .AddMicrosoftAccount(ms =>
            {
                IConfigurationSection settings = Configuration.GetSection("Authentication:Microsoft");
                ms.ClientId = settings["ClientId"];
                ms.ClientSecret = settings["ClientSecret"];
                ms.SaveTokens = true;
            })
            .AddApple(apl =>
            {
                IConfigurationSection settings = Configuration.GetSection("Authentication:Apple");
                apl.ClientId = settings["ClientId"];
                apl.KeyId = settings["KeyId"];
                apl.TeamId = settings["TeamId"];
                apl.UsePrivateKey(keyId
                    => _env.ContentRootFileProvider.GetFileInfo($"AuthKey_{keyId}.p8"));
                apl.SaveTokens = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DestaNationConnect v1"));
            }

            app.ApplyMigration<DestaNationConnectContext>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
