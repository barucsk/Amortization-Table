using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Months;

namespace ClassPayment
{
    internal class Payment
    {
        internal int NMonth { get; set; }
        internal Month Month { get; set; }
        internal decimal Balance { get; set; }
        internal decimal Interest { get; set; }
        internal decimal SDAV { get; set; }
        internal decimal FDPDP { get; set; }
        internal decimal CA { get; set; }
        internal decimal MonthlyPayment { get; set; }
        internal decimal Pattern { get; set; }
        internal decimal NewBalance { get; set; }
    }
}
