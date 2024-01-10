namespace OdooAPI2
{
    partial class ucGetFile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnFileSelect = new System.Windows.Forms.Button();
            txtAddress = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btnFileSelect
            // 
            btnFileSelect.Dock = System.Windows.Forms.DockStyle.Right;
            btnFileSelect.Location = new System.Drawing.Point(267, 0);
            btnFileSelect.Name = "btnFileSelect";
            btnFileSelect.Size = new System.Drawing.Size(75, 30);
            btnFileSelect.TabIndex = 0;
            btnFileSelect.Text = "....";
            btnFileSelect.UseVisualStyleBackColor = true;
            btnFileSelect.Click += btnFileSelect_Click;
            // 
            // txtAddress
            // 
            txtAddress.Dock = System.Windows.Forms.DockStyle.Bottom;
            txtAddress.Location = new System.Drawing.Point(0, 7);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new System.Drawing.Size(267, 23);
            txtAddress.TabIndex = 1;
            // 
            // ucGetFile
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(txtAddress);
            Controls.Add(btnFileSelect);
            Name = "ucGetFile";
            Size = new System.Drawing.Size(342, 30);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtAddress;
    }
}
