using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_DAL.ViewModel;

namespace Test_DAL.Repository
{
    public class ProcessPaymentDataBaseRepo:DbContext
    {
        public DbSet<ProcessPaymentVM> tbl_ProcessPayment { get; set; }
    }
}
