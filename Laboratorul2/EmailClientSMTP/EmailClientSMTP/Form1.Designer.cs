namespace EmailClientSMTP
{
    partial class Form1
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
            this.EmailTextLabel = new System.Windows.Forms.Label();
            this.PassTextLabel = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(27, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(266, 20);
            this.textBox2.TabIndex = 1;
            // 
            // EmailTextLabel
            // 
            this.EmailTextLabel.AutoSize = true;
            this.EmailTextLabel.Location = new System.Drawing.Point(27, 45);
            this.EmailTextLabel.Name = "EmailTextLabel";
            this.EmailTextLabel.Size = new System.Drawing.Size(39, 13);
            this.EmailTextLabel.TabIndex = 2;
            this.EmailTextLabel.Text = "EMAIL";
            // 
            // PassTextLabel
            // 
            this.PassTextLabel.AutoSize = true;
            this.PassTextLabel.Location = new System.Drawing.Point(27, 91);
            this.PassTextLabel.Name = "PassTextLabel";
            this.PassTextLabel.Size = new System.Drawing.Size(70, 13);
            this.PassTextLabel.TabIndex = 3;
            this.PassTextLabel.Text = "PASSWORD";
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(27, 150);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "LOG IN";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ONLY FOR GMAIL CLIENTS";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 321);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PassTextLabel);
            this.Controls.Add(this.EmailTextLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label EmailTextLabel;
        private System.Windows.Forms.Label PassTextLabel;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label1;
    }
}

