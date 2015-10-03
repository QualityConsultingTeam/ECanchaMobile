using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Test
{
    /// <summary>
    /// Summary description for RolesTest
    /// </summary>
    [TestClass]
    public class RolesTest
    {
        public RolesTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        
        private HttpClient GetHttpClient(string token = null)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://enlacancha-api.azurewebsites.net");

            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }


        private async Task<LoginTokenResult> GetLoginToken(string username, string password)
        {


            var pairs = new List<KeyValuePair<string, string>>
            {
             new KeyValuePair<string, string>( "grant_type", "password" ),
             new KeyValuePair<string, string>( "username", username ),
             new KeyValuePair<string, string> ( "Password", password )
            };

            var content = new FormUrlEncodedContent(pairs);

            using (var client = GetHttpClient())
            {
                var response = await client.PostAsync( "Token", content);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    return    JsonConvert.DeserializeObject<LoginTokenResult>(token);
                }
                else
                {
                    return  new LoginTokenResult { ErrorDescription = "Usuario invalido."};
                }
            }
            return null;
        }

        [TestMethod]
        public void LoginTest   ()
        {

            var token = GetLoginToken("admin@yopmail.com", "1234567").Result;
           
            Assert.IsNotNull(token);
            
        }

       
            
    }

    public class LoginTokenResult
    {
        public override string ToString()
        {
            return AccessToken;
        }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

    }
}
