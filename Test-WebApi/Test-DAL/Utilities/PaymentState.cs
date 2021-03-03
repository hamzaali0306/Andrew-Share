using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DAL.Utilities
{
    public class PaymentState
    {
        public string pending { get; set; } = string.Empty;
        public string processed { get; set; } = string.Empty;
        public string failed { get; set; } = string.Empty;
        public dynamic retrn { get; set; } = string.Empty;
    }
}
