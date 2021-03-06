﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDORM.Tools
{
    public partial class frmMain : Form
    {
        private int DBType = 0;

        private Dictionary<int, string> DBDefaultConStr = new Dictionary<int, string>();

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(int DBType)
        {
            InitializeComponent();
            this.DBType = DBType;
            InitDBType(DBType);
        }

        private void InitDBType(int DBType)
        {
            DBDefaultConStr.Add(0, "Server = ;Database = ;User ID = ;Password = ;Trusted_Connection = False;Pooling=true;Connection Lifetime=0;Min Pool Size = 1;Max Pool Size=40000");
            DBDefaultConStr.Add(1, "Server = ;Database = ;User ID = ;Password = ;Port = ;");
            DBDefaultConStr.Add(2, "Server = ;Database = ;User ID = ;Password = ;Trusted_Connection = False;");
            DBDefaultConStr.Add(3, "Server = ;Database = ;User ID = ;Password = ;Trusted_Connection = False;");
            DBDefaultConStr.Add(4, "Server = ;Database = ;User ID = ;Password = ;Trusted_Connection = False;");
            string tempConStr = string.Empty;
            if (DBDefaultConStr.TryGetValue(DBType, out tempConStr))
            {
                txtMingWen.Text = tempConStr;
            }
        }

        private void btnJiami_Click(object sender, EventArgs e)
        {
            if (txtMingWen.Text.Length <= 0)
            {
                MessageBox.Show("请输入要加密的字符串", "提示");
                txtMingWen.Focus();
                return;
            }
            else
            {
                string tempMingWen = txtMingWen.Text.Trim();
                string tempResult = MDORM.DapperExt.Utility.DESEncrypt.Encrypt(tempMingWen);
                txtMiWeng.Text = tempResult;
                Clipboard.SetDataObject(tempResult);
                MessageBox.Show("字符串加密成功并复制到系统剪切板", "提示");
            }
        }

        private void btnJiemi_Click(object sender, EventArgs e)
        {
            if (txtMiWeng.Text.Length <= 0)
            {
                MessageBox.Show("请输入要解密字符串", "提示");
                txtMiWeng.Focus();
                return;
            }
            else
            {
                string tempMiWeng = txtMiWeng.Text.Trim();
                string tempResult = MDORM.DapperExt.Utility.DESEncrypt.Decrypt(tempMiWeng);
                txtMingWen.Text = tempResult;
                MessageBox.Show("字符串解密成功", "提示");
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
