using System;
using System.Windows.Forms;
using HAGAKI.MyClass;

namespace HAGAKI.MyForm
{
    public partial class FrmUser : DevExpress.XtraEditors.XtraForm
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgv_listuser.DataSource = Global.DbBpo.GetListUser();
            cbb_idrole.DataSource = Global.DbBpo.GetListRole();
            cbb_idrole.DisplayMember = "RoleName";
            cbb_idrole.ValueMember = "RoleID";
        }
        private void frm_User_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        private void btn_suauser_Click(object sender, EventArgs e)
        {
            var nhanvien = txt_FullName.Text;
            var roleid = cbb_idrole.SelectedValue?.ToString() ?? "";

            if (!string.IsNullOrEmpty(roleid) && !string.IsNullOrEmpty(nhanvien) && !string.IsNullOrEmpty(txt_username.Text) && !string.IsNullOrEmpty(txt_password.Text))
            {
                DialogResult thongbao = MessageBox.Show(@"You want to edit the UserName '" + txt_username.Text + @"'", @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    Global.DbBpo.UpdateUsername(txt_username.Text, txt_password.Text, roleid, nhanvien, txt_grouplevel.Text);
                    frm_User_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show(@"Enter full information before saving !");
            }
            LoadData();
        }

        private void btn_themuser_Click(object sender, EventArgs e)
        {
            var nhanvien = txt_FullName.Text;
            var roleid = cbb_idrole.SelectedValue?.ToString() ?? "";

            if (!string.IsNullOrEmpty(roleid) && !string.IsNullOrEmpty(nhanvien) && !string.IsNullOrEmpty(txt_username.Text) && !string.IsNullOrEmpty(txt_password.Text))
            {
                var r = Global.DbBpo.InsertUsername(txt_username.Text, txt_password.Text, roleid, nhanvien, txt_grouplevel.Text);
                if (r == 0)
                {
                    MessageBox.Show(@"UserName already exists, Please enter another UserName");
                }
                if (r == 1)
                {
                    MessageBox.Show(@"Added UserName '" + txt_username.Text + @"' !");
                    frm_User_Load(sender, e);
                    txt_username.Text = "";
                    txt_FullName.Text = "";
                    txt_username.Focus();
                }
            }
            else
            {
                MessageBox.Show(@"Enter full information before saving !");
            }
            LoadData();
        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string username = gridView1.GetFocusedRowCellValue("Username") != null ? gridView1.GetFocusedRowCellValue("Username").ToString() : "";
            DialogResult thongbao = MessageBox.Show(@"You want to delete the UserName'" + username + @"'", @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(username))
                {
                    Global.DbBpo.DeleteUsername(username);
                    frm_User_Load(sender, e);
                }
                else
                {
                    MessageBox.Show(@"Username does not exist, can not delete");
                }
            }
            LoadData();
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //string Username, Password, grouplevel, roleid, idnhanvien;

            //Username = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username").ToString() : "";
            //grouplevel = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level").ToString() : "";
            //Password = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString() : "";
            //roleid = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole").ToString() : "";
            //idnhanvien = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName").ToString() : "";

            //txt_username.Text = Username;
            //txt_password.Text = Password;
            //txt_grouplevel.Text = grouplevel;
            //txt_FullName.Text = idnhanvien;

            //cbb_idrole.DataSource = Global.DbBpo.GetListRole();
            //cbb_idrole.DisplayMember = "RoleName";
            //cbb_idrole.ValueMember = "RoleID";
            //cbb_idrole.SelectedValue = roleid;
        }

        private void gridView1_RowCellDefaultAlignment(object sender, DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
        {
            try
            {
                txt_username.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Username").ToString() : "";
                txt_grouplevel.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Group_Level").ToString() : "";
                //txt_password.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Password").ToString() : "";
                cbb_idrole.SelectedValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDRole").ToString() : "";
                txt_FullName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName") != null ? gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FullName").ToString() : "";
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string username = gridView1.GetFocusedRowCellValue("Username").ToString();
            if (e.Column.FieldName == "NotGoodUser")
            {
                bool check = (bool)e.Value;
                if (check)
                {
                    Global.DbBpo.updateNotGoodUser(username, true);
                }
                else
                {
                    Global.DbBpo.updateNotGoodUser(username, false);
                }
            }
            LoadData();
        }     
       
    }
}