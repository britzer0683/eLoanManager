using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace eLoan.BL
{
    public class EmployerManager:ConnectionManager
    {
        public void AddEmployer(EmployerUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_INSERT_EMPLOYER";

            oCommand.Parameters.Add(new SqlParameter("@EmployerCode", oUnit.EmployerCode));
            oCommand.Parameters.Add(new SqlParameter("@EmployerName", oUnit.EmployerName));
            oCommand.Parameters.Add(new SqlParameter("@EmployerTINIDNo", oUnit.EmployerTINIDNo));
            oCommand.Parameters.Add(new SqlParameter("@Address", oUnit.Address));
            oCommand.Parameters.Add(new SqlParameter("@ContactNumber", oUnit.ContactNumber));
            oCommand.Parameters.Add(new SqlParameter("@EmailAddress", oUnit.EmailAddress));
            oCommand.Parameters.Add(new SqlParameter("@ContactPerson", oUnit.ContactPerson));

            oCommand.ExecuteNonQuery();

        }

        public void UpdateEmployer(EmployerUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_TRANS_UPDATE_EMPLOYER";

            oCommand.Parameters.Add(new SqlParameter("@EmployerCode", oUnit.EmployerCode));
            oCommand.Parameters.Add(new SqlParameter("@EmployerName", oUnit.EmployerName));
            oCommand.Parameters.Add(new SqlParameter("@EmployerTINIDNo", oUnit.EmployerTINIDNo));
            oCommand.Parameters.Add(new SqlParameter("@Address", oUnit.Address));
            oCommand.Parameters.Add(new SqlParameter("@ContactNumber", oUnit.ContactNumber));
            oCommand.Parameters.Add(new SqlParameter("@EmailAddress", oUnit.EmailAddress));
            oCommand.Parameters.Add(new SqlParameter("@ContactPerson", oUnit.ContactPerson));

            oCommand.ExecuteNonQuery();
        }

        public DataTable GetEmployerInfo(string sEmployerCode)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = "SELECT * FROM M_EMPLOYER WHERE EmployerCode=@EmployerCode";
            oCommand.Parameters.Add(new SqlParameter("@EmployerCode", sEmployerCode));
            oAdapter.SelectCommand = oCommand;

            oAdapter.Fill(dtLineItems);


            return dtLineItems;
        }
        public DataTable GetEmployerInfo()
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtLineItems = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = "SP_GET_EMPLOYERSINFO";
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
            oCommand.CommandText = "SELECT * FROM M_EMPLOYER WHERE EmployerCode=@EmployerCode";
            oCommand.Parameters.Add(new SqlParameter("@EmployerCode", sCode));

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
