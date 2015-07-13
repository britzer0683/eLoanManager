﻿namespace eLoanSystem
{
    partial class eLoanMainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(eLoanMainMenu));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barNewDocument = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barNewBorrower = new DevExpress.XtraBars.BarButtonItem();
            this.barNewEmployer = new DevExpress.XtraBars.BarButtonItem();
            this.barNewGuarantor = new DevExpress.XtraBars.BarButtonItem();
            this.barFundSetup = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarLoan = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarNewApplicationLoan = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarLoanList = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarCashRelease = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barNewDocument,
            this.barButtonItem1,
            this.barNewBorrower,
            this.barNewEmployer,
            this.barNewGuarantor,
            this.barFundSetup,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(767, 139);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Merge += new DevExpress.XtraBars.Ribbon.RibbonMergeEventHandler(this.ribbonControl1_Merge);
            // 
            // barNewDocument
            // 
            this.barNewDocument.Caption = "New";
            this.barNewDocument.Glyph = ((System.Drawing.Image)(resources.GetObject("barNewDocument.Glyph")));
            this.barNewDocument.Id = 1;
            this.barNewDocument.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barNewDocument.LargeGlyph")));
            this.barNewDocument.Name = "barNewDocument";
            this.barNewDocument.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Save";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barNewBorrower
            // 
            this.barNewBorrower.Caption = "New Borrower";
            this.barNewBorrower.Glyph = ((System.Drawing.Image)(resources.GetObject("barNewBorrower.Glyph")));
            this.barNewBorrower.Id = 3;
            this.barNewBorrower.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barNewBorrower.LargeGlyph")));
            this.barNewBorrower.Name = "barNewBorrower";
            this.barNewBorrower.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNewBorrower_ItemClick);
            // 
            // barNewEmployer
            // 
            this.barNewEmployer.Caption = "New Employer";
            this.barNewEmployer.Glyph = ((System.Drawing.Image)(resources.GetObject("barNewEmployer.Glyph")));
            this.barNewEmployer.Id = 4;
            this.barNewEmployer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barNewEmployer.LargeGlyph")));
            this.barNewEmployer.Name = "barNewEmployer";
            this.barNewEmployer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barNewEmployer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNewEmployer_ItemClick);
            // 
            // barNewGuarantor
            // 
            this.barNewGuarantor.Caption = "Guarantor";
            this.barNewGuarantor.Glyph = ((System.Drawing.Image)(resources.GetObject("barNewGuarantor.Glyph")));
            this.barNewGuarantor.Id = 5;
            this.barNewGuarantor.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barNewGuarantor.LargeGlyph")));
            this.barNewGuarantor.Name = "barNewGuarantor";
            this.barNewGuarantor.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barNewGuarantor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNewGuarantor_ItemClick);
            // 
            // barFundSetup
            // 
            this.barFundSetup.Caption = "Fund Setup";
            this.barFundSetup.Glyph = ((System.Drawing.Image)(resources.GetObject("barFundSetup.Glyph")));
            this.barFundSetup.Id = 6;
            this.barFundSetup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barFundSetup.LargeGlyph")));
            this.barFundSetup.Name = "barFundSetup";
            this.barFundSetup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barFundSetup_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Frequency Payment Setup";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 7;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "User Maintenance";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Master Files";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barNewBorrower);
            this.ribbonPageGroup3.ItemLinks.Add(this.barNewEmployer);
            this.ribbonPageGroup3.ItemLinks.Add(this.barNewGuarantor);
            this.ribbonPageGroup3.ItemLinks.Add(this.barFundSetup, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem5, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Master Files";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 442);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(767, 27);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarLoan;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarLoan,
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarNewApplicationLoan,
            this.navBarLoanList,
            this.navBarCashRelease,
            this.navBarItem1});
            this.navBarControl1.Location = new System.Drawing.Point(0, 139);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 205;
            this.navBarControl1.Size = new System.Drawing.Size(205, 303);
            this.navBarControl1.TabIndex = 3;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarLoan
            // 
            this.navBarLoan.Caption = "Loan Information";
            this.navBarLoan.Expanded = true;
            this.navBarLoan.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarNewApplicationLoan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarLoanList)});
            this.navBarLoan.Name = "navBarLoan";
            // 
            // navBarNewApplicationLoan
            // 
            this.navBarNewApplicationLoan.Caption = "Application Form";
            this.navBarNewApplicationLoan.Name = "navBarNewApplicationLoan";
            this.navBarNewApplicationLoan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarNewApplicationLoan_LinkClicked);
            // 
            // navBarLoanList
            // 
            this.navBarLoanList.Caption = "Browse Applications";
            this.navBarLoanList.Name = "navBarLoanList";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Cash Receipt/Disbursement";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarCashRelease),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarCashRelease
            // 
            this.navBarCashRelease.Caption = "Cash Release";
            this.navBarCashRelease.Name = "navBarCashRelease";
            this.navBarCashRelease.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarCashRelease_LinkClicked);
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Cash/Fund Entry";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Master Data";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Master Data";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // eLoanMainMenu
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 469);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "eLoanMainMenu";
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "eLoanMainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.eLoanMainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarLoan;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarNewApplicationLoan;
        private DevExpress.XtraNavBar.NavBarItem navBarLoanList;
        private DevExpress.XtraNavBar.NavBarItem navBarCashRelease;
        private DevExpress.XtraBars.BarButtonItem barNewDocument;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barNewBorrower;
        private DevExpress.XtraBars.BarButtonItem barNewEmployer;
        private DevExpress.XtraBars.BarButtonItem barNewGuarantor;
        private DevExpress.XtraBars.BarButtonItem barFundSetup;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
    }
}