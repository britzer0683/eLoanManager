using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressBookUnit
/// </summary>
namespace eLoan.BL
{
    public class BorrowerUnit
    {
        public BorrowerUnit()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string CardType { get; set; } // Employee, Business Man
        public string BorrowerCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Employer { get; set; } // Create a Master File for the Employer List
        public string GuarantorID { get; set; }
        public string GuarantorName { get; set; }
        public string ATMNo { get; set; }
        public string EmploymentStatus { get; set; } //Regular or Contractual
        public DateTime EffectiveDate { get; set; }
        public string InterestRate { get; set; }
        public string InterestDescription { get; set; }
        public string FrequencyOfPayment { get; set; }
        public string PayDayCode { get; set; }
        public string MortgageInfo { get; set; }
        public double CreditLimit { get; set; }

    }
}