using RecursosHumanos.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecursosHumanos.API.Services
{
    public interface IStatusService
    {
        Task<Status> GetStatusByCodeAsync(string code);
    }
}
