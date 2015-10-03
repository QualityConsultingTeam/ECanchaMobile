using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.DocumentResponse
{
    public class Login : TrackedEntity
    {
        public override string ToString()
        {
            return access_token;
        }

        
        public string access_token { get; set; }
        
        public string Error { get; set; }
        
        public string ErrorDescription { get; set; }

    }
}
