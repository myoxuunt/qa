using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void DefWndProc(ref Message m)
        {
            this.Text = m.Msg.ToString();

            base.DefWndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
