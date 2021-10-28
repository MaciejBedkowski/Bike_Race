using BikeRaceApi.Entities;
using BikeRaceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BikeRaceApi.Controllers
{
    [Route("api/race")]
    public class RaceController : ControllerBase
    {
        private readonly RaceDBContext _dbContext;
        public RaceController(RaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, string name, string location)
        {
            var race = _dbContext
                .Races
                .FirstOrDefault(r => r.Id == id);
            if (race is null) return NotFound();
            if(name != null) race.Name = name;
            if(location != null) race.Location = location;
            _dbContext.Update(race);
            _dbContext.SaveChanges();
            return Ok("Saved changes");

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var race = _dbContext
                .Races
                .FirstOrDefault(r => r.Id == id);

            if (race is null) return NotFound();

            var participant = _dbContext.Participants.Where(x => x.RaceId == id).ToList();

            foreach(var item in participant)
            {
                if(item.Result != null)
                {
                    _dbContext.Results.Remove(item.Result);
                }
                _dbContext.Participants.Remove(item);
            }
            
            _dbContext.Races.Remove(race);
            _dbContext.SaveChanges();

            return Ok("Dane usunięte");
        }

        [HttpPost]
        public ActionResult CreateRace( string name, string location)
        {
            var race = new Race { Name = name, Location = location };
            _dbContext.Races.Add(race);
            _dbContext.SaveChanges();

            return Created($"/api/race/{race.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Race>> GetAll()
        {
            var races = _dbContext
                .Races
                .ToList();

            return Ok(races);
        }

        [HttpGet("{id}")]
        public ActionResult<Race> Get([FromRoute] Guid id)
        {
            var race = _dbContext
                .Races
                .FirstOrDefault(r => r.Id == id);

            if (race is null)
            {
                return NotFound();
            }

            return Ok(race);
        }
    }
}
