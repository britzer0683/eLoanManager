namespace eLoanSystem.ViewForms
{
    partial class viewLoanApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewLoanApplications));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdCtlLoanInfo = new DevExpress.XtraGrid.GridControl();
            this.grdViewLoanInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtLoanNo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlLoanInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewLoanInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCtlLoanInfo
            // 
            this.grdCtlLoanInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtlLoanInfo.Location = new System.Drawing.Point(0, 0);
            this.grdCtlLoanInfo.MainView = this.grdViewLoanInfo;
            this.grdCtlLoanInfo.Name = "grdCtlLoanInfo";
            this.grdCtlLoanInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtLoanNo});
            this.grdCtlLoanInfo.Size = new System.Drawing.Size(678, 447);
            this.grdCtlLoanInfo.TabIndex = 1;
            this.grdCtlLoanInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewLoanInfo});
            // 
            // grdViewLoanInfo
            // 
            this.grdViewLoanInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocNo,
            this.gridColumn2,
            this.gridColumn26,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn25,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn7});
            this.grdViewLoanInfo.GridControl = this.grdCtlLoanInfo;
            this.grdViewLoanInfo.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LoanAmount", this.gridColumn4, "{0:N}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmortization", this.gridColumn5, "{0:N}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInterest", this.gridColumn6, "{0:N}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CashReleased", this.gridColumn25, "{0:N}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCollection", this.gridColumn27, "{0:N}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingBalance", this.gridColumn28, "{0:N}")});
            this.grdViewLoanInfo.Name = "grdViewLoanInfo";
            this.grdViewLoanInfo.OptionsView.ShowAutoFilterRow = true;
            this.grdViewLoanInfo.OptionsView.ShowFooter = true;
            // 
            // colDocNo
            // 
            this.colDocNo.Caption = "Loan No.";
            this.colDocNo.ColumnEdit = this.txtLoanNo;
            this.colDocNo.FieldName = "DocNum";
            this.colDocNo.Name = "colDocNo";
            this.colDocNo.OptionsColumn.ReadOnly = true;
            this.colDocNo.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colDocNo.Visible = true;
            this.colDocNo.VisibleIndex = 0;
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.AutoHeight = false;
            this.txtLoanNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtLoanNo.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtLoanNo_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Code";
            this.gridColumn2.FieldName = "CardCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Guarantor";
            this.gridColumn26.FieldName = "Guarrantor";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Name";
            this.gridColumn3.FieldName = "CardName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Principal Amount";
            this.gridColumn4.DisplayFormat.FormatString = "{0:N}";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "LoanAmount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LoanAmount", "{0:N}")});
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Total Amortization";
            this.gridColumn5.DisplayFormat.FormatString = "{0:N}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "TotalAmortization";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmortization", "{0:N}")});
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total Interest";
            this.gridColumn6.DisplayFormat.FormatString = "{0:N}";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "TotalInterest";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInterest", "{0:N}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Cash Released";
            this.gridColumn25.DisplayFormat.FormatString = "{0:N}";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "CashReleased";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CashReleased", "{0:N}")});
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 6;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Total Collection";
            this.gridColumn27.DisplayFormat.FormatString = "{0:N}";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "TotalCollection";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCollection", "{0:N}")});
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 7;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Outstanding Balance";
            this.gridColumn28.DisplayFormat.FormatString = "{0:N}";
            this.gridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn28.FieldName = "OutstandingBalance";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutstandingBalance", "{0:N}")});
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 8;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Status";
            this.gridColumn7.FieldName = "DocStatus";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            // 
            // viewLoanApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 447);
            this.Controls.Add(this.grdCtlLoanInfo);
            this.Name = "viewLoanApplications";
            this.Text = "Loan Applications";
            this.Load += new System.EventHandler(this.viewLoanApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlLoanInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewLoanInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtlLoanInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewLoanInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colDocNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtLoanNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}