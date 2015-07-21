using eLoan.BL;
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
    public partial class CollectionWorkspace : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CollectionWorkspace()
        {
            InitializeComponent();
        }
        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private DataTable LineItems { get; set; }
        void RemoveBlankRowFirst()
        {
            gridView1.MoveLast();
            int iFocusedRowIndex = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"]).ToString() == "")
            {
                gridView1.DeleteRow(iFocusedRowIndex);
            }
        }
        private void InitializeTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("RefLoanNo", typeof(string));
            dt.Columns.Add("Borrower", typeof(string));
            dt.Columns.Add("ScheduleNo", typeof(string));
            dt.Columns.Add("DueDate", typeof(DateTime));
            dt.Columns.Add("DueAmount", typeof(double));
            dt.Columns.Add("PaidAmount", typeof(double));
            dt.Columns.Add("ChangeAmount", typeof(double));

            this.LineItems = dt;

        }

        public void OpenDocument(string sDocumentNo)
        {
            BindGuarantor();
            InitializeTable();

            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM OCL WHERE OCL.DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            DataRow oRow = dt.Rows[0];

            txtDocNum.Text = oRow["DocNum"].ToString();
            cboGuarantor.EditValue = oRow["Guarantor"].ToString();
            txtRemarks.Text = oRow["Remarks"].ToString();
            dtPostDate.EditValue = (DateTime)oRow["DateCreated"];

            gridControl1.DataSource = dt;
            gridControl1.Refresh();

            oConnection.Close();

        }
        private void batchPaymentCollection_Load(object sender, EventArgs e)
        {
            BindGuarantor();
            InitializeTable();

            dtPostDate.EditValue = System.DateTime.Now;
            gridControl1.DataSource = this.LineItems;
            gridControl1.Refresh();

            if (gridView1.RowCount <= 0)
            {
                gridView1.AddNewRow();
            }
        }

        private void barMenuExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CollectionWorkspace oForm = new CollectionWorkspace();

            oForm.ConnectionString = this.ConnectionString;
            oForm.MdiParent = this.MdiParent;
            oForm.Show();
        }
        void BindGuarantor()
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM M_GUARANTORFINANCER";

            oAdapter.SelectCommand = oCommand;
            DataTable dt = new DataTable();
            oAdapter.Fill(dt);

            oConnection.Close();

            cboGuarantor.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerCode", 200, "Code"));
            cboGuarantor.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerName", 200, "Name"));

            cboGuarantor.Properties.DisplayMember = "GuarantorFinancerName";
            cboGuarantor.Properties.ValueMember = "GuarantorFinancerName";
            cboGuarantor.Properties.DataSource = dt;

            cboGuarantor.Refresh();

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        string GetSeries()
        {
            SeriesManager oManager = new SeriesManager();
            string sSeries = "";
            string sPrefix = "";
            int digitNo = 0;
            string _objectType = "Collection";

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            sSeries = oManager.GetNewSeries(_objectType);
            sPrefix = oManager.GetPrefix(_objectType);
            digitNo = Convert.ToInt16(oManager.GetDigit(_objectType));
            oManager.Close();

            return sPrefix + String.Format("{0:D5}", Convert.ToInt16(sSeries));
        }

        private void barSaveDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtDocNum.Text == "######")
            {
                RemoveBlankRowFirst();

                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "INSERT INTO OCL (DocNum, Guarantor, Remarks, DateCreated, CreatedBy, DateModified, ModifiedBy) VALUES (@DocNum, @Guarantor, @Remarks, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)";
                txtDocNum.Text = GetSeries();
                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                oCommand.Parameters.Add(new SqlParameter("@Guarantor", cboGuarantor.EditValue.ToString()));
                oCommand.Parameters.Add(new SqlParameter("@Remarks", txtRemarks.Text));
                oCommand.Parameters.Add(new SqlParameter("@DateCreated", System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@CreatedBy", this.ActiveUserID));
                oCommand.Parameters.Add(new SqlParameter("@DateModified", System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", this.ActiveUserID));
                oCommand.ExecuteNonQuery();


                SqlCommand cmd = new SqlCommand();

                foreach (DataRow oRow in this.LineItems.Rows)
                {
                    if (oRow.RowState != DataRowState.Deleted)
                    {
                        cmd = new SqlCommand();

                        cmd.Connection = oConnection;
                        cmd.CommandText = "INSERT INTO CL1 (DocNum, RefLoanNo, ScheduleNo, DueAmount, PaidAmount, ChangeAmount) VALUES (@DocNum, @RefLoanNo, @ScheduleNo, @DueAmount, @PaidAmount, @ChangeAmount)";

                        cmd.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                        cmd.Parameters.Add(new SqlParameter("@RefLoanNo", oRow["RefLoanNo"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@ScheduleNo", oRow["ScheduleNo"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@DueAmount", oRow["DueAmount"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@PaidAmount", oRow["PaidAmount"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@ChangeAmount", oRow["ChangeAmount"].ToString()));

                        cmd.ExecuteNonQuery();
                    }

                }


                oConnection.Close();

                MessageBox.Show("Adding sucessfull!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RemoveBlankRowFirst();

                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "UPDATE OCL SET Guarantor=@Guarantor, Remarks=@Remarks, DateModified=@DateModified, ModifiedBy=@ModifiedBy where DocNum=@DocNum";
                
                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                oCommand.Parameters.Add(new SqlParameter("@Guarantor", cboGuarantor.EditValue.ToString()));
                oCommand.Parameters.Add(new SqlParameter("@Remarks", txtRemarks.Text));
                oCommand.Parameters.Add(new SqlParameter("@DateCreated", System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@CreatedBy", this.ActiveUserID));
                oCommand.Parameters.Add(new SqlParameter("@DateModified", System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", this.ActiveUserID));
                oCommand.ExecuteNonQuery();

                oCommand = new SqlCommand();
                oCommand.Connection = oConnection;
                oCommand.CommandText = "DELETE FROM CL1 WHERE DocNum=@DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));

                oCommand.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand();

                foreach (DataRow oRow in this.LineItems.Rows)
                {
                    if (oRow.RowState != DataRowState.Deleted)
                    {
                        cmd = new SqlCommand();

                        cmd.Connection = oConnection;
                        cmd.CommandText = "INSERT INTO CL1 (DocNum, RefLoanNo, ScheduleNo, DueAmount, PaidAmount, ChangeAmount) VALUES (@DocNum, @RefLoanNo, @ScheduleNo, @DueAmount, @PaidAmount, @ChangeAmount)";

                        cmd.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                        cmd.Parameters.Add(new SqlParameter("@RefLoanNo", oRow["RefLoanNo"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@ScheduleNo", oRow["ScheduleNo"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@DueAmount", oRow["DueAmount"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@PaidAmount", oRow["PaidAmount"].ToString()));
                        cmd.Parameters.Add(new SqlParameter("@ChangeAmount", oRow["ChangeAmount"].ToString()));

                        cmd.ExecuteNonQuery();
                    }

                }


                oConnection.Close();
                MessageBox.Show("Updating sucessfull!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }

        void BindSchedule(string sLoanNo)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT ScheduleNo, ScheduledDate, PaymentAmount - PaidAmount PaymentAmount  FROM LOAN1 WHERE DocNum=@DocNum and (PaymentAmount - PaidAmount)>0";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sLoanNo));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            gridControl2.DataSource = dt;
            gridControl2.Refresh();

            oConnection.Close();
        }
        private void cboGuarantor_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDocNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            findLoanForCollection oForm = new findLoanForCollection();
            oForm.ConnectionString = this.ConnectionString;
            oForm.Guarantor = cboGuarantor.Text;
            oForm.ShowDialog();

            if (oForm.DocumentNo == null)
            {
                return;
            }

            int iFocusedRowIndex = gridView1.FocusedRowHandle;
                
            gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"], oForm.DocumentNo);
            gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["Borrower"], oForm.Borrower);
            

            BindSchedule(oForm.DocumentNo);
        }

        private void gridView2_Click(object sender, EventArgs e)
        {

            int iFocusedRowIndex = gridView2.FocusedRowHandle;

            string sScheduleNo = gridView2.GetRowCellValue(iFocusedRowIndex, gridView2.Columns["ScheduleNo"]).ToString();
            DateTime dtScheduleDate = (DateTime)gridView2.GetRowCellValue(iFocusedRowIndex, gridView2.Columns["ScheduledDate"]);
            double sAmount = Convert.ToDouble(gridView2.GetRowCellValue(iFocusedRowIndex, gridView2.Columns["PaymentAmount"]));
            
            iFocusedRowIndex = gridView1.FocusedRowHandle;
            
            gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduleNo"], sScheduleNo);
            gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["DueDate"], dtScheduleDate);
            gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["DueAmount"], sAmount);

            if (popupContainerControl1.OwnerEdit != null)
            {
                popupContainerControl1.OwnerEdit.ClosePopup();
            }

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (gridView1.IsLastRow)
                {
                    int iFocusedRowIndex = gridView1.FocusedRowHandle;
                    string sBlankInfo = "";

                    sBlankInfo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"]).ToString();
                    if (sBlankInfo != "")
                    {
                        gridView1.AddNewRow();
                    }
                }
            }
        }

        private void txtPaidAmount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            int iFocusedRowIndex = gridView1.FocusedRowHandle;
            DevExpress.XtraEditors.TextEdit txt = (DevExpress.XtraEditors.TextEdit )sender;
            double dueAmount = Convert.ToDouble(gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["DueAmount"]));
            double val = Convert.ToDouble(txt.EditValue);

            gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["ChangeAmount"], val - dueAmount);
            
        }
    }
}
