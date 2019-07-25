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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbText = new System.Windows.Forms.TextBox();
            this.lbNetCards = new System.Windows.Forms.ListBox();
            this.btnUpdateCfg = new System.Windows.Forms.Button();
            this.lbTips = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbText.Location = new System.Drawing.Point(0, 0);
            this.tbText.Margin = new System.Windows.Forms.Padding(4);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(549, 471);
            this.tbText.TabIndex = 0;
            // 
            // lbNetCards
            // 
            this.lbNetCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNetCards.FormattingEnabled = true;
            this.lbNetCards.IntegralHeight = false;
            this.lbNetCards.ItemHeight = 16;
            this.lbNetCards.Location = new System.Drawing.Point(0, 0);
            this.lbNetCards.Margin = new System.Windows.Forms.Padding(4);
            this.lbNetCards.Name = "lbNetCards";
            this.lbNetCards.Size = new System.Drawing.Size(222, 526);
            this.lbNetCards.TabIndex = 1;
            this.lbNetCards.SelectedIndexChanged += new System.EventHandler(this.lbNetCards_SelectedIndexChanged);
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
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
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
            this.splitContainer1.Size = new System.Drawing.Size(779, 528);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdateCfg);
            this.panel1.Controls.Add(this.lbTips);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 471);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 55);
            this.panel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(783, 532);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP配置工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.ListBox lbNetCards;
        private System.Windows.Forms.Button btnUpdateCfg;
        private System.Windows.Forms.Label lbTips;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
    }
}

