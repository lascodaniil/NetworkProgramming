using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClientSMTP
{
    public partial class SendForm : Form
    {

        private string email_sender, password_sender;
        MailMessage _mailMessage = new MailMessage();
        SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com",587);

        public SendForm(string emailaddress,string password)
        {
            
            email_sender = emailaddress;
            password_sender = password;

            InitializeComponent();
        }

        

        private void sendBtn_Click(object sender, EventArgs e)
        {
            try{
                try
                {
                    _mailMessage.From = new MailAddress(email_sender);
                    _mailMessage.To.Add(new MailAddress(textBox1.Text));
                    _mailMessage.Subject = textBox2.Text;
                    _mailMessage.IsBodyHtml = true;
                    _mailMessage.Body = textBox3.Text;
                    _smtpClient.EnableSsl = true;
                    _smtpClient.Credentials = new NetworkCredential(email_sender, password_sender);
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtpClient.Send(_mailMessage);
                }
                catch
                {
                    var tab = MessageBox.Show("Eroare, inserati datele corect");
                    this.Close();
                    this.Hide();
                    new Form1().Show();
                }
               
            }
            catch
            {
                var tab = MessageBox.Show("Eroare, inserati datele corect");
                this.Close();
                this.Hide();
                new SendForm(textBox1.Text,textBox2.Text).Show();
            }
            this.Hide();
            
                
        }
        private void attachBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName.ToString();
            pathFileBox.Text = path;
            Attachment attachment = new Attachment(path);
            if (attachment != null)
            {
                _mailMessage.Attachments.Add(attachment);
            }
        }
    }
}
