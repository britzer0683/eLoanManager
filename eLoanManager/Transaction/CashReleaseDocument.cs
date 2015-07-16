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
using eLoanSystem.Transaction;
using eLoan.BL;

namespace eLoanSystem.Transaction
{
    public partial class CashReleaseDocument : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CashReleaseDocument()
        {
            InitializeComponent();
        }

        public bool Stopper { get; set; }
        public string ConnectionString { get; set; }
        public string ActiveUserID { get; set; }
        private DataTable LineItems { get; set; }

        private void EnableControls()
        {
            cboSourceOfFund.Enabled = true;
            cboFundDestination.Enabled = true;
            cboGuarantorFinancer.Enabled = true;
            txtRemarks.Enabled = true;
            txtAmount.Enabled = true;

        }
        private void DisableControls()
        {
            cboSourceOfFund.Enabled = false;
            cboFundDestination.Enabled = false;
            cboGuarantorFinancer.Enabled = false;
            txtRemarks.Enabled = false;
            txtAmount.Enabled = false;

        }
        private void InitializeLineItems()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("RefLoanNo", typeof(string));
            dt.Columns.Add("CardCode", typeof(string));
            dt.Columns.Add("CardName", typeof(string));
            dt.Columns.Add("LoanAmount", typeof(double));
            dt.Columns.Add("ReferenceDocument", typeof(string)); //ATM or PDC
            dt.Columns.Add("ReceivedAmount", typeof(double));
            dt.Columns.Add("DocStatus", typeof(string));

            this.LineItems = dt;

        }
        string GetSeries()
        {
            SeriesManager oManager = new SeriesManager();
            string sSeries = "";
            string sPrefix = "";
            int digitNo = 0;
            string _objectType = "CashRelease";

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            sSeries = oManager.GetNewSeries(_objectType);
            sPrefix = oManager.GetPrefix(_objectType);
            digitNo = Convert.ToInt16(oManager.GetDigit(_objectType));
            oManager.Close();

            return sPrefix + String.Format("{0:D5}", Convert.ToInt16(sSeries));
        }

        void BindSourceOfFund()
        {
            FundManager oManager = new FundManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            //gridControl1.DataSource = oManager.GetCashBankSetup();
            //gridControl1.Refresh();
            cboSourceOfFund.Properties.DisplayMember = "AccountName";
            cboSourceOfFund.Properties.ValueMember = "AccountNumber";

            cboSourceOfFund.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountNumber", "Code"));
            cboSourceOfFund.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName", "Fund Name"));

            cboSourceOfFund.Properties.DataSource = oManager.GetCashBankSetup();
            cboSourceOfFund.Refresh();

            oManager.Close();
        }

        void BindDestinationOfFund()
        {
            FundManager oManager = new FundManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            //gridControl1.DataSource = oManager.GetCashBankSetup();
            //gridControl1.Refresh();
            cboFundDestination.Properties.DisplayMember = "AccountName";
            cboFundDestination.Properties.ValueMember = "AccountNumber";

            cboFundDestination.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountNumber", "Code"));
            cboFundDestination.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName", "Fund Name"));

            cboFundDestination.Properties.DataSource = oManager.GetCashBankSetup();
            cboFundDestination.Refresh();

            oManager.Close();
        }

        public void OpenDocument(string sDocNum)
        {

            InitializeLineItems();
            BindGuarantor();

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

            BindSourceOfFund();
            BindDestinationOfFund();

            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dtHeader = new DataTable();
            DataTable dtLineItems = new DataTable();


            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM OCR WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtHeader);


            oCommand = new SqlCommand();
            oAdapter = new SqlDataAdapter();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT * FROM CR1 WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sDocNum));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dtLineItems);


            this.LineItems = dtLineItems;

            DataRow oRow = dtHeader.Rows[0];

            txtDocNum.Text = oRow["DocNum"].ToString();
            cboSourceOfFund.EditValue = oRow["SourceOfFund"].ToString();
            cboFundDestination.EditValue = oRow["DestinationOfFund"].ToString();
            cboGuarantorFinancer.EditValue = oRow["Guarantor"].ToString();
            txtRemarks.Text = oRow["Remarks"].ToString();
            txtAmount.Text = oRow["Amount"].ToString();

            txtDocStatus.Text = oRow["DocStatus"].ToString();
            txtCreatedBy.Text = oRow["CreatedBy"].ToString();
            dtCreated.EditValue = oRow["DateCreated"].ToString();
            txtModifiedBy.Text = oRow["ModifiedBy"].ToString();
            dtModified.EditValue = oRow["DateModified"].ToString();

            gridControl1.DataSource = this.LineItems;
            gridControl1.Refresh();
            oConnection.Close();

            barSaveDocument.Caption = "Update";
        }
        private void CashFundRelease_Load(object sender, EventArgs e)
        {
            if (this.Stopper == true)
            {
                return;
            }

            InitializeLineItems();
            BindGuarantor();

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;
            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

            BindSourceOfFund();
            BindDestinationOfFund();

            gridControl1.DataSource = this.LineItems;
            gridControl1.Refresh();
            
            gridView1.AddNewRow();
        }

        void RemoveBlankRowFirst()
        {
            gridView1.MoveLast();
            int iFocusedRow = gridView1.FocusedRowHandle;
            if (iFocusedRow > 0)
            {
                string sLastData = gridView1.GetRowCellValue(iFocusedRow, gridView1.Columns["RefLoanNo"]).ToString();

                if (sLastData == "")
                {
                    gridView1.DeleteRow(iFocusedRow);
                    gridView1.RefreshData();
                }
            }
        }

        void BindDueLoans(string sLoanNumber)
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT ScheduleNo, ScheduledDate DueDate FROM LOAN1 WHERE PaidAmount <=0 and DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", sLoanNumber));
            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);

            oConnection.Close();



            //DevExpress.XtraEditors.LookUpEdit oLookUp = cboDueDate.OwnerEdit;
            //oLookUp = new DevExpress.XtraEditors.LookUpEdit();
            //oLookUp.Properties.Columns.Clear();
            //oLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ScheduleNo"));
            //oLookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DueDate"));

            //oLookUp.Properties.DataSource = dt;
            //oLookUp.Refresh();


            
        }

        private void txtLoanNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit txt_LoanNum = new DevExpress.XtraEditors.TextEdit();
            int iFocusedRowIndex = gridView1.FocusedRowHandle;
            findLoanCashRelease oForm = new findLoanCashRelease();

            if (cboGuarantorFinancer.EditValue == null)
            {
                MessageBox.Show("Please select guarantor before adding documents!!!", "Guarantor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oForm.ConnectionString = this.ConnectionString;
            oForm.Guarantor = cboGuarantorFinancer.Text;
            oForm.ShowDialog();

            if (oForm.DocumentNo != null)
            {
                //txt_LoanNum.Text = oForm.DocumentNo;
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"], oForm.DocumentNo);

                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();
                SqlDataAdapter oAdapter = new SqlDataAdapter();

                DataTable dt = new DataTable();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "select * from OLOAN WHERE DocNum=@DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", oForm.DocumentNo));
                oAdapter.SelectCommand = oCommand;
                oAdapter.Fill(dt);

                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["CardCode"], dt.Rows[0]["CardCode"].ToString());
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["CardName"], dt.Rows[0]["CardName"].ToString());
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["LoanAmount"], dt.Rows[0]["LoanAmount"].ToString());
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["ReferenceDocument"], "N/A");
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["ReceivedAmount"], 0);
                gridView1.SetRowCellValue(iFocusedRowIndex, gridView1.Columns["DocStatus"], "Released");

                oConnection.Close();

            }
        }
        void BindGuarantor()
        {
            GuarantorFinancerManager oManager = new GuarantorFinancerManager();
            DataTable dtGuarantor = new DataTable();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            dtGuarantor = oManager.GetGuarantorInfo();

            oManager.Close();

            cboGuarantorFinancer.Properties.DataSource = dtGuarantor;
            cboGuarantorFinancer.Properties.DisplayMember = "GuarantorFinancerName";
            cboGuarantorFinancer.Properties.ValueMember = "GuarantorFinancerName";

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col;

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerCode", "Code", 100);

            cboGuarantorFinancer.Properties.Columns.Add(col);

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GuarantorFinancerName", "Name", 100);

            cboGuarantorFinancer.Properties.Columns.Add(col);

            cboGuarantorFinancer.Refresh();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                if (!gridView1.IsLastRow)
                {
                    int iFocusedRowIndex = gridView1.FocusedRowHandle;

                    gridView1.DeleteRow(iFocusedRowIndex);
                }
                else
                {
                    int iFocusedRowIndex = gridView1.FocusedRowHandle;
                    string sLoanNo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"]).ToString();

                    if (sLoanNo != "")
                    {
                        gridView1.DeleteRow(iFocusedRowIndex);
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (gridView1.IsLastRow)
                {
                    int iFocusedRowIndex = gridView1.FocusedRowHandle;
                    string sLoanNo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["RefLoanNo"]).ToString();

                    if (sLoanNo != "")
                    {
                        gridView1.AddNewRow();
                    }
                }
            }
        }

        private void txtDocStatus_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to post this document?", "Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "UPDATE OCR SET DocStatus='Posted' where DocNum=@DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                oCommand.ExecuteNonQuery();

                oConnection.Close();

                txtDocStatus.Text = "Posted";

            }
            if (e.Button.Index == 1)
            {
                if (txtDocStatus.Text == "Draft")
                {
                    if (MessageBox.Show("Are you sure you want to cancel this document?", "Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SqlConnection oConnection = new SqlConnection();
                        SqlCommand oCommand = new SqlCommand();
                        oConnection.ConnectionString = this.ConnectionString;
                        oConnection.Open();

                        oCommand.Connection = oConnection;
                        oCommand.CommandText = "UPDATE OCR SET DocStatus='Canceled' where DocNum=@DocNum";
                        oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                        oCommand.ExecuteNonQuery();

                        oConnection.Close();
                        txtDocStatus.Text = "Canceled";
                    }
                }
                else if (txtDocStatus.Text == "Posted")
                {
                    if (MessageBox.Show("Are you sure you want to cancel this document?", "Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SqlConnection oConnection = new SqlConnection();
                        SqlCommand oCommand = new SqlCommand();
                        oConnection.ConnectionString = this.ConnectionString;
                        oConnection.Open();

                        oCommand.Connection = oConnection;
                        oCommand.CommandText = "UPDATE OCR SET DocStatus='Closed' where DocNum=@DocNum";
                        oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                        oCommand.ExecuteNonQuery();

                        oConnection.Close();
                        txtDocStatus.Text = "Closed";
                    }
                }
            }
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }

        private void barNewDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CashReleaseDocument oForm = new CashReleaseDocument();
            oForm.ConnectionString = this.ConnectionString;
            oForm.ActiveUserID = this.ActiveUserID;
            oForm.MdiParent = this.MdiParent;
            oForm.Show();

        }

        private void barSaveDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            RemoveBlankRowFirst();

            if (barSaveDocument.Caption == "Save")
            {
                if (cboSourceOfFund.EditValue == null)
                {
                    MessageBox.Show("Please select source of fund!!!", "Fund", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboFundDestination.EditValue == null)
                {
                    MessageBox.Show("Please select fund destination!!!", "Fund", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToDouble(txtAmount.EditValue) <= 0)
                {
                    MessageBox.Show("Please insert cash amount!!!", "Fund", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();


                oCommand.Connection = oConnection;
                oCommand.CommandText = "INSERT INTO OCR (DocNum, Guarantor, SourceOfFund, DestinationOfFund, Remarks, Amount, DocStatus, DateCreated, CreatedBy, DateModified, ModifiedBy) VALUES (@DocNum, @Guarantor, @SourceOfFund, @DestinationOfFund, @Remarks, @Amount, @DocStatus, @DateCreated, @CreatedBy, @DateModified, @ModifiedBy)";
                txtDocNum.Text = GetSeries();
                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                oCommand.Parameters.Add(new SqlParameter("@SourceOfFund", cboSourceOfFund.EditValue != null ? cboSourceOfFund.EditValue : ""));
                oCommand.Parameters.Add(new SqlParameter("@DestinationOfFund", cboFundDestination.EditValue != null ? cboFundDestination.EditValue : ""));
                oCommand.Parameters.Add(new SqlParameter("@Guarantor", cboGuarantorFinancer.EditValue.ToString()));
                oCommand.Parameters.Add(new SqlParameter("@Remarks", txtRemarks.Text));
                oCommand.Parameters.Add(new SqlParameter("@Amount", txtAmount.EditValue != null ? txtAmount.EditValue : "0"));

                oCommand.Parameters.Add(new SqlParameter("@DocStatus", txtDocStatus.Text));
                oCommand.Parameters.Add(new SqlParameter("@DateCreated", dtCreated.EditValue != null ? (DateTime)dtCreated.EditValue : System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@CreatedBy", txtCreatedBy.Text));
                oCommand.Parameters.Add(new SqlParameter("@DateModified", dtModified.EditValue != null ? (DateTime)dtModified.EditValue : System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", txtModifiedBy.Text));

                oCommand.ExecuteNonQuery();

                foreach (DataRow oRow in this.LineItems.Rows)
                {
                    if (oRow.RowState != DataRowState.Deleted)
                    {
                        oCommand = new SqlCommand();

                        oCommand.Connection = oConnection;

                        oCommand.CommandText = "INSERT INTO CR1 (DocNum, RefLoanNo, CardCode, CardName, LoanAmount, ReferenceDocument, ReceivedAmount, DocStatus) VALUES (@DocNum, @RefLoanNo, @CardCode, @CardName, @LoanAmount, @ReferenceDocument, @ReceivedAmount, @DocStatus)";
                        oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                        oCommand.Parameters.Add(new SqlParameter("@RefLoanNo", oRow["RefLoanNo"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@CardCode", oRow["CardCode"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@CardName", oRow["CardName"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@LoanAmount", oRow["LoanAmount"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@ReferenceDocument", oRow["ReferenceDocument"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@ReceivedAmount", oRow["ReceivedAmount"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@DocStatus", oRow["DocStatus"].ToString()));

                        oCommand.ExecuteNonQuery();
                    }
                }
                oConnection.Close();
                barSaveDocument.Caption = "Update";
                MessageBox.Show("Operation successfull.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                SqlConnection oConnection = new SqlConnection();
                SqlCommand oCommand = new SqlCommand();

                oConnection.ConnectionString = this.ConnectionString;
                oConnection.Open();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "UPDATE OCR SET Guarantor=@Guarantor, DocStatus=@DocStatus, SourceOfFund=@SourceOfFund, DestinationOfFund=@DestinationOfFund, Remarks=@Remarks, Amount=@Amount, DateModified=@DateModified, ModifiedBy=@ModifiedBy where DocNum=@DocNum";

                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));

                oCommand.Parameters.Add(new SqlParameter("@SourceOfFund", cboSourceOfFund.EditValue != null ? cboSourceOfFund.EditValue : ""));
                oCommand.Parameters.Add(new SqlParameter("@DestinationOfFund", cboFundDestination.EditValue != null ? cboFundDestination.EditValue : ""));
                oCommand.Parameters.Add(new SqlParameter("@Guarantor", cboGuarantorFinancer.Text));
                oCommand.Parameters.Add(new SqlParameter("@Remarks", txtRemarks.Text));
                oCommand.Parameters.Add(new SqlParameter("@Amount", txtAmount.EditValue != null ? txtAmount.EditValue : "0"));

                oCommand.Parameters.Add(new SqlParameter("@DocStatus", txtDocStatus.Text));
                oCommand.Parameters.Add(new SqlParameter("@DateModified", dtModified.EditValue != null ? Convert.ToDateTime(dtModified.EditValue) : System.DateTime.Now));
                oCommand.Parameters.Add(new SqlParameter("@ModifiedBy", txtModifiedBy.Text));

                oCommand.ExecuteNonQuery();

                oCommand = new SqlCommand();

                oCommand.Connection = oConnection;
                oCommand.CommandText = "DELETE CR1 WHERE DocNum=@DocNum";
                oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                oCommand.ExecuteNonQuery();

                foreach (DataRow oRow in this.LineItems.Rows)
                {
                    if (oRow.RowState != DataRowState.Deleted)
                    {
                        oCommand = new SqlCommand();

                        oCommand.Connection = oConnection;

                        oCommand.CommandText = "INSERT INTO CR1 (DocNum, RefLoanNo, CardCode, CardName, LoanAmount, ReferenceDocument, ReceivedAmount, DocStatus) VALUES (@DocNum, @RefLoanNo, @CardCode, @CardName, @LoanAmount, @ReferenceDocument, @ReceivedAmount, @DocStatus)";
                        oCommand.Parameters.Add(new SqlParameter("@DocNum", txtDocNum.Text));
                        oCommand.Parameters.Add(new SqlParameter("@RefLoanNo", oRow["RefLoanNo"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@CardCode", oRow["CardCode"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@CardName", oRow["CardName"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@LoanAmount", oRow["LoanAmount"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@ReferenceDocument", oRow["ReferenceDocument"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@ReceivedAmount", oRow["ReceivedAmount"].ToString()));
                        oCommand.Parameters.Add(new SqlParameter("@DocStatus", oRow["DocStatus"].ToString()));

                        oCommand.ExecuteNonQuery();
                    }
                }
                oConnection.Close();

                MessageBox.Show("Operation successfull.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barFindDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            findCashReleaseDocument oForm = new findCashReleaseDocument();
            oForm.ConnectionString = this.ConnectionString;
            oForm.ShowDialog();

            if (oForm.DocumentNumber == null)
            {
                return;
            }

            OpenDocument(oForm.DocumentNumber);
        }

        private void barPrintDocument_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txtDocStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDocStatus.Text == "Draft")
            {
                //btnReleaseCash.Enabled = false;
                txtDocStatus.Properties.Buttons[0].Visible = true;
                txtDocStatus.Properties.Buttons[1].Visible = true;
                EnableControls();
                barSaveDocument.Enabled = true;
                gridView1.OptionsBehavior.Editable = true;

                colRefLoanNo.OptionsColumn.AllowEdit = true;
                colCardName.OptionsColumn.AllowEdit = true;
                colCardCode.OptionsColumn.AllowEdit = true;
                colLoanAmount.OptionsColumn.AllowEdit = true;
                colRefDocument.OptionsColumn.AllowEdit = true;
                colReceivedAmount.OptionsColumn.AllowEdit = true;
                colStatus.OptionsColumn.AllowEdit = true;

            }
            else if (txtDocStatus.Text == "Posted")
            {
                //btnReleaseCash.Enabled = false;
                txtDocStatus.Properties.Buttons[0].Visible = false;
                txtDocStatus.Properties.Buttons[1].Visible = true;
                DisableControls();

                colRefLoanNo.OptionsColumn.AllowEdit = false;
                colCardName.OptionsColumn.AllowEdit = false;
                colCardCode.OptionsColumn.AllowEdit = false;
                colLoanAmount.OptionsColumn.AllowEdit = false;
                colRefDocument.OptionsColumn.AllowEdit = true;
                colReceivedAmount.OptionsColumn.AllowEdit = true;
                colStatus.OptionsColumn.AllowEdit = true;
                
                //gridView1.OptionsBehavior.Editable = false;
                //barSaveDocument.Enabled = false;
            }
            else if (txtDocStatus.Text == "Canceled" || txtDocStatus.Text == "Closed")
            {
                //btnReleaseCash.Enabled = false;
                txtDocStatus.Properties.Buttons[0].Visible = false;
                txtDocStatus.Properties.Buttons[1].Visible = false;
                barSaveDocument.Enabled = false;
                gridView1.OptionsBehavior.Editable = false;


                colRefLoanNo.OptionsColumn.AllowEdit = false;
                colCardName.OptionsColumn.AllowEdit = false;
                colCardCode.OptionsColumn.AllowEdit = false;
                colLoanAmount.OptionsColumn.AllowEdit = false;
                colRefDocument.OptionsColumn.AllowEdit = false;
                colReceivedAmount.OptionsColumn.AllowEdit = false;
                colStatus.OptionsColumn.AllowEdit = false;

                DisableControls();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
      
    }
}
