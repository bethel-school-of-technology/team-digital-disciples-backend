using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;


    public class PrayerRequestRepository : IPrayerRequestRepository
{
    private readonly ApiContext _context;

    public PrayerRequestRepository (ApiContext context)
    {
        _context = context;
    }
    public PrayerRequest CreatePrayerRequest(PrayerRequest aRequest)
    {
        if(aRequest != null)
        _context.Add(aRequest);
        _context.SaveChanges();
        return aRequest; 
       
    }
    public  PrayerRequest UpdateRequest(PrayerRequest newRequest)
    {
        var request = _context.PrayerRequests.FirstOrDefault(r => r.RequestId == newRequest.RequestId);
        if(request != null)
        {
            request.PrayerAsk = newRequest.PrayerAsk;
            request.IsAnswered = newRequest.IsAnswered;
            request.IsRespondedTo = newRequest.IsRespondedTo;
        }
        _context.SaveChanges();
        return request;
    }

    public PrayerRequest GetOneRequest(int requestId)
    {
       return _context.PrayerRequests.FirstOrDefault(r => r.RequestId == requestId);
    }
    
    public void DeleteOne(int requestId)
    {
       var request =  _context.PrayerRequests.FirstOrDefault(r => r.RequestId == requestId);
        if (request != null)
        { _context.PrayerRequests.Remove(request);}
    }

    public IEnumerable<PrayerRequest> GetUserPrayerRequests(int userId)
    {
       return _context.PrayerRequests.Where(x => x.UserId == userId);
    }

   
    // Is this taken care of in the UpdateRequest method? or does it need it's own?
    public IEnumerable<PrayerRequest> GetAllFalse(bool responded)
    {
        return _context.PrayerRequests.Where(x => x.IsRespondedTo == false);
    }
}
