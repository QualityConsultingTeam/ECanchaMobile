using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.ServiceAgents.Interfaces
{
    public interface IAccountService : IUpdatableUrl
    {
        Task<bool> Register(string Email, string Password, bool RefreshToken);

        Task<bool> Login(string Email, string Password, bool RefreshToken);
    }
}
