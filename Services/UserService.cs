namespace WebApi.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Data;
using WebApi.Helpers;
using WebApi.Models;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int UserId);
    bool UserExistByUsername(string username);
    void NewUser(User user);
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    // private List<User> _users = new List<User>
    // {
    //     new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    // };

    private readonly AppSettings _appSettings;
    private readonly ApiContext _context;

    public UserService(IOptions<AppSettings> appSettings, ApiContext context)
    {
        _appSettings = appSettings.Value;
        _context = context;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        model.HashPasword();
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetById(int UserId)
    {
        return _context.Users.FirstOrDefault(x => x.Id == UserId);
    }

    public void NewUser(User user)
    {
        user.HashPasword();
        _context.Add(user);
        _context.SaveChanges();
    }

    public bool UserExistByUsername(string username)
    {
        var userId = _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).Select(x => x.Id).FirstOrDefault();
        return userId > 0;
    }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}