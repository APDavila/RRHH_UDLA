using Microsoft.EntityFrameworkCore;
using RecursosHumanos.API.Data;
using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Status> GetStatusByCodeAsync(string code)
        {
            return await _context.Statuses
            .FirstOrDefaultAsync(p => p.Code == code);
        }
    }
}
