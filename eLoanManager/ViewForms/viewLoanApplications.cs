using eLoan.BL;
using eLoanSystem.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLoanSystem.ViewForms
{
    public partial class viewLoanApplications : Form
    {
        public viewLoanApplications()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        public void BindLoans()
        {
            LoanManager oManager = new LoanManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            grdCtlLoanInfo.DataSource = oManager.GetLoans();
            grdCtlLoanInfo.Refresh();
            oManager.Close();
        }
        private void viewLoanApplications_Load(object sender, EventArgs e)
        {
            BindLoans();
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
            oForm.MdiParent = this.MdiParent;
            oForm.Show();
        }
    }
}
