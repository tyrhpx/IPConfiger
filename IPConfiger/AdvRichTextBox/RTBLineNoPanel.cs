using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPConfiger
{
    /// <summary>
    /// RichTextBox的行号显示控件
    /// </summary>
    public partial class RTBLineNoPanel : UserControl
    {
        /// <summary>
        /// 富文本框控件
        /// </summary>
        public RichTextBox RTB { get; set; }

        /// <summary>
        /// 选中行颜色 
        /// </summary>
        public Color SelectColor { get; set; }

        public RTBLineNoPanel()
        {
            InitializeComponent();

            //启用双缓冲
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RTBLineNoPanel_Load(object sender, EventArgs e)
        {
            // 添加RichTextBox事件处理
            if (this.RTB != null)
            {
                this.RTB.TextChanged += (a, b) => { UpdateLineNo(); };
                this.RTB.VScroll += (a, b) => { UpdateLineNo(); };
                this.RTB.SelectionChanged += (a, b) => { UpdateLineNo(); };
            }
        }

        /// <summary>
        /// 绘图事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineNoPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.RTB != null)
            {
                ShowLineNo(this.RTB, e.Graphics);
            }
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        private void ShowLineNo(RichTextBox richTB, Graphics g)
        {
            //获得当前坐标信息
            var p = richTB.Location;
            var crntFirstIndex = richTB.GetCharIndexFromPosition(p);
            var crntFirstLine = richTB.GetLineFromCharIndex(crntFirstIndex);
            var crntFirstPos = richTB.GetPositionFromCharIndex(crntFirstIndex);
            var crntCurrentLine = richTB.GetLineFromCharIndex(richTB.GetFirstCharIndexOfCurrentLine());

            p.Y += richTB.Height;

            var crntLastIndex = richTB.GetCharIndexFromPosition(p);
            var crntLastLine = richTB.GetLineFromCharIndex(crntLastIndex);
            var crntLastPos = richTB.GetPositionFromCharIndex(crntLastIndex);

            //准备画图
            var font = new Font(richTB.Font, richTB.Font.Style);
            var brush = new SolidBrush(this.BackColor);

            //刷新画布
            var rect = this.ClientRectangle;
            brush.Color = this.BackColor;
            g.FillRectangle(brush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);

            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                lineSpace = Convert.ToInt32(richTB.Font.Size);
            }

            var brushX = this.ClientRectangle.Width - Convert.ToInt32(font.Size * 3);
            var brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);//惊人的算法啊！！
            for (var i = crntLastLine; i >= crntFirstLine; i--)
            {
                if (i == crntCurrentLine) //当前光标所在行
                {
                    brush.Color = this.SelectColor;//重置画笔颜色
                    g.DrawString((i + 1).ToString("D3"), font, brush, brushX, brushY);
                }
                else
                {
                    brush.Color = this.ForeColor;//重置画笔颜色
                    g.DrawString((i + 1).ToString("D3"), font, brush, brushX, brushY);
                }
                brushY -= lineSpace;
            }

            font.Dispose();
            brush.Dispose();
        }

        /// <summary>
        /// 更新行号
        /// </summary>
        public void UpdateLineNo()
        {
            this.Invalidate(this.ClientRectangle);
        }
    }
}
