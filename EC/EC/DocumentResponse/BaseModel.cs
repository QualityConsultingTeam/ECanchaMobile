

namespace EC.Client.Core.DocumentResponse
{
    using System;
    using System.Collections.Generic;

    public class BaseModel
    {
        
        public int Id { get; set; }
    }

    public class TrackedEntity : BaseModel
    {

        public TrackedEntity()
        {

        }

        
        public virtual Guid UserSign { get; set; }


    }
}