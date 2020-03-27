using Limilabs.Client.IMAP;
using Limilabs.Client.POP3;
using Limilabs.Mail;
using MailKit.Net.Pop3;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClientSMTP
{
    public partial class RetriveMail : Form
    {
        List<MimeMessage> allMessages = null;
        int messageCount = -1;
        Pop3Client _client = null;
        MimeMessage mimeMessage = null;
        public RetriveMail()
        {
            _client = new Pop3Client();
            InitializeComponent();
        }

        private void RetriveMail_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Pop3Client _client = new Pop3Client();
            _client.Connect("pop.gmail.com", 995, SecureSocketOptions.SslOnConnect);

            try
            {
                _client.Authenticate(TextBoxEmail.Text, TextBoxPass.Text);
                messageCount = _client.GetMessageCount();
                 allMessages = new List<MimeMessage>(messageCount);
                for (int i = messageCount; i >= 0; i--)
                {
                    try
                    {
                        allMessages.Add(_client.GetMessage(i));
                        ListViewItem itemlist = new ListViewItem(_client.GetMessage(i).Subject);
                        TitleListView.Items.Add(itemlist);

                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
                MessageBox.Show("CONNECTION ERROR");
                this.Close();
                new RetriveMail().Show();
            }

        }

        private void email_BTN_Click(object sender, EventArgs e)
        {
            string selectedTitle = TitleListView.SelectedItems[0].SubItems[0].Text;
            var attach = false;

            foreach (MimeMessage mimeMessage in allMessages)
            {
                if (mimeMessage.Subject == selectedTitle)
                {
                    if(mimeMessage.Attachments.Count() >0)
                    {
                        attach = true;
                        foreach (var attachment in mimeMessage.Attachments)
                        {
                            
                                var part = (MimePart)attachment;
                                var fileName = @"D:\Universitate\PR\Laborator4\Attachments\" + part.FileName;

                                using (var stream = File.Create(fileName))
                                    part.Content.DecodeTo(stream);
                            
                        }

                    }
                    

                    string[] row = { mimeMessage.From.ToString(), mimeMessage.Subject.ToString(), mimeMessage.Date.ToString("MM/dd/yyyy hh:mm tt"),attach.ToString()};
                    ListViewItem itemlist = new ListViewItem(row);
                    INFOEMAIL.Items.Add(itemlist);
                    try
                    {
                        emailbody.Text = mimeMessage.HtmlBody.ToString();
                    }catch
                    {
                        emailbody.Text = " ";
                    }
                    
                    
                    break;
                }
            }


        }
    }
}

