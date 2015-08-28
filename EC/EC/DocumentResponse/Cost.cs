
namespace EC.Client.Core.DocumentResponse
{
    using System.Collections.Generic;
    using System;

    public class Cost : BaseModel
    {

        public Cost()
        {
            CreateDate = DateTime.Now;
            CreateTime = DateTime.Now.Hour;
            OBJECTTYPE = "1";

        }
        
        public int? Opentime { get; set; }
        
        public int? Closetime { get; set; }
        
        public decimal? Price { get; set; }
        
        public decimal? DownPayment { get; set; }
        
        public int? Dayofweek { get; set; }
        
        public int? IdCancha { get; set; }
        
        public Guid UserSign { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public int CreateTime { get; set; }
        
        public string OBJECTTYPE { get; set; }

        // public Field Field { get; set; }

        //[ForeignKey("Field")]
        //public int FieldId { get; set; }
    }
}