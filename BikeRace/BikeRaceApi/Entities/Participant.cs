using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Entities
{
    public class Participant
    {
        public Guid Id { get; init; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public Result Result { get; set; }

        public bool Payed { get; set; }

        public int Number { get; set; } //Ranom Number from 0-1000 to be printed on the participant shirt. 
        public Guid RaceId { get; set; }
        public virtual Race Race { get; set; }
    }
}
