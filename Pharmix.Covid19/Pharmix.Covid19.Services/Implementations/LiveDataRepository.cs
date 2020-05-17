using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Pharmix.Covid19.Models;
using Pharmix.Covid19.Services.Extensions;
using Pharmix.Covid19.Services.Interfaces;

namespace Pharmix.Covid19.Services.Implementations
{
    public class LiveDataRepository : ILiveDataRepository
    {
        private readonly ICovid19Context _context;

        public LiveDataRepository(ICovid19Context context)
        {
            _context = context;
        }
        //https://www.worldometers.info/coronavirus/  table#main_table_countries_today

        public WorldMeterReport GetWorldmeterCountrywiseReport()
        {
            return GetWorldMeterContent();
        }

       

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<bool> StoreWorldmeterCountrywiseReport()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                var report = GetWorldMeterContent();
                foreach (var item in report.CountryReports)
                {
                    item.LogTime = DateTime.Now;
                    _context.WorldMeterReports.Add(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public List<string> GetWorldMeterCountryNames()
        {
            return GetWorldMeterContent().Countries;
        }

        private WorldMeterReport GetWorldMeterContent()
        {
            var htmlContent = GetHtmlResponseFromPage("https://www.worldometers.info/coronavirus");
            var tableContent = GetHtmlContentById("main_table_countries_today", htmlContent);
            var data = ReadTableRowToObjects("<div>"+tableContent+"</div>");

            var result = new WorldMeterReport(data);

            LoadWorldMeterReport(result, htmlContent);

            return result;
        }

        private WorldMeterReport LoadWorldMeterReport(WorldMeterReport input, string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);
            return input;
        }

        private List<WorldMeterData> ReadTableRowToObjects(string tableHtml)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(tableHtml);

            var tableContent = (from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>() select table).FirstOrDefault();
            var rows = (from row in tableContent.SelectNodes("//tr").Cast<HtmlNode>() select row).ToList();

            var results = new List<WorldMeterData>();

            foreach (HtmlNode row in rows)
            {
                if (row.SelectNodes("th")!=null && row.SelectNodes("th").Count > 0) continue;

                LoadRowObjects(row, results);
            }
             
            return results;
        }

        private static void LoadRowObjects(HtmlNode row, List<WorldMeterData> results)
        {
            var cells = row.SelectNodes("td").Cast<HtmlNode>().ToList();
            var worldReport = new WorldMeterData();
            worldReport.Country = cells[1].InnerText;
            worldReport.TotalCases = cells[2].InnerText.AsInt();
            worldReport.NewCases = cells[3].InnerText.AsInt();
            worldReport.TotalDeaths = cells[4].InnerText.AsInt();
            worldReport.NewDeaths = cells[5].InnerText.AsInt();
            worldReport.TotalRecovered = cells[6].InnerText.AsInt();
            worldReport.ActiveCases = cells[7].InnerText.AsInt();
            worldReport.SeriousOrCriticalCases = cells[8].InnerText.AsInt();
            worldReport.CasesPerMillion = cells[9].InnerText.AsInt();
            worldReport.DeathsPerMillion = cells[10].InnerText.AsInt();
            worldReport.TotalTests = cells[11].InnerText.AsInt();
            worldReport.TestsPerMillion = cells[12].InnerText.AsInt();
            if (cells.Count > 13)
            {
                worldReport.TotalPopulation = cells[13].InnerText.AsInt();
            }

            results.Add(worldReport);
        }

        private string GetHtmlContentById(string id, string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);
            return doc.GetElementbyId(id).OuterHtml;
        }

        private string GetHtmlResponseFromPage(string urlAddress)
        {
            var request = (HttpWebRequest)WebRequest.Create(urlAddress);
            var response = (HttpWebResponse)request.GetResponse();

            var result = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                result = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            return result;
        }

        public WorldMeterReport GetWorldmeterCountrywiseReportHistoryical()
        {
            var data = _context.WorldMeterReports.ToList();
            var result = new WorldMeterReport(data);
            return result;
        }
    }
}
