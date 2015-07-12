using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace eLoan.BL
{
    public class LoanManager:ConnectionManager
    {
        public bool IsExists(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLoanInfo = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM OLOAN WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLoanInfo);

            return dtLoanInfo.Rows.Count >= 1 ? true : false;

        }
        public void CloseDocument(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "UPDATE OLOAN SET DocStatus='Closed' WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oCommand.ExecuteNonQuery();
        }
        public void CancelDocument(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "UPDATE OLOAN SET DocStatus='Canceled' WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oCommand.ExecuteNonQuery();
        }

        public void Approved(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "UPDATE OLOAN SET DocStatus='Approved' WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oCommand.ExecuteNonQuery();
        }
        public void PostDocument(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();
            
            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "UPDATE OLOAN SET DocStatus='Posted' WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oCommand.ExecuteNonQuery();
        }
        public DataTable GetLoanInfo(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLoanInfo = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM OLOAN WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLoanInfo);

            return dtLoanInfo;

        }

        public DataTable GetLoanInfoLineItems(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLoanInfo = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM LOAN1 WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLoanInfo);

            return dtLoanInfo;

        }
        public void DeleteLineItems(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;

            oCommand.CommandText = "DELETE FROM LOAN1 WHERE DocNum=@DocNum";

            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));
            oCommand.ExecuteNonQuery();
            
        }
        public void AddLineItems(string sDocNum, DataTable dtLines)
        {
            SqlCommand oCommand = new SqlCommand();

            
            foreach (DataRow oRow in dtLines.Rows)
            {
                if (oRow.RowState != DataRowState.Deleted)
                {
                    oCommand = new SqlCommand();
                    oCommand.Connection = this.Connection;
                    oCommand.CommandText = "INSERT INTO LOAN1 (DocNum, ScheduleNo, PaymentAmount, ScheduledDate, PrincipalReduction, InterestAmount, PaidAmount) VALUES (@DocNum, @ScheduleNo, @PaymentAmount, @ScheduledDate, @PrincipalReduction, @InterestAmount, @PaidAmount)";
                    oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));
                    oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", oRow["ScheduleNo"].ToString()));
                    oCommand.Parameters.Add(new SqlParameter("@PaymentAmount", string.Format("{0}", oRow["PaymentAmount"]).Replace(",","")));
                    oCommand.Parameters.Add(new SqlParameter("@ScheduledDate", oRow["ScheduledDate"].ToString()));
                    oCommand.Parameters.Add(new SqlParameter("@PrincipalReduction", string.Format("{0}", oRow["PrincipalReduction"]).Replace(",", "")));
                    oCommand.Parameters.Add(new SqlParameter("@InterestAmount", string.Format("{0}", oRow["InterestAmount"]).Replace(",", "")));
                    //PaidAmount
                    oCommand.Parameters.Add(new SqlParameter("@PaidAmount", string.Format("{0}", oRow["PaidAmount"]).Replace(",", "")));

                    oCommand.ExecuteNonQuery();
                }
            }
        }
        public void AddLoan(LoanUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
       
            oCommand.CommandText = "SP_INSERT_LOAN";
            
            oCommand.Parameters.Add(new SqlParameter("@DocNum", oUnit.DocumentNumber));
            oCommand.Parameters.Add(new SqlParameter("@CardCode", oUnit.CardCode));
            oCommand.Parameters.Add(new SqlParameter("@CardName", oUnit.CardName));
            oCommand.Parameters.Add(new SqlParameter("@TransType", oUnit.TransactionType));
            oCommand.Parameters.Add(new SqlParameter("@ModeOfPayment", oUnit.ModeOfPayment != null ? oUnit.ModeOfPayment : ""));
            oCommand.Parameters.Add(new SqlParameter("@Guarrantor", oUnit.Guarantor));
            oCommand.Parameters.Add(new SqlParameter("@LoanAmount", oUnit.LoanAmount));
            oCommand.Parameters.Add(new SqlParameter("@Terms", oUnit.Terms));
            oCommand.Parameters.Add(new SqlParameter("@InterestRate", oUnit.InterestRate));
            oCommand.Parameters.Add(new SqlParameter("@FreqOfPayment", oUnit.FrequencyOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.PayDayCode));
            oCommand.Parameters.Add(new SqlParameter("@FirstPaymentDate", oUnit.FirstDateOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@DateOfReleasing", oUnit.ReleaseDate));
            oCommand.Parameters.Add(new SqlParameter("@MonthlyPayment", oUnit.MonthlyPayment));
            oCommand.Parameters.Add(new SqlParameter("@NoOfPayment", oUnit.NumberOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@TotalAmortization", oUnit.TotalAmortization));
            oCommand.Parameters.Add(new SqlParameter("@TotalInterest", oUnit.TotalInterest));
            oCommand.Parameters.Add(new SqlParameter("@DocStatus", oUnit.DocumentStatus));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", oUnit.CreatedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateCreated", oUnit.DateCreated));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));

            oCommand.ExecuteNonQuery();

        }
        public void UpdateLoan(LoanUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;

            oCommand.CommandText = "SP_UPDATE_LOAN";

            oCommand.Parameters.Add(new SqlParameter("@DocNum", oUnit.DocumentNumber));
            oCommand.Parameters.Add(new SqlParameter("@CardCode", oUnit.CardCode));
            oCommand.Parameters.Add(new SqlParameter("@CardName", oUnit.CardName));
            oCommand.Parameters.Add(new SqlParameter("@TransType", oUnit.TransactionType));
            oCommand.Parameters.Add(new SqlParameter("@ModeOfPayment", oUnit.ModeOfPayment == null ? "" : oUnit.ModeOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@Guarrantor", oUnit.Guarantor));
            oCommand.Parameters.Add(new SqlParameter("@LoanAmount", oUnit.LoanAmount));
            oCommand.Parameters.Add(new SqlParameter("@Terms", oUnit.Terms));
            oCommand.Parameters.Add(new SqlParameter("@InterestRate", oUnit.InterestRate));
            oCommand.Parameters.Add(new SqlParameter("@FreqOfPayment", oUnit.FrequencyOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.PayDayCode));
            oCommand.Parameters.Add(new SqlParameter("@FirstPaymentDate", oUnit.FirstDateOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@DateOfReleasing", oUnit.ReleaseDate));
            oCommand.Parameters.Add(new SqlParameter("@MonthlyPayment", oUnit.MonthlyPayment));
            oCommand.Parameters.Add(new SqlParameter("@NoOfPayment", oUnit.NumberOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@TotalAmortization", oUnit.TotalAmortization));
            oCommand.Parameters.Add(new SqlParameter("@TotalInterest", oUnit.TotalInterest));
            oCommand.Parameters.Add(new SqlParameter("@DocStatus", oUnit.DocumentStatus));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));

            oCommand.ExecuteNonQuery();

        }
        
        public DataTable GetLoans()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            DataTable dt = new DataTable();
            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;

            oCommand.CommandText = "SELECT *, (SELECT CASE WHEN SUM(Amount) is NULL then 0 else SUM(Amount) end FROM LOAN3 WHERE LOAN3.DocNum=OLOAN.DocNum) as CashReleased FROM OLOAN";

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            return dt;

        }
    }
}

