using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLoanSystem.Transaction
{
    public partial class findCashReleaseDocument : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public findCashReleaseDocument()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        public string DocumentNumber { get; set; }
        private void BindCashRelease()
        {
            if (cboSearchIndex.SelectedIndex == 0)
            {
                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                DataTable dt = new DataTable();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "SELECT * FROM OCR WHERE DocNum LIKE @DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", "%" + txtSearch.Text +"%"));

                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);
                gridControl1.DataSource = dt;
                gridControl1.Refresh();
                oConnection.Close();
            }
            else if (cboSearchIndex.SelectedIndex == 1)
            {
                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                DataTable dt = new DataTable();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.Parameters.Add(new SqlParameter("@Guarrantor", "%" + txtSearch.Text + "%"));

                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);
                gridControl1.DataSource = dt;
                gridControl1.Refresh();
                oConnection.Close();
            }

            
        }
        private void findCashReleaseDocument_Load(object sender, EventArgs e)
        {
            cboSearchIndex.SelectedIndex = 0;
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            int iFocusedRow = gridView1.FocusedRowHandle;

            if (iFocusedRow <= 0)
            {
                return;
            }
            this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRow, gridView1.Columns["DocNum"]).ToString();
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iFocusedRow = gridView1.FocusedRowHandle;

            this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRow, gridView1.Columns["DocNum"]).ToString();
            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int iFocusedRow = gridView1.FocusedRowHandle;

                this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRow, gridView1.Columns["DocNum"]).ToString();
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BindCashRelease();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindCashRelease();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
