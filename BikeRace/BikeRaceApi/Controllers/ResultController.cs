using BikeRaceApi.Entities;
using BikeRaceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Controllers
{
    [Route("api/result")]
    public class ResultController : ControllerBase
    {
        
        private readonly RaceDBContext _dbContext;

        public ResultController(RaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("{idResult}")]
        public ActionResult Update(Guid idResult, string status, TimeSpan time)
        {
            var result = _dbContext
                .Results
                .FirstOrDefault(r => r.Id == idResult);
            if (result is null) return NotFound();
            if (status != null) result.Status = status;
            if (time != null) result.Time = time;
            _dbContext.Update(result);
            _dbContext.SaveChanges();
            return Ok("Saved changes");

        }

        [HttpDelete("{idResult}")]
        public ActionResult Delete(Guid idResult)
        {
            var result = _dbContext
                .Results
                .FirstOrDefault(r => r.Id == idResult);

            _dbContext.Results.Remove(result);
            _dbContext.SaveChanges();

            return Ok("Dane usunięte");
        }

        [HttpPost]
        public ActionResult CreateResult(Guid ParticipantId, string status, TimeSpan time)
        {
            var participant = _dbContext
                .Participants
                .Where(x => x.Id == ParticipantId);

            if (participant is null) return NotFound();

            var result = new Result { IdParticipant = ParticipantId, Status = status, Time = time };
            _dbContext.Results.Add(result);
            
            foreach (var item in participant)
            {
                item.Result = result;
            }

            _dbContext.SaveChanges();

            return Created($"/api/result/{result.Id}", null);
        }

        [HttpGet("{participantId}")]
        public ActionResult<Result> Get([FromRoute] Guid participantId)
        {
            var result = _dbContext
                .Results
                .FirstOrDefault(r => r.IdParticipant == participantId);

            if (result is null) return NotFound();

            return Ok(result);
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

            return Ok(results);
        }
    }
}
