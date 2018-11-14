using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhereIsMe
{
    public interface ILocationService
    {
        Task<Location> GetLocationAsync();

        Task<Location> GetLocationAsync(CancellationToken cancellationToken);
    }
}
