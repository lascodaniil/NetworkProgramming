namespace EmailClientSMTP
{
    partial class RetriveMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.TextBoxPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TitleListView = new System.Windows.Forms.ListView();
            this.email_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.email_BTN = new System.Windows.Forms.Button();
            this.INFOEMAIL = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailbody = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Location = new System.Drawing.Point(40, 48);
            this.TextBoxEmail.Multiline = true;
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(206, 20);
            this.TextBoxEmail.TabIndex = 0;
            // 
            // TextBoxPass
            // 
            this.TextBoxPass.Location = new System.Drawing.Point(40, 104);
            this.TextBoxPass.Multiline = true;
            this.TextBoxPass.Name = "TextBoxPass";
            this.TextBoxPass.PasswordChar = '*';
            this.TextBoxPass.Size = new System.Drawing.Size(206, 20);
            this.TextBoxPass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "EMAIL (Only Gmail clients)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PASSWORD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "LOG IN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // TitleListView
            // 
            this.TitleListView.BackColor = System.Drawing.SystemColors.Menu;
            this.TitleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.email_title});
            this.TitleListView.FullRowSelect = true;
            this.TitleListView.GridLines = true;
            this.TitleListView.HideSelection = false;
            this.TitleListView.HoverSelection = true;
            this.TitleListView.Location = new System.Drawing.Point(281, 48);
            this.TitleListView.MultiSelect = false;
            this.TitleListView.Name = "TitleListView";
            this.TitleListView.Size = new System.Drawing.Size(320, 317);
            this.TitleListView.TabIndex = 6;
            this.TitleListView.TabStop = false;
            this.TitleListView.UseCompatibleStateImageBehavior = false;
            this.TitleListView.View = System.Windows.Forms.View.Details;
            // 
            // email_title
            // 
            this.email_title.Text = "TITLE";
            this.email_title.Width = 269;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "INBOX MAIL";
            // 
            // email_BTN
            // 
            this.email_BTN.Location = new System.Drawing.Point(281, 385);
            this.email_BTN.Name = "email_BTN";
            this.email_BTN.Size = new System.Drawing.Size(75, 23);
            this.email_BTN.TabIndex = 8;
            this.email_BTN.Text = "Show Email";
            this.email_BTN.UseVisualStyleBackColor = true;
            this.email_BTN.Click += new System.EventHandler(this.email_BTN_Click);
            // 
            // INFOEMAIL
            // 
            this.INFOEMAIL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.INFOEMAIL.HideSelection = false;
            this.INFOEMAIL.Location = new System.Drawing.Point(620, 48);
            this.INFOEMAIL.Name = "INFOEMAIL";
            this.INFOEMAIL.Size = new System.Drawing.Size(523, 88);
            this.INFOEMAIL.TabIndex = 9;
            this.INFOEMAIL.UseCompatibleStateImageBehavior = false;
            this.INFOEMAIL.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FROM";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TITLE";
            this.columnHeader2.Width = 138;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TIME";
            this.columnHeader3.Width = 66;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ATTACH";
            this.columnHeader4.Width = 90;
            // 
            // emailbody
            // 
            this.emailbody.Location = new System.Drawing.Point(620, 142);
            this.emailbody.Multiline = true;
            this.emailbody.Name = "emailbody";
            this.emailbody.Size = new System.Drawing.Size(523, 223);
            this.emailbody.TabIndex = 10;
            // 
            // RetriveMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 450);
            this.Controls.Add(this.emailbody);
            this.Controls.Add(this.INFOEMAIL);
            this.Controls.Add(this.email_BTN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TitleListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPass);
            this.Controls.Add(this.TextBoxEmail);
            this.Name = "RetriveMail";
            this.Text = "RetriveMail";
            this.Load += new System.EventHandler(this.RetriveMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.TextBox TextBoxPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView TitleListView;
        private System.Windows.Forms.ColumnHeader email_title;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button email_BTN;
        private System.Windows.Forms.ListView INFOEMAIL;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox emailbody;
    }
}