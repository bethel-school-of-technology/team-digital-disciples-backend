using WebApi.Helpers;
using WebApi.Services;
using WebApi.Data;
using WebApi.Repositories;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    //Adding DBContext DI
    builder.Services.AddDbContext<ApiContext>
    (opt => opt.UseSqlite("Data Source=" + Path.GetFullPath("PrayerDb")));
    builder.Services.AddSingleton<IPrayerResponseRepository, PrayerResponseRepository>();
    builder.Services.AddSingleton<IPrayerRequestRepository, PrayerRequestRepository>();
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.Run("http://localhost:4000");