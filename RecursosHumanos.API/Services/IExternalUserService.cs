using RecursosHumanos.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecursosHumanos.API.Services
{
    public interface IExternalUserService
    {
        Task<List<ExternalUser>> GetExternalUsersAsync();
    }
}
