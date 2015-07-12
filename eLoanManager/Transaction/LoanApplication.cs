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
using eLoan.BL;
namespace eLoanSystem.Transaction
{
    public partial class LoanApplication : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public LoanApplication()
        {
            InitializeComponent();
        }
        int iRowCounter = 0;
        public string ActiveUserID { get; set; }
        public string ConnectionString { get; set; }
        public DataTable LineScheduleOfPayment { get; set; }

        void DisableControls()
        {
            txtLoanNo.Enabled = false;
            cboTransType.Enabled = false;
            cboModeOfPayment.Enabled = false;
            txtCardCode.Enabled = false;
            txtCardName.Enabled = false;
            txtGuarrantor.Enabled = false;

            txtLoanAmount.Enabled = false;
            txtTerms.Enabled = false;
            txtInterestRate.Enabled = false;
            cboFrequencyOfPayment.Enabled = false;
            dtStartOfPayment.Enabled = false;
            cboPayDayCode.Enabled = false;
            dtDateOfRelease.Enabled = false;

         
        }

        void EnableControls()
        {
            //txtLoanNo.Enabled = true;
            cboTransType.Enabled = true;
            cboModeOfPayment.Enabled = true;
            txtCardCode.Enabled = true;
            txtCardName.Enabled = true;
            txtGuarrantor.Enabled = true;

            txtLoanAmount.Enabled = true;
            txtTerms.Enabled = true;
            txtInterestRate.Enabled = true;
            cboFrequencyOfPayment.Enabled = true;
            dtStartOfPayment.Enabled = true;
            cboPayDayCode.Enabled = true;
            dtDateOfRelease.Enabled = true;
            
        }
        private void BindCollections(string sDocNum)
        {
            CollectionManager oManager = new CollectionManager();
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            DataTable dt = oManager.GetCollection(sDocNum);
            oManager.Close();

            gridControl3.DataSource = dt;
            gridControl3.Refresh();
        }
        private void Initializetable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ScheduleNo", typeof(string));
            dt.Columns.Add("PaymentAmount", typeof(string));
            dt.Columns.Add("ScheduledDate", typeof(DateTime));
            dt.Columns.Add("PrincipalReduction", typeof(string));
            dt.Columns.Add("InterestAmount", typeof(string));
            dt.Columns.Add("OtherCharges", typeof(string));
            dt.Columns.Add("PaidAmount", typeof(string));

            this.LineScheduleOfPayment = dt;
        }
        void BindPayDayCode()
        {
            PayDayCodeManager oManager = new PayDayCodeManager();
            DataTable dtLines = new DataTable();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            dtLines = oManager.GetPayDayCodeHeader();

            cboPayDayCode.Properties.DataSource = dtLines;
            cboPayDayCode.Properties.DisplayMember = "Remarks";
            cboPayDayCode.Properties.ValueMember = "PayDayCode";

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col;

            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PayDayCode", "Code", 100);
            cboPayDayCode.Properties.Columns.Add(col);
            col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Remarks", "Name", 100);

            cboPayDayCode.Properties.Columns.Add(col);
            cboPayDayCode.Refresh();

            oManager.Close();


        }

        public void CustomFrequencyOfPaymentDetails(double loanAmount, double interest, double downPayment, int _frequency, double monthly)
        {
            var endingBalance = loanAmount - downPayment;
            //var rate = interest / 1200.0;
            var rate = interest;
            var count = 1;
            iRowCounter = 1;

            if (cboPayDayCode.EditValue == null)
            {
                MessageBox.Show("Please select pay day code!!!", "Pay Day Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            while (count <= _frequency) // count over number of months
            {
                var interestPaid = endingBalance * rate;
                var principlePaid = monthly - interestPaid;

                endingBalance -= principlePaid;

                CreateRowInCustomFrequency(cboPayDayCode.EditValue.ToString(), monthly.ToString(), count, (loanAmount * interest).ToString(),
                          (loanAmount / _frequency).ToString(), endingBalance.ToString(), count++);
            }
        }
        public static double CalculatePayment(double presentValue, double financingPeriod, double interestRatePerYear)
        {
            double a, b, x;
            double monthlyPayment;

            a = (1 + interestRatePerYear / 1200);
            b = financingPeriod;

            x = Math.Pow(a, b);

            x = 1 / x;
            x = 1 - x;
            monthlyPayment = (presentValue) * (interestRatePerYear / 1200) / x;
            return (monthlyPayment);
        }
        public void FrequencyOfPaymentDetails(double loanAmount, double interest, double downPayment, int _frequency, double monthly)
        {
            var endingBalance = loanAmount - downPayment;
            //var rate = interest / 1200.0;
            var rate = interest;
            var count = 1;

            while (count <= _frequency) // count over number of months
            {
                var interestPaid = endingBalance * rate;
                var principlePaid = monthly - interestPaid;

                endingBalance -= principlePaid;

                CreateRow(count, String.Format("{0:N}", monthly), String.Format("{0:N}", loanAmount * interest), String.Format("{0:N}",
                          loanAmount / _frequency), String.Format("{0:N}", endingBalance), count++);
            }
        }

        public void CreateRowInCustomFrequency(string sPayDayCode, string sPayment, int count, string sInterestPaid, string sPrincipalPaid, string sEndingBalance, int countRow)
        {

          
            DateTime dateStart = (DateTime)dtStartOfPayment.EditValue;
            string sPaymentTerm = cboFrequencyOfPayment.Text;

           

            PayDayCodeManager oManager = new PayDayCodeManager();
            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();
            DataTable dtLines = oManager.GetPayDayCodeLineItems(sPayDayCode);
            oManager.Close();
            
            int iRowCount = dtLines.Rows.Count;
            int iRowNo = 0;
            dateStart = dateStart.AddMonths(countRow - 1);
            foreach (DataRow lineRow in dtLines.Rows)
            {
                DataRow oRow = this.LineScheduleOfPayment.NewRow();

                oRow["ScheduleNo"] = iRowCounter;
                string sMonth = dateStart.Month.ToString();
                string sDay = lineRow["DayWeekNo"].ToString();
                string sYear = dateStart.Year.ToString();
                DateTime dtSchedule;
            repeat:
                string sConcatMonth = (sMonth + "/" + sDay + "/" + sYear);
                try
                {

                   dtSchedule = Convert.ToDateTime(sConcatMonth);
                }
                catch
                {
                    sDay = (Convert.ToInt16(sDay) - 1).ToString();
                    goto repeat;
                }
                
                //dtSchedule = Convert.ToDateTime(sConcatMonth);
                oRow["ScheduledDate"] = dtSchedule;
                oRow["PaymentAmount"] = String.Format("{0:N}", Convert.ToDouble(sPayment) / iRowCount); ;
                oRow["PrincipalReduction"] = String.Format("{0:N}", Convert.ToDouble(sPrincipalPaid) / iRowCount);
                oRow["InterestAmount"] = String.Format("{0:N}", Convert.ToDouble(sInterestPaid) / iRowCount);
                oRow["PaidAmount"] = 0;
                oRow["OtherCharges"] = 0;
                this.LineScheduleOfPayment.Rows.Add(oRow);
                iRowCounter = iRowCounter + 1;
                
            }

            txtNoOfPayments.Text = (iRowCounter - 1).ToString("#,###");

           

        }
        public void CreateRow(int count, string sPayment, string sInterestPaid, string sPrincipalPaid, string sEndingBalance, int countRow)
        {

            DataRow oRow = this.LineScheduleOfPayment.NewRow();
            DateTime dateStart = (DateTime)dtStartOfPayment.EditValue;
            string sPaymentTerm = cboFrequencyOfPayment.Text;

            oRow["ScheduleNo"] = countRow.ToString();
            //oRow["ScheduledDate"] = (DateTime)dateStart.AddMonths(countRow - 1);

            if (sPaymentTerm == "Daily")
            {

                oRow["ScheduledDate"] = (DateTime)dateStart.AddDays(countRow - 1);


            }
            else if (sPaymentTerm == "Bi-Weekly")
            {
                int additionalDays = (7 * (countRow - 1)) * 2;
                oRow["ScheduledDate"] = (DateTime)dateStart.AddDays(additionalDays);


            }
            else if (sPaymentTerm == "Weekly")
            {
                countRow = (7 * (countRow - 1));
                oRow["ScheduledDate"] = (DateTime)dateStart.AddDays(countRow);


            }
            else if (sPaymentTerm == "Monthly")
            {

                oRow["ScheduledDate"] = (DateTime)dateStart.AddMonths(countRow - 1);

            }
            else if (sPaymentTerm == "Bi-Monthly")
            {
                countRow = ((countRow - 1) * 2);
                oRow["ScheduledDate"] = (DateTime)dateStart.AddMonths(countRow);


            }
            else if (sPaymentTerm == "Quarterly")
            {
                countRow = countRow * 3;
                oRow["ScheduledDate"] = (DateTime)dateStart.AddMonths(countRow - 1);
            
            }
            oRow["PaymentAmount"] = sPayment;
            oRow["PrincipalReduction"] = sPrincipalPaid;
            oRow["InterestAmount"] = sInterestPaid;
            oRow["OtherCharges"] = 0;
            oRow["PaidAmount"] = 0;

            this.LineScheduleOfPayment.Rows.Add(oRow);
            txtNoOfPayments.Text = countRow.ToString("#,###");
        }

        void BindCashReleased()
        {
            CashReleaseManager oManager = new CashReleaseManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dt = oManager.GetInfo(txtLoanNo.Text);

            gridControl2.DataSource = dt;
            gridControl2.Refresh();

            oManager.Close();

        }
        public void OpenDocument(string sDocNum)
        {
            Initializetable();
            BindPayDayCode();

            cboModeOfPayment.SelectedIndex = 0;
            cboTransType.SelectedIndex = 0;

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;

            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

            dtStartOfPayment.EditValue = dtNow;
            dtDateOfRelease.EditValue = dtNow;

            txtTerms.Text = "1";

            LoanManager oManager = new LoanManager();

            oManager.ConnectionString = this.ConnectionString;
            oManager.Open();

            DataTable dtInfo = oManager.GetLoanInfo(sDocNum);


            DataRow oRow = dtInfo.Rows[0];

            //ounit.documentnumber = txtloanno.text;
            txtLoanNo.Text = oRow["DocNum"].ToString();
            txtCardCode.Text = oRow["CardCode"].ToString();
            txtCardName.Text = oRow["CardName"].ToString();
            cboTransType.Text = oRow["TransType"].ToString();
            txtGuarrantor.Text = oRow["Guarrantor"].ToString();
            txtLoanAmount.Text = string.Format("{0:N}", oRow["LoanAmount"].ToString());
            txtTerms.Text = string.Format("{0:N}", oRow["Terms"]);
            txtInterestRate.Text = oRow["InterestRate"].ToString();
            cboFrequencyOfPayment.Text = oRow["FreqOfPayment"].ToString();
            cboPayDayCode.Text = oRow["PayDayCode"].ToString();
            dtStartOfPayment.EditValue = (DateTime)oRow["FirstPaymentDate"];
            dtDateOfRelease.EditValue = (DateTime)oRow["DateOfReleasing"];
            txtAmortization.Text = string.Format("{0:N}", oRow["MonthlyPayment"]);
            txtNoOfPayments.Text = string.Format("{0}", oRow["NoOfPayment"]);
            txtTotalAmortization.Text = string.Format("{0:N}", oRow["TotalAmortization"]);
            txtTotalInterest.Text = string.Format("{0:N}", oRow["TotalInterest"]);
            txtStatus.Text = string.Format("{0:N}", oRow["DocStatus"]);

            txtCreatedBy.Text = oRow["CreatedBy"].ToString();
            dtCreated.EditValue = Convert.ToDateTime(oRow["DateCreated"]);
            txtModifiedBy.Text = oRow["ModifiedBy"].ToString();
            dtModified.EditValue = Convert.ToDateTime(oRow["DateModified"]);

            this.LineScheduleOfPayment = oManager.GetLoanInfoLineItems(sDocNum);

            gridControl1.DataSource = this.LineScheduleOfPayment;
            gridControl1.Refresh();

            btnAdd.Text = "Update";
            txtLoanNo.Enabled = false;

            BindCashReleased();
            BindCollections(txtLoanNo.Text);
            ComputeOutstandingBalance();
        }
        public bool Stopper { get; set; }
        public void ComputeOutstandingBalance()
        {
            SqlConnection oConnection = new SqlConnection();
            SqlCommand oCommand = new SqlCommand();
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataRow oRow;

            oConnection.ConnectionString = this.ConnectionString;
            oConnection.Open();

            oCommand.Connection = oConnection;
            oCommand.CommandText = "SELECT  SUM(PaymentAmount - PaidAmount) FROM LOAN1 WHERE DocNum=@DocNum";
            oCommand.Parameters.Add(new SqlParameter("@DocNum", txtLoanNo.Text));

            oAdapter.SelectCommand = oCommand;
            oAdapter.Fill(dt);
            oRow = dt.Rows[0];

            txtOutstandingBalance.Text = oRow[0].ToString();
            oConnection.Close();
        }
        private void LoanApplication_Load(object sender, EventArgs e)
        {
            if (this.Stopper == true)
            {
                return;
            }
            
            Initializetable();
            BindPayDayCode();

            cboModeOfPayment.SelectedIndex = 0;
            cboTransType.SelectedIndex = 0;

            txtCreatedBy.Text = this.ActiveUserID;
            txtModifiedBy.Text = this.ActiveUserID;

            DateTime dtNow = System.DateTime.Now;

            dtCreated.EditValue = dtNow;
            dtModified.EditValue = dtNow;

            dtStartOfPayment.EditValue = dtNow;
            dtDateOfRelease.EditValue = dtNow;

            txtTerms.Text = "1";
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txtBorrowerCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LA_fndBorrower findForm = new LA_fndBorrower();

            findForm.ConnectionString = this.ConnectionString;
            findForm.ShowDialog();

            if (findForm.SelectedCode != null)
            {
                txtCardCode.Text = findForm.SelectedCode;
                txtCardName.Text = findForm.SelectedName;

                txtInterestRate.Text = findForm.InterestRate;
                txtGuarrantor.Text = findForm.GuarrantorName;
                cboFrequencyOfPayment.Text = findForm.FrequencyOfPayment;
                cboPayDayCode.EditValue = findForm.PayDayCode;
                

                cboPayDayCode.ClosePopup();
                cboFrequencyOfPayment.ClosePopup();
            }
        }

        private void txtLoanAmount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iNumberOfPayments = Convert.ToInt16(txtTerms.Text);
            double _amountPer = 0;
            string sPaymentTerm = cboFrequencyOfPayment.Text;
            DateTime dateStart = Convert.ToDateTime(dtStartOfPayment.EditValue);
            double loanAmount = Convert.ToDouble(txtLoanAmount.Text);

            _amountPer = loanAmount / iNumberOfPayments;

            txtAmortization.Text = _amountPer.ToString("#,###.00");
            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double LoanAmount = 0;
            int NumberOfMonths = 0;
            double InterestRate = 0;
            double MonthlyAmortization = 0;
            
            double MonthlyPayment = 0;
            double MonthlyInterest = 0;

            double TotalPayments = 0;
            double TotalInterest = 0;

            LoanAmount = Convert.ToDouble(txtLoanAmount.Text.Replace(",", ""));
            NumberOfMonths = Convert.ToInt16(string.Format("{0:#}",txtTerms.Text));
            InterestRate = Convert.ToDouble(txtInterestRate.Text.Replace(",", ""));
            MonthlyPayment = LoanAmount / NumberOfMonths;

            MonthlyAmortization = MonthlyPayment + ((MonthlyPayment * (InterestRate / 100)) * NumberOfMonths) ;
            MonthlyInterest = (MonthlyPayment * (InterestRate / 100)) * NumberOfMonths;

            TotalPayments = MonthlyAmortization * NumberOfMonths;
            TotalInterest = (MonthlyInterest * NumberOfMonths);

            //txtAmortization.Text = CalculatePayment(LoanAmount, NumberOfMonths, InterestRate).ToString("#,###.00");
            //txtTotalInterest.Text = ((CalculatePayment(LoanAmount, NumberOfMonths, InterestRate) * NumberOfMonths) - LoanAmount).ToString("#,###.00");
            //txtTotalAmortization.Text = ((CalculatePayment(LoanAmount, NumberOfMonths, InterestRate) * NumberOfMonths)).ToString("#,###.00");


            txtAmortization.Text = String.Format("{0:N}", MonthlyAmortization);
            txtTotalInterest.Text = String.Format("{0:N}", TotalInterest);
            txtTotalAmortization.Text = String.Format("{0:N}", TotalPayments);

            this.LineScheduleOfPayment = new DataTable();
            Initializetable();

            double _downPayment = 0;

            if (cboFrequencyOfPayment.Text != "Custom")
            {
                FrequencyOfPaymentDetails(LoanAmount, (InterestRate / 100), _downPayment, NumberOfMonths,
                    //CalculatePayment(LoanAmount, NumberOfMonths, InterestRate)
                    MonthlyAmortization);
            }
            else
            {
                CustomFrequencyOfPaymentDetails(LoanAmount, (InterestRate / 100), _downPayment, NumberOfMonths, 
                    //CalculatePayment(LoanAmount, NumberOfMonths, InterestRate)
                    MonthlyAmortization);
            }
            gridControl1.DataSource = this.LineScheduleOfPayment;
            gridControl1.Refresh();
            
        }

        string GetSeries()
        {
            SeriesManager oManager = new SeriesManager();
            string sSeries = "";
            string sPrefix = "";
            int digitNo = 0;
            string _objectType = "Loan";

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
            if (btnAdd.Text == "Add")
            {
                LoanManager oConnectionManager = new LoanManager();
                LoanUnit oUnit = new LoanUnit();


                txtLoanNo.Text = GetSeries();

                oConnectionManager.ConnectionString = this.ConnectionString;
                oConnectionManager.Open();

                if (oConnectionManager.IsExists(txtLoanNo.Text))
                {
                    MessageBox.Show("Loan Document Number is already exists!!!", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                oUnit.DocumentNumber = txtLoanNo.Text;
                oUnit.CardCode = txtCardCode.Text;
                oUnit.CardName = txtCardName.Text;
                oUnit.TransactionType = cboTransType.Text;
                oUnit.Guarantor = txtGuarrantor.Text;
                oUnit.LoanAmount = Convert.ToDouble(txtLoanAmount.Text.Replace(",", ""));
                oUnit.Terms = Convert.ToInt16(txtTerms.Text);
                oUnit.InterestRate = Convert.ToDouble(txtInterestRate.Text);
                oUnit.FrequencyOfPayment = cboFrequencyOfPayment.EditValue.ToString();
                oUnit.PayDayCode = cboPayDayCode.EditValue != null? cboPayDayCode.EditValue.ToString() : "";
                oUnit.FirstDateOfPayment = (DateTime)dtStartOfPayment.EditValue;
                oUnit.ReleaseDate = (DateTime)dtDateOfRelease.EditValue;
                oUnit.MonthlyPayment = Convert.ToDouble(string.Format("{0}",txtAmortization.Text));
                oUnit.NumberOfPayment = Convert.ToInt16(txtNoOfPayments.Text);
                oUnit.TotalAmortization = Convert.ToDouble(string.Format("{0}", txtTotalAmortization.Text));
                oUnit.TotalInterest = Convert.ToDouble(txtTotalInterest.Text);

                oUnit.DocumentStatus = txtStatus.Text;
                oUnit.CreatedBy = this.ActiveUserID;
                oUnit.DateCreated = (DateTime)dtCreated.EditValue;
                oUnit.ModifiedBy = txtModifiedBy.Text;
                oUnit.DateModified = (DateTime)dtModified.EditValue;

                oConnectionManager.AddLoan(oUnit);

                oConnectionManager.AddLineItems(txtLoanNo.Text, this.LineScheduleOfPayment);
                oConnectionManager.Close();

                btnAdd.Text = "Update";
                txtLoanNo.Enabled = false;

                MessageBox.Show("Adding completed successfully!!!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoanManager oConnectionManager = new LoanManager();
                LoanUnit oUnit = new LoanUnit();

                oConnectionManager.ConnectionString = this.ConnectionString;
                oConnectionManager.Open();
                oUnit.DocumentNumber = txtLoanNo.Text;
                oUnit.CardCode = txtCardCode.Text;
                oUnit.CardName = txtCardName.Text;
                oUnit.TransactionType = cboTransType.Text;
                oUnit.Guarantor = txtGuarrantor.Text;
                oUnit.LoanAmount = Convert.ToDouble(txtLoanAmount.Text.Replace(",", ""));
                oUnit.Terms = Convert.ToInt16(txtTerms.Text);
                oUnit.InterestRate = Convert.ToDouble(txtInterestRate.Text);
                oUnit.FrequencyOfPayment = cboFrequencyOfPayment.EditValue.ToString();
                oUnit.PayDayCode = cboPayDayCode.EditValue != null ? cboPayDayCode.EditValue.ToString() : "";
                oUnit.FirstDateOfPayment = (DateTime)dtStartOfPayment.EditValue;
                oUnit.ReleaseDate = (DateTime)dtDateOfRelease.EditValue;
                oUnit.MonthlyPayment = Convert.ToDouble(txtAmortization.Text.Replace(",", ""));
                oUnit.NumberOfPayment = Convert.ToInt16(txtNoOfPayments.Text);
                oUnit.TotalAmortization = Convert.ToDouble(txtTotalAmortization.Text.Replace(",", ""));
                oUnit.TotalInterest = Convert.ToDouble(txtTotalInterest.Text);
                oUnit.DocumentStatus = txtStatus.Text;
                oUnit.ModifiedBy = txtModifiedBy.Text;
                oUnit.DateModified = (DateTime)dtModified.EditValue;

                oConnectionManager.UpdateLoan(oUnit);

                oConnectionManager.DeleteLineItems(txtLoanNo.Text);
                oConnectionManager.AddLineItems(txtLoanNo.Text, this.LineScheduleOfPayment);

                oConnectionManager.Close();
                MessageBox.Show("Updating completed successfully!!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboFrequencyOfPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFrequencyOfPayment.Text == "Custom")
            {
                cboPayDayCode.EditValue = null;
                cboPayDayCode.Enabled = true;
                cboPayDayCode.ClosePopup();
            }
            else
            {
                cboPayDayCode.EditValue = null;
                cboPayDayCode.Enabled = false;
                cboPayDayCode.ClosePopup();
            }
        }

        private void txtStatus_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (MessageBox.Show("Are you sure you want to post this document? This action is irreversible!!!", "Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    LoanManager oManager = new LoanManager();

                    oManager.ConnectionString = this.ConnectionString;
                    oManager.Open();

                    oManager.PostDocument(txtLoanNo.Text);

                    oManager.Close();

                    MessageBox.Show("Successfully posted!!!", "Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtStatus.Text = "Posted";
                }
                else
                {
                    return;
                }
            }
            else if (e.Button.Index == 1)
            {
                if (txtStatus.Text == "Draft")
                {
                    if (MessageBox.Show("Are you sure you want to cancel this document? This action is irreversible!!!", "Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        LoanManager oManager = new LoanManager();

                        oManager.ConnectionString = this.ConnectionString;
                        oManager.Open();

                        oManager.CancelDocument(txtLoanNo.Text);

                        oManager.Close();

                        MessageBox.Show("Successfully cancelled!!!", "Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtStatus.Text = "Canceled";
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to close this document? This action is irreversible!!!", "Post", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        LoanManager oManager = new LoanManager();

                        oManager.ConnectionString = this.ConnectionString;
                        oManager.Open();

                        oManager.CloseDocument(txtLoanNo.Text);

                        oManager.Close();

                        MessageBox.Show("Successfully closed!!!", "Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtStatus.Text = "Closed";
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void txtStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Draft")
            {
                btnReleaseCash.Enabled = false;
                txtStatus.Properties.Buttons[0].Visible = true;
                txtStatus.Properties.Buttons[1].Visible = true;
                btnCalculate.Enabled = true;
                EnableControls();
                btnAdd.Enabled = true;
                
            }
            else if (txtStatus.Text == "Posted")
            {
                btnReleaseCash.Enabled = true;
                txtStatus.Properties.Buttons[0].Visible = false;
                txtStatus.Properties.Buttons[1].Visible = true;
                btnCalculate.Enabled = false;
                DisableControls();
                btnAdd.Enabled = false;
            }
            else if (txtStatus.Text == "Canceled" || txtStatus.Text == "Closed")
            {
                btnReleaseCash.Enabled = false;
                txtStatus.Properties.Buttons[0].Visible = false;
                txtStatus.Properties.Buttons[1].Visible = false;
                btnCalculate.Enabled = false;
                btnAdd.Enabled = false;
                DisableControls();
            }
        }

        private void btnReleaseCash_Click(object sender, EventArgs e)
        {
            CashFundRelease oFundRelease = new CashFundRelease();

            oFundRelease.ConnectionString = this.ConnectionString;
            oFundRelease.ActiveUserID = this.ActiveUserID;
            oFundRelease.LoanNumber = txtLoanNo.Text;

            oFundRelease.ShowDialog();
            BindCashReleased();
        }

        private void txtPayment_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (txtStatus.Text == "Closed" || txtStatus.Text == "Canceled")
                {
                    MessageBox.Show("Your not able to add payment to closed documents!!!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                addCollection oform = new addCollection();
                int iFocusedRowIndex = gridView1.FocusedRowHandle;

                oform.ConnectionString = this.ConnectionString;
                oform.ActiveUserID = this.ActiveUserID;
                oform.LoanNumber = txtLoanNo.Text;

                oform.ScheduledNo = Convert.ToInt16(gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduleNo"]));

                oform.ShowDialog();

                LoanManager oManager = new LoanManager();

                oManager.ConnectionString = this.ConnectionString;
                oManager.Open();

                this.LineScheduleOfPayment = oManager.GetLoanInfoLineItems(txtLoanNo.Text);

                oManager.Close();

                gridControl1.DataSource = this.LineScheduleOfPayment;
                gridControl1.Refresh();

                BindCollections(txtLoanNo.Text);
                ComputeOutstandingBalance();
            }
            else
            {
                PaymentBreakdown oForm = new PaymentBreakdown();
                int iFocusedRowIndex = gridView1.FocusedRowHandle;

                oForm.ConnectionString = this.ConnectionString;
                oForm.ScheduleNo = Convert.ToInt16(gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduleNo"]));
                oForm.DocumentNumber = txtLoanNo.Text;

                oForm.ShowDialog();
                ComputeOutstandingBalance();
            }
        }

        private void btnAddCollection_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPayment_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtOtherCharges_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (txtStatus.Text == "Closed" || txtStatus.Text == "Canceled")
                {
                    MessageBox.Show("Your not able to add charges to canceled or closed documents!!!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                addOtherCharges oForm = new addOtherCharges();

                int iFocusedRowIndex = gridView1.FocusedRowHandle;
                string sScheduleNo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduleNo"]).ToString();
                DateTime dtDueDate = (DateTime)gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduledDate"]);

                oForm.ConnectionString = this.ConnectionString;
                oForm.DocumentNumber = txtLoanNo.Text;
                oForm.ScheduleNo = sScheduleNo;
                oForm.ScheduledDate = dtDueDate;

                oForm.ShowDialog();

                LoanManager oManager = new LoanManager();

                oManager.ConnectionString = this.ConnectionString;
                oManager.Open();
                this.LineScheduleOfPayment = oManager.GetLoanInfoLineItems(txtLoanNo.Text);
                oManager.Close();

                gridControl1.DataSource = this.LineScheduleOfPayment;
                gridControl1.Refresh();

                btnAdd.Text = "Update";
                txtLoanNo.Enabled = false;

                BindCashReleased();
                BindCollections(txtLoanNo.Text);
                ComputeOutstandingBalance();
            }
            else
            {
                detailOtherCharges oForm = new detailOtherCharges();

                int iFocusedRowIndex = gridView1.FocusedRowHandle;
                string sScheduleNo = gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduleNo"]).ToString();
                DateTime dtDueDate = (DateTime)gridView1.GetRowCellValue(iFocusedRowIndex, gridView1.Columns["ScheduledDate"]);

                oForm.ConnectionString = this.ConnectionString;
                oForm.DocumentNumber = txtLoanNo.Text;
                oForm.ScheduleNo = sScheduleNo;
                oForm.ShowDialog();
                ComputeOutstandingBalance();
            }
        }
    }
}
