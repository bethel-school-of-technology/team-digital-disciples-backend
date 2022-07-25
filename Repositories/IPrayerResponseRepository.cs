using WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Repositories;

public interface IPrayerResponseRepository 
{
    IEnumerable<PrayerResponse> GetInbox(int OpId);

    void AddPrayerResponse (PrayerResponse prayerResponse);
}