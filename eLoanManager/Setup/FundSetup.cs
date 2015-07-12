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
    public partial class FundSetup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FundSetup()
        {
            InitializeComponent();
        }

        public eLoanMain eLoanMainForm { get; set; }
        public string ConnectionString { get; set; }
        private void BindGrid()
        {
            FundManager oManager = new FundManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            gridControl1.DataSource = oManager.GetCashBankSetup();
            gridControl1.Refresh();
            oManager.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FundManager oManager = new FundManager();
            FundUnit oUnit = new FundUnit();

            
            oUnit.AccountNumber = txtAccountNo.Text;
            oUnit.AccountName = txtAccountName.Text;

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            oManager.AddCashBank(oUnit);
            oManager.Close();

            txtAccountNo.Text = "";
            txtAccountName.Text = "";

            BindGrid();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CashBankSetup_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
