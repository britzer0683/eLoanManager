namespace eLoanSystem.ViewForms
{
    partial class viewGuarantorFinancer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewGuarantorFinancer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdCtlGuarantorFinancer = new DevExpress.XtraGrid.GridControl();
            this.cardView2 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutViewColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlGuarantorFinancer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCtlGuarantorFinancer
            // 
            this.grdCtlGuarantorFinancer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtlGuarantorFinancer.Location = new System.Drawing.Point(0, 0);
            this.grdCtlGuarantorFinancer.MainView = this.cardView2;
            this.grdCtlGuarantorFinancer.Name = "grdCtlGuarantorFinancer";
            this.grdCtlGuarantorFinancer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtCode});
            this.grdCtlGuarantorFinancer.Size = new System.Drawing.Size(578, 440);
            this.grdCtlGuarantorFinancer.TabIndex = 2;
            this.grdCtlGuarantorFinancer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView2});
            // 
            // cardView2
            // 
            this.cardView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.layoutViewColumn1,
            this.layoutViewColumn2,
            this.layoutViewColumn3,
            this.layoutViewColumn4,
            this.layoutViewColumn5,
            this.layoutViewColumn6});
            this.cardView2.FocusedCardTopFieldIndex = 0;
            this.cardView2.GridControl = this.grdCtlGuarantorFinancer;
            this.cardView2.Name = "cardView2";
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "Code";
            this.layoutViewColumn1.ColumnEdit = this.txtCode;
            this.layoutViewColumn1.FieldName = "GuarantorFinancerCode";
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            this.layoutViewColumn1.OptionsColumn.ReadOnly = true;
            this.layoutViewColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.layoutViewColumn1.Visible = true;
            this.layoutViewColumn1.VisibleIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.AutoHeight = false;
            this.txtCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("txtCode.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.txtCode.Name = "txtCode";
            // 
            // layoutViewColumn2
            // 
            this.layoutViewColumn2.Caption = "Name";
            this.layoutViewColumn2.FieldName = "GuarantorFinancerName";
            this.layoutViewColumn2.Name = "layoutViewColumn2";
            this.layoutViewColumn2.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn2.Visible = true;
            this.layoutViewColumn2.VisibleIndex = 1;
            // 
            // layoutViewColumn3
            // 
            this.layoutViewColumn3.Caption = "Address";
            this.layoutViewColumn3.FieldName = "Address";
            this.layoutViewColumn3.Name = "layoutViewColumn3";
            this.layoutViewColumn3.OptionsColumn.ReadOnly = true;
            this.layoutViewColumn3.Visible = true;
            this.layoutViewColumn3.VisibleIndex = 2;
            // 
            // layoutViewColumn4
            // 
            this.layoutViewColumn4.Caption = "Contact #";
            this.layoutViewColumn4.FieldName = "ContactNumber";
            this.layoutViewColumn4.Name = "layoutViewColumn4";
            this.layoutViewColumn4.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn4.Visible = true;
            this.layoutViewColumn4.VisibleIndex = 3;
            // 
            // layoutViewColumn5
            // 
            this.layoutViewColumn5.Caption = "Email";
            this.layoutViewColumn5.FieldName = "EmailAddress";
            this.layoutViewColumn5.Name = "layoutViewColumn5";
            this.layoutViewColumn5.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn5.Visible = true;
            this.layoutViewColumn5.VisibleIndex = 4;
            // 
            // layoutViewColumn6
            // 
            this.layoutViewColumn6.Caption = "Contact Person";
            this.layoutViewColumn6.FieldName = "ContactPerson";
            this.layoutViewColumn6.Name = "layoutViewColumn6";
            this.layoutViewColumn6.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn6.Visible = true;
            this.layoutViewColumn6.VisibleIndex = 5;
            // 
            // viewGuarantorFinancer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 440);
            this.Controls.Add(this.grdCtlGuarantorFinancer);
            this.Name = "viewGuarantorFinancer";
            this.Text = "Guarantor/Financer";
            this.Load += new System.EventHandler(this.viewGuarantorFinancer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCtlGuarantorFinancer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCtlGuarantorFinancer;
        private DevExpress.XtraGrid.Views.Card.CardView cardView2;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit txtCode;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn6;
    }
}