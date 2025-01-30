using Microsoft.EntityFrameworkCore;
using RecursosHumanos.API.Data;
using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly AppDbContext _context;
        public GenderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Gender> GetGenderByCodeAsync(string code)
        {
            return await _context.Genders
            .FirstOrDefaultAsync(p => p.Code == code);
        }
    }
}
