using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Entities
{
    public class Race
    {
        public Guid Id { get; init; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual List<Participant> Participants { get; set; }
    }
}
