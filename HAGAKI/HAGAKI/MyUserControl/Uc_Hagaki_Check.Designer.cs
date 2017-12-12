namespace HAGAKI.MyUserControl
{
    partial class Uc_Hagaki_Check
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
            this.cbx_Truong08 = new System.Windows.Forms.ComboBox();
            this.txt_Truong07 = new DevExpress.XtraEditors.TextEdit();
            this.txt_Truong06 = new DevExpress.XtraEditors.TextEdit();
            this.txt_Truong01 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rt_Truong02 = new System.Windows.Forms.RichTextBox();
            this.rt_Trupng03 = new System.Windows.Forms.RichTextBox();
            this.rt_Truong04 = new System.Windows.Forms.RichTextBox();
            this.rt_Truong05 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong07.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong06.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong01.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_Truong08
            // 
            this.cbx_Truong08.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Truong08.FormattingEnabled = true;
            this.cbx_Truong08.Items.AddRange(new object[] {
            "氏名複数記載有り",
            "電話番号複数記載有り",
            "郵便番号・住所不一致",
            "機種依存文字有り",
            "ローマ数字有り",
            "住所から逆引き"});
            this.cbx_Truong08.Location = new System.Drawing.Point(21, 215);
            this.cbx_Truong08.Name = "cbx_Truong08";
            this.cbx_Truong08.Size = new System.Drawing.Size(300, 28);
            this.cbx_Truong08.TabIndex = 24;
            this.cbx_Truong08.TextChanged += new System.EventHandler(this.cbx_Truong08_TextChanged_1);
            // 
            // txt_Truong07
            // 
            this.txt_Truong07.EditValue = "";
            this.txt_Truong07.Location = new System.Drawing.Point(206, 179);
            this.txt_Truong07.Name = "txt_Truong07";
            this.txt_Truong07.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Truong07.Properties.Appearance.Options.UseFont = true;
            this.txt_Truong07.Properties.Mask.EditMask = "[1-2●]";
            this.txt_Truong07.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Truong07.Properties.MaxLength = 1;
            this.txt_Truong07.Size = new System.Drawing.Size(84, 26);
            this.txt_Truong07.TabIndex = 23;
            this.txt_Truong07.EditValueChanged += new System.EventHandler(this.txt_Truong07_EditValueChanged_1);
            // 
            // txt_Truong06
            // 
            this.txt_Truong06.EditValue = "";
            this.txt_Truong06.Location = new System.Drawing.Point(21, 181);
            this.txt_Truong06.Name = "txt_Truong06";
            this.txt_Truong06.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Truong06.Properties.Appearance.Options.UseFont = true;
            this.txt_Truong06.Properties.Mask.EditMask = "[0-9●]+";
            this.txt_Truong06.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Truong06.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txt_Truong06.Properties.MaxLength = 2;
            this.txt_Truong06.Size = new System.Drawing.Size(139, 26);
            this.txt_Truong06.TabIndex = 22;
            this.txt_Truong06.EditValueChanged += new System.EventHandler(this.txt_Truong06_EditValueChanged_1);
            // 
            // txt_Truong01
            // 
            this.txt_Truong01.EditValue = "";
            this.txt_Truong01.Location = new System.Drawing.Point(21, 7);
            this.txt_Truong01.Name = "txt_Truong01";
            this.txt_Truong01.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Truong01.Properties.Appearance.Options.UseFont = true;
            this.txt_Truong01.Properties.Mask.EditMask = "[0-9●][0-9●][0-9●]-[0-9●][0-9●][0-9●][0-9●]+";
            this.txt_Truong01.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_Truong01.Properties.MaxLength = 15;
            this.txt_Truong01.Size = new System.Drawing.Size(300, 26);
            this.txt_Truong01.TabIndex = 17;
            this.txt_Truong01.EditValueChanged += new System.EventHandler(this.txt_Truong01_EditValueChanged_1);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(3, 219);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(10, 18);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "8";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(191, 183);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(10, 18);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "7";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(6, 183);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(10, 18);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "6";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(6, 150);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(10, 18);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "5";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(6, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(10, 18);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "4";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 78);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(10, 18);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "3";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(10, 18);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(10, 18);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "1";
            // 
            // rt_Truong02
            // 
            this.rt_Truong02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rt_Truong02.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rt_Truong02.Location = new System.Drawing.Point(20, 38);
            this.rt_Truong02.Name = "rt_Truong02";
            this.rt_Truong02.Size = new System.Drawing.Size(301, 27);
            this.rt_Truong02.TabIndex = 25;
            this.rt_Truong02.Text = "";
            this.rt_Truong02.TextChanged += new System.EventHandler(this.rt_Truong02_TextChanged);
            // 
            // rt_Trupng03
            // 
            this.rt_Trupng03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rt_Trupng03.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rt_Trupng03.Location = new System.Drawing.Point(19, 76);
            this.rt_Trupng03.Name = "rt_Trupng03";
            this.rt_Trupng03.Size = new System.Drawing.Size(301, 27);
            this.rt_Trupng03.TabIndex = 26;
            this.rt_Trupng03.Text = "";
            this.rt_Trupng03.TextChanged += new System.EventHandler(this.rt_Trupng03_TextChanged);
            // 
            // rt_Truong04
            // 
            this.rt_Truong04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rt_Truong04.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rt_Truong04.Location = new System.Drawing.Point(19, 109);
            this.rt_Truong04.Name = "rt_Truong04";
            this.rt_Truong04.Size = new System.Drawing.Size(301, 27);
            this.rt_Truong04.TabIndex = 27;
            this.rt_Truong04.Text = "";
            this.rt_Truong04.TextChanged += new System.EventHandler(this.rt_Truong04_TextChanged);
            // 
            // rt_Truong05
            // 
            this.rt_Truong05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rt_Truong05.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rt_Truong05.Location = new System.Drawing.Point(19, 146);
            this.rt_Truong05.Name = "rt_Truong05";
            this.rt_Truong05.Size = new System.Drawing.Size(301, 27);
            this.rt_Truong05.TabIndex = 28;
            this.rt_Truong05.Text = "";
            this.rt_Truong05.TextChanged += new System.EventHandler(this.rt_Truong05_TextChanged);
            this.rt_Truong05.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox4_KeyPress);
            // 
            // Uc_Hagaki_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rt_Truong05);
            this.Controls.Add(this.rt_Truong04);
            this.Controls.Add(this.rt_Trupng03);
            this.Controls.Add(this.rt_Truong02);
            this.Controls.Add(this.cbx_Truong08);
            this.Controls.Add(this.txt_Truong07);
            this.Controls.Add(this.txt_Truong06);
            this.Controls.Add(this.txt_Truong01);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Uc_Hagaki_Check";
            this.Size = new System.Drawing.Size(325, 246);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong07.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong06.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Truong01.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbx_Truong08;
        public DevExpress.XtraEditors.TextEdit txt_Truong07;
        public DevExpress.XtraEditors.TextEdit txt_Truong06;
        public DevExpress.XtraEditors.TextEdit txt_Truong01;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public System.Windows.Forms.RichTextBox rt_Truong02;
        public System.Windows.Forms.RichTextBox rt_Trupng03;
        public System.Windows.Forms.RichTextBox rt_Truong04;
        public System.Windows.Forms.RichTextBox rt_Truong05;
    }
}
