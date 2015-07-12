using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLoan.BL
{
    public class CashReleaseUnit
    {
        public string DocNum { get; set; }
        public string ReleaseNo { get; set; }        
        public string TypeOfPayment { get; set; }
        public string SourceOfFund { get; set; }
        public string ChequeNo { get; set; }
        public double Amount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }

    }
}
