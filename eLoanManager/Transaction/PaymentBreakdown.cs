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
    public partial class PaymentBreakdown : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public PaymentBreakdown()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public int ScheduleNo { get; set; }
        public string DocumentNumber { get; set; }

        void BindPaymentBreakDown(int iScheduleNo, string sDocNum)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM LOAN2 WHERE DocNum=@DocNum AND ScheduledNo=@ScheduleNo";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));
            oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", iScheduleNo));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            gridControl1.DataSource = dt;
            gridControl1.Refresh();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaymentBreakdown_Load(object sender, EventArgs e)
        {
            BindPaymentBreakDown(this.ScheduleNo, this.DocumentNumber);
        }
    }
}
