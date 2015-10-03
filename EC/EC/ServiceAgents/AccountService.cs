using EC.DocumentResponse;
using EC.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EC.ServiceAgents
{
    internal class AccountService : BaseRequest, IAccountService
    {
        //por defecto 
        public AccountService(string urlPrefix, string securityToken)
            : base(urlPrefix, securityToken)
        {

        }
        
        //devuelve cliente http
        private HttpClient GetHttpClient(string token = null)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://enlacancha-api.azurewebsites.net");

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }


        //login
        public async Task<Login> Login(string Email, string Password, bool RefreshToken)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
             new KeyValuePair<string, string>( "grant_type", "password" ),
             new KeyValuePair<string, string>( "username", Email ),
             new KeyValuePair<string, string> ( "Password", Password )
            };

            var content = new FormUrlEncodedContent(pairs);

            using (var client = GetHttpClient())
            {
                var response = await client.PostAsync("Token", content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Login>(token);
                }
                else
                {
                    return new Login { ErrorDescription = "Usuario invalido." };
                }
            }
            return null;
        }


        //register
        public Task<bool> Register(string Email, string Password, bool RefreshToken)
        {
            throw new NotImplementedException();
        }
    }
}

