using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class PrayerResponseRepository : IPrayerResponseRepository
{
    private readonly ApiContext _context;

    public PrayerResponseRepository (ApiContext context)
    {
        _context = context;
    }

     public void AddPrayerResponse(PrayerResponse prayerResponse)
    {
        if(prayerResponse.responseId == 0)
            {
                _context.PrayerResponses.Add(prayerResponse);
            }
            _context.SaveChanges();
    }
    public IEnumerable<PrayerResponse> GetInbox(int opId)
    {
        return _context.PrayerResponses.Where(x => x.opId == opId);
    }

   
}