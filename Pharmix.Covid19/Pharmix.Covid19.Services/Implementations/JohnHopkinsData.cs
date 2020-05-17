using System.Collections.Generic;
using System.Linq;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Services.Implementations
{
    public class JohnHopkinsData : IJohnHopkinsDataService
    {
        private readonly ICovid19Context _context;
        public JohnHopkinsData(ICovid19Context context)
        {
            _context = context;
        } 

        List<Models.JohnHopkinsData> IJohnHopkinsDataService.GetJohnHopkinsCountrywiseReportHistoryical()
        {
            return _context.JohnHopkinsData.ToList();
        }
    }
}