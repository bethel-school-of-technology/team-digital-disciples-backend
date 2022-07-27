using WebApi.Models;

namespace WebApi.Repositories;

public interface IPrayerRequestRepository 
{
    //(what will it return?) (Name of the method) ((parematers for method))
   PrayerRequest CreatePrayerRequest(PrayerRequest aRequest);
   
    bool UpdateRequest(PrayerRequest newRequest);
    bool DeleteOne(int requestId);
    PrayerRequest GetOneRequest(int requestId);

    IEnumerable<PrayerRequest> GetUserPrayerRequests(int userId);

   IEnumerable<PrayerRequest> GetAllFalse();
}