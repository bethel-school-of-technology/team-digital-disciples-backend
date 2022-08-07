using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;
using WebApi.Repositories;
using WebApi.Helpers;
namespace WebApi.Controllers

{
    [Route("api/[Controller]")]
    [Authorize]
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
        [Authorize]
        [HttpPost("new")]
        public JsonResult NewPrayerResponse(PrayerResponse prayerResponse)
        {
        _prayerResponseRepository.AddPrayerResponse(prayerResponse);
        return new JsonResult(Ok("User Added"));
        }
        [Authorize]
        [HttpGet("inbox/{opId}")]
        public IEnumerable<PrayerResponse> GetInbox(int opId)
        {
        return _prayerResponseRepository.GetInbox(opId);
        }

    }
}