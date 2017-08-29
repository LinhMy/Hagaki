using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using HAGAKI.MyClass;
using HAGAKI.Properties;
using Application = System.Windows.Forms.Application;

namespace HAGAKI.MyForm
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        private bool _lock;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void SetValue()
        {
                lb_SoHinhConLai.Text = (from w in Global.Db.tbl_Images
                                        where
                                        w.ReadImageDEJP < 2 && w.fbatchname == Global.StrBatch &&
                                        (w.UserNameDEJP!= Global.StrUsername || w.UserNameDEJP == null || w.UserNameDEJP == "")
                                        select w.idimage).Count().ToString();
                lb_SoHinhLamDuoc.Text = (from w in Global.Db.tbl_MissImage_DEJPs
                                         where w.UserName == Global.StrUsername && w.fBatchName == Global.StrBatch
                                         select w.IdImage).Count().ToString();
        }

        public string GetImage()
        {
                string temp = (from w in Global.Db.tbl_MissImage_DEJPs
                               where w.fBatchName == Global.StrBatch && w.UserName == Global.StrUsername && w.Submit == 0
                               select w.IdImage).FirstOrDefault();
                if (string.IsNullOrEmpty(temp))
                {
                    try
                    {
                        var getFilename =
                            (from w in Global.Db.LayHinhMoi_DeJP(Global.StrBatch, Global.StrUsername)
                             select w.Column1).FirstOrDefault();
                        if (string.IsNullOrEmpty(getFilename))
                        {
                            return "NULL";
                        }
                        lb_IdImage.Text = getFilename;
                        ucPictureBox1.imageBox1.Image = null;
                        if (ucPictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + getFilename, getFilename,
                            Settings.Default.ZoomImage) == "Error")
                        {
                            ucPictureBox1.imageBox1.Image = Resources.svn_deleted;
                            return "Error";

                        }
                    }
                    catch (Exception i)
                    {
                        return "NULL";
                    }
                }
                else
                {
                    lb_IdImage.Text = temp;
                    ucPictureBox1.imageBox1.Image = null;
                    if (ucPictureBox1.LoadImage(Global.Webservice + Global.StrBatch + "/" + temp, temp,
                       Settings.Default.ZoomImage) == "Error")
                    {
                        ucPictureBox1.imageBox1.Image = Resources.svn_deleted;
                       return "Error";
                    }
                }
           return "OK";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           try
            {
                Global.FreeTime = 0;
                _lock = false;
                lb_IdImage.Text = "";
                UserLookAndFeel.Default.SkinName = Settings.Default.ApplicationSkinName;
                lb_fBatchName.Text = Global.StrBatch;
                lb_UserName.Text = Global.StrUsername;
                SetValue();
                bar_Manager.Enabled = false;
                btn_Stop_Performance_Test.Enabled = false;
                bar_Manager.Enabled = false;
              
                if (Global.StrRole == "DEJP")
                {
                    Global.FlagTong = true;
                    bar_Manager.Enabled = false;
                    btn_Submit_Logout.Enabled = false;
                    btn_ZoomImage.Enabled = false;
                    btn_Check.Enabled = false;
                }
                else if (Global.StrRole == "ADMIN")
                {
                    Global.FlagTong = false;
                    btn_Start_Submit.Enabled = false;
                    btn_Submit_Logout.Enabled = false;
                    btn_ZoomImage.Enabled = true;
                    bar_Manager.Enabled = true;
                    btn_Check.Enabled = true;
                }
                else if ( Global.StrRole == "CHECKERDEJP" || Global.StrRole == "CHECKERDECHU" || Global.StrRole == "CHECKERDESO")
                {
                    Global.FlagTong = false;
                    btn_Start_Submit.Enabled = false;
                    btn_Submit_Logout.Enabled = false;
                    btn_ZoomImage.Enabled = true;
                    bar_Manager.Enabled = false;
                    btn_Check.Enabled = true;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error Load Main: " + i.Message);
            }
        }

        private void btn_Start_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
                //Kiểm tra token
                var token = (from w in Global.DbBpo.tbl_TokenLogins
                    where w.UserName == Global.StrUsername && w.IDProject == Global.StrIdProject
                    select w.Token).FirstOrDefault();

                if (token != Global.StrToken)
                {
                    MessageBox.Show(@"User logged on to another PC, please login again!");
                    DialogResult = DialogResult.Yes;
                }
                if (btn_Start_Submit.Text == @"Start")
                {

                    if (string.IsNullOrEmpty(Global.StrBatch))
                    {
                        MessageBox.Show(@"Please log in again and select Batch!");
                        return;
                    }
                    string temp = GetImage();
                    if (temp == "NULL")
                    {
                        SetValue();
                        btn_Start_Submit.Text = @"Start";
                        btn_Start_Submit_Click(null, null);
                        }
                    if (temp == "Error"){
                        MessageBox.Show(@"Can not load image!");
                        btn_Logout_ItemClick(null, null);
                    }
                    //uc_So1.ResetData();
                    //uc_Chu1.ResetData();
                    btn_Start_Submit.Text = @"Submit";

                }
                else
                {
                   if (Global.StrRole == "DEJP")
                        {
                            //uc_Chu1.SaveData(lb_IdImage.Text);
                            //uc_Chu1.ResetData();
                           var version = (from w in Global.DbBpo.tbl_Versions
                                where w.IDProject == Global.StrIdProject
                                select w.IDVersion).FirstOrDefault();
                            if (version != Global.Version)
                            {
                                MessageBox.Show(@"The current version is out of date, please update to the new version!");
                                Process.Start(Global.UrlUpdateVersion);
                                Application.Exit();
                            }

                        }
                        SetValue();
                    }
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error Submit" + i.Message);
            }
        }

        private void btn_Submit_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
                //Kiểm tra token
                var token = (from w in Global.DbBpo.tbl_TokenLogins where w.UserName == Global.StrUsername && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();

                if (token != Global.StrToken)
                {
                    MessageBox.Show(@"User logged on to another PC, please login again!");
                    DialogResult = DialogResult.Yes;
                }
                
                //uc_Chu1.SaveData(lb_IdImage.Text);
                btn_Logout_ItemClick(null, null);
            }
            catch (Exception i)
            {
                MessageBox.Show(@"Error Submit" + i.Message);
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (_lock==false)
            {
                if (e.Control && e.KeyCode == Keys.Enter)
                    btn_Start_Submit_Click(null, null);
                if (e.Control && e.KeyCode == Keys.PageUp)
                    ucPictureBox1.btn_Xoaytrai_Click(null, null);
                if (e.Control && e.KeyCode == Keys.PageDown)
                    ucPictureBox1.btn_xoayphai_Click(null, null);
                if (e.KeyCode == Keys.Escape)
                {
                   // new FrmFreeTime().ShowDialog();
                    Global.DbBpo.UpdateTimeFree(Global.StrToken, Global.FreeTime);
                }
            }
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Global.DbBpo.UpdateTimeLastRequest(Global.StrToken);
            Global.DbBpo.UpdateTimeLogout(Global.StrToken);
            Global.DbBpo.ResetToken(Global.StrUsername, Global.StrIdProject, Global.StrToken);
            Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
            Global.FlagTong = false;
        }
        private void btn_Logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
        private void btn_ZoomImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmChangeZoom().ShowDialog();
            Settings.Default.Reload();
            GetImage();
        }
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            //new FrmFreeTime().ShowDialog();
            Global.DbBpo.UpdateTimeFree(Global.StrToken, Global.FreeTime);
        }
        private void btn_Batch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmManagerBatch().ShowDialog();
        }
        private void btn_User_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new FrmUser().ShowDialog();
        }
        private void btn_Check_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
                //new FrmCheckDeChu().ShowDialog();
        }
        private void btn_Progress_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new FrmTienDo().ShowDialog();
        }
        private void btn_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new FrmExportExcel().ShowDialog();
        }
        private void lb_IdImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_IdImage.Text);
            XtraMessageBox.Show("Copy Success!");
        }
        private void LockControl(bool kt)
        {
            if (kt)
            {
                _lock = true;
                btn_ZoomImage.Enabled = false;
                btn_Start_Submit.Enabled = false;
                btn_Submit_Logout.Enabled = false;
            }
            else
            {
                _lock = false;
                btn_ZoomImage.Enabled = true;
                btn_Start_Submit.Enabled = true;
                btn_Submit_Logout.Enabled = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LockControl(false);
            timer1.Enabled = false;
        }
        }
}