using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
using System.Collections.Generic;
using WebApi.Repositories;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PrayerRequestsController : ControllerBase
    {
     
        //private readonly ILogger<PrayerResponsesController> _logger; //what is this for? creates a log of actions for debugging later
        private readonly IPrayerRequestRepository _prayerRequestRepository; 

        public PrayerRequestsController(IPrayerRequestRepository repo)
        {
           _prayerRequestRepository = repo;
        }
      
      //Create prayer request
      //POST: api/prayerRequests/new
      //TESTED BY CR - WORKS ON POSTMAN 7-26-2022
      [HttpPost("new")] 
      public PrayerRequest CreatePrayerRequest(PrayerRequest aRequest)
      {// do data validation for all fields
        if(aRequest == null || !ModelState.IsValid)
        {
          Response.StatusCode = (int) HttpStatusCode.BadRequest;
          return null;
        }
        return _prayerRequestRepository.CreatePrayerRequest(aRequest); 
      }
           
  //PUT: edit a prayer request
  //   :api/PrayerRequests/updatOne/1
  //UNDER REVIEW BY CR -TESTING WITH POSTMAN
  [HttpPut("updateOne/{RequestId}")]
  public PrayerRequest UpdateRequest(PrayerRequest newRequest)
      {// do data validation for all fields
        if(newRequest == null || !ModelState.IsValid)
        {
          Response.StatusCode = (int) HttpStatusCode.BadRequest;
          return null;
        }
         
        return _prayerRequestRepository.UpdateRequest(newRequest); 
      }

      // GET:api/PrayerRequests/getone/5 
    // GetOnePrayerRequest(RequestId) 
    [HttpGet("getone/{RequestId}")]

    public PrayerRequest GetOneRequest(int requestId)
    {
      return _prayerRequestRepository.GetOneRequest(requestId);
    }   

    //This still needs to be tested with Postman
  //   //api/PrayerRequests/getAll/1 ( gets a list of all prayer requests submitted by user matching userId)
  //   //GetAllPrayerRequests(userId)
   [HttpGet("{UserId}")]
   public IEnumerable<PrayerRequest> GetUserPrayerRequests(int userid)
   {
      return _prayerRequestRepository.GetUserPrayerRequests(userid);  
   }
  


   // delete 1 prayer request (Deletes the request matching the requestId passed into function)
    //DETETE /api/PrayerRequests/deleteOne/2
    [HttpDelete("deleteOne/{RequestId}")]
    public void DeleteOne(int requestId)
    {
      _prayerRequestRepository.DeleteOne(requestId);
      Response.StatusCode = (int) HttpStatusCode.NoContent;
    }

//  GET  /api/PrayerRequests/unresponded/false
    [HttpGet("unresponded/{IsRespondedTo}")]
    public IEnumerable<PrayerRequest> GetAllFalse(bool isRespondedTo)
    {
        return _prayerRequestRepository.GetAllFalse(isRespondedTo); 
    }
      
    }

}