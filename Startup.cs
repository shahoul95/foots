using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace foots
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
            services.AddSession();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            


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
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseDefaultFiles("/Images");
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "connexion",
                 pattern: "{controller=Connexion}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
               name: "profile",
              pattern: "{controller=Profile}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
              name: "deconnection",
             pattern: "{controller=Deconnection}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                 name: "inscription",
                 pattern: "{controller=Inscription}/{action=Index}/{id?}");


              endpoints.MapControllerRoute(
              name: "password",
              pattern: "{controller=Password}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
              name: "passchange",
              pattern: "{controller=Passchange}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
             name: "classement",
             pattern: "{controller=Classement}/{action=Index}/{id?}");

           
            });
        }
    }
}
