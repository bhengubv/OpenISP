using Android.App;
using Android.Content;
using Android.Net.Wifi.P2p;
using Android.OS;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System;
using System.Threading.Tasks;
using OpenISP.Shared.Services;

namespace OpenISP.Services
{
    public class AndroidWiFiDirectService : IWiFiDirectService
    {
        private readonly WifiP2pManager _manager;
        private readonly WifiP2pManager.Channel? _channel;
        private bool _isDisposed;

        public AndroidWiFiDirectService(Activity activity)
        {
            ArgumentNullException.ThrowIfNull(activity, nameof(activity));
            _manager = (WifiP2pManager)activity.GetSystemService(Context.WifiP2pService);
            _channel = _manager.Initialize(activity, Looper.MainLooper, null);
        }

        public async Task<bool> DiscoverPeersAsync()
        {
            if (_isDisposed) throw new ObjectDisposedException(nameof(AndroidWiFiDirectService));
            var tcs = new TaskCompletionSource<bool>();
            _manager.DiscoverPeers(_channel, new WiFiDirectActionListener(tcs));
            return await tcs.Task.ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
#if ANDROID27_0_OR_GREATER
                _channel?.Close();
#endif
                _isDisposed = true;
            }
        }

        private sealed class WiFiDirectActionListener : Java.Lang.Object, WifiP2pManager.IActionListener
        {
            private readonly TaskCompletionSource<bool> _tcs;

            public WiFiDirectActionListener(TaskCompletionSource<bool> tcs)
            {
                ArgumentNullException.ThrowIfNull(tcs, nameof(tcs));
                _tcs = tcs;
            }

            public void OnSuccess()
            {
                _tcs.TrySetResult(true);
            }

            public void OnFailure(WifiP2pFailureReason reason)
            {
                _tcs.TrySetException(new Exception($"Wi-Fi Direct discovery failed with reason: {reason}"));
            }
        }
    }
}