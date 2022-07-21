using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class PrayerRequestContext : DbContext
    {
    public DbSet<PrayerRequest> PrayerRequests {get; set; }
    public PrayerRequestContex.PrayerRequestContext(DbContextOptions<PrayerRequestContext> options)
        :base(options)
        {

        }

    }
}