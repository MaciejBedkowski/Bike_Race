using BikeRaceApi.Entities;
using BikeRaceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRaceApi.Controllers
{
    [Route("api/participant")]
    public class ParticipantController : ControllerBase
    {
        private readonly RaceDBContext _dbContext;

        public ParticipantController(RaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut("{participantId}")]
        public ActionResult Update(Guid participantId, string name, string surname, bool payed)
        {
            var participant = _dbContext
                .Participants
                .FirstOrDefault(r => r.Id == participantId);
            if (participant is null) return NotFound();
            if (name != null) participant.Name = name;
            if (surname != null) participant.Surname = surname;
            if (payed != null) participant.Payed = payed;
            _dbContext.Update(participant);
            _dbContext.SaveChanges();
            return Ok("Saved changes");

        }

        [HttpDelete("{participantId}")]
        public ActionResult Delete(Guid participantId)
        {
            var participant = _dbContext
                .Participants
                .FirstOrDefault(r => r.Id == participantId);

            if (participant is null) return NotFound();
           
            _dbContext.Participants.Remove(participant);
            _dbContext.SaveChanges();

            return Ok("Dane usunięte");
        }

        [HttpPost]
        public ActionResult CreateParticipant(string name, string surname, Guid idRace, bool payed)
        {
            Random rnd = new Random();
            bool numberExist = true;
            var number = 0;

            var race = _dbContext
                .Races
                .FirstOrDefault(x => x.Id == idRace);

            var participants = _dbContext
                .Participants
                .ToList();

            if (race is null) return NotFound();
            while(numberExist)
            {
                numberExist = false;
                number = rnd.Next(0, 1000);
                foreach(var item in participants)
                {
                    if (item.Number == number) numberExist = true;
                }    
            }
                
            var participant = new Participant { Name = name, Surname = surname, RaceId = idRace, Number = number, Payed = payed };
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            return Created($"/api/participant/{participant.Id}", null);
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Participant>> GetAll(Guid id)
        {
            var participants = _dbContext
                .Participants
                .Where(x => x.RaceId == id)
                .ToList();

            return Ok(participants);
        }
    }
}
