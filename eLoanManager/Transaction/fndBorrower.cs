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
    public partial class fndBorrower : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fndBorrower()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }

        public string SelectedCode { get; set; }
        public string SelectedName { get; set; }
        public string InterestRate { get; set; }

        public string FrequencyOfPayment { get; set; }
        public string PayDayCode { get; set; }
        public string GuarrantorName { get; set; }

        void BindGrid(string sSearch)
        {
            BorrowerManager oManager = new BorrowerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            gridControl1.DataSource = oManager.SearchBorrowersInfo(sSearch);
            gridControl1.Refresh();

            oManager.Close();
        }
        private void LA_fndBorrower_Load(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            this.SelectedCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["BorrowerCode"]).ToString();
            this.SelectedName = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["FullName"]).ToString();

            this.InterestRate = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["InterestRate"]).ToString();
            this.FrequencyOfPayment = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["FrequencyOfPayment"]).ToString();
            this.PayDayCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["PayDayCode"]).ToString();
            this.GuarrantorName = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["GuarantorName"]).ToString();

            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            this.SelectedCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["BorrowerCode"]).ToString();
            this.SelectedName = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["FullName"]).ToString();
            this.InterestRate = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["InterestRate"]).ToString();
            this.FrequencyOfPayment = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["FrequencyOfPayment"]).ToString();
            this.PayDayCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["PayDayCode"]).ToString();
            this.GuarrantorName = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["GuarantorName"]).ToString();

            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int iFocusedRowIndex = gridView1.FocusedRowHandle;

                    this.SelectedCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["BorrowerCode"]).ToString();
                    this.SelectedName = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["FullName"]).ToString();
                    this.InterestRate = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["InterestRate"]).ToString();
                    this.FrequencyOfPayment = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["FrequencyOfPayment"]).ToString();
                    this.PayDayCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["PayDayCode"]).ToString();
                    this.GuarrantorName = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["GuarantorName"]).ToString();

                }
                catch { }
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BindGrid(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindGrid(txtSearch.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
