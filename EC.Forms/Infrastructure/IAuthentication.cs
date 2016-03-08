using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace EC.Forms.Infrastructure
{
	public interface IAuthentication
	{
		Task<MobileServiceUser> DisplayWebView();

		void ClearCookies();
	}
}