using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLoan.BL
{
    public class PayDayCodeManager:ConnectionManager
    {
        public void Add(PayDayCodeUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType  = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_INSERT_PAYDAYCODE";
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.Code));
            oCommand.Parameters.Add(new SqlParameter("@Remarks", oUnit.Description));

            oCommand.Parameters.Add(new SqlParameter("@DateCreated", oUnit.DateCreated));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", oUnit.CreatedBy));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));
            oCommand.ExecuteNonQuery();

            foreach (DataRow oRow in oUnit.LineItems.Rows)
            {
                SqlCommand oLineCommand = new SqlCommand();

                oLineCommand.Connection = this.Connection;
                oLineCommand.CommandType = CommandType.StoredProcedure;
                oLineCommand.CommandText = "SP_TRANS_INSERT_PAYDAYCODE_LINES";

                oLineCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.Code));
                oLineCommand.Parameters.Add(new SqlParameter("@Interval", oRow["Interval"].ToString()));
                oLineCommand.Parameters.Add(new SqlParameter("@DayWeekNo", oRow["DayWeekNo"].ToString()));
                oLineCommand.ExecuteNonQuery();
            }
        }

        public void Update(PayDayCodeUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_UPDATE_PAYDAYCODE";
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.Code));
            oCommand.Parameters.Add(new SqlParameter("@Remarks", oUnit.Description));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", oUnit.DateModified));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", oUnit.ModifiedBy));

            SqlCommand oLineCommand = new SqlCommand();

            oLineCommand.Connection = this.Connection;
            oLineCommand.CommandType = CommandType.Text;
            oLineCommand.CommandText = "DELETE M_PAYDAY1 WHERE PayDayCode=@PayDayCode";
            oLineCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.Code));

            oLineCommand.ExecuteNonQuery();

            foreach (DataRow oRow in oUnit.LineItems.Rows)
            {
                oLineCommand = new SqlCommand();

                oLineCommand.Connection = this.Connection;
                oLineCommand.CommandType = CommandType.StoredProcedure;
                oLineCommand.CommandText = "SP_TRANS_INSERT_PAYDAYCODE_LINES";

                oLineCommand.Parameters.Add(new SqlParameter("@PayDayCode", oUnit.Code));
                oLineCommand.Parameters.Add(new SqlParameter("@Inteval", oRow["Interval"].ToString()));
                oLineCommand.Parameters.Add(new SqlParameter("@DayWeekNo", oRow["DayWeekNo"].ToString()));
                oLineCommand.ExecuteNonQuery();
            }
        }

        public DataTable GetPayDayCodeHeader()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtHeader = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_PDAY";

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtHeader);

            return dtHeader;

        }

        public DataTable GetPayDayCodeLineItems()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtHeader = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_PDAY1";

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtHeader);

            return dtHeader;

        }

        public DataTable GetPayDayCodeLineItems(string sPayDayCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtHeader = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_PDAY1 where PayDayCode=@PayDayCode";
            oCommand.Parameters.Add(new SqlParameter("@PayDayCode", sPayDayCode));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtHeader);

            return dtHeader;

        }
    }
}
