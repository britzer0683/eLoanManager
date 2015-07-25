using eLoan.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLoanSystem.Transaction;

namespace eLoanSystem.Setup
{
    public partial class BorrowerInfo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public BorrowerInfo()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public eLoanMain MainMenuForm { get; set; }

        void BindPayDayCode()
        {
            PayDayCodeManager oManager = new PayDayCodeManager();
            DataTable dtLines = new DataTable();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            dtLines = oManager.GetPayDayCodeHeader();

            cboPayDayCode.Properties.DataSource = dtLines;
            cboPayDayCode.Properties.DisplayMember = "Remarks";
            cboPayDayCode.Properties.ValueMember = "PayDayCode";

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col;

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayDayCode", "Code", 100);
            cboPayDayCode.Properties.Columns.Add(col);
            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Remarks", "Name", 100);

            cboPayDayCode.Properties.Columns.Add(col);
            cboPayDayCode.Refresh();

            oManager.Close();


        }
        void BindEmployer()
        {
            EmployerManager oManager = new EmployerManager();
            DataTable dtEmployer = new DataTable();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            dtEmployer = oManager.GetEmployerInfo();
            oManager.Close();

            cboEmployer.Properties.DataSource = dtEmployer;
            cboEmployer.Properties.DisplayMember = "EmployerName";
            cboEmployer.Properties.ValueMember = "EmployerCode";

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col;

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerCode", "Code", 100);
            cboEmployer.Properties.Columns.Add(col);
            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerName", "Name", 100);

            cboEmployer.Properties.Columns.Add(col);
            cboEmployer.Refresh();

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
        public void OpenDocument(string BorrowerCode)
        {
            BorrowerManager oManager = new BorrowerManager();
            BorrowerUnit oUnit = new BorrowerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dtBorrowerInfo = oManager.GetBorrowersRecord(BorrowerCode);
            DataRow oRow = dtBorrowerInfo.Rows[0];
            
            cboType.Text = oRow["CardType"].ToString();
            txtBorrowerCode.Text = oRow["BorrowerCode"].ToString();
            txtLastName.Text = oRow["LastName"].ToString();
            txtFirstName.Text = oRow["FirstName"].ToString();
            txtMiddleName.Text = oRow["MiddleName"].ToString();
            txtAddress.Text = oRow["Address"].ToString();
            txtContactNumber.Text = oRow["ContactNumber"].ToString();
            cboEmployer.EditValue = oRow["Employer"].ToString();
            cboGuarantorFinancer.EditValue = oRow["GuarantorID"].ToString();
            txtATMNo.Text = oRow["ATMNo"].ToString();
            cboEmploymentStatus.Text = oRow["EmploymentStatus"].ToString();
            dtEffectiveDate.EditValue = Convert.ToDateTime(oRow["EffectiveDate"].ToString());
            cboFrequencyOfPayment.Text = oRow["FrequencyOfPayment"].ToString();
            txtInterestRate.Text = oRow["InterestRate"].ToString();
            cboPayDayCode.EditValue = oRow["PayDayCode"].ToString();
            txtMortgageInfo.Text = oRow["MortgageInfo"].ToString();
            txtCreditLimit.Text = oRow["CreditLimit"].ToString();
            
            txtBorrowerCode.Enabled = false;
            
            oManager.Close();
            
        }

        private void BorrowerInfo_Load(object sender, EventArgs e)
        {
            BindEmployer();
            BindGuarantor();
            BindPayDayCode();

            cboEmploymentStatus.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BorrowerManager oManager = new BorrowerManager();
            BorrowerUnit oUnit = new BorrowerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            // Details

            oUnit.CardType = cboType.Text;
            oUnit.BorrowerCode = txtBorrowerCode.Text;
            oUnit.LastName = txtLastName.Text;
            oUnit.FirstName = txtFirstName.Text;
            oUnit.MiddleName = txtMiddleName.Text;
            oUnit.Address = txtAddress.Text;
            oUnit.ContactNumber = txtContactNumber.Text;
            oUnit.Employer = cboEmployer.EditValue.ToString();
            oUnit.GuarantorID = cboGuarantorFinancer.EditValue.ToString();
            oUnit.GuarantorName = cboGuarantorFinancer.Text;
            oUnit.ATMNo = txtATMNo.Text;
            oUnit.EmploymentStatus = cboEmploymentStatus.Text;
            oUnit.EffectiveDate = Convert.ToDateTime(dtEffectiveDate.EditValue);
            oUnit.InterestRate = txtInterestRate.Text;
            oUnit.PayDayCode = cboPayDayCode.EditValue.ToString();
            oUnit.MortgageInfo = txtMortgageInfo.Text;
            oUnit.CreditLimit = Convert.ToDouble(txtCreditLimit.Text);

            oManager.UpdateBorrower(oUnit);
            oManager.Close();

            txtBorrowerCode.Enabled = false;
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.MainMenuForm.RefreshMainMenu();
            this.Close();
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BorrowerInfo oForm = new BorrowerInfo();

            oForm.ConnectionString = this.ConnectionString;
            
            oForm.MdiParent = this.MdiParent;
            oForm.Show();
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }

        private void barSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtBorrowerCode.Enabled == true)
            {
                if (txtBorrowerCode.Text == "")
                {
                    MessageBox.Show("Blank code is not permitted!!!", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                BorrowerManager oManager = new BorrowerManager();
                BorrowerUnit oUnit = new BorrowerUnit();

                oManager.ConnectionString = this.ConnectionString;
                oManager.Open();

                if (oManager.isBorrowerCodeExists(txtBorrowerCode.Text))
                {
                    oManager.Close();

                    MessageBox.Show("Code already exists!!! Please try another code", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                oUnit.CardType = cboType.Text;
                oUnit.BorrowerCode = txtBorrowerCode.Text;
                oUnit.LastName = txtLastName.Text;
                oUnit.FirstName = txtFirstName.Text;
                oUnit.MiddleName = txtMiddleName.Text;
                oUnit.Address = txtAddress.Text;
                oUnit.ContactNumber = txtContactNumber.Text;
                oUnit.Employer = cboEmployer.EditValue.ToString();
                oUnit.GuarantorID = cboGuarantorFinancer.EditValue.ToString();
                oUnit.GuarantorName = cboGuarantorFinancer.Text;
                oUnit.ATMNo = txtATMNo.Text;
                oUnit.EmploymentStatus = cboEmploymentStatus.Text;
                oUnit.EffectiveDate = Convert.ToDateTime(dtEffectiveDate.EditValue);
                oUnit.InterestRate = txtInterestRate.Text;
                oUnit.FrequencyOfPayment = cboFrequencyOfPayment.Text;
                if (cboPayDayCode.EditValue == null)
                {
                    oUnit.PayDayCode = "";
                }
                else
                {
                    oUnit.PayDayCode = cboPayDayCode.EditValue.ToString();
                }
                oUnit.MortgageInfo = txtMortgageInfo.Text;
                oUnit.CreditLimit = Convert.ToDouble(txtCreditLimit.Text);
                // Details

                oManager.AddBorrower(oUnit);
                oManager.Close();

                txtBorrowerCode.Enabled = false;
                MessageBox.Show("Adding successfull!!!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                BorrowerManager oManager = new BorrowerManager();
                BorrowerUnit oUnit = new BorrowerUnit();

                oManager.ConnectionString = this.ConnectionString;
                oManager.Open();

                oUnit.CardType = cboType.Text;
                oUnit.BorrowerCode = txtBorrowerCode.Text;
                oUnit.LastName = txtLastName.Text;
                oUnit.FirstName = txtFirstName.Text;
                oUnit.MiddleName = txtMiddleName.Text;
                oUnit.Address = txtAddress.Text;
                oUnit.ContactNumber = txtContactNumber.Text;
                oUnit.Employer = cboEmployer.Text;
                oUnit.GuarantorID = cboGuarantorFinancer.EditValue.ToString();
                oUnit.GuarantorName = cboGuarantorFinancer.Text;
                oUnit.ATMNo = txtATMNo.Text;
                oUnit.EmploymentStatus = cboEmploymentStatus.Text;
                oUnit.EffectiveDate = Convert.ToDateTime(dtEffectiveDate.EditValue);
                oUnit.InterestRate = txtInterestRate.Text;
                oUnit.FrequencyOfPayment = cboFrequencyOfPayment.Text;
                if (cboPayDayCode.EditValue == null)
                {
                    oUnit.PayDayCode = "";
                }
                else
                {
                    oUnit.PayDayCode = cboPayDayCode.EditValue.ToString();
                }
                oUnit.MortgageInfo = txtMortgageInfo.Text;
                oUnit.CreditLimit = Convert.ToDouble(txtCreditLimit.Text);
                // Details

                oManager.UpdateBorrower(oUnit);
                oManager.Close();

                txtBorrowerCode.Enabled = false;
                MessageBox.Show("Updating successfull!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barCloseBorrower_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cboFrequencyOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFrequencyOfPayment.Text == "Custom")
            {
                cboPayDayCode.EditValue = null;
                cboPayDayCode.Enabled = true;
                cboPayDayCode.ClosePopup();
            }
            else
            {
                cboPayDayCode.EditValue = null;
                cboPayDayCode.Enabled = false;
                cboPayDayCode.ClosePopup();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barFindBorrower_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fndBorrower oForm = new fndBorrower();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();

            if (oForm.SelectedCode != null)
            {
                this.OpenDocument(oForm.SelectedCode);
            }

        }

        private void txtBorrowerCode_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
