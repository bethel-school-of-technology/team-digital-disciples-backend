using System.ComponentModel.DataAnnotations;
namespace WebApi.Models;



public class PrayerRequest
{

    [Key]
    public int RequestId {get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public string PrayerAsk { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public Boolean IsAnswered { get; set; }

    [Required]
    public Boolean IsRespondedTo { get; set; }
}