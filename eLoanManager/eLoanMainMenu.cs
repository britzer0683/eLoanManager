using DevExpress.XtraBars.Ribbon;
using eLoanSystem.Setup;
using eLoanSystem.Transaction;
using eLoanSystem.ViewForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLoanSystem
{
    public partial class eLoanMainMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public eLoanMainMenu()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private void eLoanMainMenu_Load(object sender, EventArgs e)
        {
            this.ribbonControl1.MdiMergeStyle = RibbonMdiMergeStyle.Always;
        }

        private void barNewBorrower_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrowerInfo oForm = new BorrowerInfo();

            oForm.WindowState = FormWindowState.Maximized;
            oForm.ConnectionString = this.ConnectionString;
            oForm.MdiParent = this;
            oForm.Show();

        }

        private void barNewEmployer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EmployerInfo oForm = new EmployerInfo();

            oForm.MdiParent = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.Show();
        }

        private void barNewGuarantor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuarantorFinancerInfo oForm = new GuarantorFinancerInfo();

            oForm.MdiParent = this;
            oForm.ConnectionString = this.ConnectionString;
            oForm.Show();
        }

        private void barFundSetup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FundSetup oForm = new FundSetup();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PayDayCodeSetup oForm = new PayDayCodeSetup();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserMaintenanceSetup oForm = new UserMaintenanceSetup();

            oForm.ShowDialog();
        }

        private void navBarNewApplicationLoan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        
        private void ribbonControl1_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            Ribbon.SelectedPage = Ribbon.MergedPages[0];            
        }

        private void ribbonControl2_Click(object sender, EventArgs e)
        {

        }

        private void barNewLoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoanApplication oForm = new LoanApplication();

            oForm.MdiParent = this;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.ConnectionString = this.ConnectionString;
            oForm.Show();
        }

        private void barCashRelease_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CashReleaseDocument oForm = new CashReleaseDocument();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void navBarBorrowerFiles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            viewBorrowers oForm = new viewBorrowers();

            oForm.ConnectionString = this.ConnectionString;
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void navViewGuarantor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            viewGuarantorFinancer oForm = new viewGuarantorFinancer();

            oForm.ConnectionString = this.ConnectionString;
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            viewEmployer oForm = new viewEmployer();

            oForm.ConnectionString = this.ConnectionString;
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CollectionWorkspace oForm = new CollectionWorkspace();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.MdiParent = this;
            oForm.Show();
        }
    }
}
