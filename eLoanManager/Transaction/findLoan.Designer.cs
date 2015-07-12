namespace eLoanSystem.Transaction
{
    partial class findLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(findLoan));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.cboSearchIndex = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLoanNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoanAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnChoose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchIndex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(162, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtSearch.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtSearch.Size = new System.Drawing.Size(423, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearch_ButtonClick);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cboSearchIndex
            // 
            this.cboSearchIndex.Location = new System.Drawing.Point(56, 16);
            this.cboSearchIndex.Name = "cboSearchIndex";
            this.cboSearchIndex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSearchIndex.Properties.Items.AddRange(new object[] {
            "Borrower",
            "Guarantor",
            "Loan Number"});
            this.cboSearchIndex.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboSearchIndex.Size = new System.Drawing.Size(100, 20);
            this.cboSearchIndex.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(573, 200);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLoanNo,
            this.colCardName,
            this.colLoanAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colLoanNo
            // 
            this.colLoanNo.Caption = "Loan#";
            this.colLoanNo.FieldName = "DocNum";
            this.colLoanNo.Name = "colLoanNo";
            this.colLoanNo.OptionsColumn.FixedWidth = true;
            this.colLoanNo.Visible = true;
            this.colLoanNo.VisibleIndex = 0;
            this.colLoanNo.Width = 64;
            // 
            // colCardName
            // 
            this.colCardName.Caption = "Borrower";
            this.colCardName.FieldName = "CardName";
            this.colCardName.Name = "colCardName";
            this.colCardName.Visible = true;
            this.colCardName.VisibleIndex = 1;
            this.colCardName.Width = 162;
            // 
            // colLoanAmount
            // 
            this.colLoanAmount.Caption = "Loan Amount";
            this.colLoanAmount.DisplayFormat.FormatString = "{0:N}";
            this.colLoanAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLoanAmount.FieldName = "LoanAmount";
            this.colLoanAmount.Name = "colLoanAmount";
            this.colLoanAmount.Visible = true;
            this.colLoanAmount.VisibleIndex = 2;
            this.colLoanAmount.Width = 167;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(12, 252);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 4;
            this.btnChoose.Text = "Choose";
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // findLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.cboSearchIndex);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelControl1);
            this.Name = "findLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "findLoan";
            this.Load += new System.EventHandler(this.findLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSearchIndex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cboSearchIndex;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnChoose;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colLoanNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCardName;
        private DevExpress.XtraGrid.Columns.GridColumn colLoanAmount;
    }
}