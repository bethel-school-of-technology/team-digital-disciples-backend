using System.ComponentModel.DataAnnotations;
namespace WebApi.Models;
public class CombinedResponse
{
    [Key]
    public int responseId { get; set;}
    public string requestText {get; set;}

    public string ministerName {get; set;}

    public int opName {get; set;}

    public string prayerTextResponse {get; set;}

    public string dateTime {get; set;}
    
}