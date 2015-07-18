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
    public partial class findGuarantor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public findGuarantor()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string GuarantorID { get; set; }
        void BindGuarantorByID(string sEID)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM M_GUARANTORFINANCER WHERE GuarantorFinancerCode=@GuarantorFinancerCode";
            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerCode", sEID));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            

            oConnection.Close();
        }

        void BindGuarantorByName(string sName)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM M_GUARANTORFINANCER WHERE GuarantorFinancerName=@GuarantorFinancerName";
            oCommand.Parameters.Add(new SqlParameter("@GuarantorFinancerName", sName));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);



            oConnection.Close();
        }

        private void findGuarantor_Load(object sender, EventArgs e)
        {
            cboSelectedIndex.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            string sCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["GuarantorFinancerCode"]).ToString();
            this.GuarantorID = sCode;
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            string sCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["GuarantorFinancerCode"]).ToString();
            this.GuarantorID = sCode;
            this.Close();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int iFocusedRowIndex = gridView1.FocusedRowHandle;

                string sCode = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["GuarantorFinancerCode"]).ToString();
                this.GuarantorID = sCode;
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (cboSelectedIndex.SelectedIndex == 0)
            {
                BindGuarantorByName("%" + txtSearch.Text + "%");
            }
            else
            {
                BindGuarantorByID("%" + txtSearch.Text + "%");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboSelectedIndex.SelectedIndex == 0)
                {
                    BindGuarantorByName("%" + txtSearch.Text + "%");
                }
                else
                {
                    BindGuarantorByID("%" + txtSearch.Text + "%");
                }
            }
        }
    }
}
