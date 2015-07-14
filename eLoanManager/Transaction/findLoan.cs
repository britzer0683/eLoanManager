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
    public partial class findLoan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public findLoan()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        public string DocumentNumber { get; set; }
        private void findLoan_Load(object sender, EventArgs e)
        {
            cboSearchIndex.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            if (cboSearchIndex.SelectedIndex == 0)
            {
                oCommand.CommandText = "SELECT * FROM OLOAN WHERE CARDNAME LIKE @CardName";
                oCommand.Parameters.Add(new SqlParameter("@CardName", "%" + txtSearch.Text + "%"));
                
            }
            else if (cboSearchIndex.SelectedIndex == 1)
            {
                oCommand.CommandText = "SELECT * FROM OLOAN WHERE Guarantor LIKE @Guarantor";
                oCommand.Parameters.Add(new SqlParameter("@Guarantor", "%" + txtSearch.Text + "%"));
            }
            else if (cboSearchIndex.SelectedIndex == 2)
            {

                oCommand.CommandText = "SELECT * FROM OLOAN WHERE DocNum LIKE @DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", "%" + txtSearch.Text + "%"));
            }

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            oConnection.Close();

            gridControl1.DataSource = dt;
            gridControl1.Refresh();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                if (cboSearchIndex.SelectedIndex == 0)
                {
                    oCommand.CommandText = "SELECT * FROM OLOAN WHERE CARDNAME LIKE @CardName ORDER BY DocNum DESC";
                    oCommand.Parameters.Add(new SqlParameter("@CardName", "%" + txtSearch.Text + "%"));

                }
                else if (cboSearchIndex.SelectedIndex == 1)
                {
                    oCommand.CommandText = "SELECT * FROM OLOAN WHERE Guarrantor LIKE @Guarantor ORDER BY DocNum DESC";
                    oCommand.Parameters.Add(new SqlParameter("@Guarantor", "%" + txtSearch.Text + "%"));
                }
                else if (cboSearchIndex.SelectedIndex == 2)
                {

                    oCommand.CommandText = "SELECT * FROM OLOAN WHERE DocNum LIKE @DocNum  ORDER BY DocNum DESC";
                    oCommand.Parameters.Add(new SqlParameter("@DocNum", "%" + txtSearch.Text + "%"));
                }

                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);

                oConnection.Close();

                gridControl1.DataSource = dt;
                gridControl1.Refresh();
            }
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
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;
            this.DocumentNumber = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocNum"]).ToString();
            this.Close();
        }
    }
}
