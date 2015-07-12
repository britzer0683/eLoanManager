using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLoan.BL
{
    public class CollectionManager:ConnectionManager
    {
        public void AddCollection(CollectionUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "INSERT LOAN2 (DocNum, ScheduledNo, RefNo, Remarks, TotalBalance, TotalPayment, DateCreated, CreatedBy, DateModified, ModifiedBy) VALUES (@DocNum, @ScheduleNo, @RefNo, @Remarks, @TotalBalance, @TotalPayment, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)";

            oCommand.Parameters.Add(new SqlParameter("@DocNum", oUnit.DocNum));
            oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", oUnit.ScheduleNo));
            oCommand.Parameters.Add(new SqlParameter("@RefNo", oUnit.RefNo));
            oCommand.Parameters.Add(new SqlParameter("@Remarks", oUnit.Remarks));
            oCommand.Parameters.Add(new SqlParameter("@TotalBalance", oUnit.TotalBalance));
            oCommand.Parameters.Add(new SqlParameter("@TotalPayment", oUnit.TotalPayment));
            oCommand.Parameters.Add(new SqlParameter("@DateCreated", oUnit.DateCreated));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", oUnit.CreatedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));

            oCommand.ExecuteNonQuery();
        }
        public void UpdateCollection(CollectionUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "UPDATE LOAN2 SET ScheduledNo=@ScheduleNo, RefNo=@RefNo, Remarks=@Remarks, TotalBalance=@TotalBalance, TotalPayment=@TotalPayment, DateCreated=@DateCreated, CreatedBy=@CreatedBy, DateModified=@DateModified, ModifiedBy=@ModifiedBy WHERE DocNum=@DocNum";

            oCommand.Parameters.Add(new SqlParameter("@DocNum", oUnit.DocNum));
            oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", oUnit.ScheduleNo));
            oCommand.Parameters.Add(new SqlParameter("@RefNo", oUnit.RefNo));
            oCommand.Parameters.Add(new SqlParameter("@Remarks", oUnit.Remarks));
            oCommand.Parameters.Add(new SqlParameter("@TotalBalance", oUnit.TotalBalance));
            oCommand.Parameters.Add(new SqlParameter("@TotalPayment", oUnit.TotalPayment));
            oCommand.Parameters.Add(new SqlParameter("@DateCreated", oUnit.DateCreated));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", oUnit.CreatedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));

            oCommand.ExecuteNonQuery();
        }

        public DataTable GetCollection(string LoanNumber)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "SELECT * FROM LOAN2 WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", LoanNumber));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            return dt;
            
        }

        public DataTable GetCollection(DateTime dFrom, DateTime dTo)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_GET_PAYMENTS";
            oCommand.Parameters.Add(new SqlParameter("@FROM", dFrom));
            oCommand.Parameters.Add(new SqlParameter("@TO", dTo));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            return dt;

        }

    }
}
