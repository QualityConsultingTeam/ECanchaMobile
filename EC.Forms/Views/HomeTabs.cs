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

			var createFeedToolbarItem = new ToolbarItem()
			{
				Icon = "ic_location_searching_black_24dp.png",
				Text = "Edit",
			};
			//createFeedToolbarItem.SetBinding(ToolbarItem.CommandProperty, "CreateFeedCommand");
			this.ToolbarItems.Add(createFeedToolbarItem);



            var fields = new FieldView();
            fields.Title = "Canchas";

            var centers = new Centers();
            centers.Title = "Complejos";
            
            

            this.Children.Add(fields);
            this.Children.Add(centers);   

        }
    }
}
