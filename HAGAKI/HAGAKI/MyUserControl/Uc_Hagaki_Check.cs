using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAGAKI.MyClass;

namespace HAGAKI.MyUserControl
{
    public delegate void AllTextChange1(object sender, EventArgs e);
    public partial class Uc_Hagaki_Check : UserControl
    {
        public event AllTextChange1 Changed;
        public Uc_Hagaki_Check()
        {
            InitializeComponent();
        }
        private void Txt_GotFocus(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }
        private void Cbx_GotFocus(object sender, EventArgs e)
        {
            ((ComboBoxEdit)sender).SelectAll();
        }
        private void Rtb_GotFocus(object sender, EventArgs e)
        {
            ((RichTextBox)sender).SelectAll();
        }
        private void uc_Hagaki_Load(object sender, EventArgs e)
        {
            txt_Truong01.GotFocus += Txt_GotFocus;
            rt_Truong02.GotFocus += Rtb_GotFocus;
            rt_Trupng03.GotFocus += Rtb_GotFocus;
            rt_Truong04.GotFocus += Rtb_GotFocus;
            rt_Truong05.GotFocus += Rtb_GotFocus;
            txt_Truong06.GotFocus += Txt_GotFocus;
            txt_Truong07.GotFocus += Txt_GotFocus;
            cbx_Truong08.GotFocus += Cbx_GotFocus;
        }
        private void txt_Truong01_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        public void DoiMauTextBox(TextEdit txt, int sobytenho, int sobytelon)
        {
            if (txt.Text != "" && txt.Text.IndexOf('?') < 0 && (txt.Text.Length > sobytelon || txt.Text.Length < sobytenho))
            {
                txt.BackColor = Color.Red;
                txt.ForeColor = Color.White; txt.Tag = "1";
            }
            else
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.Tag = "0";
            }
        }
        public void DoiMauRichTextBox(RichTextBox rtb, int sobytenho, int sobytelon)
        {
            if (rtb.Text != "" && rtb.Text.IndexOf('?') < 0 && (rtb.Text.Length > sobytelon || rtb.Text.Length < sobytenho))
            {
                rtb.BackColor = Color.Red;
                rtb.ForeColor = Color.White; rtb.Tag = "1";
            }
            else
            {
                rtb.BackColor = Color.White;
                rtb.ForeColor = Color.Black;
                rtb.Tag = "0";
            }
        }
        public void SaveData(string idImage)
        {
            Global.Db.Insert_Data_DEJP_New(
                idImage, Global.StrBatch, Global.StrUsername,
                txt_Truong01.Text,
                rt_Truong02.Text,
                rt_Trupng03.Text,
                rt_Truong04.Text,
                rt_Truong05.Text,
                txt_Truong06.Text,
                txt_Truong07.Text,
                cbx_Truong08.Text

            );
        }

        public void SuaVaLuu(string usersaiit, string usersainhieu, string idimage)
        {
            Global.Db.SuaVaLuu(usersaiit, usersainhieu, idimage, Global.StrBatch, Global.StrUsername,
                txt_Truong01.Text,
                rt_Truong02.Text,
                rt_Trupng03.Text,
                rt_Truong04.Text,
                rt_Truong05.Text,
                txt_Truong06.Text,
                txt_Truong07.Text,
                cbx_Truong08.Text);
        }

        public bool IsEmpty()
        {

            if (string.IsNullOrEmpty(this.txt_Truong01.Text) &&
                string.IsNullOrEmpty(this.rt_Truong02.Text) &&
                string.IsNullOrEmpty(this.rt_Trupng03.Text) &&
                string.IsNullOrEmpty(this.rt_Truong04.Text) &&
                string.IsNullOrEmpty(this.rt_Truong05.Text) &&
                string.IsNullOrEmpty(this.txt_Truong06.Text) &&
                string.IsNullOrEmpty(this.txt_Truong07.Text) &&
                string.IsNullOrEmpty(this.cbx_Truong08.Text))
            {
                return true;
            }
            return false;

        }


        public string DieuKienTruong()
        {
            if (!string.IsNullOrEmpty(txt_Truong01.Text) && txt_Truong01.Text.Length != 8)
            {
                txt_Truong01.Focus();
                return "Trường số 1 không đúng. Vui lòng kiểm tra lại";
            }
            if (rt_Truong05.Text.Length > 13)
            {
                rt_Truong05.Focus();
                return "Trường số 5 không được lớn hơn 13 ký tự";
            }
            foreach (char cItem in rt_Truong02.Text)
            {
                if (MyClass.Global.DanhSachDuLieuCam1.IndexOf(cItem) >= 0)
                    return "Trường số 2 có chứa một trong những ký tự đặc biệt sau: \r\n" + MyClass.Global.DanhSachDuLieuCam1;
                if (MyClass.Global.DanhSachDuLieuCam2.IndexOf(cItem) >= 0)
                    return "Trường số 2 có chứa một trong những ký tự đặc biệt sau: \r\n" +
                           "「" + MyClass.Global.DanhSachDuLieuCam2 + "」";
                rt_Truong02.Focus();
            }
            foreach (char cItem in rt_Trupng03.Text)
            {
                if (MyClass.Global.DanhSachDuLieuCam1.IndexOf(cItem) >= 0)
                    return "Trường số 3 có chứa một trong những ký tự đặc biệt sau: \r\n" +
                           MyClass.Global.DanhSachDuLieuCam1;
                rt_Trupng03.Focus();
            }
            foreach (char cItem in rt_Truong04.Text)
            {
                if (MyClass.Global.DanhSachDuLieuCam2.IndexOf(cItem) >= 0)
                    return "Trường số 4 có chứa một trong những ký tự đặc biệt sau: \r\n" +
                           "「" + MyClass.Global.DanhSachDuLieuCam2 + "」";
                rt_Truong04.Focus();
            }
            return "Ok";
        }

       

        //private void txt_Truong05_EditValueChanged(object sender, EventArgs e)
        //{
        //    DoiMauTextBox((TextEdit)sender, 0, 13);
        //    Changed?.Invoke(sender, e);
        //}

        //private void txt_Truong02_EditValueChanged(object sender, EventArgs e)
        //{
        //    Changed?.Invoke(sender, e);
        //    DoiMauTextBox((TextEdit)sender, 0, 50);
        //}

        //private void txt_Truong03_EditValueChanged(object sender, EventArgs e)
        //{
        //    Changed?.Invoke(sender, e);
        //    DoiMauTextBox((TextEdit)sender, 0, 50);
        //}

        //private void txt_Truong04_EditValueChanged(object sender, EventArgs e)
        //{
        //    Changed?.Invoke(sender, e);
        //    DoiMauTextBox((TextEdit)sender, 0, 50);
        //}

       

        public void ResetData()
        {
            txt_Truong01.Focus();
            txt_Truong01.Text = rt_Truong02.Text = rt_Trupng03.Text = rt_Truong04.Text =
            rt_Truong05.Text = txt_Truong06.Text = txt_Truong07.Text = cbx_Truong08.Text = "";
        }

        private void cbx_Truong08_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changed?.Invoke(sender, e);
        }

        private void richTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)&& e.KeyChar!= '●' && e.KeyChar!='+' && e.KeyChar!='-')
            {
                e.Handled = true;
            }
           
        }

        private void txt_Truong01_EditValueChanged_1(object sender, EventArgs e)
        {
            DoiMauTextBox((TextEdit)sender, 8, 8);
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong06_EditValueChanged_1(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 3);

        }

        private void txt_Truong07_EditValueChanged_1(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 2);
        }

        private void cbx_Truong08_TextChanged_1(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void rt_Truong02_TextChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauRichTextBox((RichTextBox)sender, 0, 50);
        }

        private void rt_Trupng03_TextChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauRichTextBox((RichTextBox)sender, 0, 50);
        }

        private void rt_Truong04_TextChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauRichTextBox((RichTextBox)sender, 0, 50);
        }

        private void rt_Truong05_TextChanged(object sender, EventArgs e)
        {
            DoiMauRichTextBox((RichTextBox)sender, 0, 13);
            Changed?.Invoke(sender, e);
        }
    }
}
