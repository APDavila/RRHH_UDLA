using RecursosHumanos.API.Models;
using RecursosHumanos.API.Repositories;

namespace RecursosHumanos.API.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public async Task<Gender> GetGenderByCodeAsync(string code)
        {
            return await _genderRepository.GetGenderByCodeAsync(code);
        }
    }
}
