namespace HAGAKI.MyUserControl
{
    partial class uc_FeedBack_Hagaki
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uc_FeddBack3 = new HAGAKI.MyUserControl.uc_FeddBack();
            this.uc_FeddBack2 = new HAGAKI.MyUserControl.uc_FeddBack();
            this.uc_FeddBack1 = new HAGAKI.MyUserControl.uc_FeddBack();
            this.ucPictureBox1 = new HAGAKI.MyUserControl.UcPictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucPictureBox1);
            this.panel1.Location = new System.Drawing.Point(34, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 507);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 24);
            this.textBox1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.uc_FeddBack3);
            this.panel2.Controls.Add(this.uc_FeddBack2);
            this.panel2.Controls.Add(this.uc_FeddBack1);
            this.panel2.Location = new System.Drawing.Point(730, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 478);
            this.panel2.TabIndex = 5;
            // 
            // uc_FeddBack3
            // 
            this.uc_FeddBack3.AutoScroll = true;
            this.uc_FeddBack3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(171)))), ((int)(((byte)(132)))));
            this.uc_FeddBack3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_FeddBack3.Location = new System.Drawing.Point(520, 14);
            this.uc_FeddBack3.Name = "uc_FeddBack3";
            this.uc_FeddBack3.Size = new System.Drawing.Size(262, 267);
            this.uc_FeddBack3.TabIndex = 6;
            // 
            // uc_FeddBack2
            // 
            this.uc_FeddBack2.AutoScroll = true;
            this.uc_FeddBack2.BackColor = System.Drawing.SystemColors.Control;
            this.uc_FeddBack2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_FeddBack2.Location = new System.Drawing.Point(261, 14);
            this.uc_FeddBack2.Name = "uc_FeddBack2";
            this.uc_FeddBack2.Size = new System.Drawing.Size(259, 267);
            this.uc_FeddBack2.TabIndex = 5;
            // 
            // uc_FeddBack1
            // 
            this.uc_FeddBack1.AutoScroll = true;
            this.uc_FeddBack1.BackColor = System.Drawing.SystemColors.Control;
            this.uc_FeddBack1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc_FeddBack1.Location = new System.Drawing.Point(0, 14);
            this.uc_FeddBack1.Name = "uc_FeddBack1";
            this.uc_FeddBack1.Size = new System.Drawing.Size(261, 267);
            this.uc_FeddBack1.TabIndex = 4;
            // 
            // ucPictureBox1
            // 
            this.ucPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.ucPictureBox1.Name = "ucPictureBox1";
            this.ucPictureBox1.Size = new System.Drawing.Size(697, 507);
            this.ucPictureBox1.TabIndex = 0;
            // 
            // uc_FeedBack_Hagaki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "uc_FeedBack_Hagaki";
            this.Size = new System.Drawing.Size(1517, 505);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public UcPictureBox ucPictureBox1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        public uc_FeddBack uc_FeddBack3;
        public uc_FeddBack uc_FeddBack2;
        public uc_FeddBack uc_FeddBack1;
    }
}
