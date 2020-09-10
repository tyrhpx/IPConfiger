namespace IPConfiger
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbNetCards = new System.Windows.Forms.ListBox();
            this.cmsNetCard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNetConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateCfg = new System.Windows.Forms.Button();
            this.lbTips = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.tlPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.pbFrmLogo = new System.Windows.Forms.PictureBox();
            this.lbFrmTitle = new System.Windows.Forms.Label();
            this.pbFrmMenu = new System.Windows.Forms.PictureBox();
            this.pbFrmMin = new System.Windows.Forms.PictureBox();
            this.pbFrmClose = new System.Windows.Forms.PictureBox();
            this.pbFrmMax = new System.Windows.Forms.PictureBox();
            this.tbText = new IPConfiger.AdvRichTextBox();
            this.cmsNetCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.tlPanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmMax)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNetCards
            // 
            this.lbNetCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNetCards.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbNetCards.FormattingEnabled = true;
            this.lbNetCards.IntegralHeight = false;
            this.lbNetCards.ItemHeight = 28;
            this.lbNetCards.Location = new System.Drawing.Point(0, 0);
            this.lbNetCards.Margin = new System.Windows.Forms.Padding(4);
            this.lbNetCards.Name = "lbNetCards";
            this.lbNetCards.Size = new System.Drawing.Size(222, 494);
            this.lbNetCards.TabIndex = 1;
            this.lbNetCards.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbNetCards_DrawItem);
            this.lbNetCards.SelectedIndexChanged += new System.EventHandler(this.lbNetCards_SelectedIndexChanged);
            // 
            // cmsNetCard
            // 
            this.cmsNetCard.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.cmsNetCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh,
            this.toolStripSeparator1,
            this.tsmiNetConnection,
            this.tsmiAbout});
            this.cmsNetCard.Name = "cmsNetCard";
            this.cmsNetCard.Size = new System.Drawing.Size(187, 106);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Image = global::IPConfiger.Properties.Resources.刷新;
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(186, 32);
            this.tsmiRefresh.Text = "刷新列表(&E)";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiNetConnection
            // 
            this.tsmiNetConnection.Image = global::IPConfiger.Properties.Resources.设置;
            this.tsmiNetConnection.Name = "tsmiNetConnection";
            this.tsmiNetConnection.Size = new System.Drawing.Size(186, 32);
            this.tsmiNetConnection.Text = "网络连接(...)";
            this.tsmiNetConnection.Click += new System.EventHandler(this.tsmiNetConnection_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::IPConfiger.Properties.Resources.菜单;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(186, 32);
            this.tsmiAbout.Text = "关于IPConfiger(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // btnUpdateCfg
            // 
            this.btnUpdateCfg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCfg.Location = new System.Drawing.Point(415, 4);
            this.btnUpdateCfg.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateCfg.Name = "btnUpdateCfg";
            this.btnUpdateCfg.Size = new System.Drawing.Size(131, 47);
            this.btnUpdateCfg.TabIndex = 2;
            this.btnUpdateCfg.Text = "应用配置";
            this.btnUpdateCfg.UseVisualStyleBackColor = true;
            this.btnUpdateCfg.Click += new System.EventHandler(this.btnUpdateCfg_Click);
            // 
            // lbTips
            // 
            this.lbTips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTips.Location = new System.Drawing.Point(3, 4);
            this.lbTips.Name = "lbTips";
            this.lbTips.Size = new System.Drawing.Size(405, 47);
            this.lbTips.TabIndex = 3;
            this.lbTips.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbNetCards);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbText);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(779, 496);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnUpdateCfg);
            this.panel1.Controls.Add(this.lbTips);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 439);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 55);
            this.panel1.TabIndex = 4;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelTitleBar.Controls.Add(this.tlPanelTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(2, 1);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panelTitleBar.Size = new System.Drawing.Size(779, 33);
            this.panelTitleBar.TabIndex = 5;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Start_MouseDown);
            // 
            // tlPanelTitle
            // 
            this.tlPanelTitle.BackColor = System.Drawing.Color.White;
            this.tlPanelTitle.ColumnCount = 6;
            this.tlPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlPanelTitle.Controls.Add(this.pbFrmLogo, 0, 0);
            this.tlPanelTitle.Controls.Add(this.lbFrmTitle, 1, 0);
            this.tlPanelTitle.Controls.Add(this.pbFrmMenu, 2, 0);
            this.tlPanelTitle.Controls.Add(this.pbFrmMin, 3, 0);
            this.tlPanelTitle.Controls.Add(this.pbFrmClose, 5, 0);
            this.tlPanelTitle.Controls.Add(this.pbFrmMax, 4, 0);
            this.tlPanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPanelTitle.Location = new System.Drawing.Point(0, 0);
            this.tlPanelTitle.Name = "tlPanelTitle";
            this.tlPanelTitle.RowCount = 1;
            this.tlPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPanelTitle.Size = new System.Drawing.Size(779, 30);
            this.tlPanelTitle.TabIndex = 2;
            this.tlPanelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Start_MouseDown);
            // 
            // pbFrmLogo
            // 
            this.pbFrmLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFrmLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbFrmLogo.Image")));
            this.pbFrmLogo.Location = new System.Drawing.Point(3, 3);
            this.pbFrmLogo.Name = "pbFrmLogo";
            this.pbFrmLogo.Size = new System.Drawing.Size(24, 24);
            this.pbFrmLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFrmLogo.TabIndex = 0;
            this.pbFrmLogo.TabStop = false;
            this.pbFrmLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Start_MouseDown);
            // 
            // lbFrmTitle
            // 
            this.lbFrmTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFrmTitle.Location = new System.Drawing.Point(33, 3);
            this.lbFrmTitle.Margin = new System.Windows.Forms.Padding(3);
            this.lbFrmTitle.Name = "lbFrmTitle";
            this.lbFrmTitle.Size = new System.Drawing.Size(543, 24);
            this.lbFrmTitle.TabIndex = 1;
            this.lbFrmTitle.Text = "IP配置工具 V1.0";
            this.lbFrmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbFrmTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFrmTitle_MouseDoubleClick);
            this.lbFrmTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Start_MouseDown);
            // 
            // pbFrmMenu
            // 
            this.pbFrmMenu.Image = global::IPConfiger.Properties.Resources.展开;
            this.pbFrmMenu.Location = new System.Drawing.Point(579, 0);
            this.pbFrmMenu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pbFrmMenu.Name = "pbFrmMenu";
            this.pbFrmMenu.Size = new System.Drawing.Size(50, 22);
            this.pbFrmMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrmMenu.TabIndex = 2;
            this.pbFrmMenu.TabStop = false;
            this.pbFrmMenu.Click += new System.EventHandler(this.pbFrmMenu_Click);
            this.pbFrmMenu.MouseEnter += new System.EventHandler(this.pbFrmMin_MouseEnter);
            this.pbFrmMenu.MouseLeave += new System.EventHandler(this.pbFrmMin_MouseLeave);
            // 
            // pbFrmMin
            // 
            this.pbFrmMin.Image = global::IPConfiger.Properties.Resources.最小化;
            this.pbFrmMin.Location = new System.Drawing.Point(629, 0);
            this.pbFrmMin.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pbFrmMin.Name = "pbFrmMin";
            this.pbFrmMin.Size = new System.Drawing.Size(50, 22);
            this.pbFrmMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrmMin.TabIndex = 3;
            this.pbFrmMin.TabStop = false;
            this.pbFrmMin.Click += new System.EventHandler(this.pbFrmMin_Click);
            this.pbFrmMin.MouseEnter += new System.EventHandler(this.pbFrmMin_MouseEnter);
            this.pbFrmMin.MouseLeave += new System.EventHandler(this.pbFrmMin_MouseLeave);
            // 
            // pbFrmClose
            // 
            this.pbFrmClose.BackColor = System.Drawing.Color.White;
            this.pbFrmClose.Image = global::IPConfiger.Properties.Resources.关闭;
            this.pbFrmClose.Location = new System.Drawing.Point(729, 0);
            this.pbFrmClose.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pbFrmClose.Name = "pbFrmClose";
            this.pbFrmClose.Size = new System.Drawing.Size(50, 22);
            this.pbFrmClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrmClose.TabIndex = 4;
            this.pbFrmClose.TabStop = false;
            this.pbFrmClose.Click += new System.EventHandler(this.pbFrmClose_Click);
            this.pbFrmClose.MouseEnter += new System.EventHandler(this.pbFrmClose_MouseEnter);
            this.pbFrmClose.MouseLeave += new System.EventHandler(this.pbFrmClose_MouseLeave);
            // 
            // pbFrmMax
            // 
            this.pbFrmMax.Image = global::IPConfiger.Properties.Resources.最大化;
            this.pbFrmMax.Location = new System.Drawing.Point(679, 0);
            this.pbFrmMax.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pbFrmMax.Name = "pbFrmMax";
            this.pbFrmMax.Size = new System.Drawing.Size(50, 22);
            this.pbFrmMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrmMax.TabIndex = 5;
            this.pbFrmMax.TabStop = false;
            this.pbFrmMax.Click += new System.EventHandler(this.pbFrmMax_Click);
            this.pbFrmMax.MouseEnter += new System.EventHandler(this.pbFrmMin_MouseEnter);
            this.pbFrmMax.MouseLeave += new System.EventHandler(this.pbFrmMin_MouseLeave);
            // 
            // tbText
            // 
            this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbText.LineNoBackColor = System.Drawing.Color.Gainsboro;
            this.tbText.LineNoForeColor = System.Drawing.Color.Blue;
            this.tbText.Lines = new string[0];
            this.tbText.Location = new System.Drawing.Point(0, 0);
            this.tbText.Margin = new System.Windows.Forms.Padding(4);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbText.Size = new System.Drawing.Size(549, 439);
            this.tbText.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(783, 532);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTitleBar);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP配置工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.cmsNetCard.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.tlPanelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrmMax)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IPConfiger.AdvRichTextBox tbText;
        private System.Windows.Forms.ListBox lbNetCards;
        private System.Windows.Forms.Button btnUpdateCfg;
        private System.Windows.Forms.Label lbTips;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsNetCard;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiNetConnection;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.TableLayoutPanel tlPanelTitle;
        private System.Windows.Forms.PictureBox pbFrmLogo;
        private System.Windows.Forms.Label lbFrmTitle;
        private System.Windows.Forms.PictureBox pbFrmMenu;
        private System.Windows.Forms.PictureBox pbFrmMin;
        private System.Windows.Forms.PictureBox pbFrmClose;
        private System.Windows.Forms.PictureBox pbFrmMax;
    }
}

