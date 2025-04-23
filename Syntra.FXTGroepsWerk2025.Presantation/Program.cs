using OWN.GroupProject2.DataLayer;
using Syntra.FXTGroepsWerk2025.Logic.Books;
using Syntra.FXTGroepsWerk2025.Logic.Movies;
using Syntra.FXTGroepsWerk2025.Objects;
using Microsoft.AspNetCore.Identity;


namespace Syntra.FXTGroepsWerk2025.Presantation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IMovieService, MovieService>();
            builder.Services.AddTransient<IBookService, BookService>();
            builder.Services.AddTransient<MyContext>();

            builder.Services.AddDbContext<MyContext>();
            builder.Services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddEntityFrameworkStores<MyContext>();

            var app = builder.Build();


           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
