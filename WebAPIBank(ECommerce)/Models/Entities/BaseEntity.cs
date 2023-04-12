using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBank_ECommerce_.Models.Enums;

namespace WebAPIBank_ECommerce_.Models.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }


        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
      
    }
}