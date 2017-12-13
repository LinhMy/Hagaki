using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAGAKI.MyClass;
using HAGAKI.MyUserControl;

namespace HAGAKI.MyForm
{
    public partial class FrmFeedback : XtraForm
    {
        public static int Num = 0;
        public FrmFeedback()
        {
            InitializeComponent();
        }

        private void LoadUser()
        {
            if (chb_User.Checked)
            {
                cbb_username.Visible = true;
                cbb_username.Text = "";
                cbb_username.DataSource = Global.Db.GetUserFailDeJP_Getsu(cbb_batch.Text);
                cbb_username.DisplayMember = "UserName";
            }
            if (chb_User.Checked == false)
            {
                cbb_username.Visible = false;
            }
        }

        private void GetImageDeso(int n)
        {
            string NameUserChecker = "Checker%";
            var idimage =(from w in (Global.Db.GetImageFail_Getsu(NameUserChecker, cbb_batch.Text)) select w.IdImage).ToList();
         lb_soloi.Text = idimage.Count.ToString();

            if ((n + 50) < idimage.Count && n >= 0)
            {
                btn_next.Enabled = true;
                for (int j = n; j <= n + 49; j++)
                {
                    string id = idimage[j];
                    uc_FeedBack_Hagaki ucF = new uc_FeedBack_Hagaki();
                    ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;
                    ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImage(cbb_batch.Text, url, id);
                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls){
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.Location = p;
                    ucF.textBox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);}
            }
            else if ((n + 50) >= idimage.Count && n >= 0)
            {
                btn_next.Enabled = false;
                for (int j = n; j <= idimage.Count - 1; j++)
                {
                    string id = idimage[j];
                    uc_FeedBack_Hagaki ucF = new uc_FeedBack_Hagaki();
                    ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;
                    ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImage(cbb_batch.Text, url, id);

                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.Location = p;
                   ucF.textBox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);
                }
            }
        }

        private void GetImageDesoUser(int n)
        {

            var idimage =(from w in (Global.Db.GetImageFailUserDeJP_Getsu(cbb_username.Text, cbb_batch.Text)) select w.IdImage).ToList();
            lb_soloi.Text = idimage.Count.ToString();
            if ((n + 8) < idimage.Count && n >= 0)
            {
                btn_next.Enabled = true;
                for (int j = n; j <= n + 7; j++)
                {
                    string id = idimage[j];
                    uc_FeedBack_Hagaki ucF = new uc_FeedBack_Hagaki();
                    ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImageUser(cbb_username.Text, cbb_batch.Text, url, id);
                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.uc_FeddBack1.Visible = false;
                    ucF.Location = p;
                   ucF.textBox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);
                }
            }
            else if ((n + 8) >= idimage.Count && n >= 0)
            {
                btn_next.Enabled = false;
                for (int j = n; j <= idimage.Count - 1; j++){
                    string id = idimage[j];
                    uc_FeedBack_Hagaki ucF = new uc_FeedBack_Hagaki();
                    ucF.ucPictureBox1.FocusPicture += UcF_FocusPicture;
                    ucF.ucPictureBox1.FocusPictureLeave += UcPictureBox1_FocusPictureLeave;
                    string url = Global.Webservice + cbb_batch.Text + "/" + id;
                    ucF.LoadImageUser(cbb_username.Text, cbb_batch.Text, url, id);
                    Point p = new Point();
                    foreach (Control ct in pnl_Mainfeedback1.Controls)
                    {
                        p = ct.Location;
                        p.Y += ct.Size.Height;
                    }
                    ucF.uc_FeddBack1.Visible = false;
                    ucF.Location = p;
                   ucF.textBox1.Text = (j + 1).ToString();
                    pnl_Mainfeedback1.Controls.Add(ucF);
                }
            }
        }
        
        private int _a;
        private bool _b = true;
        private void UcF_FocusPicture(object sender, EventArgs e)
        {
            _a = pnl_Mainfeedback1.VerticalScroll.Value;
            _b = false;
        }
        private void UcPictureBox1_FocusPictureLeave(object sender, EventArgs e)
        {
            _b = true;
        }

        private void frmFeedback_Load(object sender, EventArgs e)
        {
            cbb_batch.DataSource = Global.Db.GetBatch_Feedback_Getsu();
            cbb_batch.DisplayMember = "fBatchName";
            cbb_batch.ValueMember = "IDBatch";
            cbb_batch.Text = Global.StrBatch;
            Num = 0;
            pnl_Mainfeedback1.MouseWheel += Pnl_Mainfeedback1_MouseWheel;
        }
        private void Pnl_Mainfeedback1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_b)
                pnl_Mainfeedback1.VerticalScroll.Value = _a;
        }
        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            try
            {
                Num = 0;
                lb_soloi.Text = @"0";
                pnl_Mainfeedback1.Controls.Clear();
                GC.Collect();
                btn_back.Enabled = false;

                if (chb_User.Checked)
                {
                    GetImageDesoUser(Num);
                }
                if (chb_User.Checked == false)
                {
                    GetImageDeso(Num);
                }
            }
            catch (Exception w) { MessageBox.Show(@"Can not retrieve data. Error:" + w); }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                Num += 50;
                if (Num < 50)
                {
                    btn_back.Enabled = false;
                }
                else
                {
                    btn_back.Enabled = true;
                }
                pnl_Mainfeedback1.Controls.Clear();
                GC.Collect();
                
                if (chb_User.Checked)
                {
                    GetImageDesoUser(Num);
                }
                if (chb_User.Checked == false)
                {
                    GetImageDeso(Num);
                }
            }
            catch (Exception w) { MessageBox.Show(@"Can not retrieve data. Error: " + w); }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            try
            {
                Num -= 50;
                if (Num < 50)
                {
                    btn_back.Enabled = false;
                }
                else
                {
                    btn_back.Enabled = true;
                }
                pnl_Mainfeedback1.Controls.Clear();
                GC.Collect();
                
                if (chb_User.Checked)
                {
                    GetImageDesoUser(Num);
                }
                if (chb_User.Checked == false)
                {
                    GetImageDeso(Num);
                }
            }
            catch (Exception w) { MessageBox.Show(@"Can not retrieve data. Error: " + w); }
        }

        private void cbb_batch_TextChanged(object sender, EventArgs e)
        {
            pnl_Mainfeedback1.Controls.Clear();
            btn_back.Enabled = false;
            btn_next.Enabled = false;
            LoadUser();
        }
        
        private void chb_User_CheckedChanged(object sender, EventArgs e)
        {
            pnl_Mainfeedback1.Controls.Clear();
            btn_back.Enabled = false;
            btn_next.Enabled = false;
            LoadUser();
        }

        private void cbb_username_TextChanged(object sender, EventArgs e)
        {
            pnl_Mainfeedback1.Controls.Clear();
            btn_back.Enabled = false;
            btn_next.Enabled = false;
        }

       }
}