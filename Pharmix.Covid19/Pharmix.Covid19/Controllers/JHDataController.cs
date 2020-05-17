using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class JHDataController : ControllerBase
    {
        private readonly ILiveDataRepository _liveDataRepository;
        private readonly IJohnHopkinsDataService _johnHopkinsDataService;

        public JHDataController(ILiveDataRepository liveDataRepository, IJohnHopkinsDataService johnHopkinsDataService)
        {
            _liveDataRepository = liveDataRepository;
            _johnHopkinsDataService = johnHopkinsDataService;
        }

        [HttpGet]
        public string Get()
        {
            var report = _johnHopkinsDataService.GetJohnHopkinsCountrywiseReportHistoryical();
            return JsonConvert.SerializeObject(report, Formatting.Indented);
        }
    }
}