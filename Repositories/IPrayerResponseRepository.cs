using WebApi.Models;

namespace WebApi.Repositories;

public interface IPrayerResponseRepository 
{
    IEnumerable<PrayerResponse> GetInbox(int OpId);

    void AddPrayerResponse (PrayerResponse prayerResponse);

    List<CombinedResponse> GetCombinedResponse(int userId);
}