package md5655fbaa54d1fe8c5c8fe72cef6486bd8;


public class NavBarMagicOnGlobalLayoutListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnGlobalLayoutListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGlobalLayout:()V:GetOnGlobalLayoutHandler:Android.Views.ViewTreeObserver/IOnGlobalLayoutListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("BottomNavigationBar.Listeners.NavBarMagicOnGlobalLayoutListener, BottomNavigationBar, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null", NavBarMagicOnGlobalLayoutListener.class, __md_methods);
	}


	public NavBarMagicOnGlobalLayoutListener ()
	{
		super ();
		if (getClass () == NavBarMagicOnGlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Listeners.NavBarMagicOnGlobalLayoutListener, BottomNavigationBar, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public NavBarMagicOnGlobalLayoutListener (md55df38b2a7c6090d13d1b5301e673d9ed.BottomBar p0, android.view.View p1, int p2, boolean p3, boolean p4)
	{
		super ();
		if (getClass () == NavBarMagicOnGlobalLayoutListener.class)
			mono.android.TypeManager.Activate ("BottomNavigationBar.Listeners.NavBarMagicOnGlobalLayoutListener, BottomNavigationBar, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null", "BottomNavigationBar.BottomBar, BottomNavigationBar, Version=1.4.0.2, Culture=neutral, PublicKeyToken=null:Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Boolean, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public void onGlobalLayout ()
	{
		n_onGlobalLayout ();
	}

	private native void n_onGlobalLayout ();

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
