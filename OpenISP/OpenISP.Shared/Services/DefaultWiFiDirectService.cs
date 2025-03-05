using System;
using System.Threading.Tasks;

namespace OpenISP.Shared.Services
{
    public class DefaultWiFiDirectService : IWiFiDirectService
    {
        public DefaultWiFiDirectService()
        {
            // Parameterless constructor for iOS/Windows
        }

        public Task<bool> DiscoverPeersAsync()
        {
            return Task.FromResult(false); // Placeholder for iOS/Windows
        }

        public void Dispose()
        {
            // No-op for non-Android platforms
        }
    }
}