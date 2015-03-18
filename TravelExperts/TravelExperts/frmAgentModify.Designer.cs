namespace TravelExperts
{
    partial class frmAgentModify
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
            this.txtAgtBusPhone = new System.Windows.Forms.TextBox();
            this.txtAgtLastName = new System.Windows.Forms.TextBox();
            this.txtAgtMiddleInitial = new System.Windows.Forms.TextBox();
            this.txtAgtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAgtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAgentId = new System.Windows.Forms.ComboBox();
            this.cmbAgtPosition = new System.Windows.Forms.ComboBox();
            this.txtAgtPassword = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAgtBusPhone
            // 
            this.txtAgtBusPhone.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgtBusPhone.Location = new System.Drawing.Point(182, 133);
            this.txtAgtBusPhone.MaxLength = 20;
            this.txtAgtBusPhone.Name = "txtAgtBusPhone";
            this.txtAgtBusPhone.Size = new System.Drawing.Size(142, 22);
            this.txtAgtBusPhone.TabIndex = 52;
            this.txtAgtBusPhone.Tag = "Phone Number";
            // 
            // txtAgtLastName
            // 
            this.txtAgtLastName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgtLastName.Location = new System.Drawing.Point(182, 105);
            this.txtAgtLastName.MaxLength = 20;
            this.txtAgtLastName.Name = "txtAgtLastName";
            this.txtAgtLastName.Size = new System.Drawing.Size(235, 22);
            this.txtAgtLastName.TabIndex = 51;
            this.txtAgtLastName.Tag = "Last Name";
            // 
            // txtAgtMiddleInitial
            // 
            this.txtAgtMiddleInitial.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgtMiddleInitial.Location = new System.Drawing.Point(182, 76);
            this.txtAgtMiddleInitial.MaxLength = 5;
            this.txtAgtMiddleInitial.Name = "txtAgtMiddleInitial";
            this.txtAgtMiddleInitial.Size = new System.Drawing.Size(235, 22);
            this.txtAgtMiddleInitial.TabIndex = 50;
            this.txtAgtMiddleInitial.Tag = "Middle Initial";
            // 
            // txtAgtFirstName
            // 
            this.txtAgtFirstName.Location = new System.Drawing.Point(182, 48);
            this.txtAgtFirstName.MaxLength = 20;
            this.txtAgtFirstName.Name = "txtAgtFirstName";
            this.txtAgtFirstName.Size = new System.Drawing.Size(142, 22);
            this.txtAgtFirstName.TabIndex = 49;
            this.txtAgtFirstName.Tag = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Phone Number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 47;
            this.label3.Text = "Last Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Middle Initial";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "First Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(450, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(129, 37);
            this.btnAdd.TabIndex = 44;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(450, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 37);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAgtEmail
            // 
            this.txtAgtEmail.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgtEmail.Location = new System.Drawing.Point(182, 162);
            this.txtAgtEmail.MaxLength = 50;
            this.txtAgtEmail.Name = "txtAgtEmail";
            this.txtAgtEmail.Size = new System.Drawing.Size(235, 22);
            this.txtAgtEmail.TabIndex = 54;
            this.txtAgtEmail.Tag = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "Email";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Position";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 57;
            this.label7.Text = "Agency ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 59;
            this.label8.Text = "Password";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAgentId
            // 
            this.cmbAgentId.FormattingEnabled = true;
            this.cmbAgentId.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbAgentId.Location = new System.Drawing.Point(182, 218);
            this.cmbAgentId.Name = "cmbAgentId";
            this.cmbAgentId.Size = new System.Drawing.Size(142, 24);
            this.cmbAgentId.TabIndex = 61;
            this.cmbAgentId.Tag = "Agency ID";
            // 
            // cmbAgtPosition
            // 
            this.cmbAgtPosition.FormattingEnabled = true;
            this.cmbAgtPosition.Items.AddRange(new object[] {
            "Junior Agent",
            "Senior Agent",
            "Intermediate Agent"});
            this.cmbAgtPosition.Location = new System.Drawing.Point(182, 190);
            this.cmbAgtPosition.Name = "cmbAgtPosition";
            this.cmbAgtPosition.Size = new System.Drawing.Size(142, 24);
            this.cmbAgtPosition.TabIndex = 62;
            this.cmbAgtPosition.Tag = "Agent Position ";
            // 
            // txtAgtPassword
            // 
            this.txtAgtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgtPassword.Location = new System.Drawing.Point(182, 246);
            this.txtAgtPassword.MaxLength = 20;
            this.txtAgtPassword.Name = "txtAgtPassword";
            this.txtAgtPassword.Size = new System.Drawing.Size(235, 22);
            this.txtAgtPassword.TabIndex = 60;
            this.txtAgtPassword.Tag = "Password";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 28);
            this.menuStrip1.TabIndex = 63;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // frmAgentModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 315);
            this.Controls.Add(this.cmbAgtPosition);
            this.Controls.Add(this.cmbAgentId);
            this.Controls.Add(this.txtAgtPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAgtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAgtBusPhone);
            this.Controls.Add(this.txtAgtLastName);
            this.Controls.Add(this.txtAgtMiddleInitial);
            this.Controls.Add(this.txtAgtFirstName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAgentModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgentModify";
            this.Load += new System.EventHandler(this.frmAgentModify_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAgtBusPhone;
        private System.Windows.Forms.TextBox txtAgtLastName;
        private System.Windows.Forms.TextBox txtAgtMiddleInitial;
        private System.Windows.Forms.TextBox txtAgtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAgtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAgentId;
        private System.Windows.Forms.ComboBox cmbAgtPosition;
        private System.Windows.Forms.TextBox txtAgtPassword;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}