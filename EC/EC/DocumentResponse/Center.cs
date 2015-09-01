using System;

namespace EC.DocumentResponse
{
    public class Center : BaseModel
    {
        public Center()
        {
            CreateDate = DateTime.Now;
            CreateTime = DateTime.Now.Hour;
        }

       public string Name { get; set; }
        
        public string Type { get; set; }
        
        public string FieldPicure { get; set; }
        
        public string Location { get; set; }
        
        //public DbGeography Coordinates { get; set; }
        
        public string Description { get; set; }
        
        public int? Town { get; set; }
        
        public int? Department { get; set; }
        
        public int? Country { get; set; }
         
        public string Neighborhood { get; set; }
         
        public string Administrator { get; set; }
 
        public string Personcontact { get; set; }
         
        public string Phone1 { get; set; }
 
        public string Phone2 { get; set; }
 
        public string Email { get; set; }
 
        public int Opentime { get; set; }
         
        public int Closetime { get; set; }
         
        public Status Status { get; set; }
         
        public int? UserSign { get; set; }
 
        public DateTime CreateDate { get; set; }
 
        public int? CreateTime { get; set; }
 
        public string OBJECTTYPE { get; set; }


        //public List<Field> Fields { get; set; }

        //public List<ImageField> ImageField { get; set; }

        ////public List<CenterAccount> Employees { get; set; }

        //public List<Service> Services { get; set; }

        //public List<AccountAccessLevel> AccountAccess { get; set; }


    }
}