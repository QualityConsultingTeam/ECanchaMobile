namespace EC.Client.Core.DocumentResponse
{
    using System;

    public class Booking : TrackedEntity
    {

        public Booking()
        {
            CreateDate = DateTime.Now;
            CreateTime = DateTime.Now.Hour;
            Start = DateTime.Now;
            End = DateTime.Now;
            OBJECTTYPE = "1";
        }
         
        public Guid Userid { get; set; }

        public int? Idcancha { get; set; }

        public DateTime? Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public string Invoice { get; set; }
        
        public BookingStatus Status { get; set; }
        
        public decimal? Price { get; set; }
        
        public decimal? DownPayment { get; set; }
        
        public bool? HasDownpay { get; set; }
        
        public decimal? Pending { get; set; }
        
        public string Team1 { get; set; }
        
        public string Team2 { get; set; }
        
        public DateTime CreateDate { get; set; }

        public int? CreateTime { get; set; }
        
        public byte[] RowVersion { get; set; }
        
        public BookingType Type { get; set; }
        
        public string OBJECTTYPE { get; set; }
      
        public bool Isbusy
        {
            get { return Id > 0; }
        }

        public bool IsNearTo
        {
            get
            {
                if (!Start.HasValue) return false;
                var date = DateTime.Now;
                TimeSpan time = Start.Value - date;

                return time.Hours == 0 && time.Minutes < 30;
            }
        }
        

    }
}