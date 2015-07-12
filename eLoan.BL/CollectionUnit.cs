using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLoan.BL
{
    public class CollectionUnit
    {
        public string DocNum { get; set; }
        public int ScheduleNo { get; set; }
        public string RefNo { get; set; }
        public string Remarks { get; set; }
        public double TotalBalance { get; set; }
        public double TotalPayment { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
