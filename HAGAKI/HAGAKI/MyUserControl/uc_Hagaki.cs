using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using HAGAKI.MyClass;

namespace HAGAKI.MyUserControl
{
    public delegate void AllTextChange(object sender, EventArgs e);
    public partial class uc_Hagaki : UserControl
    {
        public event AllTextChange Changed;
        public uc_Hagaki()
        {
            InitializeComponent();
        }
        private void Txt_GotFocus(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }
        private void uc_Hagaki_Load(object sender, EventArgs e)
        {
            txt_Truong01.GotFocus += Txt_GotFocus;
            txt_Truong02.GotFocus += Txt_GotFocus;
            txt_Truong03.GotFocus += Txt_GotFocus;
            txt_Truong04.GotFocus += Txt_GotFocus;
            txt_Truong05.GotFocus += Txt_GotFocus;
            txt_Truong06.GotFocus += Txt_GotFocus;
            txt_Truong07.GotFocus += Txt_GotFocus;
            //cbx_Truong08.GotFocus += Txt_GotFocus;
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
            if (txt.Text != ""  && txt.Text.IndexOf('?') < 0 && (txt.Text.Length > sobytelon || txt.Text.Length < sobytenho))
            {
                txt.BackColor = Color.Red;
                txt.ForeColor = Color.White;txt.Tag = "1";}
            else
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.Tag = "0";
            }
        }
        public void SaveData(string idImage)
        {
            Global.Db.Insert_Data_DEJP_New(
                idImage, Global.StrBatch, Global.StrUsername,
                txt_Truong01.Text,
                txt_Truong02.Text,
                txt_Truong03.Text,
                txt_Truong04.Text,
                txt_Truong05.Text,
                txt_Truong06.Text,
                txt_Truong07.Text,
                cbx_Truong08.Text

            );}

        public void SuaVaLuu(string usersaiit, string usersainhieu, string idimage)
        {
            Global.Db.SuaVaLuu(usersaiit, usersainhieu, idimage, Global.StrBatch, Global.StrUsername,
                txt_Truong01.Text,
                txt_Truong02.Text,
                txt_Truong03.Text,
                txt_Truong04.Text,
                txt_Truong05.Text,
                txt_Truong06.Text,
                txt_Truong07.Text,
                cbx_Truong08.Text);
        }

        public bool IsEmpty()
        {

            if (String.IsNullOrEmpty(this.txt_Truong01.Text) &&
                string.IsNullOrEmpty(this.txt_Truong02.Text) &&
                string.IsNullOrEmpty(this.txt_Truong03.Text) &&
                string.IsNullOrEmpty(this.txt_Truong04.Text) &&
                string.IsNullOrEmpty(this.txt_Truong05.Text) &&
                string.IsNullOrEmpty(this.txt_Truong06.Text) &&
                string.IsNullOrEmpty(this.txt_Truong07.Text) &&
                string.IsNullOrEmpty(this.cbx_Truong08.Text))
            {
                return true;}
            return false;
            
        }


        public string DieuKienTruong()
        {
            if (!string.IsNullOrEmpty(txt_Truong01.Text) && txt_Truong01.Text.Length != 8)
            {
                txt_Truong01.Focus();
                return "Trường số 1 không đúng. Vui lòng kiểm tra lại";
                }
            if (txt_Truong05.Text.Length > 13)
            {
                txt_Truong05.Focus();
                return "Trường số 5 không được lớn hơn 13 ký tự";
            }
            foreach (char cItem in txt_Truong02.Text)
            {
                if (MyClass.Global.DanhSachDuLieuCam1.IndexOf(cItem) >= 0)
                    return "Trường số 2 có chứa một trong những ký tự đặc biệt sau: \r\n" +MyClass.Global.DanhSachDuLieuCam1;
                if (MyClass.Global.DanhSachDuLieuCam2.IndexOf(cItem) >= 0)
                    return "Trường số 2 có chứa một trong những ký tự đặc biệt sau: \r\n" +
                           "「" + MyClass.Global.DanhSachDuLieuCam2 + "」";
                txt_Truong02.Focus();
            }
            foreach (char cItem in txt_Truong03.Text)
            {
                if (MyClass.Global.DanhSachDuLieuCam1.IndexOf(cItem) >= 0)
                    return "Trường số 3 có chứa một trong những ký tự đặc biệt sau: \r\n" +
                           MyClass.Global.DanhSachDuLieuCam1;
                txt_Truong03.Focus();
            }
            foreach (char cItem in txt_Truong04.Text)
            {
                if (MyClass.Global.DanhSachDuLieuCam2.IndexOf(cItem) >= 0)
                    return "Trường số 4 có chứa một trong những ký tự đặc biệt sau: \r\n" +
                           "「" + MyClass.Global.DanhSachDuLieuCam2 + "」";
                txt_Truong04.Focus();
            }
            return "Ok";
        }

        private void txt_Truong01_EditValueChanged(object sender, EventArgs e)
        {
            DoiMauTextBox((TextEdit)sender, 8, 8);
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong05_EditValueChanged(object sender, EventArgs e)
        {
            DoiMauTextBox((TextEdit)sender, 0, 13);
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong02_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 50);
        }

        private void txt_Truong03_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 50);
        }

        private void txt_Truong04_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 50);
        }

        private void txt_Truong06_EditValueChanged(object sender, EventArgs e)
        {
          Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 3);
        }
        private void txt_Truong07_EditValueChanged(object sender, EventArgs e)
        {
          Changed?.Invoke(sender, e);
            DoiMauTextBox((TextEdit)sender, 0, 2);
        }
    
        public void ResetData()
        {
            txt_Truong01.Focus();
            txt_Truong01.Text = txt_Truong02.Text = txt_Truong03.Text = txt_Truong04.Text =
            txt_Truong05.Text = txt_Truong06.Text = txt_Truong07.Text = cbx_Truong08.Text= "";
        }

        private void cbx_Truong08_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changed?.Invoke(sender, e);
        }

        private void cbx_Truong08_TextChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }
    }
}
