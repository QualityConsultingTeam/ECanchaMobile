using System;
using EC.Client.Core.Model;
using System.Threading.Tasks;

namespace EC.Client.Core.Infrastructure.Abstractions.Services
{
    public interface ILocationServiceSingleton
    {
        Task<Location> CalculatePositionAsync();
    }
}
