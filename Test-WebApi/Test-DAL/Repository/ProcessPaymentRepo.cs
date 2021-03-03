using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_DAL.Interface;
using Test_DAL.ViewModel;

namespace Test_DAL.Repository
{
   public class ProcessPaymentRepo:IPaymentProcess
    {
        public int ICheapPaymentGateway(ProcessPaymentVM ObjVm)
        {
            try
            {
              int val = Insert(ObjVm, "ICheapPaymentGateway");
              return val;
            }
            catch { return 0; }
        }

        public int IExpensivePaymentGateway(ProcessPaymentVM ObjVm)
        {
            try
            {
                int val = Insert(ObjVm, "IExpensivePaymentGateway");
                return val;
            }
            catch { return 0; }
        }

        public int IPremiumPaymentService(ProcessPaymentVM ObjVm)
        {
            try
            {
                int val = Insert(ObjVm, "IPremiumPaymentService");
                return val;
            }
            catch { return 0; }
        }
        public int Insert(ProcessPaymentVM ObjVm,string GateWay)
        {
            try
            {
                    int ret = 0;
                    using (var context = new ProcessPaymentDataBaseRepo())
                    {
                        var res = new ProcessPaymentVM()
                        {
                            CreditCardNumber=ObjVm.CreditCardNumber, 
                            CardHolder= ObjVm.CardHolder,
                            ExpirationDate= ObjVm.ExpirationDate, 
                            SecurityCode= ObjVm.SecurityCode, 
                            Amount= ObjVm.Amount,
                            GateWay=GateWay 
                        };
                        context.tbl_ProcessPayment.Add(res);
                        context.SaveChanges();
                        ret = 1; 
                        return ret;
                    }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
