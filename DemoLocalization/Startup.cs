using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLocalization.Extensions;
using DemoLocalization.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoLocalization
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
            services.AddControllersWithViews();

            services.ConfigureRequestLocalization();
            services.AddLocalization(); // 註冊Localization
            services.AddControllersWithViews()
                .AddViewLocalization() // 在View裡使用Localization
                .AddDataAnnotationsLocalization(options => { // 設定Model的Annotations Localization
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(Resources.SharedResource));
                });
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture=zh-TW}/{controller=Home}/{action=Index}/{id?}"); // 新增culture的路由，判斷多國語系
            });
        }
    }
}
