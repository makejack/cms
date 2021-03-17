using System.IO;
using System.ComponentModel.Design;
using System.Text;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using www.veinid365.cn.Data;
using Microsoft.EntityFrameworkCore;
using www.veinid365.cn.Data.IRepositories;
using www.veinid365.cn.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using www.veinid365.cn.Configs;
using www.veinid365.cn.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using www.veinid365.cn.Fluid;
using Fluid;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace www.veinid365.cn
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
            services.AddDbContext<AppDatabase>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped(typeof(IRepositoryDefault<>), typeof(RepositoryDefault<>));
            services.AddSingleton(typeof(FluidProvider));
            services.AddSingleton(typeof(FluidParser));
            services.AddSingleton(typeof(RenderTagRegistering));
            services.AddSingleton(typeof(RequestViewBlockRegistering));
            services.AddSingleton(typeof(RequestListBlockRegistering));
            services.AddSingleton(typeof(RequestMenuBlockRegistering));

            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IEmailService, EmailService>();
            services.Configure<EmailConfig>(Configuration.GetSection(nameof(EmailConfig)));

            services.AddAutoMapper(typeof(Startup));

            var appSettings = new AppSettings();
            Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);
            services.AddSingleton(appSettings);

            var key = Encoding.UTF8.GetBytes(appSettings.Secret);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/admin"),
                ServeUnknownFileTypes = true,
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "admin"))
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapFallback(context =>
                {
                    if (context.Request.Path.StartsWithSegments("/admin", StringComparison.Ordinal))
                    {
                        context.Response.Redirect("/admin/index.html");
                    }

                    return Task.CompletedTask;
                });
            });
        }
    }
}
