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
        [HttpPost("new")]
        public JsonResult CreateResponse (PrayerResponse prayerResponse)
        {
            if(prayerResponse.responseId == 0)
            {
                _context.PrayerResponses.Add(prayerResponse);
            }
            else
            {
                return new JsonResult(NotFound());
            }
            _context.SaveChanges();
            return new JsonResult(Ok(prayerResponse));
        }

        [HttpGet]
        public JsonResult GetPrayerResponseByOpId (int id)
        {
            var result =  _context.PrayerResponses.Where(opId == id);
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