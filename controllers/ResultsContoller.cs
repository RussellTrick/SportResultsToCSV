using Microsoft.AspNetCore.Mvc;
using MediaInformationSystem.Models;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace MediaInformationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        [HttpPost("convert-to-csv")]
        public IActionResult ConvertToCsv([FromBody] RaceResults raceResults)
        {
            if (raceResults?.Results?.Athletes == null || raceResults.Results.Athletes.Count == 0)
            {
                return BadRequest("No race results provided.");
            }

            var records = raceResults.Results.Athletes;
            var csvData = new StringWriter();

            using (var csvWriter = new CsvWriter(csvData, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteField("Rank");
                csvWriter.WriteField("Full Name");
                csvWriter.WriteField("Finish Time");
                csvWriter.WriteField("Country Code");
                csvWriter.NextRecord();

                foreach (var record in records)
                {
                    csvWriter.WriteField(record.Rank);
                    csvWriter.WriteField(record.FirstName + " " + record.Surname);
                    csvWriter.WriteField(record.FinishTime);
                    csvWriter.WriteField(record.Flag);
                    csvWriter.NextRecord();
                }
            }

            var csvBytes = System.Text.Encoding.UTF8.GetBytes(csvData.ToString());
            return File(csvBytes, "text/csv", "race_results.csv");
        }
    }
}
