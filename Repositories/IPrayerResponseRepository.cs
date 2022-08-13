using WebApi.Models;

namespace WebApi.Repositories;

public interface IPrayerResponseRepository 
{
    void AddPrayerResponse (PrayerResponse prayerResponse);

    List<CombinedResponse> GetCombinedResponse(int userId);
}