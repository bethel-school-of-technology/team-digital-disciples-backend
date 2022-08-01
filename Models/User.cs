namespace WebApi.Models;

using System.Text.Json.Serialization;
using System.Security.Cryptography;
using System.Text;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    public void HashPasword(){
        var sha = SHA256.Create();
        var asByteArray = Encoding.Default.GetBytes(this.Password);
        var hashedPassword = sha.ComputeHash(asByteArray);
        this.Password = Convert.ToBase64String(hashedPassword);
    }


}


