using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ConnectionManager
/// </summary>

namespace eLoan.BL
{
    public class ConnectionManager
    {
        
        SqlConnection DBConnection = new SqlConnection();
        public string ConnectionString { get; set; }
        public SqlConnection Connection
        {
            get { return DBConnection; }
        }
        public void Open()
        {
            DBConnection = new SqlConnection();
            DBConnection.ConnectionString = this.ConnectionString;
            DBConnection.Open();
        }
        public void Close()
        {
            DBConnection.Close();
        }
    }
}