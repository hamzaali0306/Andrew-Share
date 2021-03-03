using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test_DAL.Repository;
using Test_DAL.Utilities;
using Test_DAL.ViewModel;

namespace Test_WebApi.Controllers
{
    [RoutePrefix("api/payment")]
    public class PaymentController : ApiController
    {
        ProcessPaymentRepo _objProcessPaymentRepo = new ProcessPaymentRepo();
        #region ProcessPayment
        [Route("processpayment")]
        [HttpPost]
        public PaymentState ProcessPayment(string creditCardNumber, string cardHolder, DateTime expirationDate,string securityCode,decimal amount)
        {
            try
            {
                int val = 0;
                PaymentState objPaymentStateClass = new PaymentState();
                if(!string.IsNullOrEmpty(creditCardNumber) && !string.IsNullOrEmpty(cardHolder) && expirationDate!=null && amount!=null)
                {
                    if(CardValidation.ValidateCreditCard(creditCardNumber))
                    {
                        if(amount>0)
                        {
                            var yesterday = DateTime.Today.AddDays(-1);
                            if (expirationDate>=yesterday)
                            {
                                var gData = new ProcessPaymentVM
                                {
                                    CreditCardNumber = creditCardNumber,
                                    CardHolder = cardHolder,
                                    Amount = amount,
                                    ExpirationDate = expirationDate,
                                    SecurityCode = securityCode
                                };

                                if (amount<=20)
                                {
                                     val = _objProcessPaymentRepo.ICheapPaymentGateway(gData);
                                }else if(amount>=21 && amount<=500)
                                {
                                    val = _objProcessPaymentRepo.IExpensivePaymentGateway(gData);
                                }
                                else
                                {
                                    val = _objProcessPaymentRepo.IPremiumPaymentService(gData);
                                }
                                if(val>0)
                                {
                                    objPaymentStateClass.processed = "- Payment is processed";
                                    objPaymentStateClass.retrn = "200 OK";
                                }else
                                {
                                    objPaymentStateClass.failed = "error";
                                    objPaymentStateClass.retrn = "500 internal server error";
                                }
                            }
                            else
                            {
                                objPaymentStateClass.failed = "cannot be enter past date";
                                objPaymentStateClass.retrn = "The request is invalid: 400 bad request";
                            }

                        }else
                        {
                            objPaymentStateClass.failed = "Enter positive amount";
                            objPaymentStateClass.retrn = "The request is invalid: 400 bad request";
                        }

                    }else
                    {
                        var g = CardValidation.ValidateCreditCard(creditCardNumber);
                        objPaymentStateClass.failed = "The Credit Card Number is invalid";
                        objPaymentStateClass.retrn = "The request is invalid: 400 bad request";
                    }
                }else
                {
                    objPaymentStateClass.failed = "Fill All Fields";
                    objPaymentStateClass.retrn = "Error";
                }
                return objPaymentStateClass;
            }
            catch (Exception ex)
            {
                return new PaymentState { failed = "Exception :"+ex.Message, retrn = "Any error: 500 internal server error" };
            }
        }

        #endregion

    }
}
