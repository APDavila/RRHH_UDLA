using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Repositories
{
    public interface IStatusRepository
    {
        Task<Status> GetStatusByCodeAsync(string code);
    }
}
