namespace eLoanSystem.Transaction
{
    partial class CashReleaseDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashReleaseDocument));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocStatus = new DevExpress.XtraEditors.ButtonEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.txtModifiedBy = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.dtCreated = new DevExpress.XtraEditors.DateEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.dtModified = new DevExpress.XtraEditors.DateEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRefLoanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtLoanNo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colCardCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoanAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefDocument = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceivedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cboDueDate = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cboScheduleNo = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.lblDocNo = new DevExpress.XtraEditors.LabelControl();
            this.txtDocNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboSourceOfFund = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboFundDestination = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.lblGuarantor = new DevExpress.XtraEditors.LabelControl();
            this.cboGuarantorFinancer = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifiedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboScheduleNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSourceOfFund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFundDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGuarantorFinancer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(475, 51);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(35, 13);
            this.labelControl16.TabIndex = 10;
            this.labelControl16.Text = "Status:";
            // 
            // txtDocStatus
            // 
            this.txtDocStatus.EditValue = "Draft";
            this.txtDocStatus.Location = new System.Drawing.Point(574, 51);
            this.txtDocStatus.MenuManager = this.ribbonControl1;
            this.txtDocStatus.Name = "txtDocStatus";
            this.txtDocStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtDocStatus.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtDocStatus.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtDocStatus.Size = new System.Drawing.Size(111, 22);
            this.txtDocStatus.TabIndex = 11;
            this.txtDocStatus.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtDocStatus_ButtonClick);
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
            this.ribbonControl1.Size = new System.Drawing.Size(710, 27);
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
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(475, 79);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(58, 13);
            this.labelControl15.TabIndex = 12;
            this.labelControl15.Text = "Created By:";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(574, 79);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(112, 20);
            this.txtCreatedBy.TabIndex = 13;
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.Location = new System.Drawing.Point(574, 133);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Size = new System.Drawing.Size(112, 20);
            this.txtModifiedBy.TabIndex = 17;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(475, 105);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(69, 13);
            this.labelControl14.TabIndex = 14;
            this.labelControl14.Text = "Date Created:";
            // 
            // dtCreated
            // 
            this.dtCreated.EditValue = null;
            this.dtCreated.Location = new System.Drawing.Point(574, 105);
            this.dtCreated.Name = "dtCreated";
            this.dtCreated.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreated.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreated.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dtCreated.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dtCreated.Size = new System.Drawing.Size(112, 20);
            this.dtCreated.TabIndex = 15;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(475, 159);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(70, 13);
            this.labelControl13.TabIndex = 18;
            this.labelControl13.Text = "Date Modified:";
            // 
            // dtModified
            // 
            this.dtModified.EditValue = null;
            this.dtModified.Location = new System.Drawing.Point(574, 159);
            this.dtModified.Name = "dtModified";
            this.dtModified.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtModified.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtModified.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.dtModified.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.dtModified.Size = new System.Drawing.Size(112, 20);
            this.dtModified.TabIndex = 19;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(475, 133);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(59, 13);
            this.labelControl12.TabIndex = 16;
            this.labelControl12.Text = "Modified By:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(97, 511);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 511);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRefLoanNo,
            this.colCardCode,
            this.colCardName,
            this.colLoanAmount,
            this.colRefDocument,
            this.colReceivedAmount,
            this.colStatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // colRefLoanNo
            // 
            this.colRefLoanNo.Caption = "Loan#";
            this.colRefLoanNo.ColumnEdit = this.txtLoanNo;
            this.colRefLoanNo.FieldName = "RefLoanNo";
            this.colRefLoanNo.Name = "colRefLoanNo";
            this.colRefLoanNo.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRefLoanNo.Visible = true;
            this.colRefLoanNo.VisibleIndex = 0;
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.AutoHeight = false;
            this.txtLoanNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtLoanNo_ButtonClick);
            // 
            // colCardCode
            // 
            this.colCardCode.Caption = "Code";
            this.colCardCode.FieldName = "CardCode";
            this.colCardCode.Name = "colCardCode";
            this.colCardCode.Visible = true;
            this.colCardCode.VisibleIndex = 2;
            // 
            // colCardName
            // 
            this.colCardName.Caption = "Borrower";
            this.colCardName.FieldName = "CardName";
            this.colCardName.Name = "colCardName";
            this.colCardName.Visible = true;
            this.colCardName.VisibleIndex = 1;
            // 
            // colLoanAmount
            // 
            this.colLoanAmount.Caption = "Loan Amount";
            this.colLoanAmount.FieldName = "LoanAmount";
            this.colLoanAmount.Name = "colLoanAmount";
            this.colLoanAmount.Visible = true;
            this.colLoanAmount.VisibleIndex = 3;
            // 
            // colRefDocument
            // 
            this.colRefDocument.Caption = "Reference Document[ATM/PDC#]";
            this.colRefDocument.FieldName = "ReferenceDocument";
            this.colRefDocument.Name = "colRefDocument";
            this.colRefDocument.Visible = true;
            this.colRefDocument.VisibleIndex = 4;
            // 
            // colReceivedAmount
            // 
            this.colReceivedAmount.Caption = "Received Amount";
            this.colReceivedAmount.FieldName = "ReceivedAmount";
            this.colReceivedAmount.Name = "colReceivedAmount";
            this.colReceivedAmount.Visible = true;
            this.colReceivedAmount.VisibleIndex = 5;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "DocStatus";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(14, 251);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboDueDate,
            this.txtLoanNo,
            this.cboScheduleNo});
            this.gridControl1.Size = new System.Drawing.Size(684, 254);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cboDueDate
            // 
            this.cboDueDate.AutoHeight = false;
            this.cboDueDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDueDate.Name = "cboDueDate";
            // 
            // cboScheduleNo
            // 
            this.cboScheduleNo.AutoHeight = false;
            this.cboScheduleNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboScheduleNo.Name = "cboScheduleNo";
            // 
            // lblDocNo
            // 
            this.lblDocNo.Location = new System.Drawing.Point(15, 51);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(63, 13);
            this.lblDocNo.TabIndex = 0;
            this.lblDocNo.Text = "Document #:";
            // 
            // txtDocNum
            // 
            this.txtDocNum.EditValue = "########";
            this.txtDocNum.Location = new System.Drawing.Point(85, 51);
            this.txtDocNum.MenuManager = this.ribbonControl1;
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.Properties.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(100, 20);
            this.txtDocNum.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "From:";
            // 
            // cboSourceOfFund
            // 
            this.cboSourceOfFund.Location = new System.Drawing.Point(85, 79);
            this.cboSourceOfFund.MenuManager = this.ribbonControl1;
            this.cboSourceOfFund.Name = "cboSourceOfFund";
            this.cboSourceOfFund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSourceOfFund.Properties.NullText = "[Source]";
            this.cboSourceOfFund.Size = new System.Drawing.Size(247, 20);
            this.cboSourceOfFund.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 105);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(16, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "To:";
            // 
            // cboFundDestination
            // 
            this.cboFundDestination.Location = new System.Drawing.Point(85, 105);
            this.cboFundDestination.Name = "cboFundDestination";
            this.cboFundDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFundDestination.Properties.NullText = "[Destination]";
            this.cboFundDestination.Size = new System.Drawing.Size(247, 20);
            this.cboFundDestination.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 160);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(85, 160);
            this.txtRemarks.MenuManager = this.ribbonControl1;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(247, 59);
            this.txtRemarks.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 225);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.EditValue = "0";
            this.txtAmount.Location = new System.Drawing.Point(85, 225);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Mask.EditMask = "#,###,###,###,###.00";
            this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAmount.Size = new System.Drawing.Size(247, 20);
            this.txtAmount.TabIndex = 9;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(625, 518);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 34);
            this.simpleButton3.TabIndex = 23;
            this.simpleButton3.Text = "Print";
            // 
            // lblGuarantor
            // 
            this.lblGuarantor.Location = new System.Drawing.Point(15, 133);
            this.lblGuarantor.Name = "lblGuarantor";
            this.lblGuarantor.Size = new System.Drawing.Size(53, 13);
            this.lblGuarantor.TabIndex = 4;
            this.lblGuarantor.Text = "Guarantor:";
            // 
            // cboGuarantorFinancer
            // 
            this.cboGuarantorFinancer.Location = new System.Drawing.Point(85, 134);
            this.cboGuarantorFinancer.Name = "cboGuarantorFinancer";
            this.cboGuarantorFinancer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGuarantorFinancer.Properties.NullText = "[Guarrantor/Employer]";
            this.cboGuarantorFinancer.Size = new System.Drawing.Size(175, 20);
            this.cboGuarantorFinancer.TabIndex = 18;
            // 
            // CashReleaseDocument
            // 
            this.AllowDisplayRibbon = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 564);
            this.Controls.Add(this.cboGuarantorFinancer);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboFundDestination);
            this.Controls.Add(this.cboSourceOfFund);
            this.Controls.Add(this.lblGuarantor);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtDocNum);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblDocNo);
            this.Controls.Add(this.txtDocStatus);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.dtModified);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.dtCreated);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.txtModifiedBy);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "CashReleaseDocument";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cash Fund Release";
            this.Load += new System.EventHandler(this.CashFundRelease_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDocStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModifiedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtModified.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboScheduleNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSourceOfFund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFundDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGuarantorFinancer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.ButtonEdit txtDocStatus;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraEditors.TextEdit txtModifiedBy;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.DateEdit dtCreated;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.DateEdit dtModified;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.LabelControl lblDocNo;
        private DevExpress.XtraEditors.TextEdit txtDocNum;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboSourceOfFund;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboFundDestination;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRefLoanNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCardCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCardName;
        private DevExpress.XtraGrid.Columns.GridColumn colLoanAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colRefDocument;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboDueDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtLoanNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit cboScheduleNo;
        private DevExpress.XtraEditors.LabelControl lblGuarantor;
        private DevExpress.XtraEditors.LookUpEdit cboGuarantorFinancer;

    }
}