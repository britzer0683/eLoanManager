using System;
using System.Data.SqlClient;
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
    public partial class findCollection : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public findCollection()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        public string DocumentNumber { get; set; }
        void BindGrid()
        {
            if (cboSearch.SelectedIndex == 0)
            {
                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "SELECT * FROM OCL WHERE DocNum LIKE @DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", "%" + txtSearch.Text + "%"));
                DataTable dt = new DataTable();
                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);
                gridControl1.DataSource = dt;
                gridControl1.Refresh();
                oConnection.Close();
            }
            else
            {
                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "SELECT * FROM OCL WHERE Guarantor LIKE @DocNum";
                oCommand.Parameters.Add(new SqlParameter("@Guarantor", "%" + txtSearch.Text + "%"));
                DataTable dt = new DataTable();
                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);
                gridControl1.DataSource = dt;
                gridControl1.Refresh();
                oConnection.Close();
            }
        }
        private void findCollection_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocNum"]).ToString();
            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                int iFocusedRowIndex = gridView1.FocusedRowHandle;

                this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocNum"]).ToString();
                this.Close();
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocNum"]).ToString();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BindGrid();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindGrid();
            }
        }
    }
}
