using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLoan.BL
{
    public class SeriesManager:ConnectionManager
    {
        public string GetNewSeries(string sDocType)
        {
            try
            {
                SqlCommand oCommand = new SqlCommand();
                oCommand.Connection = this.Connection;
                oCommand.CommandType = CommandType.Text;

                oCommand.CommandText = "SELECT Series FROM SERIES WHERE ObjectType=@ObjectType";
                oCommand.Parameters.Add(new SqlParameter("@ObjectType", sDocType));

                SqlDataAdapter oAdapter = new SqlDataAdapter();
                DataSet ds = new DataSet();
                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(ds);


                oCommand = new SqlCommand();
                oCommand.Connection = this.Connection;
                oCommand.CommandType = CommandType.Text;

                oCommand.CommandText = "UPDATE SERIES SET SERIES=SERIES+1 WHERE ObjectType=@DocType";
                oCommand.Parameters.Add(new SqlParameter("@DocType", sDocType));
                oCommand.ExecuteNonQuery();

                return Convert.ToString(ds.Tables[0].Rows[0]["Series"]);

            }
            catch
            {
                return null;
            }
        }

        public int GetDigit(string sObjecType)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtInfo = new DataTable();


            oCommand.Connection = this.Connection;
            oCommand.CommandText = "SELECT * FROM SERIES WHERE ObjectType=@DocType";
            oCommand.Parameters.Add(new SqlParameter("@DocType", sObjecType));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtInfo);

            return (int)dtInfo.Rows[0]["Series"];
        }

        public string GetPrefix(string sObjecType)
        {
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtInfo = new DataTable();


            oCommand.Connection = this.Connection;
            oCommand.CommandText = "SELECT * FROM SERIES WHERE ObjectType=@DocType";
            oCommand.Parameters.Add(new SqlParameter("@DocType", sObjecType));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtInfo);

            return (string)dtInfo.Rows[0]["Prefix"];
        }
    }
}
