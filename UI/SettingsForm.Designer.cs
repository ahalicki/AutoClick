namespace AutoClick
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClickMins = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cboClickType = new System.Windows.Forms.ComboBox();
            this.lblClickLocation = new System.Windows.Forms.Label();
            this.txtYCoord = new System.Windows.Forms.TextBox();
            this.txtXCoord = new System.Windows.Forms.TextBox();
            this.lblXCoord = new System.Windows.Forms.Label();
            this.lblyCoord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Click every x mintues:";
            // 
            // txtClickMins
            // 
            this.txtClickMins.Location = new System.Drawing.Point(18, 89);
            this.txtClickMins.Name = "txtClickMins";
            this.txtClickMins.Size = new System.Drawing.Size(121, 20);
            this.txtClickMins.TabIndex = 0;
            this.txtClickMins.Text = "60";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(201, 101);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.Start_Click);
            // 
            // cboClickType
            // 
            this.cboClickType.FormattingEnabled = true;
            this.cboClickType.Location = new System.Drawing.Point(18, 34);
            this.cboClickType.Name = "cboClickType";
            this.cboClickType.Size = new System.Drawing.Size(121, 21);
            this.cboClickType.TabIndex = 7;
            // 
            // lblClickLocation
            // 
            this.lblClickLocation.AutoSize = true;
            this.lblClickLocation.Location = new System.Drawing.Point(179, 14);
            this.lblClickLocation.Name = "lblClickLocation";
            this.lblClickLocation.Size = new System.Drawing.Size(77, 13);
            this.lblClickLocation.TabIndex = 8;
            this.lblClickLocation.Text = "Click Location:";
            // 
            // txtYCoord
            // 
            this.txtYCoord.Location = new System.Drawing.Point(236, 34);
            this.txtYCoord.Name = "txtYCoord";
            this.txtYCoord.Size = new System.Drawing.Size(40, 20);
            this.txtYCoord.TabIndex = 9;
            this.txtYCoord.Text = "0";
            // 
            // txtXCoord
            // 
            this.txtXCoord.Location = new System.Drawing.Point(167, 34);
            this.txtXCoord.Name = "txtXCoord";
            this.txtXCoord.Size = new System.Drawing.Size(40, 20);
            this.txtXCoord.TabIndex = 10;
            this.txtXCoord.Text = "0";
            // 
            // lblXCoord
            // 
            this.lblXCoord.AutoSize = true;
            this.lblXCoord.Location = new System.Drawing.Point(146, 37);
            this.lblXCoord.Name = "lblXCoord";
            this.lblXCoord.Size = new System.Drawing.Size(15, 13);
            this.lblXCoord.TabIndex = 11;
            this.lblXCoord.Text = "x:";
            // 
            // lblyCoord
            // 
            this.lblyCoord.AutoSize = true;
            this.lblyCoord.Location = new System.Drawing.Point(215, 37);
            this.lblyCoord.Name = "lblyCoord";
            this.lblyCoord.Size = new System.Drawing.Size(15, 13);
            this.lblyCoord.TabIndex = 12;
            this.lblyCoord.Text = "y:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 136);
            this.Controls.Add(this.lblyCoord);
            this.Controls.Add(this.lblXCoord);
            this.Controls.Add(this.txtXCoord);
            this.Controls.Add(this.txtYCoord);
            this.Controls.Add(this.lblClickLocation);
            this.Controls.Add(this.cboClickType);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClickMins);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 175);
            this.Name = "SettingsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClickMins;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cboClickType;
        private System.Windows.Forms.Label lblClickLocation;
        private System.Windows.Forms.TextBox txtYCoord;
        private System.Windows.Forms.TextBox txtXCoord;
        private System.Windows.Forms.Label lblXCoord;
        private System.Windows.Forms.Label lblyCoord;
    }
}