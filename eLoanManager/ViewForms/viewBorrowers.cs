using eLoan.BL;
using eLoanSystem.Setup;
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
    public partial class viewBorrowers : Form
    {
        public viewBorrowers()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        private void BindBorrowers()
        {
            BorrowerManager oManager = new BorrowerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            grdCtlBorrowerInfo.DataSource = oManager.GetBorrowersRecord();
            grdCtlBorrowerInfo.Refresh();

            oManager.Close();
        }
        private void viewBorrowers_Load(object sender, EventArgs e)
        {
            BindBorrowers();
        }

        private void txtBorrowerCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt1 = (DevExpress.XtraEditors.TextEdit)sender;

            BorrowerInfo oForm = new BorrowerInfo();
            oForm.MdiParent = this.MdiParent;
            oForm.ConnectionString = this.ConnectionString;
            oForm.OpenDocument(txt1.Text);
            oForm.Show();
        }
    }
}
