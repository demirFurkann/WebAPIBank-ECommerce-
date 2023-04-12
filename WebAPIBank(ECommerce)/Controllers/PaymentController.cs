using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIBank_ECommerce_.DesignPatterns.SingletonPattern;
using WebAPIBank_ECommerce_.Models.Context;
using WebAPIBank_ECommerce_.Models.Entities;
using WebAPIBank_ECommerce_.RequestModel;
using WebAPIBank_ECommerce_.ResponseModel;

namespace WebAPIBank_ECommerce_.Controllers
{
    public class PaymentController : ApiController
    {
        MyContext _db;
        public PaymentController()
        {
            _db = DBTool.DbInstance;
        }

        //Aşağidaki Bilgi sadece  test içindir...
        //[HttpGet]
        //public List<PaymentResponseModel> GetAll()
        //{
        //    return _db.Cards.Select(x => new PaymentResponseModel
        //    {
        //        CardExpiryMonth = x.CardExpiryMonth,
        //        CardExpiryYear = x.CardExpiryYear,
        //        CardNumber = x.CardNumber,
        //        CardUserName = x.CardUserName,
        //        SecurityNumber = x.SecurityNumber,

        //    }).ToList();
        //}


        [HttpPost]

        public IHttpActionResult ReceivePayment(PaymentRequestModel item)
        {
            CardInfo ci = _db.Cards.FirstOrDefault(x => x.CardNumber == item.CardNumber && x.SecurityNumber == item.SecurityNumber && x.CardUserName == item.CardUserName && x.CardExpiryMonth == item.CardExpiryMonth && x.CardExpiryYear == item.CardExpiryYear);

            if (ci != null)
            {
                if (ci.CardExpiryYear < DateTime.Now.Year)
                {
                    return BadRequest("Expired Card");
                }
                else if (ci.CardExpiryYear== DateTime.Now.Year)
                {
                    if (ci.CardExpiryMonth > DateTime.Now.Month)
                    {
                        return BadRequest("Expired Card(Month)");
                    }
                    if (ci.Balance >= item.ShoppingPrice)
                    {
                        SetBalance(item, ci);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Balance exceeded");
                    }
                }
                else if (ci.Balance >= item.ShoppingPrice)
                {
                    SetBalance(item, ci);
                    return Ok();
                }
                return BadRequest("Balance exceeded");
            }
            return BadRequest("CArd Info Wrong");
        }

        private void SetBalance(PaymentRequestModel item,CardInfo ci)
        {
            ci.Balance -= item.ShoppingPrice;
            _db.SaveChanges();
        }
    }
}
