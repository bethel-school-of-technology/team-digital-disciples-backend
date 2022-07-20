namespace WebApi.Models;
public class PrayerResponse
{
    public int responseId { get; set;}
    public int requestId {get; set;}

    public int userId {get; set;}

    public string prayerTextResponse {get; set;}

    public DateTime dateTime {get; set;}
    
}