using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmix.Covid19.Models;

namespace Pharmix.Covid19.Services.Interfaces
{
    public interface ILiveDataRepository
    {
        WorldMeterReport GetWorldmeterCountrywiseReport();
        WorldMeterReport GetWorldmeterCountrywiseReportHistoryical();
        Task<bool> StoreWorldmeterCountrywiseReport();
        List<string> GetWorldMeterCountryNames();
    }
}
