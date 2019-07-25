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
            var adapters = NetworkAdapterUtil.GetAllNetworkAdapters();
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
                    string[] sa = tbText.Lines[i].Split('#');
                    if (sa.Length == 2)
                    {
                        ip.Add(sa[0]);
                        mask.Add(sa[1]);
                    }
                }
                
                if (MessageBox.Show("确认要更新网卡【" + adapter.Name + "】的IP配置吗？",
                            "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    bool ret = adapter.SetIPAddress(ip.ToArray(), mask.ToArray(), null, null);
                    if (ret)
                    {
                        MessageBox.Show("很棒，更新成功^_^", "配置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("抱歉，更新失败- -!", "配置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }  
                }
            }
        }  
    }
}
