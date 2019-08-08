using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;

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

        private void UpdateAllAdapters()
        {
            var adapters = NetworkAdapterUtil.GetAllNetworkAdapters();

            lbNetCards.Items.Clear();
            foreach (var x in adapters)
            {
                lbNetCards.Items.Add(x);
            }
        }

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
            }
        }

        private void btnUpdateCfg_Click(object sender, EventArgs e)
        {
            var adapter = lbNetCards.SelectedItem as NetworkAdapter;
            if (adapter != null)
            {
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
                            MessageBox.Show(s, "配置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        string s = string.Format("抱歉，第{0}行有误，正确格式为：IP#SubMask！", i + 1);
                        MessageBox.Show(s, "配置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                if (MessageBox.Show("确认要更新网卡【" + adapter.Name + "】的IP配置吗？",
                            "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    string errStr = "";
                    bool ret = adapter.SetIPAddress(ip.ToArray(), mask.ToArray(), null, null, ref errStr);
                    if (ret)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        adapter.ReloadData();
                        this.Cursor = Cursors.Default;

                        MessageBox.Show("很棒，更新成功^_^\n返回信息：" + errStr, "配置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbNetCards_SelectedIndexChanged(null, null); //触发事件更新编辑框内容
                   }
                    else
                    {
                        MessageBox.Show("抱歉，更新失败- -!\n返回信息：" + errStr, "配置", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
