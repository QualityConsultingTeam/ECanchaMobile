using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EC.Infrastructure.Abstractions;

namespace EC.Droid.Renders
{
    //public class Authentication : IAuthentication
    //{
    //    public async Task<MobileServiceUser> DisplayWebView()
    //    {
    //        try
    //        {
    //            return await AzureService.Instance.Client.LoginAsync(Forms.Context, MobileServiceAuthenticationProvider.Google);
    //        }
    //        catch (Exception e)
    //        {
    //            InsightsManager.Report(e);
    //        }

    //        return null;
    //    }

    //    public void ClearCookies()
    //    {
    //        global::Android.Webkit.CookieManager.Instance.RemoveAllCookies(null);
    //    }
    //}
}