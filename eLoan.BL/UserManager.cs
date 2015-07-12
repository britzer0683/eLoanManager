using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for UserManager
/// </summary>

namespace eLoan.BL
{
    public class UserManager : ConnectionManager
    {
        public UserManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool Authenticate(UserUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtUsers = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "SELECT * FROM  OUSR WHERE UserID=@UserID AND UserPassword=@UserPassword";
            oCommand.Parameters.Add(new SqlParameter("@UserID", oUnit.UserID));
            oCommand.Parameters.Add(new SqlParameter("@UserPassword", oUnit.UserPassword));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtUsers);

            int iCount = dtUsers.Rows.Count;

            if (iCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsUIDExists(string sUID)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtUsers = new DataTable();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "SELECT * FROM  OUSR WHERE UserID=@UserID";
            oCommand.Parameters.Add(new SqlParameter("@UserID", sUID));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtUsers);

            int iCount = dtUsers.Rows.Count;

            if (iCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddUserUnit(UserUnit oUnit)
        {
            SqlCommand oCommand = new SqlCommand();

            oCommand.Connection = this.Connection;
            oCommand.CommandText = "INSERT INTO OUSR (UserID, UserPassword) values (@UserID, @UserPassword)";
            oCommand.Parameters.Add(new SqlParameter("@UserID", oUnit.UserID));
            oCommand.Parameters.Add(new SqlParameter("@UserPassword", oUnit.UserPassword));

            oCommand.ExecuteNonQuery();
        }


    }
}