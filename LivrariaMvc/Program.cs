using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LivrariaMvc.Data;
using LivrariaMvc.Services;
namespace LivrariaMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LivrariaMvcContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LivrariaMvcContext") ?? throw new InvalidOperationException("Connection string 'LivrariaMvcContext' not found.")));

            builder.Services.AddScoped<AutorService>();
            builder.Services.AddScoped<LivroService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
