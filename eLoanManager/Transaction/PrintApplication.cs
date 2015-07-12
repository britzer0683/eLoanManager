using CrystalDecisions.CrystalReports.Engine;
using System;
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
    public partial class PrintApplication : Form
    {
        public PrintApplication()
        {
            InitializeComponent();
        }

        public string DocumentNumber { get; set; }
        public void ViewLayout()
        {
            reportDocument1.SetParameterValue(0, this.DocumentNumber);
            reportDocument1.SetDatabaseLogon("sa", "nidaros");
            crystalReportViewer1.ReportSource = reportDocument1;
            crystalReportViewer1.Refresh();
        }
        private void PrintApplication_Load(object sender, EventArgs e)
        {
            
        }
    }
}
