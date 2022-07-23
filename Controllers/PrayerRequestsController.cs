using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
using System.Collections.Generic;
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
      


    // GET:api/PrayerRequests/getone/5 
    // GetOnePrayerRequest(RequestId)  EDIT
    [HttpGet("getone/{RequestId}")]

    public JsonResult GetOneRequest(int requestId)
    {
        var result =  _context.PrayerRequests.Find(requestId);

        if (result == null)
          return new JsonResult(NotFound());
        else
          return new JsonResult(Ok(result));   
    }

    //This still needs to be tested with Postman
  //   //api/PrayerRequests/getAll/1 ( gets a list of all prayer requests submitted by user matching userId)
  //   //GetAllPrayerRequests(userId)
  //  [HttpGet("{UserId}")]
  //  public List<PrayerRequest> GetAllRequests(int userid)
  //  {
  //     return _context.PrayerRequests.ToList();  
  //  }


   // delete 1 prayer request (Deletes the request matching the requestId passed into function)
    //DETETE /api/PrayerRequests/deleteOne/2
    [HttpDelete("deleteOne/{RequestId}")]
    public JsonResult DeleteOne(int requestId)
    {
      var result = _context.PrayerRequests.Find(requestId);
      
      if(result == null)
        return new JsonResult(NotFound());

      _context.PrayerRequests.Remove(result);
      _context.SaveChanges();

      return new JsonResult(NoContent());

    }


    /* toggle the isAnswered bool to yes (function that counts the number of isAnswered==yes) changed on front end and received and saved on back-end
    funcion that is a post function gets a reuqest by id, and update in database with object passed from Angular send back "is true"
    [HttpPost] 
    TogglePrayerAnswered(requestId)  */
      
    }

}