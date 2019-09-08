namespace MediaProject
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbError = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPaswd = new System.Windows.Forms.TextBox();
            this.lblError2 = new System.Windows.Forms.Label();
            this.txtRegisterLogin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegisterRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRegisterPswd = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(329, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(321, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LOGIN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel1.Controls.Add(this.lbError);
            this.splitContainer1.Panel1.Controls.Add(this.txtLogin);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnRegister);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnLogin);
            this.splitContainer1.Panel1.Controls.Add(this.txtPaswd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel2.Controls.Add(this.lblError2);
            this.splitContainer1.Panel2.Controls.Add(this.txtRegisterLogin);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.btnRegisterRegister);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtRegisterPswd);
            this.splitContainer1.Size = new System.Drawing.Size(309, 387);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.TabIndex = 2;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(16, 91);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 4;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(16, 25);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(278, 20);
            this.txtLogin.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "PASSWORD";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(166, 108);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "LOGIN";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(37, 108);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPaswd
            // 
            this.txtPaswd.Location = new System.Drawing.Point(16, 64);
            this.txtPaswd.Name = "txtPaswd";
            this.txtPaswd.Size = new System.Drawing.Size(278, 20);
            this.txtPaswd.TabIndex = 0;
            // 
            // lblError2
            // 
            this.lblError2.AutoSize = true;
            this.lblError2.ForeColor = System.Drawing.Color.Red;
            this.lblError2.Location = new System.Drawing.Point(16, 113);
            this.lblError2.Name = "lblError2";
            this.lblError2.Size = new System.Drawing.Size(0, 13);
            this.lblError2.TabIndex = 3;
            // 
            // txtRegisterLogin
            // 
            this.txtRegisterLogin.Location = new System.Drawing.Point(16, 47);
            this.txtRegisterLogin.Name = "txtRegisterLogin";
            this.txtRegisterLogin.Size = new System.Drawing.Size(278, 20);
            this.txtRegisterLogin.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "PASSWORD";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(16, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "LOGIN";
            // 
            // btnRegisterRegister
            // 
            this.btnRegisterRegister.Location = new System.Drawing.Point(111, 193);
            this.btnRegisterRegister.Name = "btnRegisterRegister";
            this.btnRegisterRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegisterRegister.TabIndex = 2;
            this.btnRegisterRegister.Text = "Register";
            this.btnRegisterRegister.UseVisualStyleBackColor = true;
            this.btnRegisterRegister.Click += new System.EventHandler(this.btnRegisterRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // txtRegisterPswd
            // 
            this.txtRegisterPswd.Location = new System.Drawing.Point(16, 86);
            this.txtRegisterPswd.Name = "txtRegisterPswd";
            this.txtRegisterPswd.Size = new System.Drawing.Size(278, 20);
            this.txtRegisterPswd.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRegisterPswd;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPaswd;
        private System.Windows.Forms.TextBox txtRegisterLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegisterRegister;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label lblError2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

