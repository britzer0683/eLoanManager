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
namespace eLoanSystem.Transaction
{
    public partial class addCollection : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public addCollection()
        {
            InitializeComponent();
        }

        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        public string LoanNumber { get; set; }
        public int ScheduledNo { get; set; }

        private void addCollection_Load(object sender, EventArgs e)
        {
            //txtReferenceNo.Text = this.LoanNumber;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string GetSeries()
        {
            SeriesManager oManager = new SeriesManager();
            string sSeries = "";
            string sPrefix = "";
            int digitNo = 0;
            string _objectType = "Payment";

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            sSeries = oManager.GetNewSeries(_objectType);
            sPrefix = oManager.GetPrefix(_objectType);
            digitNo = Convert.ToInt16(oManager.GetDigit(_objectType));
            oManager.Close();

            return sPrefix +  sSeries;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CollectionManager oManager = new CollectionManager();
            CollectionUnit oUnit = new CollectionUnit();

            
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            oUnit.DocNum = this.LoanNumber;
            oUnit.RefNo = txtReferenceNo.Text;
            oUnit.ScheduleNo = this.ScheduledNo;
            oUnit.Remarks = txtRemarks.Text;
            oUnit.TotalPayment = Convert.ToDouble(txtAmount.Text);

            oUnit.DateCreated = System.DateTime.Now;
            oUnit.DateModified = System.DateTime.Now;
            oUnit.CreatedBy = this.ActiveUserID;
            oUnit.ModifiedBy = this.ActiveUserID;

            oManager.AddCollection(oUnit);

            oManager.Close();

            this.Close();
        }
    }
}
