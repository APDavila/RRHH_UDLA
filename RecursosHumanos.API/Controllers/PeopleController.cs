using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.API.Models;
using RecursosHumanos.API.Services;

namespace RecursosHumanos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IGenderService _genderService;
        private readonly IStatusService _statusService;
        private readonly IExternalUserService _externalUserService;

        public PeopleController(IPersonService personService,
                                IGenderService genderService,
                                IStatusService statusService,
                                IExternalUserService externalUserService)
        {
            _personService = personService;
            _genderService = genderService;
            _statusService = statusService;
            _externalUserService = externalUserService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var people = await _personService.GetAllPeopleAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            Gender gender = await _genderService.GetGenderByCodeAsync(person.GenderCode);
            if (gender == null)
            {
                return BadRequest("Invalid GenderCode.");
            }

            Status status = await _statusService.GetStatusByCodeAsync(person.StatusCode);
            if (status == null)
            {
                return BadRequest("Invalid StatusCode.");
            }

            person.Gender = gender;
            person.Status = status;

            await _personService.AddPersonAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await _personService.UpdatePersonAsync(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personService.DeletePersonAsync(id);
            return NoContent();
        }
        [HttpGet("ExternalUsers")]
        public async Task<ActionResult<List<ExternalUser>>> GetExternalUsers()
        {
            var externalUsers = await _externalUserService.GetExternalUsersAsync();
            return Ok(externalUsers);
        }
    }
}