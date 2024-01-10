namespace OdooAPI2
{
    partial class frmMain
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
            panel1 = new System.Windows.Forms.Panel();
            btnRun = new System.Windows.Forms.Button();
            pnlAPIparams = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            txtPass = new System.Windows.Forms.TextBox();
            txtUser = new System.Windows.Forms.TextBox();
            txtDB = new System.Windows.Forms.TextBox();
            txtURL = new System.Windows.Forms.TextBox();
            lblpass = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cmbAPIlst = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            rtxtLog = new System.Windows.Forms.RichTextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(btnRun);
            panel1.Controls.Add(pnlAPIparams);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(cmbAPIlst);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(933, 179);
            panel1.TabIndex = 0;
            // 
            // btnRun
            // 
            btnRun.Location = new System.Drawing.Point(448, 146);
            btnRun.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new System.Drawing.Size(88, 27);
            btnRun.TabIndex = 3;
            btnRun.Text = "run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // pnlAPIparams
            // 
            pnlAPIparams.Location = new System.Drawing.Point(3, 34);
            pnlAPIparams.Name = "pnlAPIparams";
            pnlAPIparams.Size = new System.Drawing.Size(531, 110);
            pnlAPIparams.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(txtPass);
            panel3.Controls.Add(txtUser);
            panel3.Controls.Add(txtDB);
            panel3.Controls.Add(txtURL);
            panel3.Controls.Add(lblpass);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Dock = System.Windows.Forms.DockStyle.Right;
            panel3.Location = new System.Drawing.Point(539, 0);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(392, 177);
            panel3.TabIndex = 2;
            // 
            // txtPass
            // 
            txtPass.Location = new System.Drawing.Point(62, 126);
            txtPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtPass.Name = "txtPass";
            txtPass.Size = new System.Drawing.Size(316, 23);
            txtPass.TabIndex = 1;
            txtPass.TextChanged += txtURL_TextChanged;
            // 
            // txtUser
            // 
            txtUser.Location = new System.Drawing.Point(62, 91);
            txtUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtUser.Name = "txtUser";
            txtUser.Size = new System.Drawing.Size(316, 23);
            txtUser.TabIndex = 1;
            txtUser.TextChanged += txtConfig_TextChanged;
            // 
            // txtDB
            // 
            txtDB.Location = new System.Drawing.Point(62, 61);
            txtDB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDB.Name = "txtDB";
            txtDB.Size = new System.Drawing.Size(316, 23);
            txtDB.TabIndex = 1;
            txtDB.TextChanged += txtURL_TextChanged;
            // 
            // txtURL
            // 
            txtURL.Location = new System.Drawing.Point(62, 31);
            txtURL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(316, 23);
            txtURL.TabIndex = 1;
            txtURL.ModifiedChanged += txtConfig_TextChanged;
            txtURL.TextChanged += txtConfig_TextChanged;
            // 
            // lblpass
            // 
            lblpass.AutoSize = true;
            lblpass.Location = new System.Drawing.Point(20, 129);
            lblpass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblpass.Name = "lblpass";
            lblpass.Size = new System.Drawing.Size(30, 15);
            lblpass.TabIndex = 0;
            lblpass.Text = "Pass";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 95);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(30, 15);
            label4.TabIndex = 0;
            label4.Text = "User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 65);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(22, 15);
            label3.TabIndex = 0;
            label3.Text = "DB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 37);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(28, 15);
            label2.TabIndex = 0;
            label2.Text = "URL";
            // 
            // cmbAPIlst
            // 
            cmbAPIlst.FormattingEnabled = true;
            cmbAPIlst.Location = new System.Drawing.Point(67, 6);
            cmbAPIlst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbAPIlst.Name = "cmbAPIlst";
            cmbAPIlst.Size = new System.Drawing.Size(316, 23);
            cmbAPIlst.TabIndex = 1;
            cmbAPIlst.SelectedValueChanged += cmbAPIlst_SelectedValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 9);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "API List";
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 477);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(933, 42);
            panel2.TabIndex = 0;
            // 
            // rtxtLog
            // 
            rtxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            rtxtLog.Location = new System.Drawing.Point(0, 179);
            rtxtLog.Name = "rtxtLog";
            rtxtLog.Size = new System.Drawing.Size(933, 298);
            rtxtLog.TabIndex = 0;
            rtxtLog.Text = "";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(rtxtLog);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "frmMain";
            Text = "Odoo Call API";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbAPIlst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Panel APIparams;
        private System.Windows.Forms.Panel pnlAPIparams;
    }
}

