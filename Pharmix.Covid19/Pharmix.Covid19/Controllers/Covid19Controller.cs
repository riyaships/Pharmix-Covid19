using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmix.Covid19.Models;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class Covid19Controller : ControllerBase
    {
        private readonly ILiveDataRepository _liveDataRepository;

        public Covid19Controller(ILiveDataRepository liveDataRepository)
        {
            _liveDataRepository = liveDataRepository;
        }
        // GET: api/Covid19
        [HttpGet]
        public string Get()
        {
            var report = _liveDataRepository.GetWorldmeterCountrywiseReport();
            return JsonConvert.SerializeObject(report, Formatting.Indented);
        }
    }
}
