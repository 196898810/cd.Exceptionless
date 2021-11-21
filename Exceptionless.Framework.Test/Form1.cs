using cd.Exceptionless;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exceptionless.Framework.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("报错啦");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "报错啦", "系统错误");
            int a = 10;
            int b = 0;
            int c = a / b;
            
        }
    }
}
