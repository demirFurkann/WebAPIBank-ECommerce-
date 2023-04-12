using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIBank_ECommerce_.Models.Context;

namespace WebAPIBank_ECommerce_.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        DBTool() { }

        static MyContext _dbInstance;

        public static MyContext DbInstance
        {
            get
            {
                if (_dbInstance == null) _dbInstance = new MyContext();
                return _dbInstance;
            }
        }
    }
}