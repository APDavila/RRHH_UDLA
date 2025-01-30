using RecursosHumanos.API.Models;
using RecursosHumanos.API.Repositories;

namespace RecursosHumanos.API.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public async Task<Status> GetStatusByCodeAsync(string code)
        {
            return await _statusRepository.GetStatusByCodeAsync(code);
        }
    }
}
