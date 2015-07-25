using eLoan.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eLoanSystem.ViewForms
{
    public partial class viewCashRelease : Form
    {
        public viewCashRelease()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }

        void BindGrid()
        {
            CashReleaseManager oManager = new CashReleaseManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            gridControl1.DataSource = oManager.GetCashReleased();
            gridControl1.Refresh();
            oManager.Close();
        }
        private void viewCashRelease_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
