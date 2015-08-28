
namespace EC.Client.Core.DocumentResponse
{
    using System;
    using System.Collections.Generic;

    public class Field : TrackedEntity
    {

        public Field()
        {

            CreateDate = DateTime.Now;
            CreateTime = DateTime.Now.Hour;
        }

     
        public string Name { get; set; }

        
        public int? CenterId { get; set; }

       
        public FieldType Type { get; set; }
        
        public string Distance { get; set; }
        
        public string Description { get; set; }

        
        public string Comments { get; set; }

        
        public decimal? Length { get; set; }

        
        public decimal? Width { get; set; }

        
        public Lawntypes Lawn { get; set; }

        
        public ShoesTypes Shoes { get; set; }

      
        // given by user from 1 to 5
       
        public decimal? Grade { get; set; }

       
        public Status Status { get; set; }

        
        public DateTime CreateDate { get; set; }

         

        public int? CreateTime { get; set; }

        
        public byte[] RowVersion { get; set; }

       

        public int OBJECTTYPE { get; set; }

        
        public List<Booking> Bookings { get; set; }

        public Cost Cost { get; set; }

        public Center Center { get; set; }



    }
}
