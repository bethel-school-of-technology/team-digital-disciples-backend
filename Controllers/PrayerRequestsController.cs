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

  //------------------------------------------------------------------------------------------
  //chaged methed from PUT TO POST as we are working with a readonly _prayerRequestRepository and you can't do that with PUT
  //Removed the "/{requestId}" from the HTTP as we are passing the entire object to the api through the body as a PrayerRequest object
  //In IPrayerRequestRepository and PrayerRequestRepository, changed the return type of the UpdateOne function from PrayerRequest to bool as we only need to know if it was added to database or not
  //changed method return type to Json Result as we just need to know that it was successfully updated
  //TESTED ON POSTMAN CR - It is WORKING 7-26-2022
  //--------------------------------------------------------------------------------------------
  [HttpPost("updateOne")]
  public JsonResult UpdateRequest(PrayerRequest newRequest)
      {// do data validation for all fields
        if(newRequest == null || !ModelState.IsValid)
        {
          Response.StatusCode = (int) HttpStatusCode.BadRequest;
          return null;
        }
         
        var result = _prayerRequestRepository.UpdateRequest(newRequest);
        if (result)
        {
          return new JsonResult(Ok("Successfully Updated Request"));
        }
        return new JsonResult(BadRequest("Prayer Request Doesn't exist in database"));

      }


      // GET:api/PrayerRequests/getone/5 
    // GetOnePrayerRequest(RequestId) 
    // TESTED AND WORKING - CR - 7-26-2022
    [HttpGet("getone/{RequestId}")]

    public PrayerRequest GetOneRequest(int requestId)
    {
      return _prayerRequestRepository.GetOneRequest(requestId);
    }   

  //api/PrayerRequests/getAll/1 ( gets a list of all prayer requests submitted by user matching userId)
  //GetAllPrayerRequests(userId)
 //CHANGED HTTPGet Method from [HttpGet("{UserId}")] to [HttpGet("getAll/{UserId}")]
 //TESTED BY CR ON POSTMAN.  WORKING 7-26-2022
    [HttpGet("getAll/{UserId}")]
   public IEnumerable<PrayerRequest> GetUserPrayerRequests(int userid)
   {
      return _prayerRequestRepository.GetUserPrayerRequests(userid);  
   }
  


   // delete 1 prayer request (Deletes the request matching the requestId passed into function)
    //DETETE /api/PrayerRequests/deleteOne/2
    //Changed Return Type to JsonResult as we only need to know that it was deleted
    //Changed Interface and Repository Delete Function to return type of bool as we only need true or false returned.
    //add if statement below to check if true or false and return appropriate message to front end
    //added _context.SaveChages() to the PrayerRequestRepository funtion so that changes would be saved in database
    //TESTED AND WORKING - CR - 7-26-2022
    [HttpDelete("deleteOne/{RequestId}")]
    public JsonResult DeleteOne(int requestId)
    {
      var result = _prayerRequestRepository.DeleteOne(requestId);

      if (result)
      {
        return new JsonResult(Ok("Record Successfully Deleted"));
      }
      return new JsonResult(BadRequest("Prayer Request does not Exist in the Database"));

    }

//  GET  /api/PrayerRequests/unresponded
// removed bool false out of the function parameter as this function does not require a paremeter to be passed into it.  It simply needs to be excecuted
//Did the same thing in the interface and repository
//TESTED AND WORKING - CR - 7-26-2022
    [HttpGet("unresponded")]
    public IEnumerable<PrayerRequest> GetAllFalse()
    {
        return _prayerRequestRepository.GetAllFalse(); 
    }
      
    }

}