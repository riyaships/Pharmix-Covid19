using Microsoft.AspNetCore.Mvc;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILiveDataRepository _liveDataRepository;

        public LogController(ILiveDataRepository liveDataRepository)
        {
            _liveDataRepository = liveDataRepository;
        }

        [HttpGet]
        public string Get()
        {
            var report = _liveDataRepository.StoreWorldmeterCountrywiseReport();
            return "Data from world meter saved successfully";
        }
    }
}