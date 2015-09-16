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
using System.Runtime.CompilerServices;
using EC.Infrastructure.Abstractions.Services;
using EC.Droid.Infraestructure;
using EC.Model;
using Android.Locations;

//[assembly: Dependency(typeof(LocationService))]
namespace EC.Droid.Infraestructure
{
    //public class LocationService : ISimpleLocationService
    //{
    //    public Location CalculateLocation()
    //    {
    //        //var  _locationManager = (LocationManager)GetSystemService(LocationService);
    //        //  Criteria criteriaForLocationService = new Criteria
    //        //  {
    //        //      Accuracy = Accuracy.Fine
    //        //  };
    //        //  IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

    //        //  if (acceptableLocationProviders.Any())
    //        //  {
    //        //      _locationProvider = acceptableLocationProviders.First();
    //        //  }
    //        //  else
    //        //  {
    //        //      _locationProvider = String.Empty;
    //        //  }

    //       Thow
    //        //return new EC.Model.Location();
    //    }
    //}
}