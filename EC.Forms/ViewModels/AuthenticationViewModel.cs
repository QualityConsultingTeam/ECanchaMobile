using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Forms.ViewModels
{
    public  class AuthenticationViewModel
    {
        //async Task ShowGoogleAuthenticationView()
        //{
        //    if (App.AuthToken != null && Settings.Instance.User != null)
        //    {
        //        var success = await GetUserProfile();

        //        if (success)
        //        {
        //            AzureService.Instance.Client.CurrentUser = Settings.Instance.User;
        //            return;
        //        }
        //    }

        //    try
        //    {
        //        AuthenticationStatus = "Loading...";
        //        MobileServiceUser user = await _authenticator.DisplayWebView();

        //        var identity = await AzureService.Instance.Client.InvokeApiAsync("getUserIdentity", null, HttpMethod.Get, null);

        //        App.AuthToken = identity.Value<string>("accessToken");
        //        Utility.SetSecured("AuthToken", App.AuthToken, "xamarin.sport", "authentication");

        //        Settings.Instance.User = user;
        //        await Settings.Instance.Save();

        //        if (App.CurrentAthlete != null && App.CurrentAthlete.Id != null)
        //        {
        //            var task = AzureService.Instance.SaveAthlete(App.CurrentAthlete);
        //            await RunSafe(task);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("**SPORT AUTHENTICATION ERROR**\n\n" + e.GetBaseException());
        //        InsightsManager.Report(e);
        //    }
        //}
    }
}
