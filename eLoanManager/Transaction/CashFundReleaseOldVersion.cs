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

namespace eLoanSystem.Transaction
{
    public partial class CashFundReleaseOldVersion : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CashFundReleaseOldVersion()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private void CashFundRelease_Load(object sender, EventArgs e)
        {
            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;
        }

        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {
        
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
