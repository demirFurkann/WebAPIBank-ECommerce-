using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIBank_ECommerce_.Models.Entities;
using WebAPIBank_ECommerce_.Models.Init;

namespace WebAPIBank_ECommerce_.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());

        }

        public DbSet<CardInfo> Cards{ get; set; }
    }
}