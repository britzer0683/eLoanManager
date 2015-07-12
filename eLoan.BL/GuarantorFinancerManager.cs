using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace eLoan.BL
{
    public class GuarantorFinancerManager:ConnectionManager
    {
        public void AddGuarantorFinancer(GuarantorFinancerUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_INSERT_GUARANTORFINANCER";

            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerCode", oUnit.GuarantorFinancerCode));
            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerName", oUnit.GuarantorFinancerName));
            oCommand.Parameters.Add(new SqlParameter("@Address", oUnit.Address));
            oCommand.Parameters.Add(new SqlParameter("@ContactNumber", oUnit.ContactNumber));
            oCommand.Parameters.Add(new SqlParameter("@EmailAddress", oUnit.EmailAddress));
            oCommand.Parameters.Add(new SqlParameter("@ContactPerson", oUnit.ContactPerson));

            oCommand.ExecuteNonQuery();

        }

        public void UpdateGuarantor(GuarantorFinancerUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_UPDATE_GUARANTORFINANCER";

            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerCode", oUnit.GuarantorFinancerCode));
            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerName", oUnit.GuarantorFinancerName));
            oCommand.Parameters.Add(new SqlParameter("@Address", oUnit.Address));
            oCommand.Parameters.Add(new SqlParameter("@ContactNumber", oUnit.ContactNumber));
            oCommand.Parameters.Add(new SqlParameter("@EmailAddress", oUnit.EmailAddress));
            oCommand.Parameters.Add(new SqlParameter("@ContactPerson", oUnit.ContactPerson));

            oCommand.ExecuteNonQuery();
        }

        public DataTable GetGuarantorInfo()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_GET_GUARANTORFINANCER";
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            return dtLineItems;
        }

        public DataTable GetGuarantorInfo(string sCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_GUARANTORFINANCER WHERE GuarantorFinancerCode=@GuarantorFinancerCode";
            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerCode", sCode));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            return dtLineItems;
        }
        public bool IsExists(string sCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_GUARANTORFINANCER WHERE GuarantorFinancerCode=@GuarantorFinancerCode";
            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerCode", sCode));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);

            int iRowCount = dtLineItems.Rows.Count;

            if (iRowCount <= 0)
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
