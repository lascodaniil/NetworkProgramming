namespace EmailClientSMTP
{
    partial class SendForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.pathFileBox = new System.Windows.Forms.TextBox();
            this.attachBtn = new System.Windows.Forms.Button();
            this.btnsendemail = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.titletexbox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(510, 20);
            this.textBox1.TabIndex = 0;
//            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(26, 94);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(510, 22);
            this.textBox2.TabIndex = 1;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(257, 415);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 23);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "SEND";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // pathFileBox
            // 
            this.pathFileBox.Location = new System.Drawing.Point(26, 358);
            this.pathFileBox.Name = "pathFileBox";
            this.pathFileBox.Size = new System.Drawing.Size(412, 20);
            this.pathFileBox.TabIndex = 3;
            // 
            // attachBtn
            // 
            this.attachBtn.Location = new System.Drawing.Point(444, 355);
            this.attachBtn.Name = "attachBtn";
            this.attachBtn.Size = new System.Drawing.Size(92, 23);
            this.attachBtn.TabIndex = 4;
            this.attachBtn.Text = "Attach ...";
            this.attachBtn.UseVisualStyleBackColor = true;
            this.attachBtn.Click += new System.EventHandler(this.attachBtn_Click);
            // 
            // btnsendemail
            // 
            this.btnsendemail.AutoSize = true;
            this.btnsendemail.Location = new System.Drawing.Point(26, 32);
            this.btnsendemail.Name = "btnsendemail";
            this.btnsendemail.Size = new System.Drawing.Size(58, 13);
            this.btnsendemail.TabIndex = 5;
            this.btnsendemail.Text = "SEND TO ";
            // 
            // body
            // 
            this.body.AutoSize = true;
            this.body.Location = new System.Drawing.Point(23, 134);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(37, 13);
            this.body.TabIndex = 6;
            this.body.Text = "BODY";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(26, 150);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(510, 202);
            this.textBox3.TabIndex = 7;
            // 
            // titletexbox
            // 
            this.titletexbox.AutoSize = true;
            this.titletexbox.Location = new System.Drawing.Point(26, 78);
            this.titletexbox.Name = "titletexbox";
            this.titletexbox.Size = new System.Drawing.Size(37, 13);
            this.titletexbox.TabIndex = 8;
            this.titletexbox.Text = "TITLE";
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 450);
            this.Controls.Add(this.titletexbox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.body);
            this.Controls.Add(this.btnsendemail);
            this.Controls.Add(this.attachBtn);
            this.Controls.Add(this.pathFileBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "SendForm";
            this.Text = "SendForm";
//            this.Load += new System.EventHandler(this.SendForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox pathFileBox;
        private System.Windows.Forms.Button attachBtn;
        private System.Windows.Forms.Label btnsendemail;
        private System.Windows.Forms.Label body;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label titletexbox;
    }
}