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
    public partial class viewGuarantorFinancer : Form
    {
        public viewGuarantorFinancer()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        private void BindGuarantor()
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            DataTable dtGuarantor = oManager.GetGuarantorInfo();
            oManager.Close();

            grdCtlGuarantorFinancer.DataSource = dtGuarantor;
            grdCtlGuarantorFinancer.Refresh();
        }
        private void viewGuarantorFinancer_Load(object sender, EventArgs e)
        {
            BindGuarantor();
        }
    }
}
