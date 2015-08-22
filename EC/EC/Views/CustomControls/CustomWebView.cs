using System;
using Xamarin.Forms;

namespace EC.Views
{
	public class CustomWebView : WebView
	{
        public static readonly BindableProperty PdfPathProperty =
          BindableProperty.Create((CustomWebView webView) => webView.PdfPath, string.Empty);

	    public string PdfPath
	    {
	        get { return (string)GetValue(PdfPathProperty); } 
            set{ SetValue(PdfPathProperty, value);}
	    }
	}
}

