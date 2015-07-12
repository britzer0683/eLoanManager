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

namespace eLoanSystem.Transaction
{
    public partial class CashFundRelease : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CashFundRelease()
        {
            InitializeComponent();
        }


        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        public string LoanNumber { get; set; }

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

        private void CashFundRelease_Load(object sender, EventArgs e)
        {
            dtCreated.EditValue = System.DateTime.Now;
            dtModified.EditValue = System.DateTime.Now;

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            txtLoanNo.Text = this.LoanNumber;

            BindSourceOfFund();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                CashReleaseManager oManager = new CashReleaseManager();
                CashReleaseUnit oUnit = new CashReleaseUnit();

                oManager.ConnectionString = this.ConnectionString;
                oManager.Open();

                oUnit.ReleaseNo = txtReleaseNo.Text;
                oUnit.RefLoanNo = txtLoanNo.Text;
                oUnit.ChequeNo = txtCheckNo.Text;
                oUnit.TypeOfPayment = cboTypeOfPayment.Text;
                oUnit.SourceOfFund = cboSourceOfFund.EditValue == null ? "" : cboSourceOfFund.EditValue.ToString();
                oUnit.Amount = Convert.ToDouble(txtAmount.Text);

                oUnit.CreatedBy = this.ActiveUserID;
                oUnit.DateCreated = (DateTime)dtCreated.EditValue;
                oUnit.ModifiedBy = this.ActiveUserID;
                oUnit.DateModified = (DateTime)dtModified.EditValue;
                
                oManager.AddCashRelease(oUnit);

                oManager.Close();

                this.Close();
            }
            else if (btnAdd.Text == "Update")
            {
                CashReleaseManager oManager = new CashReleaseManager();
                CashReleaseUnit oUnit = new CashReleaseUnit();

                oManager.ConnectionString = this.ConnectionString;
                oManager.Open();

                oUnit.ReleaseNo = txtReleaseNo.Text;
                oUnit.RefLoanNo = txtLoanNo.Text;
                oUnit.ChequeNo = txtCheckNo.Text;
                oUnit.TypeOfPayment = cboTypeOfPayment.Text;
                oUnit.SourceOfFund = cboSourceOfFund.EditValue.ToString();
                oUnit.Amount = Convert.ToDouble(txtAmount.Text);

                oUnit.CreatedBy = this.ActiveUserID;
                oUnit.DateCreated = (DateTime)dtCreated.EditValue;
                oUnit.ModifiedBy = this.ActiveUserID;
                oUnit.DateModified = (DateTime)dtModified.EditValue;

                oManager.UpdateCashRelease(oUnit);

                oManager.Close();

            }
        }

        private void txtStatus_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboTypeOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCheckNo.Text = cboTypeOfPayment.Text == "Cash" ? "Cash" : "";
            txtCheckNo.Enabled = cboTypeOfPayment.Text == "Cash" ? false : true;
        }
    }
}
