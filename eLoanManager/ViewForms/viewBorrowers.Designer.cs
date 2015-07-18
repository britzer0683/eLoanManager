namespace eLoanSystem.ViewForms
{
    partial class viewBorrowers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewBorrowers));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdCtlBorrowerInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BorrowerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBorrowerCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGuarantorFinancer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployer = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlBorrowerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrowerCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCtlBorrowerInfo
            // 
            this.grdCtlBorrowerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtlBorrowerInfo.Location = new System.Drawing.Point(0, 0);
            this.grdCtlBorrowerInfo.MainView = this.gridView3;
            this.grdCtlBorrowerInfo.Name = "grdCtlBorrowerInfo";
            this.grdCtlBorrowerInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtBorrowerCode});
            this.grdCtlBorrowerInfo.Size = new System.Drawing.Size(609, 357);
            this.grdCtlBorrowerInfo.TabIndex = 4;
            this.grdCtlBorrowerInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colType,
            this.BorrowerCode,
            this.colLastName,
            this.colFirstName,
            this.colMI,
            this.colGuarantorFinancer,
            this.colEmployer});
            this.gridView3.GridControl = this.grdCtlBorrowerInfo;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "CardType";
            this.colType.Name = "colType";
            // 
            // BorrowerCode
            // 
            this.BorrowerCode.Caption = "Code";
            this.BorrowerCode.ColumnEdit = this.txtBorrowerCode;
            this.BorrowerCode.FieldName = "BorrowerCode";
            this.BorrowerCode.Name = "BorrowerCode";
            this.BorrowerCode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.BorrowerCode.Visible = true;
            this.BorrowerCode.VisibleIndex = 0;
            // 
            // txtBorrowerCode
            // 
            this.txtBorrowerCode.AutoHeight = false;
            this.txtBorrowerCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtBorrowerCode.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtBorrowerCode.Name = "txtBorrowerCode";
            this.txtBorrowerCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtBorrowerCode_ButtonClick);
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Last Name";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 1;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "First Name";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 2;
            // 
            // colMI
            // 
            this.colMI.Caption = "M.I.";
            this.colMI.FieldName = "MiddleName";
            this.colMI.Name = "colMI";
            this.colMI.Visible = true;
            this.colMI.VisibleIndex = 3;
            // 
            // colGuarantorFinancer
            // 
            this.colGuarantorFinancer.Caption = "Guarantor/Financer";
            this.colGuarantorFinancer.FieldName = "GuarantorName";
            this.colGuarantorFinancer.Name = "colGuarantorFinancer";
            this.colGuarantorFinancer.Visible = true;
            this.colGuarantorFinancer.VisibleIndex = 4;
            // 
            // colEmployer
            // 
            this.colEmployer.Caption = "Employer";
            this.colEmployer.FieldName = "Employer";
            this.colEmployer.Name = "colEmployer";
            this.colEmployer.Visible = true;
            this.colEmployer.VisibleIndex = 5;
            // 
            // viewBorrowers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 357);
            this.Controls.Add(this.grdCtlBorrowerInfo);
            this.Name = "viewBorrowers";
            this.Text = "viewBorrowers";
            this.Load += new System.EventHandler(this.viewBorrowers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlBorrowerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrowerCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtlBorrowerInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn BorrowerCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtBorrowerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colMI;
        private DevExpress.XtraGrid.Columns.GridColumn colGuarantorFinancer;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployer;
    }
}