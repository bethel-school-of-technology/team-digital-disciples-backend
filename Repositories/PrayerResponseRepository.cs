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

    public List<CombinedResponse> GetCombinedResponse(int userId)
    {
        IEnumerable<PrayerResponse> prayerResponses = _context.PrayerResponses.Where(x => x.opId == userId);
        List<CombinedResponse> combinedResponses = new List<CombinedResponse>();
        CombinedResponse currentCombinedResponse = new CombinedResponse();
        List<User> userList = _context.Users.ToList();
        foreach (var response in prayerResponses)
        {

            currentCombinedResponse.ministerName = userList.FirstOrDefault(x => x.Id == response.ministerId).FirstName.ToString();
            currentCombinedResponse.opName = userList.FirstOrDefault(x => x.Id == response.opId).FirstName.ToString();
            currentCombinedResponse.prayerTextResponse = response.prayerTextResponse;
            currentCombinedResponse.responseDateTime = response.dateTime;
            currentCombinedResponse.requestDateTime = _context.PrayerRequests.FirstOrDefault(x => x.RequestId == response.requestId).DateTime;
            currentCombinedResponse.requestText = _context.PrayerRequests.FirstOrDefault(x => x.RequestId == response.requestId).PrayerAsk.ToString();
            combinedResponses.Add(currentCombinedResponse);

        }
        return combinedResponses;
    }
}
