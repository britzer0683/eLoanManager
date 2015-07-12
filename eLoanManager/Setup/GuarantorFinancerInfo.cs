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

namespace eLoanSystem.Setup
{
    public partial class GuarantorFinancerInfo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public GuarantorFinancerInfo()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }

        public eLoanMain eLoanMainMenu { get; set; }

        public void OpenGuarantorInfo(string sCode)
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            DataTable dtGuarantorInfo = oManager.GetGuarantorInfo(sCode);
            oManager.Close();

            DataRow oRow = dtGuarantorInfo.Rows[0];
            txtCode.Text = oRow["GuarantorFinancerCode"].ToString();
            txtEmployerName.Text = oRow["GuarantorFinancerName"].ToString();
            txtAddress.Text = oRow["Address"].ToString();
            txtContactNo.Text = oRow["ContactNumber"].ToString();
            txtEmailAddress.Text = oRow["EmailAddress"].ToString();
            txtContactPerson.Text = oRow["ContactPerson"].ToString();

            txtCode.Enabled = false;

        }

        bool IsExists(string sCode)
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();
            GuarantorFinancerUnit oUnit = new GuarantorFinancerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            bool rValue = oManager.IsExists(txtCode.Text);
            
            oManager.Close();

            return rValue;
        }
        public void AddGuarantor()
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();
            GuarantorFinancerUnit oUnit = new GuarantorFinancerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            oUnit.GuarantorFinancerCode = txtCode.Text;
            oUnit.GuarantorFinancerName = txtEmployerName.Text;
            oUnit.Address = txtAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.EmailAddress = txtEmailAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.ContactPerson = txtContactPerson.Text;

            oManager.AddGuarantorFinancer(oUnit);

            oManager.Close();

        }

        public void UpdateGuarantor()
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();
            GuarantorFinancerUnit oUnit = new GuarantorFinancerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            oUnit.GuarantorFinancerCode = txtCode.Text;
            oUnit.GuarantorFinancerName = txtEmployerName.Text;
            oUnit.Address = txtAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.EmailAddress = txtEmailAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.ContactPerson = txtContactPerson.Text;

            oManager.UpdateGuarantor(oUnit);

            oManager.Close();

        }
        private void GuarantorFinancerInfo_Load(object sender, EventArgs e)
        {

        }

        private void barCloseForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCode.Enabled == true)
            {
                if(txtCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please insert code!!! Blank code is not permitted!!!", "Blank Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (IsExists(txtCode.Text))
                {
                    MessageBox.Show("Code is already exists please try another code!!!!", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                AddGuarantor();
                this.eLoanMainMenu.RefreshMainMenu();
                this.Close();
            }
            else
            {
                UpdateGuarantor();
                this.eLoanMainMenu.RefreshMainMenu();
                this.Close();
            }
        }

        private void barSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCode.Enabled == true)
            {
                if (txtCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please insert code!!! Blank code is not permitted!!!", "Blank Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IsExists(txtCode.Text))
                {
                    MessageBox.Show("Code is already exists please try another code!!!!", "Record Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                AddGuarantor();
                this.eLoanMainMenu.RefreshMainMenu();
                txtCode.Text = "";
                txtEmployerName.Text = "";
                txtAddress.Text = "";
                txtContactNo.Text = "";
                txtEmailAddress.Text = "";
                txtContactNo.Text = "";
                txtContactPerson.Text = "";
            }
            else
            {
                UpdateGuarantor();
                this.eLoanMainMenu.RefreshMainMenu();
                txtCode.Enabled = true;
                txtCode.Text = "";
                txtEmployerName.Text = "";
                txtAddress.Text = "";
                txtContactNo.Text = "";
                txtEmailAddress.Text = "";
                txtContactNo.Text = "";
                txtContactPerson.Text = "";
            }
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            txtEmployerName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailAddress.Text = "";
            txtContactNo.Text = "";
            txtContactPerson.Text = "";
        }
    }
}
