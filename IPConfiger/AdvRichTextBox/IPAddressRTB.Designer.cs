namespace IPConfiger
{
    partial class IPAddressRTB
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPAddressRTB));
            this.cmsRTB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddrList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRTB.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsRTB
            // 
            resources.ApplyResources(this.cmsRTB, "cmsRTB");
            this.cmsRTB.BackColor = System.Drawing.Color.White;
            this.cmsRTB.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRTB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndo,
            this.tsmiRedo,
            this.toolStripSeparator1,
            this.tsmiCut,
            this.tsmiCopy,
            this.tsmiParse,
            this.tsmiDelete,
            this.toolStripSeparator2,
            this.tsmiSelectAll,
            this.tsmiClearAll,
            this.toolStripSeparator3,
            this.tsmiAddrList});
            this.cmsRTB.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.cmsRTB.Name = "cmsRTB";
            this.cmsRTB.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRTB_Opening);
            this.cmsRTB.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsRTB_ItemClicked);
            // 
            // tsmiUndo
            // 
            resources.ApplyResources(this.tsmiUndo, "tsmiUndo");
            this.tsmiUndo.Image = global::IPConfiger.Properties.Resources.撤销;
            this.tsmiUndo.Name = "tsmiUndo";
            // 
            // tsmiRedo
            // 
            resources.ApplyResources(this.tsmiRedo, "tsmiRedo");
            this.tsmiRedo.Image = global::IPConfiger.Properties.Resources.重做;
            this.tsmiRedo.Name = "tsmiRedo";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // tsmiCut
            // 
            resources.ApplyResources(this.tsmiCut, "tsmiCut");
            this.tsmiCut.Image = global::IPConfiger.Properties.Resources.剪切;
            this.tsmiCut.Name = "tsmiCut";
            // 
            // tsmiCopy
            // 
            resources.ApplyResources(this.tsmiCopy, "tsmiCopy");
            this.tsmiCopy.Image = global::IPConfiger.Properties.Resources.复制;
            this.tsmiCopy.Name = "tsmiCopy";
            // 
            // tsmiParse
            // 
            resources.ApplyResources(this.tsmiParse, "tsmiParse");
            this.tsmiParse.Image = global::IPConfiger.Properties.Resources.粘贴;
            this.tsmiParse.Name = "tsmiParse";
            // 
            // tsmiDelete
            // 
            resources.ApplyResources(this.tsmiDelete, "tsmiDelete");
            this.tsmiDelete.Name = "tsmiDelete";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tsmiSelectAll
            // 
            resources.ApplyResources(this.tsmiSelectAll, "tsmiSelectAll");
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            // 
            // tsmiClearAll
            // 
            resources.ApplyResources(this.tsmiClearAll, "tsmiClearAll");
            this.tsmiClearAll.Name = "tsmiClearAll";
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // tsmiAddrList
            // 
            resources.ApplyResources(this.tsmiAddrList, "tsmiAddrList");
            this.tsmiAddrList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiImport,
            this.tsmiExport});
            this.tsmiAddrList.Image = global::IPConfiger.Properties.Resources.导入导出;
            this.tsmiAddrList.Name = "tsmiAddrList";
            // 
            // tsmiImport
            // 
            resources.ApplyResources(this.tsmiImport, "tsmiImport");
            this.tsmiImport.Name = "tsmiImport";
            // 
            // tsmiExport
            // 
            resources.ApplyResources(this.tsmiExport, "tsmiExport");
            this.tsmiExport.Name = "tsmiExport";
            // 
            // IPAddressRTB
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.cmsRTB;
            this.DetectUrls = false;
            this.ShowSelectionMargin = true;
            this.cmsRTB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsRTB;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiCut;
        private System.Windows.Forms.ToolStripMenuItem tsmiParse;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddrList;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
    }
}
