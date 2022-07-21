using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PrayerResponsesController : ControllerBase
    {
        private readonly ApiContext _context;

        public PrayerResponsesController(ApiContext context)
        {
            _context = context;
        }
        [HttpPost]
        public JsonResult CreateResponse (PrayerResponse prayerResponse)
        {
            if(prayerResponse.responseId == 0)
            {
                _context.PrayerResponses.Add(prayerResponse);
            }
            else
            {
                var responseInDb = _context.PrayerResponses.Find(prayerResponse.responseId);
                if (responseInDb == null)
                    return new JsonResult(NotFound());

                responseInDb = prayerResponse;
                
            }
            
            _context.SaveChanges();
            return new JsonResult(Ok(prayerResponse));
        }

        [HttpGet]
        public JsonResult GetPrayerResponseById (int id)
        {
            var result =  _context.PrayerResponses.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            else
            { 
                return new JsonResult(Ok(result));
            }
        }
    }
}