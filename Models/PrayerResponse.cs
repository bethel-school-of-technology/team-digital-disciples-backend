using System.ComponentModel.DataAnnotations;
namespace WebApi.Models;
public class PrayerResponse
{
    [Key]
    public int responseId { get; set;}
    public int requestId {get; set;}

    public int ministerId {get; set;}

    public int opId {get; set;}


    public string prayerTextResponse {get; set;}

    public DateTime dateTime {get; set;}
    
}