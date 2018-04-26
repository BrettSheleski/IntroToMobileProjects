using System;
using System.Threading.Tasks;

namespace GpsDemo
{
    public interface ILocationService
    {
        Task<Location> GetLocationAsync();
    }


}
