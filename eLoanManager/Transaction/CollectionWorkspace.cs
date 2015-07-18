using eLoan.BL;
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
    public partial class CollectionWorkspace : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CollectionWorkspace()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private DataTable LineItems { get; set; }
        private void batchPaymentCollection_Load(object sender, EventArgs e)
        {
            BindGuarantor();

            dtPostDate.EditValue = System.DateTime.Now;
        }

        private void barMenuExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CollectionWorkspace oForm = new CollectionWorkspace();

            oForm.ConnectionString = this.ConnectionString;
            oForm.MdiParent = this.MdiParent;
            oForm.Show();
        }
        void BindGuarantor()
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM M_GUARANTORFINANCER";

            oAdapter.SelectCommand = oCommand;
            DataTable dt = new DataTable();
            oAdapter.Fill(dt);

            oConnection.Close();

            cboGuarantor.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerCode", 200, "Code"));
            cboGuarantor.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerName", 200, "Name"));

            cboGuarantor.Properties.DisplayMember = "GuarantorFinancerName";
            cboGuarantor.Properties.ValueMember = "GuarantorFinancerName";
            cboGuarantor.Properties.DataSource = dt;

            cboGuarantor.Refresh();

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        string GetSeries()
        {
            SeriesManager oManager = new SeriesManager();
            string sSeries = "";
            string sPrefix = "";
            int digitNo = 0;
            string _objectType = "Collection";

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            sSeries = oManager.GetNewSeries(_objectType);
            sPrefix = oManager.GetPrefix(_objectType);
            digitNo = Convert.ToInt16(oManager.GetDigit(_objectType));
            oManager.Close();

            return sPrefix + String.Format("{0:D5}", Convert.ToInt16(sSeries));
        }

        private void barSaveDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "INSERT INTO OCL (DocNum, Guarantor, Remarks, DateCreated, CreatedBy, DateModified, ModifiedBy) VALUES (@DocNum, @Guarantor, @Remarks, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)";
            txtDocNum.Text = GetSeries();
            oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
            oCommand.Parameters.Add(new SqlParameter("@Guarantor", cboGuarantor.EditValue.ToString()));
            oCommand.Parameters.Add(new SqlParameter("@Remarks", txtRemarks.Text));
            oCommand.Parameters.Add(new SqlParameter("@DateCreated", System.DateTime.Now));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", this.ActiveUserID));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", System.DateTime.Now));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", this.ActiveUserID));
            oCommand.ExecuteNonQuery();


            //SqlCommand cmd = new SqlCommand();

            //foreach (DataRow oRow in this.LineItems.Rows)
            //{
            //    cmd = new SqlCommand();

            //    cmd.Connection = oConnection;
            //    cmd.CommandText = "INSERT INTO CL1 (DocNum, RefLoanNo, ScheduleNo, DueAmount, PaidAmount, ChangeAmount) VALUES (DocNum, RefLoanNo, ScheduleNo, DueAmount, PaidAmount, ChangeAmount)";
                
            //    cmd.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
            //    cmd.Parameters.Add(new SqlParameter("@RefLoanNo", oRow["RefLoanNo"].ToString()));
            //    cmd.Parameters.Add(new SqlParameter("@ScheduleNo", oRow["ScheduleNo"].ToString()));
            //    cmd.Parameters.Add(new SqlParameter("@DueAmount", oRow["DueAmount"].ToString()));
            //    cmd.Parameters.Add(new SqlParameter("@PaidAmount", oRow["PaidAmount"].ToString()));
            //    cmd.Parameters.Add(new SqlParameter("@ChangeAmount", oRow["ChangeAmount"].ToString()));

            //    cmd.ExecuteNonQuery();


            //}
            //oCommand.Parameters.Add(new SqlParameter("@DocNum", ))

            oConnection.Close();
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
