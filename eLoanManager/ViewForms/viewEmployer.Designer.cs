namespace eLoanSystem.ViewForms
{
    partial class viewEmployer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewEmployer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colEmpCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCardCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colEmpName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.cardView1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtCardCode});
            this.gridControl2.Size = new System.Drawing.Size(607, 403);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpCode,
            this.colEmpName,
            this.colEmpAddress,
            this.colEmpContact,
            this.colEmpEmail});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridControl2;
            this.cardView1.Name = "cardView1";
            // 
            // colEmpCode
            // 
            this.colEmpCode.Caption = "Code";
            this.colEmpCode.ColumnEdit = this.txtCardCode;
            this.colEmpCode.FieldName = "EmployerCode";
            this.colEmpCode.Name = "colEmpCode";
            this.colEmpCode.OptionsColumn.ReadOnly = true;
            this.colEmpCode.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colEmpCode.Visible = true;
            this.colEmpCode.VisibleIndex = 0;
            // 
            // txtCardCode
            // 
            this.txtCardCode.AutoHeight = false;
            this.txtCardCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtCardCode.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.txtCardCode.Name = "txtCardCode";
            // 
            // colEmpName
            // 
            this.colEmpName.Caption = "Employer Name";
            this.colEmpName.FieldName = "EmployerName";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.OptionsColumn.AllowEdit = false;
            this.colEmpName.Visible = true;
            this.colEmpName.VisibleIndex = 1;
            // 
            // colEmpAddress
            // 
            this.colEmpAddress.Caption = "Address";
            this.colEmpAddress.FieldName = "Address";
            this.colEmpAddress.Name = "colEmpAddress";
            this.colEmpAddress.OptionsColumn.ReadOnly = true;
            this.colEmpAddress.Visible = true;
            this.colEmpAddress.VisibleIndex = 2;
            // 
            // colEmpContact
            // 
            this.colEmpContact.Caption = "Contact";
            this.colEmpContact.FieldName = "ContactNumber";
            this.colEmpContact.Name = "colEmpContact";
            this.colEmpContact.OptionsColumn.AllowEdit = false;
            this.colEmpContact.Visible = true;
            this.colEmpContact.VisibleIndex = 3;
            // 
            // colEmpEmail
            // 
            this.colEmpEmail.Caption = "Email";
            this.colEmpEmail.FieldName = "EmailAddress";
            this.colEmpEmail.Name = "colEmpEmail";
            this.colEmpEmail.OptionsColumn.AllowEdit = false;
            this.colEmpEmail.Visible = true;
            this.colEmpEmail.VisibleIndex = 4;
            // 
            // viewEmployer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 403);
            this.Controls.Add(this.gridControl2);
            this.Name = "viewEmployer";
            this.Text = "Employer Information";
            this.Load += new System.EventHandler(this.viewEmployer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtCardCode;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpContact;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpEmail;
    }
}