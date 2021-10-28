using BikeRaceApi.Entities;
using BikeRaceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi
{
    public class RaceSeeder
    {
        private readonly RaceDBContext _dbContext;
        public RaceSeeder(RaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Initialization of initial values ​​in the database
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Races.Any())
                {
                    var races = GetRaces();
                    _dbContext.Races.AddRange(races);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Race> GetRaces()
        {
            var races = new List<Race>()
            {
                new Race()
                {
                    Name = "First Race!",
                    Location = "Kraków",
                    Participants = new List<Participant>()
                    {
                        new Participant()
                        {
                            Name = "Zawodnik 1",
                            Surname = "Najlepszy",
                            Payed = true,
                            Number = 1,
                        },
                        new Participant()
                        {
                            Name = "Zawodnik 2",
                            Surname = "Dobry",
                            Payed = true,
                            Number = 2,
                        }
                    }
                }
            };

            return races;
        }
    }
}
