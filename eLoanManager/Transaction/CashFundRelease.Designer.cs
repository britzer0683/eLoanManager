namespace eLoanSystem.Transaction
{
    partial class CashFundRelease
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashFundRelease));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblTypeOfPayment = new DevExpress.XtraEditors.LabelControl();
            this.cboTypeOfPayment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblChequeNo = new DevExpress.XtraEditors.LabelControl();
            this.txtCheckNo = new DevExpress.XtraEditors.TextEdit();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.lblSourceOfFund = new DevExpress.XtraEditors.LabelControl();
            this.cboSourceOfFund = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblReleaseNo = new DevExpress.XtraEditors.LabelControl();
            this.txtReleaseNo = new DevExpress.XtraEditors.TextEdit();
            this.lblLoanNo = new DevExpress.XtraEditors.LabelControl();
            this.txtLoanNo = new DevExpress.XtraEditors.TextEdit();
            this.txtStatus = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.dtModified = new DevExpress.XtraEditors.DateEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.dtCreated = new DevExpress.XtraEditors.DateEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtModifiedBy = new DevExpress.XtraEditors.TextEdit();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.cboTypeOfPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSourceOfFund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifiedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTypeOfPayment
            // 
            this.lblTypeOfPayment.Location = new System.Drawing.Point(15, 113);
            this.lblTypeOfPayment.Name = "lblTypeOfPayment";
            this.lblTypeOfPayment.Size = new System.Drawing.Size(86, 13);
            this.lblTypeOfPayment.TabIndex = 4;
            this.lblTypeOfPayment.Text = "Type of Payment:";
            // 
            // cboTypeOfPayment
            // 
            this.cboTypeOfPayment.Location = new System.Drawing.Point(108, 113);
            this.cboTypeOfPayment.Name = "cboTypeOfPayment";
            this.cboTypeOfPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTypeOfPayment.Properties.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cboTypeOfPayment.Size = new System.Drawing.Size(100, 20);
            this.cboTypeOfPayment.TabIndex = 5;
            this.cboTypeOfPayment.SelectedIndexChanged += new System.EventHandler(this.cboTypeOfPayment_SelectedIndexChanged);
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.Location = new System.Drawing.Point(15, 139);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(61, 13);
            this.lblChequeNo.TabIndex = 8;
            this.lblChequeNo.Text = "Cheque No.:";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.Location = new System.Drawing.Point(108, 139);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(313, 20);
            this.txtCheckNo.TabIndex = 9;
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(15, 169);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(41, 13);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(108, 166);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.DisplayFormat.FormatString = "{0:N}";
            this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmount.Properties.EditFormat.FormatString = "{0:N}";
            this.txtAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAmount.Properties.Mask.EditMask = "#,###,###,###,###,###.00";
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmount.Size = new System.Drawing.Size(313, 20);
            this.txtAmount.TabIndex = 11;
            // 
            // lblSourceOfFund
            // 
            this.lblSourceOfFund.Location = new System.Drawing.Point(237, 113);
            this.lblSourceOfFund.Name = "lblSourceOfFund";
            this.lblSourceOfFund.Size = new System.Drawing.Size(77, 13);
            this.lblSourceOfFund.TabIndex = 6;
            this.lblSourceOfFund.Text = "Source of Fund:";
            // 
            // cboSourceOfFund
            // 
            this.cboSourceOfFund.Location = new System.Drawing.Point(321, 113);
            this.cboSourceOfFund.Name = "cboSourceOfFund";
            this.cboSourceOfFund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSourceOfFund.Properties.NullText = "[Select Fund]";
            this.cboSourceOfFund.Size = new System.Drawing.Size(100, 20);
            this.cboSourceOfFund.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(15, 210);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 50);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(110, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 50);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblReleaseNo
            // 
            this.lblReleaseNo.Location = new System.Drawing.Point(15, 42);
            this.lblReleaseNo.Name = "lblReleaseNo";
            this.lblReleaseNo.Size = new System.Drawing.Size(62, 13);
            this.lblReleaseNo.TabIndex = 0;
            this.lblReleaseNo.Text = "Release No.:";
            // 
            // txtReleaseNo
            // 
            this.txtReleaseNo.Location = new System.Drawing.Point(108, 42);
            this.txtReleaseNo.Name = "txtReleaseNo";
            this.txtReleaseNo.Size = new System.Drawing.Size(100, 20);
            this.txtReleaseNo.TabIndex = 1;
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.Location = new System.Drawing.Point(15, 68);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(43, 13);
            this.lblLoanNo.TabIndex = 2;
            this.lblLoanNo.Text = "Loan No:";
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.Location = new System.Drawing.Point(108, 68);
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(100, 20);
            this.txtLoanNo.TabIndex = 3;
            // 
            // txtStatus
            // 
            this.txtStatus.EditValue = "Draft";
            this.txtStatus.Location = new System.Drawing.Point(591, 42);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtStatus.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtStatus.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtStatus.Size = new System.Drawing.Size(111, 22);
            this.txtStatus.TabIndex = 74;
            this.txtStatus.Visible = false;
            this.txtStatus.EditValueChanged += new System.EventHandler(this.txtStatus_EditValueChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(492, 121);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(59, 13);
            this.labelControl12.TabIndex = 73;
            this.labelControl12.Text = "Modified By:";
            this.labelControl12.Visible = false;
            // 
            // dtModified
            // 
            this.dtModified.EditValue = null;
            this.dtModified.Location = new System.Drawing.Point(591, 147);
            this.dtModified.Name = "dtModified";
            this.dtModified.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtModified.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtModified.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dtModified.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dtModified.Size = new System.Drawing.Size(112, 20);
            this.dtModified.TabIndex = 71;
            this.dtModified.Visible = false;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(492, 147);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(70, 13);
            this.labelControl13.TabIndex = 69;
            this.labelControl13.Text = "Date Modified:";
            this.labelControl13.Visible = false;
            // 
            // dtCreated
            // 
            this.dtCreated.EditValue = null;
            this.dtCreated.Location = new System.Drawing.Point(591, 93);
            this.dtCreated.Name = "dtCreated";
            this.dtCreated.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreated.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreated.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dtCreated.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dtCreated.Size = new System.Drawing.Size(112, 20);
            this.dtCreated.TabIndex = 72;
            this.dtCreated.Visible = false;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(492, 93);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(69, 13);
            this.labelControl14.TabIndex = 70;
            this.labelControl14.Text = "Date Created:";
            this.labelControl14.Visible = false;
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.Location = new System.Drawing.Point(591, 121);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Size = new System.Drawing.Size(112, 20);
            this.txtModifiedBy.TabIndex = 67;
            this.txtModifiedBy.Visible = false;
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(591, 67);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(112, 20);
            this.txtCreatedBy.TabIndex = 68;
            this.txtCreatedBy.Visible = false;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(492, 67);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(58, 13);
            this.labelControl15.TabIndex = 66;
            this.labelControl15.Text = "Created By:";
            this.labelControl15.Visible = false;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(492, 42);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(35, 13);
            this.labelControl16.TabIndex = 65;
            this.labelControl16.Text = "Status:";
            this.labelControl16.Visible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(446, 27);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 282);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(446, 31);
            // 
            // CashFundRelease
            // 
            this.AllowDisplayRibbon = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 313);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.dtModified);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.dtCreated);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.txtModifiedBy);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.txtLoanNo);
            this.Controls.Add(this.txtReleaseNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboSourceOfFund);
            this.Controls.Add(this.lblSourceOfFund);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtCheckNo);
            this.Controls.Add(this.lblChequeNo);
            this.Controls.Add(this.lblLoanNo);
            this.Controls.Add(this.cboTypeOfPayment);
            this.Controls.Add(this.lblReleaseNo);
            this.Controls.Add(this.lblTypeOfPayment);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "CashFundRelease";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "CashFundRelease";
            this.Load += new System.EventHandler(this.CashFundRelease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTypeOfPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSourceOfFund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifiedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTypeOfPayment;
        private DevExpress.XtraEditors.ComboBoxEdit cboTypeOfPayment;
        private DevExpress.XtraEditors.LabelControl lblChequeNo;
        private DevExpress.XtraEditors.TextEdit txtCheckNo;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraEditors.LabelControl lblSourceOfFund;
        private DevExpress.XtraEditors.LookUpEdit cboSourceOfFund;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblReleaseNo;
        private DevExpress.XtraEditors.TextEdit txtReleaseNo;
        private DevExpress.XtraEditors.LabelControl lblLoanNo;
        private DevExpress.XtraEditors.TextEdit txtLoanNo;
        private DevExpress.XtraEditors.ButtonEdit txtStatus;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.DateEdit dtModified;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.DateEdit dtCreated;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtModifiedBy;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
    }
}