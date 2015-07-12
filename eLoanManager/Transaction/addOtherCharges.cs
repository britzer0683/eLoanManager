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
    public partial class addOtherCharges : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public addOtherCharges()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string DocumentNumber { get; set; }
        public string ScheduleNo { get; set; }
        public DateTime ScheduledDate { get; set; }
        private void addOtherCharges_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();
            oCommand.Connection = oConnection;
            oCommand.CommandText = "INSERT INTO LOAN4 (DocNum, ScheduleNo, DueDate, Amount, Particulars) VALUES (@DocNum, @ScheduleNo, @DueDate, @Amount, @Particulars)";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", this.DocumentNumber));
            oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", this.ScheduleNo));
            oCommand.Parameters.Add(new SqlParameter("@DueDate", this.ScheduledDate));
            oCommand.Parameters.Add(new SqlParameter("@Amount", txtCharges.EditValue));
            oCommand.Parameters.Add(new SqlParameter("@Particulars", txtParticulars.Text));

            oCommand.ExecuteNonQuery();
            


            oCommand = new SqlCommand();
            oCommand.Connection = oConnection;
            oCommand.CommandText = "UPDATE LOAN1 SET PaymentAmount=PaymentAmount + @OtherCharges, OtherCharges=@OtherCharges WHERE DocNum=@DocNum AND ScheduleNo=@ScheduleNo";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", this.DocumentNumber));
            oCommand.Parameters.Add(new SqlParameter("@ScheduleNo", this.ScheduleNo));
            oCommand.Parameters.Add(new SqlParameter("@OtherCharges", txtCharges.EditValue));

            oCommand.ExecuteNonQuery();
            oConnection.Close();

            this.Close();
        }
    }
}
