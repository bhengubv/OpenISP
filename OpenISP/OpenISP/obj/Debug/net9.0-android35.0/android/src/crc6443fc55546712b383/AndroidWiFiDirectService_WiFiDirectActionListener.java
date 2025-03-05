package crc6443fc55546712b383;


public class AndroidWiFiDirectService_WiFiDirectActionListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.net.wifi.p2p.WifiP2pManager.ActionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(I)V:GetOnFailure_IHandler:Android.Net.Wifi.P2p.WifiP2pManager/IActionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onSuccess:()V:GetOnSuccessHandler:Android.Net.Wifi.P2p.WifiP2pManager/IActionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("OpenISP.Services.AndroidWiFiDirectService+WiFiDirectActionListener, OpenISP", AndroidWiFiDirectService_WiFiDirectActionListener.class, __md_methods);
	}

	public AndroidWiFiDirectService_WiFiDirectActionListener ()
	{
		super ();
		if (getClass () == AndroidWiFiDirectService_WiFiDirectActionListener.class) {
			mono.android.TypeManager.Activate ("OpenISP.Services.AndroidWiFiDirectService+WiFiDirectActionListener, OpenISP", "", this, new java.lang.Object[] {  });
		}
	}

	public void onFailure (int p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (int p0);

	public void onSuccess ()
	{
		n_onSuccess ();
	}

	private native void n_onSuccess ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
