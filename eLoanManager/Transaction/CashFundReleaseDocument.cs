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
using eLoanSystem.Transaction;
using eLoan.BL;

namespace eLoanSystem.Transaction
{
    public partial class CashFundReleaseDocument : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CashFundReleaseDocument()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private DataTable LineItems { get; set; }

        private void InitializeLineItems()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("RefLoanNo", typeof(string));
            dt.Columns.Add("ScheduleNo", typeof(string));
            dt.Columns.Add("CardCode", typeof(string));
            dt.Columns.Add("CardName", typeof(string));
            dt.Columns.Add("LoanAmount", typeof(double));
            dt.Columns.Add("ReferenceDocument", typeof(string)); //ATM or PDC
            dt.Columns.Add("ReceivedAmount", typeof(double));
            dt.Columns.Add("DocStatus", typeof(string));

            this.LineItems = dt;

        }
        string GetSeries()
        {
            SeriesManager oManager = new SeriesManager();
            string sSeries = "";
            string sPrefix = "";
            int digitNo = 0;
            string _objectType = "CashRelease";

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            sSeries = oManager.GetNewSeries(_objectType);
            sPrefix = oManager.GetPrefix(_objectType);
            digitNo = Convert.ToInt16(oManager.GetDigit(_objectType));
            oManager.Close();

            return sPrefix + String.Format("{0:D5}", Convert.ToInt16(sSeries));
        }

        void BindSourceOfFund()
        {
            FundManager oManager = new FundManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            //gridControl1.DataSource = oManager.GetCashBankSetup();
            //gridControl1.Refresh();
            cboSourceOfFund.Properties.DisplayMember = "AccountName";
            cboSourceOfFund.Properties.ValueMember = "AccountNumber";

            cboSourceOfFund.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountNumber", "Code"));
            cboSourceOfFund.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName", "Fund Name"));

            cboSourceOfFund.Properties.DataSource = oManager.GetCashBankSetup();
            cboSourceOfFund.Refresh();

            oManager.Close();
        }

        void BindDestinationOfFund()
        {
            FundManager oManager = new FundManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            //gridControl1.DataSource = oManager.GetCashBankSetup();
            //gridControl1.Refresh();
            cboFundDestination.Properties.DisplayMember = "AccountName";
            cboFundDestination.Properties.ValueMember = "AccountNumber";

            cboFundDestination.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountNumber", "Code"));
            cboFundDestination.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName", "Fund Name"));

            cboFundDestination.Properties.DataSource = oManager.GetCashBankSetup();
            cboFundDestination.Refresh();

            oManager.Close();
        }
        private void CashFundRelease_Load(object sender, EventArgs e)
        {
            InitializeLineItems();

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

            BindSourceOfFund();
            BindDestinationOfFund();

            gridControl1.DataSource = this.LineItems;
            gridControl1.Refresh();
        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {
        
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
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
            oCommand.CommandText = "INSERT INTO OCR (DocNum, SourceOfFund, DestinationOfFund, Remarks, Amount, DateCreated, CreatedBy, DateModified, ModifiedBy) VALUES (@DocNum, @SourceOfFund, @DestinationOfFund, @Remarks, @Amount, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)";

            oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
            oCommand.Parameters.Add(new SqlParameter("@SourceOfFund", cboSourceOfFund.EditValue != null ? cboSourceOfFund.EditValue : ""));
            oCommand.Parameters.Add(new SqlParameter("@DestinationOfFund", cboFundDestination.EditValue != null ? cboFundDestination.EditValue : ""));
            oCommand.Parameters.Add(new SqlParameter("@Remarks", txtRemarks.Text));
            oCommand.Parameters.Add(new SqlParameter("@Amount", txtAmount.EditValue != null ? (double)txtAmount.EditValue : 0));

            oCommand.Parameters.Add(new SqlParameter("@DateCreated", dtCreated.EditValue != null ? (DateTime)dtCreated.EditValue : System.DateTime.Now));
            oCommand.Parameters.Add(new SqlParameter("@CreatedBy", txtCreatedBy.Text));
            oCommand.Parameters.Add(new SqlParameter("@DateModified", dtModified.EditValue != null ? (DateTime)dtModified.EditValue : System.DateTime.Now));
            oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", txtModifiedBy.Text));

            oCommand.ExecuteNonQuery();
            oConnection.Close();

        }

        void BindDueLoans(string sLoanNumber)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT ScheduleNo, ScheduledDate DueDate FROM LOAN1 WHERE PaidAmount <=0 and DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sLoanNumber));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            oConnection.Close();
            cboDueDate.Columns.Clear();
            
            cboDueDate.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ScheduleNo", 100, "#"));
            cboDueDate.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DueDate", 100, "Due Date"));

            cboDueDate.DataSource = dt;

            
        }

        private void txtLoanNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt_LoanNum = new DevExpress.XtraEditors.TextEdit();
            findLoan oForm = new findLoan();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();

            if (oForm.DocumentNo != null)
            {
                txt_LoanNum.Text = oForm.DocumentNo;
                BindDueLoans(txt_LoanNum.Text);
            }
        }
    }
}
