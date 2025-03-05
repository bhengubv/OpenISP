using System;
using System.Threading.Tasks;

namespace OpenISP.Shared.Services
{
    public interface IWiFiDirectService : IDisposable
    {
        Task<bool> DiscoverPeersAsync();
    }
}