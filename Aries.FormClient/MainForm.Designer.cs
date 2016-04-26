namespace Aries.FormClient
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnAddFile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageImage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mainNavBar = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgImage = new DevExpress.XtraNavBar.NavBarGroup();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.galleryPanel = new System.Windows.Forms.Panel();
            this.mainGallery = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.nbgAlbum = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbgFolder = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.btnShowAll = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainNavBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.galleryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGallery)).BeginInit();
            this.mainGallery.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainRibbon
            // 
            this.mainRibbon.ExpandCollapseItem.Id = 0;
            this.mainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbon.ExpandCollapseItem,
            this.barBtnAddFile,
            this.barButtonItem1,
            this.btnShowAll});
            this.mainRibbon.Location = new System.Drawing.Point(0, 0);
            this.mainRibbon.MaxItemId = 4;
            this.mainRibbon.Name = "mainRibbon";
            this.mainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageImage,
            this.ribbonPage2});
            this.mainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbon.Size = new System.Drawing.Size(931, 145);
            this.mainRibbon.StatusBar = this.ribbonStatusBar1;
            // 
            // barBtnAddFile
            // 
            this.barBtnAddFile.Caption = "添加图片";
            this.barBtnAddFile.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnAddFile.Glyph")));
            this.barBtnAddFile.Id = 1;
            this.barBtnAddFile.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnAddFile.LargeGlyph")));
            this.barBtnAddFile.Name = "barBtnAddFile";
            this.barBtnAddFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnAddFile_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPageImage
            // 
            this.ribbonPageImage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPageImage.Name = "ribbonPageImage";
            this.ribbonPageImage.Text = "图片";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnShowAll);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "查看";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "管理";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barBtnAddFile);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "图片上传";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 554);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.mainRibbon;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(931, 27);
            // 
            // mainNavBar
            // 
            this.mainNavBar.ActiveGroup = this.nbgImage;
            this.mainNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgImage,
            this.nbgAlbum,
            this.nbgFolder});
            this.mainNavBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1});
            this.mainNavBar.Location = new System.Drawing.Point(0, 145);
            this.mainNavBar.Name = "mainNavBar";
            this.mainNavBar.OptionsNavPane.ExpandedWidth = 153;
            this.mainNavBar.Size = new System.Drawing.Size(153, 409);
            this.mainNavBar.TabIndex = 2;
            this.mainNavBar.Text = "navBarControl1";
            // 
            // nbgImage
            // 
            this.nbgImage.Caption = "图片";
            this.nbgImage.Expanded = true;
            this.nbgImage.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1)});
            this.nbgImage.Name = "nbgImage";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("9947daa0-fe44-4484-af6b-ea7cda45bac6");
            this.dockPanel1.Location = new System.Drawing.Point(731, 145);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 409);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 382);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // galleryPanel
            // 
            this.galleryPanel.Controls.Add(this.mainGallery);
            this.galleryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.galleryPanel.Location = new System.Drawing.Point(153, 145);
            this.galleryPanel.Name = "galleryPanel";
            this.galleryPanel.Size = new System.Drawing.Size(578, 409);
            this.galleryPanel.TabIndex = 6;
            // 
            // mainGallery
            // 
            this.mainGallery.Controls.Add(this.galleryControlClient1);
            this.mainGallery.DesignGalleryGroupIndex = 0;
            this.mainGallery.DesignGalleryItemIndex = 0;
            this.mainGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.mainGallery.Gallery.ImageSize = new System.Drawing.Size(210, 210);
            this.mainGallery.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.mainGallery.Location = new System.Drawing.Point(0, 0);
            this.mainGallery.Name = "mainGallery";
            this.mainGallery.Size = new System.Drawing.Size(578, 409);
            this.mainGallery.TabIndex = 0;
            this.mainGallery.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.mainGallery;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(557, 405);
            // 
            // nbgAlbum
            // 
            this.nbgAlbum.Caption = "专辑";
            this.nbgAlbum.Name = "nbgAlbum";
            // 
            // nbgFolder
            // 
            this.nbgFolder.Caption = "文件夹";
            this.nbgFolder.Name = "nbgFolder";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Caption = "显示所有";
            this.btnShowAll.Glyph = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Glyph")));
            this.btnShowAll.Id = 3;
            this.btnShowAll.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnShowAll.LargeGlyph")));
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowAll_ItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 581);
            this.Controls.Add(this.galleryPanel);
            this.Controls.Add(this.mainNavBar);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.mainRibbon);
            this.Name = "MainForm";
            this.Text = "照片墙";
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainNavBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.galleryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGallery)).EndInit();
            this.mainGallery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageImage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraNavBar.NavBarControl mainNavBar;
        private DevExpress.XtraNavBar.NavBarGroup nbgImage;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barBtnAddFile;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarGroup nbgAlbum;
        private DevExpress.XtraNavBar.NavBarGroup nbgFolder;
        private System.Windows.Forms.Panel galleryPanel;
        private DevExpress.XtraBars.Ribbon.GalleryControl mainGallery;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraBars.BarButtonItem btnShowAll;
    }
}

