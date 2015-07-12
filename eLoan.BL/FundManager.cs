using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace eLoan.BL
{
    public class FundManager:ConnectionManager
    {
        public void AddCashBank(FundUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_INSERT_FUND";
            oCommand.Parameters.Add(new SqlParameter("@AccountNumber", oUnit.AccountNumber));
            oCommand.Parameters.Add(new SqlParameter("@AccountName", oUnit.AccountName));

            oCommand.ExecuteNonQuery();
        }
        public void UpdateCashBank(FundUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_UPDATE_FUND";
            
            oCommand.Parameters.Add(new SqlParameter("@AccountNumber", oUnit.AccountNumber));
            oCommand.Parameters.Add(new SqlParameter("@AccountName", oUnit.AccountName));

            oCommand.ExecuteNonQuery();
        }

        public DataTable GetCashBankSetup()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_GET_FUNDSETUP";
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            return dtLineItems;
        }

        public bool IsCodeExists(string sCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_FUNDSETUP WHERE AccountNumber=@AccountNumber";
            oCommand.Parameters.Add(new SqlParameter("@AccountNumber", sCode));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);

            int iRowCount = dtLineItems.Rows.Count;

            if (iRowCount >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
