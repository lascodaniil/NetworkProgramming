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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                MessageBox.Show("DATE INCOMPLETE");
                new Form1(); 
            }
            else
            {
                new SendForm(textBox1.Text, textBox2.Text).Show();
                this.Hide();
            }
                
        }
    }
}
