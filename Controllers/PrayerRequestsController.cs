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
      
      //Create and Edit prayer request
      //POST: api/newRequest
      [HttpPost("newAsk")] //can this just be "new" or does it need a new name because "new" is already being used in PrayerRequest
      public JsonResult CreatePrayerRequest(PrayerRequest PrayerRequest)
      {
        if(PrayerRequest.RequestId == 0)
        {
            _context.PrayerRequests.Add(PrayerRequest); //create new request
        }else
        {
          var requestInDb = _context.PrayerRequests.Find(PrayerRequest.RequestId);

          if(requestInDb == null)
            return new JsonResult(NotFound());

            requestInDb = PrayerRequest;
        }

        _context.SaveChanges();

        return new JsonResult(Ok(PrayerRequest));

      }
      


    // GET:api/request/5 Get 1 prayer request (allows user to change current request)
    // [HttpPostAttribute]
    // UpdatePrayerRequest(RequestId)
    
    [HttpGet("{RequestId}")]

    public JsonResult GetOneRequest(int RequestId);
    {
        var result =  _context.PrayerRequests.Find(RequestId);

        if (result == null)
            return new JsonResult(NotFound());
        RequestTrailerExtensions new JsonResult(Ok(result));    

        
   }

    
//get all prayer requests by userID ( gets a list of all prayer requests submitted by user matching userId)
    //[HttpGet]
    //GetAllPrayerRequests(userId)
   



   /*  delete 1 prayer request (Deletes the request matching the requestId passed into function)
    [HttpDeleteAttribute]
    DeletePrayerRequest(requestId) */



    /* toggle the isAnswered bool to yes (function that counts the number of isAnswered==yes)
    [HttpPost] 
    TogglePrayerAnswered(requestId)  */
      
    }

}