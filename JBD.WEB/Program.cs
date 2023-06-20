using AutoMapper;
using JBD.DATA;
using JBD.Service;
using JBD.Service.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Starterkit._keenthemes;
using Starterkit._keenthemes.libs;

namespace JBD.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();

            try
            {
                Log.Information("Starting web application");

                var builder = WebApplication.CreateBuilder(args);

                // Add AutoMapper
                builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

                // Add services to the container.
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                                       throw new InvalidOperationException(
                                           "Connection string 'DefaultConnection' not found.");

                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();

                builder.Services.AddMvc();

                builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
                    {
                        config.Password = new PasswordOptions
                        {
                            RequireDigit = false,
                            RequiredLength = 6,
                            RequiredUniqueChars = 0,
                            RequireLowercase = false,
                            RequireNonAlphanumeric = false,
                            RequireUppercase = false
                        };
                    })
                    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

                // Configure authentication services
                builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.Name = "YourCookieName";
                        options.LoginPath = "/";
                        options.LogoutPath = "/Account/Logout";
                        options.AccessDeniedPath = "/Account/AccessDenied";
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        options.SlidingExpiration = true;
                        options.Events.OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        };
                    });




                builder.Services.AddScoped<IUserRegistrationRepository, UserRegistrationRepository>();
                builder.Services.AddScoped<IProductRepository, ProductRepository>();
                builder.Services.AddScoped<IProductService, ProductService>();
                builder.Services.AddScoped<IImageStorageService, LocalStorageImageStorageService>();



                builder.Services.AddScoped<IKTTheme, KTTheme>();
                builder.Services.AddSingleton<IKTBootstrapBase, KTBootstrapBase>();

                IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonFile("themesettings.json")
                    .Build();

                KTThemeSettings.init(configuration);




                builder.Host.UseSerilog((ctx, lc) => lc
                    .WriteTo.Console());

                var app = builder.Build();
              
               // app.UseSerilogRequestLogging();
              
                // Configure AutoMapper
                var mapper = app.Services.GetRequiredService<IMapper>();
                mapper.ConfigurationProvider.AssertConfigurationIsValid();

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

                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                app.MapRazorPages();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}