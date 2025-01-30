using RecursosHumanos.API.Models;
using RecursosHumanos.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecursosHumanos.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _personRepository.GetAllPeopleAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }

        public async Task AddPersonAsync(Person person)
        {
            await _personRepository.AddPersonAsync(person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await _personRepository.UpdatePersonAsync(person);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personRepository.DeletePersonAsync(id);
        }
    }
}