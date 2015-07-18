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
    public partial class viewEmployer : Form
    {
        public viewEmployer()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        private void BindEmployers()
        {
            EmployerManager oManager = new EmployerManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            gridControl2.DataSource = oManager.GetEmployerInfo();
            gridControl2.Refresh();

            oManager.Close();
        }

        private void viewEmployer_Load(object sender, EventArgs e)
        {
            BindEmployers();
        }
    }
}
