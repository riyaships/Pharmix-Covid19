using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly ILiveDataRepository _liveDataRepository;

        public HistoryController(ILiveDataRepository liveDataRepository)
        {
            _liveDataRepository = liveDataRepository;
        }
        // GET: api/Covid19
        [HttpGet]
        public string Get()
        {
            var report = _liveDataRepository.GetWorldmeterCountrywiseReportHistoryical();
            return JsonConvert.SerializeObject(report, Formatting.Indented);
        }
    }
}