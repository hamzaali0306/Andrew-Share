using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DAL.ViewModel
{
    public class ProcessPaymentVM
    {
        [Key]
        public int ID { get; set; }
        public string CreditCardNumber { get; set; } = string.Empty;
        public string CardHolder { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }=("1/1/1900").ToDateTime();
        public string SecurityCode { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string GateWay { get; set; } = string.Empty;
    }
}
