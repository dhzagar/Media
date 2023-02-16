using AccesoDatos;
using AccesoDatos.EntityFramework;
using Media.Data;
using Series.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Media
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SerieContext>(options => options.UseSqlite("DataSource=series.db"));

            builder.Services.AddScoped<ISeriesDatos, SeriesDatos>();
            builder.Services.AddScoped<ISeriesServices, SerieServices>();

            builder.Services.AddScoped<IActoresDatos, ActoresDatos>();
            builder.Services.AddScoped<IActoresServices, ActoresServices>();

            
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("DataSource=users.db"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>();
                        
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}