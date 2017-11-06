package md59bd45d89d7d0c8a32a0c15cd36ed1109;


public class AppNumberSelectorRenderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.ViewRenderer_2
	implements
		mono.android.IGCUserPeer,
		android.widget.NumberPicker.OnValueChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onValueChange:(Landroid/widget/NumberPicker;II)V:GetOnValueChange_Landroid_widget_NumberPicker_IIHandler:Android.Widget.NumberPicker/IOnValueChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("UlziUI.Droid.Renderers.AppNumberSelectorRenderer, UlziUI.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AppNumberSelectorRenderer.class, __md_methods);
	}


	public AppNumberSelectorRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == AppNumberSelectorRenderer.class)
			mono.android.TypeManager.Activate ("UlziUI.Droid.Renderers.AppNumberSelectorRenderer, UlziUI.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public AppNumberSelectorRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == AppNumberSelectorRenderer.class)
			mono.android.TypeManager.Activate ("UlziUI.Droid.Renderers.AppNumberSelectorRenderer, UlziUI.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public AppNumberSelectorRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == AppNumberSelectorRenderer.class)
			mono.android.TypeManager.Activate ("UlziUI.Droid.Renderers.AppNumberSelectorRenderer, UlziUI.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void onValueChange (android.widget.NumberPicker p0, int p1, int p2)
	{
		n_onValueChange (p0, p1, p2);
	}

	private native void n_onValueChange (android.widget.NumberPicker p0, int p1, int p2);

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
