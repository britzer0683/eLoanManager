using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLoan.BL;
using eLoanSystem.Setup;
using eLoanSystem.Transaction;
using DevExpress.XtraGrid.Views.Card;

namespace eLoanSystem
{
    public partial class eLoanMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public eLoanMain()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }

        public void BindLoan()
        {
            LoanManager oManager = new LoanManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            grdCtlLoanInfo.DataSource = oManager.GetLoans();
            grdCtlLoanInfo.Refresh();
            oManager.Close();
        }
        private void BindPayDayCode()
        {
            PayDayCodeManager oManager = new PayDayCodeManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dtHeader = oManager.GetPayDayCodeHeader();
            DataTable dtLineItems = oManager.GetPayDayCodeLineItems();

            DataSet dsPayDayCode = new DataSet();

            dsPayDayCode.Tables.Add(dtHeader);
            dsPayDayCode.Tables.Add(dtLineItems);

            
            DataColumn keyColumn = dsPayDayCode.Tables[0].Columns["PayDayCode"];
            DataColumn foreignKeyColumn = dsPayDayCode.Tables[1].Columns["PayDayCode"];
            dsPayDayCode.Relations.Add("PayDayCode", keyColumn, foreignKeyColumn);

            //Bind the grid control to the data source
            gridControl1.DataSource = dsPayDayCode.Tables[0];
            
            gridControl1.Refresh();
        }
        private void BindGuarantor()
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            DataTable dtGuarantor = oManager.GetGuarantorInfo();
            oManager.Close();

            grdCtlGuarantorFinancer.DataSource = dtGuarantor;
            grdCtlGuarantorFinancer.Refresh();
        }
        
        private void BindEmployers()
        {
            EmployerManager oManager = new EmployerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            gridControl2.DataSource = oManager.GetEmployerInfo();
            gridControl2.Refresh();

            oManager.Close();
        }
        private void BindBorrowers()
        {
            BorrowerManager oManager = new BorrowerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            grdCtlBorrowerInfo.DataSource = oManager.GetBorrowersRecord();
            grdCtlBorrowerInfo.Refresh();

            oManager.Close();
        }
        void BindPayments(DateTime dFrom, DateTime dTo)
        {
            CollectionManager oManager = new CollectionManager();
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dt = oManager.GetCollection(dFrom, dTo);

            gridControl3.DataSource = dt;
            gridControl3.Refresh();

            oManager.Close();
        }
        void BindCashReleased(DateTime dFrom, DateTime dTo)
        {
            CashReleaseManager oManager = new CashReleaseManager();
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dt = oManager.GetCashReleased(dFrom, dTo);

            gridControl4.DataSource = dt;
            gridControl4.Refresh();

            oManager.Close();
        }
        public void RefreshMainMenu()
        {
            BindLoan();
            BindBorrowers();
            BindGuarantor();
            BindEmployers();
            BindPayDayCode();
            BindPayments((DateTime)dtPaymentStart.EditValue, (DateTime)dtPaymentEnd.EditValue);
            BindCashReleased((DateTime)dtCFRStartDate.EditValue, (DateTime)dtCFREndDate.EditValue);
        }

        private void eLoanMain_Load(object sender, EventArgs e)
        {
            dtPaymentStart.EditValue = System.DateTime.Now;
            dtPaymentEnd.EditValue = System.DateTime.Now;

            dtCFRStartDate.EditValue = System.DateTime.Now;
            dtCFREndDate.EditValue = System.DateTime.Now;


            backstageViewControl1.SelectedTabIndex = 0;
            BindLoan();
            BindBorrowers();
            BindGuarantor();
            BindEmployers();
            BindPayDayCode();
        }

        private void barNewBorrower_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrowerInfo oForm = new BorrowerInfo();

            oForm.ConnectionString = this.ConnectionString;
            oForm.MainMenuForm = this;
            oForm.ShowDialog();

            
        }

        private void barFundSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FundSetup oForm = new FundSetup();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();
        }

        private void barGuarantorFinancer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuarantorFinancerInfo oForm = new GuarantorFinancerInfo();

            oForm.eLoanMainMenu = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();
        }

        private void barEmployerCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EmployerInfo oForm = new EmployerInfo();

            oForm.MainMenu = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();
        }

        

        private void barPayDayCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PayDayCodeSetup oForm = new PayDayCodeSetup();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.MainMenu = this;
            oForm.ShowDialog();
        }

        private void barUserMaintenance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserMaintenanceSetup oForm = new UserMaintenanceSetup();

            oForm.ShowDialog();
        }

        private void barNewLoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void backstageViewClientControl5_Load(object sender, EventArgs e)
        {

        }

        private void backstageViewControl1_Click(object sender, EventArgs e)
        {

        }

        private void barNewBorrowerInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrowerInfo oForm = new BorrowerInfo();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FundTransferEntry oForm = new FundTransferEntry();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CashFundEntry oForm = new CashFundEntry();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CashFundReleaseOldVersion oForm = new CashFundReleaseOldVersion();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Payment oForm = new Payment();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoanApplication oForm = new LoanApplication();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barCashFundRelease_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CashFundReleaseOldVersion oForm = new CashFundReleaseOldVersion();
            
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barFundTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FundTransferEntry oForm = new FundTransferEntry();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barCashFundTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FundTransferEntry oForm = new FundTransferEntry();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void txtCardCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            EmployerInfo oForm = new EmployerInfo();
            DevExpress.XtraEditors.TextEdit txt1 = (DevExpress.XtraEditors.TextEdit)sender;

            oForm.MainMenu = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.OpenEmployerInfo(txt1.Text);
            
            oForm.ShowDialog();
            RefreshMainMenu();
        }

        private void txtCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt1 = (DevExpress.XtraEditors.TextEdit)sender;

            GuarantorFinancerInfo oForm = new GuarantorFinancerInfo();
            oForm.eLoanMainMenu = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.OpenGuarantorInfo(txt1.Text);
            oForm.ShowDialog();
        }

        private void txtBorrowerCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt1 = (DevExpress.XtraEditors.TextEdit)sender;

            BorrowerInfo oForm = new BorrowerInfo();
            oForm.MainMenuForm = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.OpenDocument(txt1.Text);
            oForm.ShowDialog();

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoanApplication oForm = new LoanApplication();

            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();
        }

        private void eLoanMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void eLoanMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void txtLoanNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iFocusRowIndex = grdViewLoanInfo.FocusedRowHandle;
            DevExpress.XtraEditors.TextEdit txt = (DevExpress.XtraEditors.TextEdit)sender;

            LoanApplication oForm = new LoanApplication();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.Stopper = true;
            oForm.OpenDocument(txt.Text);
            oForm.ShowDialog();

        }

        private void backstageViewTabItem10_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindPayments((DateTime)dtPaymentStart.EditValue, (DateTime)dtPaymentEnd.EditValue);
        }

        private void btnRefreshCashReleased_Click(object sender, EventArgs e)
        {
            BindCashReleased((DateTime)dtCFRStartDate.EditValue, (DateTime)dtCFREndDate.EditValue);
        }

    }
}
