using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Services
{
    public interface IGenderService
    {
        Task<Gender> GetGenderByCodeAsync(string code);
    }
}
