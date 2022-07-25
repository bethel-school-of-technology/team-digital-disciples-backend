using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
using WebApi.Repositories;
namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PrayerResponsesController : ControllerBase
    {
        private readonly ILogger<PrayerResponsesController> _logger;
        private readonly IPrayerResponseRepository _prayerResponseRepository;

        public PrayerResponsesController(ILogger<PrayerResponsesController> logger, IPrayerResponseRepository repo)
        {
            _logger = logger;
            _prayerResponseRepository = repo;
        }
        [HttpPost("new")]
     public JsonResult NewPrayerResponse(PrayerResponse prayerResponse)
    {
        _prayerResponseRepository.AddPrayerResponse(prayerResponse);
        return new JsonResult(Ok("User Added"));
    }

    [HttpGet("inbox")]
    public IEnumerable<PrayerResponse> GetInbox(int opId)
    {
        return _prayerResponseRepository.GetInbox(opId);
    }
        //     if(prayerResponse.responseId == 0)
        //     {
        //         _context.PrayerResponses.Add(prayerResponse);
        //     }
        //     else
        //     {
        //         return new JsonResult(NotFound());
        //     }
        //     _context.SaveChanges();
        //     return new JsonResult(Ok(prayerResponse));
        // }
//  [HttpGet]
//         public JsonResult GetPrayerResponseByOpId (int id)
//         {
//             var result =  _context.PrayerResponses.Where(opId == id);
//             if (result == null)
//             {
//                 return new JsonResult(NotFound());
//             }
//             else
//             { 
//                 return new JsonResult(Ok(result));
//             }
       
//         }
    }
}