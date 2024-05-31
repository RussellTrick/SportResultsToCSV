using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediaInformationSystem.Models
{
    public class Athlete
    {
        public int Rank { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? AthleteId { get; set; }
        public string? FinishTime { get; set; }
        public string? RaceProgress { get; set; }
        public string? TeamName { get; set; }
        public string? BibNumber { get; set; }
        public string? Flag { get; set; }
        public string? CountryName { get; set; }
    }

    public class RaceDetails
    {
        public string? RaceStatus { get; set; }
        public string? Gender { get; set; }
        public string? RaceName { get; set; }
        public string? Tod { get; set; }
        public string? LastUpdated { get; set; }
        public double RaceLength { get; set; }
        public List<Athlete>? Athletes { get; set; }
    }

    public class RaceResults
    {
        public RaceDetails? Results { get; set; }
    }
}
