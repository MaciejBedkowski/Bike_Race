using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Entities
{
    public class Result
    {
        public Guid Id { get; set; }
        public Guid IdParticipant { get; set; }
        public string Status { get; set; } //From[completed, not completed, disqualifiedi]
        public TimeSpan Time {get; set;} // The result of the race
}
}
