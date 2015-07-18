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
    public partial class EmployerInfo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public EmployerInfo()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        public eLoanMain MainMenu { get; set; }

        public void OpenEmployerInfo(string sCode)
        {
            EmployerManager oManager = new EmployerManager();
            
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dtEmployer = oManager.GetEmployerInfo(sCode);
            DataRow dtRow = dtEmployer.Rows[0];

            txtCode.Text = dtRow["EmployerCode"].ToString();
            txtEmployerName.Text = dtRow["EmployerName"].ToString();
            txtTINIDNo.Text = dtRow["EmployerTINIDNo"].ToString();
            txtAddress.Text = dtRow["Address"].ToString();
            txtContactNo.Text = dtRow["ContactNumber"].ToString();
            txtEmailAddress.Text = dtRow["EmailAddress"].ToString();
            txtContactPerson.Text = dtRow["ContactPerson"].ToString();

            txtCode.Enabled = false;

            oManager.Close();

        }

        private bool IsEmployerCodeExists(string sCode)
        {
            EmployerManager oManager = new EmployerManager();
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            bool _returnValue = oManager.IsCodeExists(sCode);

            oManager.Close();

            return _returnValue;
        }
        public void AddEmployer()
        {
            EmployerManager oManager = new EmployerManager();
            EmployerUnit oUnit = new EmployerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            oUnit.EmployerCode = txtCode.Text;
            oUnit.EmployerName = txtEmployerName.Text;
            oUnit.EmployerTINIDNo = txtTINIDNo.Text;
            oUnit.Address = txtAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.EmailAddress = txtEmailAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.ContactPerson = txtContactPerson.Text;

            oManager.AddEmployer(oUnit);

            oManager.Close();
            txtCode.Enabled = false;
            
        }
        public void UpdateEmployer()
        {
            EmployerManager oManager = new EmployerManager();
            EmployerUnit oUnit = new EmployerUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            oUnit.EmployerCode = txtCode.Text;
            oUnit.EmployerName = txtEmployerName.Text;
            oUnit.EmployerTINIDNo = txtTINIDNo.Text;
            oUnit.Address = txtAddress.Text;
            oUnit.EmailAddress = txtEmailAddress.Text;
            oUnit.ContactNumber = txtContactNo.Text;
            oUnit.ContactPerson = txtContactPerson.Text;

            oManager.UpdateEmployer(oUnit);
            oManager.Close();

            txtCode.Enabled = false;
            
        }
        
        private void EmployerInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Blank code is not accepted, please insert code.", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsEmployerCodeExists(txtCode.Text) == false)
            {
                AddEmployer();
                txtCode.Enabled = false;
                MessageBox.Show("Adding is successfull", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtCode.Enabled == true)
                {
                    MessageBox.Show("Code already exists in the database. Please check or try another code.", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    UpdateEmployer();
                    txtCode.Enabled = false;
                    MessageBox.Show("Updating is successfull", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void barFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            findEmployee oForm = new findEmployee();

            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();

            if (oForm.EmployeeCode != null)
            {
                this.OpenEmployerInfo(oForm.EmployeeCode);
            }

        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtCode.Enabled = true;
            txtCode.Text = "";
            txtEmployerName.Text = "";
            txtTINIDNo.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailAddress.Text = "";
            txtContactPerson.Text = "";
        }

    
    }
}
