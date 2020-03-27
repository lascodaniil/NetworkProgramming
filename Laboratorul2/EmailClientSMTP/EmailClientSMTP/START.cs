using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClientSMTP
{
    public partial class START : Form
    {
        public START()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RetriveMail().Show();
        }
    }
}
