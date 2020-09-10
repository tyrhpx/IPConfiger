namespace IPConfiger
{
    partial class AdvRichTextBox
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
            this.richTB = new IPConfiger.IPAddressRTB(this.components);
            this.panelLeft = new IPConfiger.RTBLineNoPanel();
            this.SuspendLayout();
            // 
            // richTB
            // 
            this.richTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTB.DetectUrls = false;
            this.richTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTB.Font = new System.Drawing.Font("宋体", 12F);
            this.richTB.Location = new System.Drawing.Point(30, 0);
            this.richTB.Name = "richTB";
            this.richTB.ShowSelectionMargin = true;
            this.richTB.Size = new System.Drawing.Size(639, 401);
            this.richTB.TabIndex = 0;
            this.richTB.Text = "";
            this.richTB.WordWrap = false;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Gainsboro;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.ForeColor = System.Drawing.Color.Blue;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.RTB = this.richTB;
            this.panelLeft.SelectColor = System.Drawing.Color.Magenta;
            this.panelLeft.Size = new System.Drawing.Size(30, 401);
            this.panelLeft.TabIndex = 1;
            // 
            // AdvRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTB);
            this.Controls.Add(this.panelLeft);
            this.Name = "AdvRichTextBox";
            this.Size = new System.Drawing.Size(669, 401);
            this.ResumeLayout(false);

        }

        #endregion

        private IPConfiger.IPAddressRTB richTB;
        private IPConfiger.RTBLineNoPanel panelLeft;
    }
}
