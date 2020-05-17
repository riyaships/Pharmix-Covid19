using System.Collections.Generic;
using Pharmix.Covid19.Models;

namespace Pharmix.Covid19.Services.Interfaces
{
    public interface IJohnHopkinsDataService
    {
        List<Models.JohnHopkinsData> GetJohnHopkinsCountrywiseReportHistoryical();

    }
}