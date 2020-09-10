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
            this.cmsRTB = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRTB.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsRTB
            // 
            this.cmsRTB.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
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
            this.tsmiImport,
            this.tsmiExport,
            this.tsmiExportAll});
            this.cmsRTB.Name = "cmsRTB";
            this.cmsRTB.Size = new System.Drawing.Size(210, 286);
            this.cmsRTB.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRTB_Opening);
            this.cmsRTB.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsRTB_ItemClicked);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(153, 24);
            this.tsmiCopy.Text = "复制(&C)";
            // 
            // tsmiCut
            // 
            this.tsmiCut.Name = "tsmiCut";
            this.tsmiCut.Size = new System.Drawing.Size(153, 24);
            this.tsmiCut.Text = "剪切(&T)";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(153, 24);
            this.tsmiDelete.Text = "删除(&D)";
            // 
            // tsmiParse
            // 
            this.tsmiParse.Name = "tsmiParse";
            this.tsmiParse.Size = new System.Drawing.Size(153, 24);
            this.tsmiParse.Text = "粘贴(&P)";
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.Size = new System.Drawing.Size(153, 24);
            this.tsmiSelectAll.Text = "全选(&A)";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.Size = new System.Drawing.Size(153, 24);
            this.tsmiUndo.Text = "撤销(&U)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Name = "tsmiRedo";
            this.tsmiRedo.Size = new System.Drawing.Size(153, 24);
            this.tsmiRedo.Text = "重做(&R)";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(209, 24);
            this.tsmiImport.Text = "导入地址列表(...)";
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(209, 24);
            this.tsmiExport.Text = "导出选中地址列表(...)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // tsmiClearAll
            // 
            this.tsmiClearAll.Name = "tsmiClearAll";
            this.tsmiClearAll.Size = new System.Drawing.Size(153, 24);
            this.tsmiClearAll.Text = "清空(&L)";
            // 
            // tsmiExportAll
            // 
            this.tsmiExportAll.Name = "tsmiExportAll";
            this.tsmiExportAll.Size = new System.Drawing.Size(209, 24);
            this.tsmiExportAll.Text = "导出全部地址列表(...)";
            // 
            // IPAddressRTB
            // 
            this.ContextMenuStrip = this.cmsRTB;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportAll;
    }
}
