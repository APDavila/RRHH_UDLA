using Microsoft.EntityFrameworkCore;
using RecursosHumanos.API.Data;
using RecursosHumanos.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecursosHumanos.API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return await _context.People
                .Include(p => p.Gender)
                .Include(p => p.Status)
                .ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.People
                .Include(p => p.Gender)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPersonAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}