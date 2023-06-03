using e_Book.Data;
//using eTickets.Data.Cart;
//using eTickets.Data.Services;
using e_Book.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_Book.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Sockets;
using e_Book.Data.Services;
using e_Book.Data;
using e_Book.Data.Cart;
using Microsoft.Data.SqlClient;

namespace e_Book
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
            services.AddSession();
            services.AddDataProtection();
            services.AddDistributedMemoryCache();
            services.AddControllers();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddDbContext<AppDbContext>(options => {
            options.UseSqlServer(Configuration.GetConnectionString("Data Source=NAFIJE-PC\\SQLEXPRESS;Initial Catalog=movie-ticket;Integrated Security=True;Pooling=False; trustServerCertificate=true"));
            }, ServiceLifetime.Scoped);
            services.AddScoped<DbContextOptions<AppDbContext>>();
            services.AddScoped<AppDbContext>();
            //Services configuration
            services.AddScoped<AppDbInitializzer>();
            services.AddScoped<IAuthorsService, AuthorsService>();
            services.AddScoped<IPublishing_houseService, Publishing_houseService>();
            services.AddScoped<IbookService, BookService>();
            services.AddScoped<IOrdersServices, OrdersService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sc=>ShopingCart.GetShopingCart(sc));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication();
            services.AddControllersWithViews();

        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbInitializzer appDbInitializzer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Books}/{action=Index}/{id?}");
        });
        }

    }
}
