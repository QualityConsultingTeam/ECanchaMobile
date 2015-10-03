
namespace EC.ServiceAgents
{
    using DocumentResponse;
    using Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAccountService : IUpdatableUrl
    {
        Task<bool> Register(string Email, string Password, bool RefreshToken);

        Task<Login> Login(string Email, string Password, bool RefreshToken);
    }
}
