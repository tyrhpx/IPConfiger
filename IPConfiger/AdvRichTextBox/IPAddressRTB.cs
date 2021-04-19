using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;

namespace IPConfiger
{
    /// <summary>
    /// IP地址富文本框
    /// </summary>
    public partial class IPAddressRTB : RichTextBox
    {
        /// <summary>
        /// 适配器
        /// </summary>
        public NetworkAdapter Adapter { get; set; }

        public IPAddressRTB()
        {
            InitializeComponent();
            InitRTB();
        }

        public IPAddressRTB(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            InitRTB();
        }

        /// <summary>
        /// 初始化文本框
        /// </summary>
        protected void InitRTB()
        {
            tsmiAddrList.DropDownItemClicked += cmsRTB_ItemClicked; /* 二级菜单响应 */
        }

        /// <summary>
        /// 重载窗口处理过程
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            //WM_MOUSEWHEEL
            if (m.Msg == 0x020A)
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return; // 禁止使用CTRL + 滚轮 缩放
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsRTB_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var tsmi = e.ClickedItem;
            if (tsmi != null)
            {
                this.Select();//先获取焦点，防止点两下才运行
                switch (tsmi.Name)
                {
                    case "tsmiUndo":
                        this.Undo();
                        break;
                    case "tsmiRedo":
                        this.Redo();
                        break;
                    case "tsmiCut":
                        this.Cut();
                        break;
                    case "tsmiCopy":
                        this.Copy();
                        break;
                    case "tsmiParse":
                        this.Paste();
                        break;
                    case "tsmiDelete":
                        this.SelectedText = string.Empty;
                        break;
                    case "tsmiSelectAll":
                        this.SelectAll();
                        break;
                    case "tsmiClearAll":
                        this.Clear();
                        break;
                    case "tsmiImport":
                        cmsRTB.Close();
                        this.ImportIPList();
                        break;
                    case "tsmiExport":
                        cmsRTB.Close();
                        this.ExportIPList(this.Text);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 菜单打开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsRTB_Opening(object sender, CancelEventArgs e)
        {
            if (base.CanRedo)//redo重做
            {
                tsmiRedo.Enabled = true;//CopyItem
            }
            else
            {
                tsmiRedo.Enabled = false;
            }
            if (base.CanUndo)//undo
            {
                tsmiUndo.Enabled = true;
            }
            else
            {
                tsmiUndo.Enabled = false;
            }

            if (base.SelectionLength > 0)
            {
                tsmiCopy.Enabled = true;
                tsmiCut.Enabled = true;//剪切
                tsmiDelete.Enabled = true;
            }
            else
            {
                tsmiCopy.Enabled = false;
                tsmiCut.Enabled = false;
                tsmiDelete.Enabled = false;
            }

            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                tsmiParse.Enabled = true;
            }
            else
            {
                tsmiParse.Enabled = false;
            }

            if (base.Text.Length > 0)
            {
                tsmiSelectAll.Enabled = true;
                tsmiClearAll.Enabled = true;
            }
            else
            {
                tsmiSelectAll.Enabled = false;
                tsmiClearAll.Enabled = false;
            }

            if (base.Text.Length > 0)
            {
                tsmiExport.Enabled = true;
            }
            else
            {
                tsmiExport.Enabled = false;
            }
        }

        /// <summary>
        /// 导入地址列表
        /// </summary>
        private void ImportIPList()
        {
            var fd = new OpenFileDialog();
            fd.Title = "IPConfiger_导入地址列表";
            fd.Filter = "文本地址列表文件(*.txt)|*.txt";
            fd.FileName = "IPConfiger_*";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.Text = File.ReadAllText(fd.FileName);
            }
        }

        /// <summary>
        /// 导出地址列表
        /// </summary>
        private void ExportIPList(string ipList)
        {
            var fd = new SaveFileDialog();
            fd.Title = "IPConfiger_导出地址列表";
            fd.Filter = "文本文件(*.txt)|*.txt";
            if (Adapter != null)
            {
                fd.FileName = string.Format("IPConfiger_{0}", Adapter.Name);
            }
            else
            {
                fd.FileName = string.Format("IPConfiger_");
            }
            if (fd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(fd.FileName, ipList);
            }
        }
    }
}
