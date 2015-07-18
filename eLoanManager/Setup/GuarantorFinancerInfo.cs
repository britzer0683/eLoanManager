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
using eLoanSystem.Transaction;

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

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                MessageBox.Show("Adding is successfull!!!!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Enabled = true;

            }
            else
            {
                UpdateGuarantor();
                MessageBox.Show("Updating is successfull!!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Enabled = true;
            }
        }

        private void barFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            findGuarantor oForm = new findGuarantor();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();

            if (oForm.GuarantorID != null)
            {
                this.OpenGuarantorInfo(oForm.GuarantorID);
                txtCode.Enabled = false;
            }
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuarantorFinancerInfo oForm = new GuarantorFinancerInfo();

            oForm.ConnectionString = this.ConnectionString;

            oForm.MdiParent = this.MdiParent;
            oForm.Show();
        }
    }
}
