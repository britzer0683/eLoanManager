using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLoanSystem.Transaction
{
    public partial class Payment : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Payment()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private void Payment_Load(object sender, EventArgs e)
        {
            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;

            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;
        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void labelControl13_Click(object sender, EventArgs e)
        {

        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
