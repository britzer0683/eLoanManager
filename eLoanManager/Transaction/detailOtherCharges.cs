using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLoanSystem.Transaction
{
    public partial class detailOtherCharges : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public detailOtherCharges()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string DocumentNumber { get; set; }
        public string ScheduleNo { get; set; }
        public void BindGrid()
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM LOAN4 WHERE DocNum=@DocNum AND ScheduleNo=@ScheduleNo";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", this.DocumentNumber));
            oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", this.ScheduleNo));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            gridControl1.DataSource = dt;
            gridControl1.Refresh();

            oConnection.Close();

            
        }
        private void detailOtherCharges_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
