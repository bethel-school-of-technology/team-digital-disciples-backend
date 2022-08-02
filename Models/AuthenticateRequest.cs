namespace WebApi.Models;

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }


    public void HashPasword(){
        var sha = SHA256.Create();
        var asByteArray = Encoding.Default.GetBytes(this.Password);
        var hashedPassword = sha.ComputeHash(asByteArray);
        this.Password = Convert.ToBase64String(hashedPassword);
    }
}