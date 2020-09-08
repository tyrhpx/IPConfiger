using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;

namespace IPConfiger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateAllAdapters();
        }

        /// <summary>
        /// 更新所有适配器
        /// </summary>
        private void UpdateAllAdapters()
        {
            SetWorkingStatus(true);
            var adapters = NetworkAdapter.GetAllNetworkAdapters();

            lbNetCards.Items.Clear();
            foreach (var x in adapters)
            {
                lbNetCards.Items.Add(x);
            }
            SetWorkingStatus(false);
        }

        /// <summary>
        /// 更新指定适配器
        /// </summary>
        /// <param name="adapter">适配器对象</param>
        private void UpdateAdapter(NetworkAdapter adapter)
        {
            if (adapter != null)
            {
                SetWorkingStatus(true);
                adapter.Reload();
                SetWorkingStatus(false);
            }
        }

        /// <summary>
        /// 列表框选项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNetCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            var adapter = lbNetCards.SelectedItem as NetworkAdapter;
            if (adapter != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < adapter.IPAddrs.Count; i++)
                {
                    var ip = adapter.IPAddrs[i];
                    if (ip.Address.AddressFamily.ToString() == "InterNetwork")
                    {//IPV4
                        sb.AppendFormat("{0}#{1}\r\n", ip.Address.ToString(), ip.IPv4Mask.ToString());
                    }
                }
                lbTips.Text = adapter.Desc;
                tbText.Text = sb.ToString();

                tbText.Enabled = !adapter.DhcpEnabled;
                btnUpdateCfg.Enabled = !adapter.DhcpEnabled;
            }
        }

        /// <summary>
        /// 应用配置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateCfg_Click(object sender, EventArgs e)
        {
            var adapter = lbNetCards.SelectedItem as NetworkAdapter;
            if (adapter != null)
            {
                if (adapter.DhcpEnabled)
                {
                    string s = string.Format("抱歉，网卡处于DHCP模式下不支持修改IP！");
                    MessageBox.Show(s, "IPConfiger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ip = new List<string>();
                var mask = new List<string>();
                for (int i = 0; i < tbText.Lines.Length; i++)
                {
                    string lineStr = tbText.Lines[i].Trim();
                    if (string.IsNullOrEmpty(lineStr))
                    {
                        continue;
                    }
                    string[] sa = lineStr.Split('#');
                    if (sa.Length == 2)
                    {
                        if (IsIPAddressValid(sa[0]) && IsIPAddressValid(sa[1]))
                        {
                            ip.Add(sa[0]);
                            mask.Add(sa[1]);
                        }
                        else
                        {
                            string s = string.Format("抱歉，第{0}行有误，请检查IP或子网掩码！", i + 1);
                            MessageBox.Show(s, "IPConfiger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        string s = string.Format("抱歉，第{0}行有误，正确格式为：IP#SubMask！", i + 1);
                        MessageBox.Show(s, "IPConfiger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (ip.Count == 0 || mask.Count == 0)
                {
                    string s = string.Format("抱歉，IP不能为空，必须保留至少一个IP#SubMask！");
                    MessageBox.Show(s, "IPConfiger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (MessageBox.Show("确认要更新网卡【" + adapter.Name + "】的IP配置吗？",
                            "IPConfiger", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    string errStr = "";
                    bool ret = adapter.SetIPAddress(ip.ToArray(), mask.ToArray(), null, null, ref errStr);
                    if (ret)
                    {
                        UpdateAdapter(adapter);
                        lbNetCards_SelectedIndexChanged(null, null); //触发事件更新编辑框内容

                        MessageBox.Show("很棒，更新成功^_^\n返回信息：" + errStr, "IPConfiger", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("抱歉，更新失败- -!\n返回信息：" + errStr, "IPConfiger", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }
            }
        }

        /// <summary>
        /// 判断IP地址是否有效
        /// </summary>
        /// <param name="ipStr"></param>
        /// <returns>true-有效，false-无效</returns>
        private bool IsIPAddressValid(string ipStr)
        {
            IPAddress ip;
            return IPAddress.TryParse(ipStr, out ip);
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("名称：IPConfiger - IP配置工具");
            sb.AppendLine();
            sb.AppendLine("版本：V" + Application.ProductVersion);
            sb.AppendLine();
            sb.AppendLine("作者：TyrhpXs");
            sb.AppendLine();
            sb.AppendLine("描述：Windows下的IP配置工具，能够批量配置IP和子网掩码。");
            sb.AppendLine();
            sb.AppendLine("说明：不支持禁用和自动获取IP的网卡。");
            this.tbText.Text = sb.ToString();
        }

        /// <summary>
        /// 重载绘制项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNetCards_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            var item = lbNetCards.Items[e.Index];
            Color foreColor = Color.Black;
            Color backColor = Color.White;

            var adapter = item as NetworkAdapter;
            if (adapter != null)
            {
                if (adapter.DhcpEnabled)
                {
                    foreColor = Color.Black;
                    backColor = Color.LightCyan;
                }
                else
                {
                    foreColor = Color.Blue;
                }
            }

            // 颜色设置
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = Color.FromArgb(192, 255, 192);
            }

            // 绘制背景及焦点框
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            e.DrawFocusRectangle();

            // 绘制文本
            var format = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.NoClip)
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(string.Format("[{0:D2}]{1}", e.Index + 1, item), e.Font, new SolidBrush(foreColor), e.Bounds, format);
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            UpdateAllAdapters();
        }

        /// <summary>
        /// 设置工作状态
        /// </summary>
        /// <param name="isDoing"></param>
        private void SetWorkingStatus(bool isDoing)
        {
            var ver = new Version(Application.ProductVersion);
            var s = string.Format("IP配置工具 V{0}.{1}", ver.Major, ver.Minor);
            if (isDoing)
            {
                s += "  —— 执行中，请稍候...";
            }
            this.lbFrmTitle.Text = s;
        }

        /// <summary>
        /// 网络连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiNetConnection_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ncpa.cpl");
        }

        #region 重写窗口过程处理
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;
        const int BOARDER_THIN = 10;

        private const int WM_NCPAINT = 0x0085;
        private const int WM_NCACTIVATE = 0x0086;
        private const int WM_NCLBUTTONDOWN = 0x00A1;

        /// <summary>
        /// 重写窗口过程处理
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = Control.MousePosition;
                    vPoint = PointToClient(vPoint);

                    if (vPoint.X <= BOARDER_THIN)
                    {
                        if (vPoint.Y <= BOARDER_THIN)
                        {
                            m.Result = (IntPtr)HTTOPLEFT;
                        }
                        else if (vPoint.Y >= ClientSize.Height - BOARDER_THIN)
                        {
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        }
                        else
                        {
                            m.Result = (IntPtr)HTLEFT;
                        }
                    }
                    else if (vPoint.X >= ClientSize.Width - BOARDER_THIN)
                    {
                        if (vPoint.Y <= BOARDER_THIN)
                        {
                            m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (vPoint.Y >= ClientSize.Height - BOARDER_THIN)
                        {
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                        else
                        {
                            m.Result = (IntPtr)HTRIGHT;
                        }
                    }
                    else if (vPoint.Y <= BOARDER_THIN)
                    {
                        m.Result = (IntPtr)HTTOP;
                    }
                    else if (vPoint.Y >= ClientSize.Height - BOARDER_THIN)
                    {
                        m.Result = (IntPtr)HTBOTTOM;
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        #region 无边框拖动效果
        [DllImport("user32.dll")]//拖动无窗体的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Start_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                //拖动窗体
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }
        #endregion

        #region 标题栏按钮处理
        private void pbFrmMenu_Click(object sender, EventArgs e)
        {
            var pos = PointToScreen(new Point(pbFrmMenu.Left + 2, pbFrmMenu.Bottom + 2));
            cmsNetCard.Show(pos);
        }

        private void pbFrmMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbFrmMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.pbFrmMax.Image = Properties.Resources.最大化;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximumSize = Screen.FromHandle(this.Handle).WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
                this.pbFrmMax.Image = Properties.Resources.恢复;
            }
        }

        private void pbFrmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbFrmClose_MouseLeave(object sender, EventArgs e)
        {
            this.pbFrmClose.BackColor = this.tlPanelTitle.BackColor;
        }

        private void pbFrmClose_MouseEnter(object sender, EventArgs e)
        {
            this.pbFrmClose.BackColor = Color.OrangeRed;
        }

        private void pbFrmMin_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as PictureBox;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(192, 255, 192);//SystemColors.ButtonFace;
            }
        }

        private void pbFrmMin_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as PictureBox;
            if (btn != null)
            {
                btn.BackColor = this.tlPanelTitle.BackColor;
            }
        }

        /// <summary>
        /// 标题栏双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFrmTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pbFrmMax_Click(null, null);
            }
        }
        #endregion

        /// <summary>
        /// 窗口大小改变时重新设置最大化图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.pbFrmMax.Image = Properties.Resources.恢复;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.pbFrmMax.Image = Properties.Resources.最大化;
            }
        }
    }
}
