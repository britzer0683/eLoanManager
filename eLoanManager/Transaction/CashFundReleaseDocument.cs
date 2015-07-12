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
            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;
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
            
        }
    }
}
