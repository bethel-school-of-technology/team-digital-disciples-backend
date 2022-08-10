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
        private readonly IPrayerRequestRepository _prayerRequestRepository;

        public PrayerResponsesController(ILogger<PrayerResponsesController> logger, IPrayerResponseRepository responseRepo, IPrayerRequestRepository requestRepo)
        {
            _logger = logger;
            _prayerResponseRepository = responseRepo;
            _prayerRequestRepository = requestRepo;
        }
        [HttpPost("new")]
        public JsonResult NewPrayerResponse(PrayerResponse prayerResponse)
        {
        _prayerResponseRepository.AddPrayerResponse(prayerResponse);
        _prayerRequestRepository.ToggleResponded(prayerResponse.requestId);
    
        return new JsonResult(Ok("Prayer Response Added"));
        }

        [HttpGet("inbox/{opId}")]
        public IEnumerable<PrayerResponse> GetInbox(int opId)
        {
        return _prayerResponseRepository.GetInbox(opId);
        }

    }
}