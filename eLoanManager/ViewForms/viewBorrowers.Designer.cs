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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdCtlBorrowerInfo = new DevExpress.XtraGrid.GridControl();
            this.txtBorrowerCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BorrowerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGuarantorFinancer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployer = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlBorrowerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrowerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCtlBorrowerInfo
            // 
            this.grdCtlBorrowerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtlBorrowerInfo.Location = new System.Drawing.Point(0, 0);
            this.grdCtlBorrowerInfo.MainView = this.cardView1;
            this.grdCtlBorrowerInfo.Name = "grdCtlBorrowerInfo";
            this.grdCtlBorrowerInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtBorrowerCode});
            this.grdCtlBorrowerInfo.Size = new System.Drawing.Size(609, 357);
            this.grdCtlBorrowerInfo.TabIndex = 4;
            this.grdCtlBorrowerInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            // 
            // txtBorrowerCode
            // 
            this.txtBorrowerCode.AutoHeight = false;
            this.txtBorrowerCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtBorrowerCode.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.txtBorrowerCode.Name = "txtBorrowerCode";
            this.txtBorrowerCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtBorrowerCode_ButtonClick);
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colType,
            this.BorrowerCode,
            this.colLastName,
            this.colFirstName,
            this.colMI,
            this.colGuarantorFinancer,
            this.colEmployer});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.grdCtlBorrowerInfo;
            this.cardView1.Name = "cardView1";
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "CardType";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            // 
            // BorrowerCode
            // 
            this.BorrowerCode.Caption = "Code";
            this.BorrowerCode.ColumnEdit = this.txtBorrowerCode;
            this.BorrowerCode.FieldName = "BorrowerCode";
            this.BorrowerCode.Name = "BorrowerCode";
            this.BorrowerCode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.BorrowerCode.Visible = true;
            this.BorrowerCode.VisibleIndex = 1;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Last Name";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "First Name";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 3;
            // 
            // colMI
            // 
            this.colMI.Caption = "M.I.";
            this.colMI.FieldName = "MiddleName";
            this.colMI.Name = "colMI";
            this.colMI.Visible = true;
            this.colMI.VisibleIndex = 4;
            // 
            // colGuarantorFinancer
            // 
            this.colGuarantorFinancer.Caption = "Guarantor/Financer";
            this.colGuarantorFinancer.FieldName = "GuarantorName";
            this.colGuarantorFinancer.Name = "colGuarantorFinancer";
            this.colGuarantorFinancer.Visible = true;
            this.colGuarantorFinancer.VisibleIndex = 5;
            // 
            // colEmployer
            // 
            this.colEmployer.Caption = "Employer";
            this.colEmployer.FieldName = "Employer";
            this.colEmployer.Name = "colEmployer";
            this.colEmployer.Visible = true;
            this.colEmployer.VisibleIndex = 6;
            // 
            // viewBorrowers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 357);
            this.Controls.Add(this.grdCtlBorrowerInfo);
            this.Name = "viewBorrowers";
            this.Text = "Borrower Files";
            this.Load += new System.EventHandler(this.viewBorrowers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlBorrowerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBorrowerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtlBorrowerInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtBorrowerCode;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn BorrowerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colMI;
        private DevExpress.XtraGrid.Columns.GridColumn colGuarantorFinancer;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployer;
    }
}