using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace eLoan.BL
{
    public class BorrowerManager:ConnectionManager
    {
        public void AddBorrower(BorrowerUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_INSERT_BORROWER";
            oCommand.Parameters.Add(new SqlParameter("@CardType", oUnit.CardType));
            oCommand.Parameters.Add(new SqlParameter("@BorrowerCode", oUnit.BorrowerCode));
            oCommand.Parameters.Add(new SqlParameter("@LastName", oUnit.LastName));
            oCommand.Parameters.Add(new SqlParameter("@FirstName", oUnit.FirstName));
            oCommand.Parameters.Add(new SqlParameter("@MiddleName", oUnit.MiddleName));
            oCommand.Parameters.Add(new SqlParameter("@Address", oUnit.Address));
            oCommand.Parameters.Add(new SqlParameter("@ContactNumber", oUnit.ContactNumber));
            oCommand.Parameters.Add(new SqlParameter("@Employer", oUnit.Employer));
            oCommand.Parameters.Add(new SqlParameter("@GuarantorID", oUnit.GuarantorID));
            oCommand.Parameters.Add(new SqlParameter("@GuarantorName", oUnit.GuarantorName));
            oCommand.Parameters.Add(new SqlParameter("@ATMNo", oUnit.ATMNo));
            oCommand.Parameters.Add(new SqlParameter("@EmploymentStatus", oUnit.EmploymentStatus));
            oCommand.Parameters.Add(new SqlParameter("@EffectiveDate", oUnit.EffectiveDate));
            oCommand.Parameters.Add(new SqlParameter("@FrequencyOfPayment", oUnit.FrequencyOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@InterestRate", oUnit.InterestRate));
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.PayDayCode));
            oCommand.Parameters.Add(new SqlParameter("@MortgageInfo", oUnit.MortgageInfo));
            oCommand.Parameters.Add(new SqlParameter("@CreditLimit", oUnit.CreditLimit));

            oCommand.ExecuteNonQuery();

        }

        public void UpdateBorrower(BorrowerUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_UPDATE_BORROWER";
            oCommand.Parameters.Add(new SqlParameter("@CardType", oUnit.CardType));
            oCommand.Parameters.Add(new SqlParameter("@BorrowerCode", oUnit.BorrowerCode));
            oCommand.Parameters.Add(new SqlParameter("@LastName", oUnit.LastName));
            oCommand.Parameters.Add(new SqlParameter("@FirstName", oUnit.FirstName));
            oCommand.Parameters.Add(new SqlParameter("@MiddleName", oUnit.MiddleName));
            oCommand.Parameters.Add(new SqlParameter("@Address", oUnit.Address));
            oCommand.Parameters.Add(new SqlParameter("@ContactNumber", oUnit.ContactNumber));
            oCommand.Parameters.Add(new SqlParameter("@Employer", oUnit.Employer));
            oCommand.Parameters.Add(new SqlParameter("@GuarantorID", oUnit.GuarantorID));
            oCommand.Parameters.Add(new SqlParameter("@GuarantorName", oUnit.GuarantorName));
            oCommand.Parameters.Add(new SqlParameter("@ATMNo", oUnit.ATMNo));
            oCommand.Parameters.Add(new SqlParameter("@EmploymentStatus", oUnit.EmploymentStatus));
            oCommand.Parameters.Add(new SqlParameter("@EffectiveDate", oUnit.EffectiveDate));
            oCommand.Parameters.Add(new SqlParameter("@InterestRate", oUnit.InterestRate));
            oCommand.Parameters.Add(new SqlParameter("@FrequencyOfPayment", oUnit.FrequencyOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.PayDayCode));
            oCommand.Parameters.Add(new SqlParameter("@MortgageInfo", oUnit.MortgageInfo));
            oCommand.Parameters.Add(new SqlParameter("@CreditLimit", oUnit.CreditLimit));

            oCommand.ExecuteNonQuery();

        }

        public DataTable SearchBorrowersInfo(string sCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT *, LastName + ', ' + FirstName + ' ' + MiddleName FullName FROM M_BORROWERINFO WHERE FirstName LIKE @SearchItem OR LastName LIKE @SearchItem";
            oCommand.Parameters.Add(new SqlParameter("@SearchItem", "%" + sCode.Trim() + "%"));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);

            return dtLineItems;
        }
        public DataTable GetBorrowersRecord()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_GET_BORROWERSINFO";
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            return dtLineItems;
        }

        public DataTable GetBorrowersRecord(string sCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_BORROWERINFO WHERE BorrowerCode=@BorrowerCode";
            oCommand.Parameters.Add(new SqlParameter("BorrowerCode", sCode));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            return dtLineItems;
        }

        public bool isBorrowerCodeExists(string sCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_BORROWERINFO WHERE BorrowerCode=@BorrowerCode";
            oCommand.Parameters.Add(new SqlParameter("BorrowerCode", sCode));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            int iCount = dtLineItems.Rows.Count;
            if (iCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

