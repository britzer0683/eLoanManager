using System;
using System.Data;
using System.Data.SqlClient;
namespace eLoan.BL
{
    public class CashReleaseManager:ConnectionManager
    {
        public void AddCashRelease(CashReleaseUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "INSERT INTO OCR (ReleaseNo, RefLoanNo, TypeOfPayment, SourceOfFund, ChequeNo, Amount, DateCreated, CreatedBy, DateModified, ModifiedBy) VALUES (@ReleaseNo, @RefLoanNo, @TypeOfPayment, @SourceOfFund, @ChequeNo, @Amount, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)";
            oCommand.Parameters.Add(new SqlParameter("@ReleaseNo", oUnit.ReleaseNo));
            oCommand.Parameters.Add(new SqlParameter("@RefLoanNo", oUnit.RefLoanNo));
            oCommand.Parameters.Add(new SqlParameter("@TypeOfPayment", oUnit.TypeOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@SourceOfFund", oUnit.SourceOfFund));
            oCommand.Parameters.Add(new SqlParameter("@ChequeNo", oUnit.ChequeNo));
            oCommand.Parameters.Add(new SqlParameter("@Amount", oUnit.Amount));
            oCommand.Parameters.Add(new SqlParameter("@DateCreated", oUnit.DateCreated));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", oUnit.CreatedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));

            oCommand.ExecuteNonQuery();
        }

        public void UpdateCashRelease(CashReleaseUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "UPDATE OCR SET RefLoanNo=@RefLoanNo, TypeOfPayment=@TypeOfPayment, SourceOfFund=@SourceOfFund, ChequeNo=@ChequeNo, Amount=@Amount, DateModified=@DateModified, ModifiedBy=@ModifiedBy WHERE ReleaseNo=@ReleaseNo";
            oCommand.Parameters.Add(new SqlParameter("@ReleaseNo", oUnit.ReleaseNo));
            oCommand.Parameters.Add(new SqlParameter("@RefLoanNo", oUnit.RefLoanNo));
            oCommand.Parameters.Add(new SqlParameter("@TypeOfPayment", oUnit.TypeOfPayment));
            oCommand.Parameters.Add(new SqlParameter("@SourceOfFund", oUnit.SourceOfFund));
            oCommand.Parameters.Add(new SqlParameter("@ChequeNo", oUnit.ChequeNo));
            oCommand.Parameters.Add(new SqlParameter("@Amount", oUnit.Amount));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));

            oCommand.ExecuteNonQuery();
        }

        public bool IsExists(string sReleaseNo)
        {
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            SqlCommand oCommand = new SqlCommand();
            DataTable dt = new DataTable();

            oCommand.Connection = this.Connection;

            oCommand.CommandText = "SELECT * FROM OCR Where ReleaseNo=@ReleaseNo";
            oCommand.Parameters.Add(new SqlParameter("@ReleaseNo", sReleaseNo));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            return dt.Rows.Count >= 1 ? true : false;
        }

        public void CancelDocument(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "UPDATE OCR SET DocStatus='Canceled' WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oCommand.ExecuteNonQuery();
        }
        public void PostDocument(string sDocNum)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "UPDATE OCR SET DocStatus='Posted' WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oCommand.ExecuteNonQuery();
        }
        public DataTable GetInfo(string sRefLoanNo)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLoanInfo = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM OCR WHERE RefLoanNo=@RefLoanNo";
            oCommand.Parameters.Add(new SqlParameter("@RefLoanNo", sRefLoanNo));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLoanInfo);

            return dtLoanInfo;

        }

        public DataTable GetCashReleased(DateTime dFrom, DateTime dTo)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_CASH_RELEASED";
            oCommand.Parameters.Add(new SqlParameter("@FROM", dFrom));
            oCommand.Parameters.Add(new SqlParameter("@TO", dTo));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            return dt;

        }

    }
}
