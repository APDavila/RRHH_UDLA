using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Repositories
{
    public interface IGenderRepository
    {
        Task<Gender> GetGenderByCodeAsync(string code);
    }
}
