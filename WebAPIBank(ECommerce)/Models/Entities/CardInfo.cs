﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIBank_ECommerce_.Models.Entities
{
    public class CardInfo:BaseEntity
    {
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set;}
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }

    }
}