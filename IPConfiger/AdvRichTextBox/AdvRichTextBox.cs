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
    public partial class AdvRichTextBox : UserControl
    {
        /// <summary>
        /// 多行属性
        /// </summary>
        public bool Multiline
        {
            get
            {
                return richTB.Multiline;
            }
            set 
            { 
                richTB.Multiline = value; 
            }
        }

        /// <summary>
        /// 行内容属性
        /// </summary>
        public string[] Lines
        {
            get
            {
                return richTB.Lines;
            }
            set
            {
                richTB.Lines = value;
            }
        }

        /// <summary>
        /// 滚动条属性
        /// </summary>
        public RichTextBoxScrollBars ScrollBars
        {
            get
            {
                return richTB.ScrollBars;
            }
            set
            {
                richTB.ScrollBars = value;
            }
        }

        /// <summary>
        /// 文本属性
        /// </summary>
        public override string Text
        {
            get
            {
                return richTB.Text;
            }
            set
            {
                richTB.Text = value;
                richTB.ScrollToCaret();
            }
        }

        /// <summary>
        /// 文本只读属性
        /// </summary>
        public bool Readonly
        {
            get 
            { 
                return richTB.ReadOnly; 
            }
            set 
            { 
                richTB.ReadOnly = value; 
            }
        }

        /// <summary>
        /// 行号前景色
        /// </summary>
        public Color LineNoForeColor
        {
            get
            {
                return panelLeft.ForeColor;
            }
            set
            {
                panelLeft.ForeColor = value;
            }
        }

        /// <summary>
        /// 行号背景色
        /// </summary>
        public Color LineNoBackColor
        {
            get
            {
                return panelLeft.BackColor;
            }
            set
            {
                panelLeft.BackColor = value;
            }
        }

        /// <summary>
        /// 适配器
        /// </summary>
        public NetworkAdapter Adapter
        {
            get
            {
                return richTB.Adapter;
            }
            set
            {
                richTB.Adapter = value;
            }
        }

        public AdvRichTextBox()
        {
            InitializeComponent();
        }
    }
}
