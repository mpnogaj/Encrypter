namespace Encrypter
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.save = new System.Windows.Forms.Button();
            this.pick = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.decrypt = new System.Windows.Forms.RadioButton();
            this.encrypt = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.outputString = new System.Windows.Forms.TextBox();
            this.inputString = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.doString = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.decryptString = new System.Windows.Forms.RadioButton();
            this.passwordStringBox = new System.Windows.Forms.TextBox();
            this.encryptString = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.pick);
            this.groupBox1.Controls.Add(this.outputBox);
            this.groupBox1.Controls.Add(this.inputBox);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Encryption and Decryption";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(391, 74);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // pick
            // 
            this.pick.Location = new System.Drawing.Point(391, 28);
            this.pick.Name = "pick";
            this.pick.Size = new System.Drawing.Size(75, 23);
            this.pick.TabIndex = 3;
            this.pick.Text = "Browse";
            this.pick.UseVisualStyleBackColor = true;
            this.pick.Click += new System.EventHandler(this.Pick_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(6, 67);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.outputBox.Size = new System.Drawing.Size(380, 41);
            this.outputBox.TabIndex = 2;
            this.outputBox.WordWrap = false;
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(6, 20);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.ReadOnly = true;
            this.inputBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.inputBox.Size = new System.Drawing.Size(380, 41);
            this.inputBox.TabIndex = 1;
            this.inputBox.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.passwordBox);
            this.groupBox2.Controls.Add(this.decrypt);
            this.groupBox2.Controls.Add(this.encrypt);
            this.groupBox2.Location = new System.Drawing.Point(6, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 48);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Work";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password:";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(250, 18);
            this.passwordBox.MaxLength = 2132;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(129, 20);
            this.passwordBox.TabIndex = 2;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // decrypt
            // 
            this.decrypt.AutoSize = true;
            this.decrypt.Location = new System.Drawing.Point(98, 19);
            this.decrypt.Name = "decrypt";
            this.decrypt.Size = new System.Drawing.Size(62, 17);
            this.decrypt.TabIndex = 1;
            this.decrypt.TabStop = true;
            this.decrypt.Text = "Decrypt";
            this.decrypt.UseVisualStyleBackColor = true;
            // 
            // encrypt
            // 
            this.encrypt.AutoSize = true;
            this.encrypt.Location = new System.Drawing.Point(6, 19);
            this.encrypt.Name = "encrypt";
            this.encrypt.Size = new System.Drawing.Size(61, 17);
            this.encrypt.TabIndex = 0;
            this.encrypt.TabStop = true;
            this.encrypt.Text = "Encrypt";
            this.encrypt.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 209);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(482, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(482, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Message";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.outputString);
            this.groupBox3.Controls.Add(this.inputString);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(5, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 174);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Text Encryption and Decryption";
            // 
            // outputString
            // 
            this.outputString.Location = new System.Drawing.Point(310, 19);
            this.outputString.Multiline = true;
            this.outputString.Name = "outputString";
            this.outputString.ReadOnly = true;
            this.outputString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputString.Size = new System.Drawing.Size(156, 149);
            this.outputString.TabIndex = 2;
            this.outputString.WordWrap = false;
            // 
            // inputString
            // 
            this.inputString.Location = new System.Drawing.Point(6, 19);
            this.inputString.Multiline = true;
            this.inputString.Name = "inputString";
            this.inputString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.inputString.Size = new System.Drawing.Size(156, 149);
            this.inputString.TabIndex = 1;
            this.inputString.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.doString);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.decryptString);
            this.groupBox4.Controls.Add(this.passwordStringBox);
            this.groupBox4.Controls.Add(this.encryptString);
            this.groupBox4.Location = new System.Drawing.Point(165, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 149);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Options";
            // 
            // doString
            // 
            this.doString.Location = new System.Drawing.Point(6, 104);
            this.doString.Name = "doString";
            this.doString.Size = new System.Drawing.Size(75, 23);
            this.doString.TabIndex = 4;
            this.doString.Text = "Work";
            this.doString.UseVisualStyleBackColor = true;
            this.doString.Click += new System.EventHandler(this.DoString_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // decryptString
            // 
            this.decryptString.AutoSize = true;
            this.decryptString.Location = new System.Drawing.Point(6, 42);
            this.decryptString.Name = "decryptString";
            this.decryptString.Size = new System.Drawing.Size(62, 17);
            this.decryptString.TabIndex = 1;
            this.decryptString.TabStop = true;
            this.decryptString.Text = "Decrypt";
            this.decryptString.UseVisualStyleBackColor = true;
            // 
            // passwordStringBox
            // 
            this.passwordStringBox.Location = new System.Drawing.Point(6, 80);
            this.passwordStringBox.MaxLength = 2137;
            this.passwordStringBox.Name = "passwordStringBox";
            this.passwordStringBox.Size = new System.Drawing.Size(129, 20);
            this.passwordStringBox.TabIndex = 2;
            this.passwordStringBox.UseSystemPasswordChar = true;
            // 
            // encryptString
            // 
            this.encryptString.AutoSize = true;
            this.encryptString.Location = new System.Drawing.Point(6, 19);
            this.encryptString.Name = "encryptString";
            this.encryptString.Size = new System.Drawing.Size(61, 17);
            this.encryptString.TabIndex = 0;
            this.encryptString.TabStop = true;
            this.encryptString.Text = "Encrypt";
            this.encryptString.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 224);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Encrypter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.RadioButton decrypt;
        private System.Windows.Forms.RadioButton encrypt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button pick;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox outputString;
        private System.Windows.Forms.TextBox inputString;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button doString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton decryptString;
        private System.Windows.Forms.TextBox passwordStringBox;
        private System.Windows.Forms.RadioButton encryptString;
    }
}

