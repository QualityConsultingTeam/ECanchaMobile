using System;

namespace EC.Model
{
    public class LocationCalculatedEventArgs : EventArgs
    {
        public Location CalculatedLocation { get; private set; }
        
        public LocationCalculatedEventArgs(Location location)
        {
            CalculatedLocation = location;
        }
    }
}
