using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Pharmix.Covid19.Models
{
    [Table("JohnHopkinsData")]
    public class JohnHopkinsData
    {
        public string FIPS { get; set; }
        public string Admin2 { get; set; }
        public string Province_State { get; set; }
        public string Country_Region { get; set; }
        public string Last_Update { get; set; }
        public string Lat { get; set; }
        public string Long_ { get; set; }
        public string Confirmed { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
        public string Active { get; set; }
        public string Combined_Key { get; set; }
    }

    [Table("WorldMeterData")]

    public class WorldMeterData
    {
        public WorldMeterData()
        {
             
        }
        [Key] public int WorldMeterDataID { get; set; }
        public string Country { get; set; }
        public int TotalCases { get; set; }
        public int NewCases { get; set; }
        public int TotalDeaths { get; set; }
        public int NewDeaths { get; set; }
        public int TotalRecovered { get; set; }
        public int ActiveCases { get; set; }
        public int SeriousOrCriticalCases { get; set; }
        public decimal CasesPerMillion { get; set; }
        public decimal DeathsPerMillion { get; set; }
        public decimal TotalTests { get; set; }
        public decimal TestsPerMillion { get; set; }
        public int TotalPopulation { get; set; }
        public DateTime? FirstCaseReported { get; set; }
        public DateTime? LogTime { get; set; }
    }
    public class WorldMeterReport
    {
        public WorldMeterReport()
        {
            CountryReports = new List<WorldMeterData>();
        }    
        public WorldMeterReport(List<WorldMeterData> report)
        {
            CountryReports = report;
        }
        public List<WorldMeterData> CountryReports { get; set; }

        public int NumberOfCountries
        {
            get { return CountryReports.Count; }
        }

        public List<string> Countries {
            get
            {
                return CountryReports.Select(m => m.Country).Distinct().ToList();
            }
        }

        public int WorldTotalCases { get; set; }
        public int WorldTotalDeaths { get; set; }
        public int WorldTotalRecoveries { get; set; }
        public int WorldTotalActiveCases { get; set; }
        public int WorldTotalActiveCasesMild { get; set; }
        public int WorldTotalActiveCasesSerious { get; set; }
        public int WorldTotalClosedCases { get; set; }
        public int WorldTotalClosedCasesRecovered { get; set; }
        public int WorldTotalClosedCasesDeaths { get; set; }

    }
}
