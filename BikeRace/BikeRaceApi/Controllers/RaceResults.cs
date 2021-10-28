using BikeRaceApi.Entities;
using BikeRaceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Controllers
{
    [Route("api/endRace")]
    public class RaceResults
    {
        private readonly RaceDBContext _dbContext;

        public RaceResults(RaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{raceId}")]
        public ActionResult<IEnumerable<Result>> GetAllResult(Guid raceId)
        {
            var participants = _dbContext
                .Participants
                .Where(x => x.RaceId == raceId)
                .ToList();

            var results = new List<Result>();

            foreach(var item in participants)
            {
                results.Add(item.Result);
            }

            results.GroupBy(x => x.Time);

            return results;
        }
    }
}
