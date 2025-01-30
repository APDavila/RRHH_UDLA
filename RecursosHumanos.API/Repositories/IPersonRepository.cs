using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}
