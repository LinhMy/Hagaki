namespace HAGAKI.MyForm
{
    partial class FrmFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeedback));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_next = new DevExpress.XtraEditors.SimpleButton();
            this.btn_back = new DevExpress.XtraEditors.SimpleButton();
            this.lb_soloi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chb_User = new System.Windows.Forms.CheckBox();
            this.cbb_username = new System.Windows.Forms.ComboBox();
            this.cbb_batch = new System.Windows.Forms.ComboBox();
            this.btn_hienthi = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Mainfeedback1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_next);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.lb_soloi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chb_User);
            this.panel1.Controls.Add(this.cbb_username);
            this.panel1.Controls.Add(this.cbb_batch);
            this.panel1.Controls.Add(this.btn_hienthi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 37);
            this.panel1.TabIndex = 5;
            // 
            // btn_next
            // 
            this.btn_next.Enabled = false;
            this.btn_next.Location = new System.Drawing.Point(871, 6);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(55, 23);
            this.btn_next.TabIndex = 16;
            this.btn_next.Text = ">>&Next";
            this.btn_next.ToolTip = "Load tối đa 50 lỗi tiếp theo";
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_back
            // 
            this.btn_back.Enabled = false;
            this.btn_back.Location = new System.Drawing.Point(810, 6);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(55, 23);
            this.btn_back.TabIndex = 15;
            this.btn_back.Text = "<<&Back";
            this.btn_back.ToolTip = "Load lùi lại tối đa 50 lỗi";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lb_soloi
            // 
            this.lb_soloi.AutoSize = true;
            this.lb_soloi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_soloi.Location = new System.Drawing.Point(746, 11);
            this.lb_soloi.Name = "lb_soloi";
            this.lb_soloi.Size = new System.Drawing.Size(13, 13);
            this.lb_soloi.TabIndex = 14;
            this.lb_soloi.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(664, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number errors :";
            // 
            // chb_User
            // 
            this.chb_User.AutoSize = true;
            this.chb_User.Location = new System.Drawing.Point(362, 10);
            this.chb_User.Name = "chb_User";
            this.chb_User.Size = new System.Drawing.Size(79, 17);
            this.chb_User.TabIndex = 12;
            this.chb_User.Text = "UserName:";
            this.chb_User.UseVisualStyleBackColor = true;
            this.chb_User.CheckedChanged += new System.EventHandler(this.chb_User_CheckedChanged);
            this.chb_User.Click += new System.EventHandler(this.chb_User_CheckedChanged);
            // 
            // cbb_username
            // 
            this.cbb_username.FormattingEnabled = true;
            this.cbb_username.Location = new System.Drawing.Point(444, 8);
            this.cbb_username.Name = "cbb_username";
            this.cbb_username.Size = new System.Drawing.Size(128, 21);
            this.cbb_username.TabIndex = 11;
            this.cbb_username.Visible = false;
            this.cbb_username.TextChanged += new System.EventHandler(this.cbb_username_TextChanged);
            // 
            // cbb_batch
            // 
            this.cbb_batch.FormattingEnabled = true;
            this.cbb_batch.Location = new System.Drawing.Point(58, 8);
            this.cbb_batch.Name = "cbb_batch";
            this.cbb_batch.Size = new System.Drawing.Size(298, 21);
            this.cbb_batch.TabIndex = 10;
            this.cbb_batch.TextChanged += new System.EventHandler(this.cbb_batch_TextChanged);
            // 
            // btn_hienthi
            // 
            this.btn_hienthi.Location = new System.Drawing.Point(577, 6);
            this.btn_hienthi.Name = "btn_hienthi";
            this.btn_hienthi.Size = new System.Drawing.Size(75, 23);
            this.btn_hienthi.TabIndex = 9;
            this.btn_hienthi.Text = "Show";
            this.btn_hienthi.Click += new System.EventHandler(this.btn_hienthi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Batch:";
            // 
            // pnl_Mainfeedback1
            // 
            this.pnl_Mainfeedback1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Mainfeedback1.Location = new System.Drawing.Point(0, 37);
            this.pnl_Mainfeedback1.Name = "pnl_Mainfeedback1";
            this.pnl_Mainfeedback1.Size = new System.Drawing.Size(1132, 594);
            this.pnl_Mainfeedback1.TabIndex = 6;
            // 
            // FrmFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 631);
            this.Controls.Add(this.pnl_Mainfeedback1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFeedback_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chb_User;
        private System.Windows.Forms.ComboBox cbb_username;
        private System.Windows.Forms.ComboBox cbb_batch;
        private DevExpress.XtraEditors.SimpleButton btn_hienthi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_soloi;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.XtraScrollableControl pnl_Mainfeedback1;
        private DevExpress.XtraEditors.SimpleButton btn_next;
        private DevExpress.XtraEditors.SimpleButton btn_back;
    }
}