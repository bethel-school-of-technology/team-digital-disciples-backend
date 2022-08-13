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

    public List<CombinedResponse> GetCombinedResponse(int userId)
    {
        IEnumerable<PrayerResponse> prayerResponses = _context.PrayerResponses.Where(x => x.opId == userId);
        List<CombinedResponse> combinedResponses = new List<CombinedResponse>();
        foreach (var response in prayerResponses)
        {
            CombinedResponse currentCombinedResponse = new CombinedResponse();
            PrayerRequest currentRequest = new PrayerRequest();
            User currentOp = new User();
            currentOp = _context.Users.FirstOrDefault(x => x.Id == response.opId);
            User currentMinister = new User();
            currentMinister = _context.Users.FirstOrDefault(x => x.Id == response.ministerId);
            currentRequest = _context.PrayerRequests.FirstOrDefault(x => x.RequestId == response.requestId);
            currentCombinedResponse.ministerName = currentMinister.FirstName.ToString();
            currentCombinedResponse.responseId = response.responseId;
            currentCombinedResponse.opName = currentOp.FirstName.ToString();
            currentCombinedResponse.prayerTextResponse = response.prayerTextResponse;
            currentCombinedResponse.responseDateTime = response.dateTime;
            currentCombinedResponse.requestDateTime = currentRequest.DateTime;
            currentCombinedResponse.requestText = currentRequest.PrayerAsk.ToString();
            combinedResponses.Add(currentCombinedResponse);

        }
        return combinedResponses;
    }
}
