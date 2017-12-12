using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HAGAKI.MyClass;
using HAGAKI.Properties;
using ComboBox = System.Windows.Forms.ComboBox;

namespace HAGAKI.MyForm
{
    public partial class FrmCheckDeJP : XtraForm
    {
        //private bool _flag = false;
        public FrmCheckDeJP()
        {
            InitializeComponent();
        }

        private void ResetData()
        {
            uc_Hagaki_Check1.ResetData();
            uc_Hagaki_Check2.ResetData();
            lb_username1.Text = "";
            lb_username2.Text = "";
            ucPictureBox1.imageBox1.Image = null;
        }

        private void Compare_TextBox(TextEdit t1, TextEdit t2)
        {
            if (!string.IsNullOrEmpty(t1.Text) || !string.IsNullOrEmpty(t2.Text))
            {
                if (t1.Text != t2.Text)
                {
                    t1.BackColor = Color.PaleVioletRed;
                    t2.BackColor = Color.PaleVioletRed;
                }
            }
            else
            {
                t1.BackColor = Color.White;
                t1.ForeColor = Color.Black;
                t2.BackColor = Color.White;
                t2.ForeColor = Color.Black;
            }
        }
        private void Compare_Textbox_Word(RichTextBox t1, RichTextBox t2)
        {
            int n = 0;
            string s1 = t1.Text;
            string s2 = t2.Text;
            int check = s1.CompareTo(s2);
            if(check!=0)
            {
                if (s1.Length > s2.Length)
                {
                    n = s2.Length;
                    t1.SelectionStart = n;
                    t1.SelectionLength = s1.Length - s2.Length;
                    t1.SelectionColor = Color.Red;
                    //t1.SelectionBackColor = Color.Red;
                }
                else
                {
                    n = s1.Length;
                    t2.SelectionStart = n;
                    t2.SelectionLength = s2.Length - s1.Length;
                    t2.SelectionColor = Color.Red;
                    //t2.SelectionBackColor = Color.Red;
                }
                for (int i = 0; i < n; i++)
                {
                    if (s1[i] != s2[i])
                    {
                        t1.SelectionStart = i;
                        t1.SelectionLength = 1;
                        t1.SelectionColor = Color.Red;
                      
                        //t1.SelectionBackColor = Color.Red;

                        t2.SelectionStart = i;
                        t2.SelectionLength = 1;
                        t2.SelectionColor = Color.Red;
                        //t2.SelectionBackColor = Color.Red;
                    }
                }
                t1.BackColor = Color.PaleVioletRed;
                t2.BackColor = Color.PaleVioletRed;
            }
        }
        private void Compare(RichTextBox t1, RichTextBox t2)
        {
            int n = 0, m = 0, b = 0;
            string s1 = t1.Text;
            string s2 = t2.Text;
            int check = s1.CompareTo(s2);
            if (check != 0)
            {
                    for (int i = 0; i < s1.Length; i++)
                    {
                        if (s1[i] != s2[i])
                        {
                            t1.SelectionStart = i;
                            t1.SelectionLength = 1;
                            t1.SelectionColor = Color.Red;

                            //t1.SelectionBackColor = Color.Red;

                            t2.SelectionStart = i;
                            t2.SelectionLength = 1;
                            t2.SelectionColor = Color.Red;
                            //t2.SelectionBackColor = Color.Red;
                        }
                    }
                

                if (s1.Length > s2.Length)
            {
                n = s2.Length;
                t1.SelectionStart = n;
                m = t1.SelectionLength = s1.Length - s2.Length;
                t1.SelectionColor = Color.Red;
                //t1.SelectionBackColor = Color.Red;
            }
           
            else if (s1.Length < s2.Length)
            {
                n = s1.Length;
                t2.SelectionStart = n;
                m = t2.SelectionLength = s2.Length - s1.Length;
                //  t2.SelectionColor = Color.Red;
                //t2.SelectionBackColor = Color.Red;
                //if (m > 0)
                //{

                for (int i = 0; i < n; i++)
                {
                        if (s1[i] != s2[i + b])
                        {
                            t1.SelectionStart = i;
                            t1.SelectionLength = 1;
                            //t1.SelectionColor = Color.Red;

                            //t1.SelectionBackColor = Color.Red;

                            t2.SelectionStart = i;
                            t2.SelectionLength = 1;
                            t2.SelectionColor = Color.Red;
                            //t2.SelectionBackColor = Color.Red;
                            int m1 = 1; int a = 0;
                            for (int j = i + 1; j < n + m; j++)
                            {
                                try
                                {

                                    if (s1[i + a] == s2[j])
                                    {
                                        t1.SelectionStart = j;
                                        t1.SelectionLength = 1;
                                        t1.SelectionColor = Color.Black;

                                        //t1.SelectionBackColor = Color.Red;

                                        t2.SelectionStart = j;
                                        t2.SelectionLength = 1;
                                        t2.SelectionColor = Color.Black;
                                        //t2.SelectionBackColor = Color.Red;
                                        a += 1;
                                        // m1 = j - i;
                                    }
                                    else
                                    {
                                        //b += a;
                                        //break;
                                        t2.SelectionStart = j;
                                        t2.SelectionLength = 1;
                                        t2.SelectionColor = Color.Red;

                                    }

                                }

                                catch (Exception e)
                                {
                                    t2.SelectionStart = j;
                                    t2.SelectionLength = 1;
                                    t2.SelectionColor = Color.Red;
                                }
                            }
                            return;
                        } 
                }
            }
            }
                        t1.BackColor = Color.PaleVioletRed;
                t2.BackColor = Color.PaleVioletRed;
            
        }
            private void Compare_ComBoBox(ComboBox t1, ComboBox t2)
        {
            if (!string.IsNullOrEmpty(t1.Text) || !string.IsNullOrEmpty(t2.Text))
            {
                if (t1.Text != t2.Text)
                {
                    t1.BackColor = Color.PaleVioletRed;
                    t2.BackColor = Color.PaleVioletRed;
                }
            }
            else
            {
                t1.BackColor = Color.White;
                t1.ForeColor = Color.Black;
                t2.BackColor = Color.White;
                t2.ForeColor = Color.Black;
            }
        }
        public void LoadBatchMoi()
        {
            if (MessageBox.Show(@"You want to do the next batch?", @"Notification", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                Close();
             }
            else
            {
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                ResetData();
                cbb_Batch_Check.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeJP(Global.StrUsername) select w.fbatchname).ToList();
                cbb_Batch_Check.DisplayMember = "fBatchName";
                Global.StrBatch = cbb_Batch_Check.Text;
                var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                btn_Start_Click(null, null);
            }
        }

        private void frm_Check_Load(object sender, EventArgs e)
        {
            
            try
            {
                cbb_Batch_Check.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeJP(Global.StrUsername) select w.fbatchname).ToList();
                cbb_Batch_Check.DisplayMember = "fBatchName";
                cbb_Batch_Check.Text = Global.StrBatch;
                var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                uc_Hagaki_Check1.Changed += UcHagaki1_Changed;
                uc_Hagaki_Check2.Changed += UcHagaki2_Changed;
                
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error" + i);
            }
        }

        private void UcHagaki1_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User1.Visible = true;
            btn_SuaVaLuu_User2.Visible = false;

        }

        private void UcHagaki2_Changed(object sender, EventArgs e)
        {
            btn_Luu_DeSo2.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User2.Visible = true;
            btn_SuaVaLuu_User1.Visible = false;
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                var nhap = (from w in Global.Db.tbl_Images where w.fbatchname == Global.StrBatch && w.ReadImageDEJP >= 2 select w.idimage).Count();
                var sohinh = (from w in Global.Db.tbl_Images where w.fbatchname == Global.StrBatch select w.idimage).Count();
                var check = (from w in Global.Db.tbl_MissImage_DEJPs where w.fBatchName == Global.StrBatch && w.Submit == 0 select w.IdImage).Count();
                if (sohinh > nhap)
                {
                    MessageBox.Show(@"Not finished DeJP!");
                    return;
                }
                if (check > 0)
                {
                    var listUser = (from w in Global.Db.tbl_MissImage_DEJPs where w.fBatchName == Global.StrBatch && w.Submit == 0 select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in listUser)
                    {
                        sss += item + "\r\n";
                    }

                    if (listUser.Count > 0)
                    {
                        MessageBox.Show("Danh sách User lấy về mà chưa nhập: \r\n" + sss);
                        return;
                    }
                }
                string temp = GetImage_DeJP();
                if (temp == "NULL")
                {ucPictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Finished batch '" + cbb_Batch_Check.Text + "'");
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show(@"Can not load image!");
                    return;
                }
                Load_DeJP(Global.StrBatch, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
                btn_Start.Visible = false;
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void Load_DeJP(string strBatch, string idimage)
        {
            try
            {
                var deso = (from w in Global.Db.tbl_DEJPs where w.fBatchName == strBatch && w.IdImage == idimage
                            select new
                            {
                                w.UserName,
                                w.Truong_01,
                                w.Truong_02,
                                w.Truong_03,
                                w.Truong_04,
                                w.Truong_05,
                                w.Truong_06,
                                w.Truong_07,
                                w.Truong_08
                            }).ToList();
               
                    lb_username1.Text = deso[0].UserName;
                    lb_username2.Text = deso[1].UserName;
                //load user 1
                uc_Hagaki_Check1.txt_Truong01.Text = deso[0].Truong_01;
                uc_Hagaki_Check1.rt_Truong02.Text = deso[0].Truong_02;
                uc_Hagaki_Check1.rt_Trupng03.Text = deso[0].Truong_03;
                uc_Hagaki_Check1.rt_Truong04.Text = deso[0].Truong_04;
                uc_Hagaki_Check1.rt_Truong05.Text = deso[0].Truong_05;
                uc_Hagaki_Check1.txt_Truong06.Text = deso[0].Truong_06;
                uc_Hagaki_Check1.txt_Truong07.Text = deso[0].Truong_07;
                uc_Hagaki_Check1.cbx_Truong08.Text = deso[0].Truong_08;
                //load user 2
                uc_Hagaki_Check2.txt_Truong01.Text = deso[1].Truong_01;
                uc_Hagaki_Check2.rt_Truong02.Text = deso[1].Truong_02;
                uc_Hagaki_Check2.rt_Trupng03.Text = deso[1].Truong_03;
                uc_Hagaki_Check2.rt_Truong04.Text = deso[1].Truong_04;
                uc_Hagaki_Check2.rt_Truong05.Text = deso[1].Truong_05;
                uc_Hagaki_Check2.txt_Truong06.Text = deso[1].Truong_06;
                uc_Hagaki_Check2.txt_Truong07.Text = deso[1].Truong_07;
                uc_Hagaki_Check2.cbx_Truong08.Text = deso[1].Truong_08;
                //Compare
                 Compare_TextBox(uc_Hagaki_Check1.txt_Truong01,uc_Hagaki_Check2.txt_Truong01);
                Compare_Textbox_Word(uc_Hagaki_Check1.rt_Truong02, uc_Hagaki_Check2.rt_Truong02);
                Compare_Textbox_Word(uc_Hagaki_Check1.rt_Trupng03, uc_Hagaki_Check2.rt_Trupng03);
                Compare_Textbox_Word(uc_Hagaki_Check1.rt_Truong04, uc_Hagaki_Check2.rt_Truong04);
                Compare_Textbox_Word(uc_Hagaki_Check1.rt_Truong05, uc_Hagaki_Check2.rt_Truong05);
                Compare_TextBox(uc_Hagaki_Check1.txt_Truong06, uc_Hagaki_Check2.txt_Truong06);
                Compare_TextBox(uc_Hagaki_Check1.txt_Truong07, uc_Hagaki_Check2.txt_Truong07);
                Compare_ComBoBox(uc_Hagaki_Check1.cbx_Truong08, uc_Hagaki_Check2.cbx_Truong08);
             var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(Global.StrBatch) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error loading data: " + i.Message);
            }
        }

      
        private string GetImage_DeJP()
        {
            LockControl(true);
            var temp = (from w in Global.Db.tbl_MissCheck_DEJPs where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0 select w.IdImage).FirstOrDefault();
            if (string.IsNullOrEmpty(temp))
            {
                var getFilename = (from w in Global.Db.GetImageCheck_DeJP(Global.StrBatch, Global.StrUsername) select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(getFilename))
                    return "NULL";
                lb_Image.Text = getFilename;
                ucPictureBox1.imageBox1.Image = null;
                if (ucPictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
                {
                    ucPictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            else
            {
                lb_Image.Text = temp;
                ucPictureBox1.imageBox1.Image = null;
                if (ucPictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp, Settings.Default.ZoomImage) == "Error")
                {
                    ucPictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            }
            timer1.Enabled = true;
            return "Ok";
        }

        private void btn_Luu_DeJP1_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc_Hagaki_Check1.IsEmpty())
                {
                    MessageBox.Show("Tất cả các trường đều trống, vui lòng kiểm tra lại", "Thông báo!");
                    return;
                }

                string dk = uc_Hagaki_Check1.DieuKienTruong();
                if (dk != "Ok")
                {
                    MessageBox.Show(dk);
                    return;
                }
                Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
               // Global.Db.LuuDEJP(lb_Image.Text, Global.StrBatch, lb_username1.Text, lb_username2.Text, Global.StrUsername);
                Global.Db.LuuDEJP(lb_Image.Text, Global.StrBatch, lb_username1.Text, lb_username2.Text, Global.StrUsername);
                ResetData();
                var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(Global.StrBatch) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
                if (version != Global.Version)
                {
                    MessageBox.Show(@"The current version is out of date, please update to the new version!");
                    Process.Start(Global.UrlUpdateVersion);
                    Application.Exit();
                }
                string temp = GetImage_DeJP();

                if (temp == "NULL")
                {
                    ucPictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Finished batch '" + cbb_Batch_Check.Text + "'");
                    LoadBatchMoi();
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show(@"Can not load image!");
                    btn_Luu_DeSo1.Visible = false;
                    btn_Luu_DeSo2.Visible = false;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                    return;
                }
                Load_DeJP(Global.StrBatch, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error : " + i.Message);
            }
        }
        private void btn_Luu_DeJP2_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc_Hagaki_Check2.IsEmpty())
                {
                    MessageBox.Show("Tất cả các trường đều trống, vui lòng kiểm tra lại", "Thông báo!");
                    return;
                }

                string dk = uc_Hagaki_Check2.DieuKienTruong();
                if (dk != "Ok")
                {
                    MessageBox.Show(dk);
                    return;
                }
                Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
                Global.Db.LuuDEJP(lb_Image.Text, Global.StrBatch, lb_username2.Text, lb_username1.Text, Global.StrUsername);

                var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(Global.StrBatch) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                ResetData();
                var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
                if (version != Global.Version)
                {
                    MessageBox.Show(@"The current version is out of date, please update to the new version!");
                    Process.Start(Global.UrlUpdateVersion);
                    Application.Exit();
                }
                string temp = GetImage_DeJP();

                if (temp == "NULL")
                {
                    ucPictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Finished batch '" + cbb_Batch_Check.Text + "'");
                    LoadBatchMoi();
                    return;
                }
                if (temp == "Error")
                {
                    MessageBox.Show(@"Can not load image!");
                    btn_Luu_DeSo1.Visible = false;
                    btn_Luu_DeSo2.Visible = false;
                    btn_SuaVaLuu_User1.Visible = false;
                    btn_SuaVaLuu_User2.Visible = false;
                    return;
                }
                Load_DeJP(Global.StrBatch, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error : " + i.Message);
            }
        }
        private void btn_SuaVaLuu_User1_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc_Hagaki_Check1.IsEmpty())
                {
                    MessageBox.Show("Tất cả các trường đều trống, vui lòng kiểm tra lại", "Thông báo!");
                    return;
                }

                string dk = uc_Hagaki_Check1.DieuKienTruong();
                if (dk != "Ok")
                {
                    MessageBox.Show(dk);
                    return;
                }
                Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
                uc_Hagaki_Check1.SuaVaLuu(lb_username1.Text, lb_username2.Text, lb_Image.Text);
                ResetData();
                var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(Global.StrBatch) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
                if (version != Global.Version)
                {
                    MessageBox.Show(@"The current version is out of date, please update to the new version!");
                    Process.Start(Global.UrlUpdateVersion);
                    Application.Exit();
                }
                if (GetImage_DeJP() == "NULL")
                {
                    ucPictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Finished batch '" + cbb_Batch_Check.Text + "'");
                    LoadBatchMoi();
                    return;
                }
                Load_DeJP(Global.StrBatch, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error : " + i.Message);
            }
        }

        private void btn_SuaVaLuu_User2_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc_Hagaki_Check2.IsEmpty())
                {
                    MessageBox.Show("Tất cả các trường đều trống, vui lòng kiểm tra lại", "Thông báo!");
                    return;
                }

                string dk = uc_Hagaki_Check2.DieuKienTruong();
                if (dk != "Ok")
                {
                    MessageBox.Show(dk);
                    return;
                }
                Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
                uc_Hagaki_Check2.SuaVaLuu(lb_username2.Text, lb_username1.Text, lb_Image.Text);
                ResetData();
                var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(Global.StrBatch) select w.Column1).FirstOrDefault();
                lb_Loi.Text = soloi + @" Error";
                var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
                if (version != Global.Version)
                {
                    MessageBox.Show(@"The current version is out of date, please update to the new version!");
                    Process.Start(Global.UrlUpdateVersion);
                    Application.Exit();
                }
                if (GetImage_DeJP() == "NULL")
                {
                    ucPictureBox1.imageBox1.Image = null;
                    MessageBox.Show(@"Finished batch '" + cbb_Batch_Check.Text + "'");
                    LoadBatchMoi();
                    return;
                }
                Load_DeJP(Global.StrBatch, lb_Image.Text);
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                btn_SuaVaLuu_User1.Visible = false;
                btn_SuaVaLuu_User2.Visible = false;
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error : " + i.Message);
            }
        }

        private void cbb_Batch_Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Luu_DeSo1.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_User1.Visible = false;
            btn_SuaVaLuu_User2.Visible = false;
            Global.StrBatch = cbb_Batch_Check.Text;
            var soloi = (from w in Global.Db.GetSoLoi_CheckDeJP(cbb_Batch_Check.Text) select w.Column1).FirstOrDefault();
            lb_Loi.Text = soloi + @" Error";
            ResetData();
            btn_Start.Visible = true;
        }

        private void FrmCheckDeSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.PageUp)
                ucPictureBox1.btn_Xoaytrai_Click(null, null);
            if (e.Control && e.KeyCode == Keys.PageDown)
                ucPictureBox1.btn_xoayphai_Click(null, null);
        }

        private void lb_Image_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Image.Text);
            XtraMessageBox.Show("Copy Success!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LockControl(false);
            timer1.Enabled = false;
        }
        private void LockControl(bool kt)
        {
            if (kt)
            {
                btn_Luu_DeSo1.Enabled = false;
                
                btn_Luu_DeSo2.Enabled = false;
                
            }
            else
            {
                btn_Luu_DeSo1.Enabled = true;
                btn_Luu_DeSo2.Enabled = true;
            }
        }
               
    }
}