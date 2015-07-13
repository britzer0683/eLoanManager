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
    public partial class findLoanCashRelease : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public findLoanCashRelease()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string DocumentNo { get; set; }
        public string Guarantor { get; set; }
        private void findLoan_Load(object sender, EventArgs e)
        {
            cboSearchIndex.SelectedIndex = 0;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;
            this.DocumentNo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocNum"]).ToString();
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
                oCommand.CommandText = "SELECT * FROM OLOAN WHERE CARDNAME LIKE @CardName AND Guarrantor=@Guarrantor  AND DocStatus='Approved' AND DocNum NOT IN (SELECT RefLoanNo FROM CR1)";
                oCommand.Parameters.Add(new SqlParameter("@CardName", "%" + txtSearch.Text + "%"));
                oCommand.Parameters.Add(new SqlParameter("@Guarrantor", this.Guarantor));
            }
            else if (cboSearchIndex.SelectedIndex == 1)
            {

                oCommand.CommandText = "SELECT * FROM OLOAN WHERE DocNum LIKE @DocNum AND Guarrantor=@Guarrantor AND DocStatus='Approved' AND DocNum NOT IN (SELECT RefLoanNo FROM CR1)";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", "%" + txtSearch.Text + "%"));
                oCommand.Parameters.Add(new SqlParameter("@Guarrantor", this.Guarantor));
            }


            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);
            
            oConnection.Close();

            gridControl1.DataSource = dt;
            gridControl1.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    oCommand.CommandText = "SELECT * FROM OLOAN WHERE CARDNAME LIKE @CardName AND Guarrantor=@Guarrantor  AND DocStatus='Approved' AND DocNum NOT IN (SELECT RefLoanNo FROM CR1)";
                    oCommand.Parameters.Add(new SqlParameter("@CardName", "%" + txtSearch.Text + "%"));
                    oCommand.Parameters.Add(new SqlParameter("@Guarrantor", this.Guarantor));
                }
                else if (cboSearchIndex.SelectedIndex == 1)
                {

                    oCommand.CommandText = "SELECT * FROM OLOAN WHERE DocNum LIKE @DocNum AND Guarrantor=@Guarrantor AND DocStatus='Approved' AND DocNum NOT IN (SELECT RefLoanNo FROM CR1)";
                    oCommand.Parameters.Add(new SqlParameter("@DocNum", "%" + txtSearch.Text + "%"));
                    oCommand.Parameters.Add(new SqlParameter("@Guarrantor", this.Guarantor));
                }

                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);

                oConnection.Close();

                gridControl1.DataSource = dt;
                gridControl1.Refresh();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnChoose_Click(sender, e);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnChoose_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
