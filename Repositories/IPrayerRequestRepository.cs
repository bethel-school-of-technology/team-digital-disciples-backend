using WebApi.Models;

namespace WebApi.Repositories;

public interface IPrayerRequestRepository 
{
    //(what will it return?) (Name of the method) ((parematers for method))
    PrayerRequest CreatePrayerRequest(PrayerRequest aRequest);
    //edit a prayer request
    PrayerRequest GetOneRequest(int requestId);

    IEnumerable<PrayerRequest> GetAllPrayerRequests(int userId);
    void DeleteOne(int requestId);
  
    PrayerRequest PrayerAnswered( int requestId);
}