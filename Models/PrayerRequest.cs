namespace WebApi.Models;

using System.ComponentModel.DataAnnotations;

public class PrayerRequest
{
    [Required]
    private int RequestId {get; set; }

    [Required]
    private int UserId { get; set; }

    [Required]
    public string PrayerAsk { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public Boolean IsAnswered { get; set; }

    [Required]
    public Boolean IsRespondedTo { get; set; }
}