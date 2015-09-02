using System;
using EC.Model;
using System.Threading.Tasks;

namespace EC.Infrastructure.Abstractions.Services
{
    public interface ILocationServiceSingleton
    {
        Task<Location> CalculatePositionAsync();
    }
}
