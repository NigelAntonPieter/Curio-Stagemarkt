using Microsoft.EntityFrameworkCore;
using ProtoType_Stagemarkt.Models;
using System;

namespace ProtoType_Stagemarkt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            using var db = new Appdbcontext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<Appdbcontext>();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
