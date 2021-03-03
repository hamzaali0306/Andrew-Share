using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_DAL.ViewModel;

namespace Test_DAL.Interface
{
    interface IPaymentProcess
    {
        int IExpensivePaymentGateway(ProcessPaymentVM ObjVm);
        int ICheapPaymentGateway(ProcessPaymentVM ObjVm);
        int IPremiumPaymentService(ProcessPaymentVM ObjVm);
    }
}
