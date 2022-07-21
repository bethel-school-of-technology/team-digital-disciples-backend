using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApiContext : DbContext
    {
    public DbSet<PrayerResponse> PrayerResponses {get; set; }
    public DbSet<PrayerRequest> PrayerRequests {get; set;}
    public DbSet<User> Users {get; set;}
    public ApiContext(DbContextOptions<ApiContext> options)
        :base(options)
        {

        }

    }
}