using Android.Net.Wifi.P2p;

public class WiFiDirectService
{
    private WifiP2pManager _manager;
    private WifiP2pManager.Channel _channel;

    public WiFiDirectService()
    {
        _manager = WifiP2pManager.Create(MainActivity.Instance);
        _channel = _manager.Initialize(MainActivity.Instance, MainLooper, null);
    }

    public async Task DiscoverPeers()
    {
        var tcs = new TaskCompletionSource<bool>();
        _manager.DiscoverPeers(_channel, new ActionListener(tcs));
        await tcs.Task;
    }

    class ActionListener : Java.Lang.Object, WifiP2pManager.IActionListener
    {
        private TaskCompletionSource<bool> _tcs;
        public ActionListener(TaskCompletionSource<bool> tcs) => _tcs = tcs;
        public void OnSuccess() => _tcs.SetResult(true);
        public void OnFailure(int reason) => _tcs.SetException(new Exception($"Failed: {reason}"));
    }
}
