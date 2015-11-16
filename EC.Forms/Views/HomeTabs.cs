using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Forms.Views
{
    public class HomeTabs      : TabbedPage
    {

        public HomeTabs()
        {
            this.Title = "En la Cancha Club";

            var fields = new FieldView();
            fields.Title = "Canchas";

            var centers = new Centers();
            centers.Title = "Complejos";

            var login = new LoginView();
            login.Title = "Login";

            this.BackgroundImage = "bggrass.jpg";

            this.Children.Add(fields);
            this.Children.Add(centers);
            this.Children.Add(login);




        }
    }
}
