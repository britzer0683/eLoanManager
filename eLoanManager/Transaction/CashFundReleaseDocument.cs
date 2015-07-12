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
            dt.Columns.Add("DueDate", typeof(DateTime));
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
            BindGuarantor();

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

            BindSourceOfFund();
            BindDestinationOfFund();

            gridControl1.DataSource = this.LineItems;
            gridControl1.Refresh();

            gridView1.AddNewRow();
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



            //DevExpress.XtraEditors.LookUpEdit oLookUp = cboDueDate.OwnerEdit;
            //oLookUp = new DevExpress.XtraEditors.LookUpEdit();
            //oLookUp.Properties.Columns.Clear();
            //oLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ScheduleNo"));
            //oLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DueDate"));

            //oLookUp.Properties.DataSource = dt;
            //oLookUp.Refresh();


            
        }

        private void txtLoanNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt_LoanNum = new DevExpress.XtraEditors.TextEdit();
            int iFocusedRowIndex = gridView1.FocusedRowHandle;
            findLoan oForm = new findLoan();

            if (cboGuarantorFinancer.EditValue == null)
            {
                MessageBox.Show("Please select guarantor before adding documents!!!", "Guarantor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oForm.ConnectionString = this.ConnectionString;
            oForm.Guarantor = cboGuarantorFinancer.Text;
            oForm.ShowDialog();

            if (oForm.DocumentNo != null)
            {
                //txt_LoanNum.Text = oForm.DocumentNo;
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"], oForm.DocumentNo);

                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                DataTable dt = new DataTable();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "select * from OLOAN WHERE DocNum=@DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", oForm.DocumentNo));
                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);

                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["CardCode"], dt.Rows[0]["CardCode"].ToString());
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["CardName"], dt.Rows[0]["CardName"].ToString());
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["LoanAmount"], dt.Rows[0]["LoanAmount"].ToString());
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["ReferenceDocument"], "N/A");
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["ReceivedAmount"], 0);
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocStatus"], "Released");

                oConnection.Close();

            }
        }
        void BindGuarantor()
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();
            DataTable dtGuarantor = new DataTable();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            dtGuarantor = oManager.GetGuarantorInfo();

            oManager.Close();

            cboGuarantorFinancer.Properties.DataSource = dtGuarantor;
            cboGuarantorFinancer.Properties.DisplayMember = "GuarantorFinancerName";
            cboGuarantorFinancer.Properties.ValueMember = "GuarantorFinancerCode";

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col;

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerCode", "Code", 100);

            cboGuarantorFinancer.Properties.Columns.Add(col);

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerName", "Name", 100);

            cboGuarantorFinancer.Properties.Columns.Add(col);

            cboGuarantorFinancer.Refresh();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (gridView1.IsLastRow)
                {
                    int iFocusedRowIndex = gridView1.FocusedRowHandle;
                    string sLoanNo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"]).ToString();

                    if (sLoanNo != "")
                    {
                        gridView1.AddNewRow();
                    }
                }
            }
        }
      
    }
}
