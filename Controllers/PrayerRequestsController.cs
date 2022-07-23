using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PrayerRequestsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PrayerRequestsController(ApiContext context)
        {
           _context = context;
        }
      
      //Create prayer request
      //POST: api/prayerRequests/new
      [HttpPost("new")] 
      public JsonResult CreatePrayerRequest(PrayerRequest aRequest)
      {
        if(aRequest.RequestId == 0)
        {
            _context.PrayerRequests.Add(aRequest); 
        }else
        {
            return new JsonResult(NotFound());
        }

        _context.SaveChanges();

        return new JsonResult(Ok(aRequest));

      }
      


    // GET:api/PrayerRequests/5 
    // GetOnePrayerRequest(RequestId)  EDIT
    [HttpGet("{RequestId}")]

    public JsonResult GetOneRequest(int requestId)
    {
        var result =  _context.PrayerRequests.Find(requestId);

        if (result == null)
          return new JsonResult(NotFound());
        else
          return new JsonResult(Ok(result));   
    }

    
//get all prayer requests by userID ( gets a list of all prayer requests submitted by user matching userId)
    //[HttpGet]
    //GetAllPrayerRequests(userId)
  //  [HttpGet("{Id}")]
  //  public JsonResult GetAllRequests(int Id)




   /*  delete 1 prayer request (Deletes the request matching the requestId passed into function)
    [HttpDeleteAttribute]
    DeletePrayerRequest(requestId) */



    /* toggle the isAnswered bool to yes (function that counts the number of isAnswered==yes) changed on front end and received and saved on back-end
    funcion that is a post function gets a reuqest by id, and update in database with object passed from Angular send back "is true"
    [HttpPost] 
    TogglePrayerAnswered(requestId)  */
      
    }

}