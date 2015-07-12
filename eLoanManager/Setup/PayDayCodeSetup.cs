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
    public partial class PayDayCodeSetup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public PayDayCodeSetup()
        {
            InitializeComponent();
        }
        public eLoanMain MainMenu { get; set; }
        public string ActiveUserID { get; set; }
        public string ConnectionString { get; set; }
        public DataTable LineItems { get; set; }

        private void InitializeLineItem()
        {
            DataTable dtLineItems = new DataTable();
            dtLineItems.Columns.Add("Interval", typeof(string));
            dtLineItems.Columns.Add("DayWeekNo", typeof(string));

            this.LineItems = dtLineItems;
        }
        private void PayDayCodeSetup_Load(object sender, EventArgs e)
        {
            InitializeLineItem();

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;
            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

        }

        private void txtDayWeekNo_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.MainMenu.RefreshMainMenu();
            this.Close();
        }

        private void txtDayWeekNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow oRow = this.LineItems.NewRow();

            oRow["Interval"] = cboInterval.Text;
            oRow["DayWeekNo"] = txtDayWeekNo.Text;

            this.LineItems.Rows.Add(oRow);

            txtDayWeekNo.Text = "";

            gridControl1.DataSource = this.LineItems;
            gridControl1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PayDayCodeManager oManager = new PayDayCodeManager();
            PayDayCodeUnit oUnit = new PayDayCodeUnit();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            oUnit.Code = txtCode.Text;
            oUnit.Description = txtDescription.Text;

            oUnit.DateCreated = Convert.ToDateTime(dtCreated.EditValue);
            oUnit.CreatedBy = txtCreatedBy.Text;
            oUnit.DateModified = Convert.ToDateTime(dtModified.EditValue);
            oUnit.ModifiedBy = txtModifiedBy.Text;

            oUnit.LineItems = this.LineItems;
            oManager.Add(oUnit);

            oManager.Close();

            this.MainMenu.RefreshMainMenu();
        }
    }
}
