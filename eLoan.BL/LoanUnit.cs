using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLoan.BL
{
    public class LoanUnit
    {
        public string DocumentNumber { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string TransactionType { get; set; }
        public string ModeOfPayment { get; set; }
        public string Guarantor { get; set; }
        public double LoanAmount { get; set; }
        public int Terms { get; set; }
        public double InterestRate { get; set; }
        public string FrequencyOfPayment { get; set; }  //Pay-Day Code
        public string PayDayCode { get; set; }  //Pay-Day Code
        public DateTime FirstDateOfPayment { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double MonthlyPayment { get; set; }
        public int NumberOfPayment { get; set; }
        public double TotalAmortization { get; set; }
        public double TotalInterest { get; set; }

        public string DocumentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }


    }
}
