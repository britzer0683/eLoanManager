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
    public partial class findEmployee : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public findEmployee()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        public string EmployeeCode { get; set; }
        void BindGridByCode(string sEmpCode)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM M_EMPLOYER WHERE EmployerCode LIKE @EmployerCode";
            oCommand.Parameters.Add(new SqlParameter("@EmployerCode", sEmpCode));

            oAdapter.SelectCommand = oCommand;
            DataTable dt = new DataTable();
            oAdapter.Fill(dt);

            gridControl1.DataSource = dt;
            gridControl1.Refresh();

            oConnection.Close();
        }

        void BindGridByName(string sEmpName)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM M_EMPLOYER WHERE EmployerName LIKE @EmployerName";
            oCommand.Parameters.Add(new SqlParameter("@EmployerName", sEmpName));

            oAdapter.SelectCommand = oCommand;
            DataTable dt = new DataTable();
            oAdapter.Fill(dt);

            gridControl1.DataSource = dt;
            gridControl1.Refresh();

            oConnection.Close();
        }
        private void findEmployee_Load(object sender, EventArgs e)
        {
            cboSearchIndex.SelectedIndex = 0;
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cboSearchIndex.SelectedIndex == 0)
            {
                BindGridByName("%" + txtSearch.Text + "%");
            }
            else if (cboSearchIndex.SelectedIndex == 1)
            {
                BindGridByCode("%" + txtSearch.Text + "%");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboSearchIndex.SelectedIndex == 0)
                {
                    BindGridByName("%" + txtSearch.Text + "%");
                }
                else if (cboSearchIndex.SelectedIndex == 1)
                {
                    BindGridByCode("%" + txtSearch.Text + "%");
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            this.EmployeeCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["EmployerCode"]).ToString();

            this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //int iFocusedRowIndex = gridView1.FocusedRowHandle;

            //this.EmployeeCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["EmployerCode"]).ToString();

            //this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            this.EmployeeCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["EmployerCode"]).ToString();

            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int iFocusedRowIndex = gridView1.FocusedRowHandle;

                this.EmployeeCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["EmployerCode"]).ToString();

                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
