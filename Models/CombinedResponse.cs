using System.ComponentModel.DataAnnotations;
namespace WebApi.Models;
public class CombinedResponse
{
    [Key]
    public int responseId { get; set;}
    public string requestText {get; set;}

    public string ministerName {get; set;}

    public string opName {get; set;}

    public string prayerTextResponse {get; set;}

    public DateTime responseDateTime {get; set;}

    public DateTime requestDateTime {get ; set;}
    
}