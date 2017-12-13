using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HAGAKI.MyClass;
using ImageGlass;

namespace HAGAKI.MyUserControl
{
    public partial class uc_FeedBack_Hagaki : UserControl
    {
        public uc_FeedBack_Hagaki()
        {
            InitializeComponent();
        }

        public void LoadImage(string fbatchname, string url_image, string idimage)
        {
            ucPictureBox1.LoadImage(url_image, idimage, 100);
            ucPictureBox1.imageBox1.SizeMode = ImageBoxSizeMode.Fit;
            LoadText_User(fbatchname, idimage);
            LoadChecker(fbatchname, idimage);
            SoSanhCompare();
        }

        public void LoadText_User(string fbatchname, string idimage)
        {
            var deso = (from w in Global.Db.tbl_DEJP_Backups
                        where w.fBatchName == fbatchname && w.IdImage == idimage
                        orderby w.IdImage ascending, w.UserName ascending
                        select w).ToList();

           uc_FeddBack1.lb_User.Text = deso[0].UserName;
            uc_FeddBack1.LoadData(deso[0]);

            uc_FeddBack2.lb_User.Text = deso[1].UserName;
            uc_FeddBack2.LoadData(deso[1]);
        }

        public void LoadChecker(string fbatchname, string idimage)
        {
            var deso = (from w in Global.Db.tbl_DEJPs
                        where w.fBatchName == fbatchname && w.UserName == "Checker" && w.IdImage == idimage
                        orderby w.IdImage ascending, w.UserName ascending
                        select w).ToList();
            var nameCheck = (from w in Global.Db.tbl_MissCheck_DEJPs
                             where w.fBatchName == fbatchname && w.IdImage == idimage
                             select w.UserName).FirstOrDefault();
            uc_FeddBack3.lb_User.Text = nameCheck;   // deso[0].UserName;
            uc_FeddBack3.LoadDataChecker(deso[0]);
        }

        public void LoadImageUser(string user, string fbatchname, string urlImage, string idimage)
        {
            ucPictureBox1.LoadImage(urlImage, idimage, 100);
            ucPictureBox1.imageBox1.SizeMode = ImageBoxSizeMode.Fit;
            LoadText_User(user, fbatchname, idimage);
            LoadChecker_User(fbatchname, idimage);
            SoSanhTextBoxSingle();
        }

        public void LoadText_User(string user, string fbatchname, string idimage)
        {
            var deso = (from w in Global.Db.tbl_DEJP_Backups
                        where w.fBatchName == fbatchname && w.IdImage == idimage && w.UserName == user
                        orderby w.IdImage ascending, w.UserName ascending
                        select w).ToList();
           uc_FeddBack2.lb_User.Text = deso[0].UserName;
           uc_FeddBack2.LoadData(deso[0]);
        }

        public void LoadChecker_User(string fbatchname, string idimage)
        {
            var deso = (from w in Global.Db.tbl_DEJPs
                        where w.fBatchName == fbatchname && w.IdImage == idimage && w.UserName == "Checker"
                        orderby w.IdImage ascending, w.UserName ascending
                        select w).ToList();
           uc_FeddBack3.lb_User.Text = deso[0].UserName;
           uc_FeddBack3.LoadDataChecker(deso[0]);
        }
        
        private void changeColorUser_Single(TextBox txt1, TextBox txt2)
        {
            if (txt1.Text != txt2.Text)
            {
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Red;
                txt2.ForeColor = Color.White;
                txt2.BackColor = Color.Green;
            }
            else
            {
                txt1.ForeColor = Color.Black;
                txt1.BackColor = Color.White;
                txt2.ForeColor = Color.Black;
                txt2.BackColor = Color.White;
            }
        }
        
        private void changeColorCompare(TextBox txt1, TextBox txt2, TextBox txt3)
        {
            if (txt1.Text != txt3.Text)
            {                   
                    txt1.ForeColor = Color.White;
                    txt1.BackColor = Color.Red;
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                    txt3.ForeColor = Color.White;
                    txt3.BackColor = Color.Green;
                if (txt2.Text != txt3.Text)
                {
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Red;
                }
                else if (txt2.Text == txt3.Text)
                {
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                }
            }
                if (txt2.Text != txt3.Text)
                {                   
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Red;
                    txt3.ForeColor = Color.White;
                    txt3.BackColor = Color.Green;
                if (txt1.Text != txt3.Text)
                {
                    txt1.ForeColor = Color.White;
                    txt1.BackColor = Color.Red;
                }
                else if(txt1.Text == txt3.Text)
                {
                    txt1.ForeColor = Color.White;
                    txt1.BackColor = Color.Green;
                }
                }          
        }                  
        private void SoSanhTextBoxSingle()
        {
            changeColorUser_Single(uc_FeddBack2.txt_Truong01, uc_FeddBack3.txt_Truong01);
            changeColorUser_Single(uc_FeddBack2.txt_Truong02, uc_FeddBack3.txt_Truong02);
            changeColorUser_Single(uc_FeddBack2.txt_Truong03, uc_FeddBack3.txt_Truong03);
            changeColorUser_Single(uc_FeddBack2.txt_Truong04, uc_FeddBack3.txt_Truong04);
            changeColorUser_Single(uc_FeddBack2.txt_Truong05, uc_FeddBack3.txt_Truong05);
            changeColorUser_Single(uc_FeddBack2.txt_Truong06, uc_FeddBack3.txt_Truong06);
            changeColorUser_Single(uc_FeddBack2.txt_Truong07, uc_FeddBack3.txt_Truong07);
            changeColorUser_Single(uc_FeddBack2.txt_Truong08, uc_FeddBack3.txt_Truong08);
        }        
        private void SoSanhCompare()
        {
            changeColorCompare(uc_FeddBack1.txt_Truong01, uc_FeddBack2.txt_Truong01, uc_FeddBack3.txt_Truong01);
            changeColorCompare(uc_FeddBack1.txt_Truong02, uc_FeddBack2.txt_Truong02, uc_FeddBack3.txt_Truong02);
            changeColorCompare(uc_FeddBack1.txt_Truong03, uc_FeddBack2.txt_Truong03, uc_FeddBack3.txt_Truong03);
            changeColorCompare(uc_FeddBack1.txt_Truong04, uc_FeddBack2.txt_Truong04, uc_FeddBack3.txt_Truong04);
            changeColorCompare(uc_FeddBack1.txt_Truong05, uc_FeddBack2.txt_Truong05, uc_FeddBack3.txt_Truong05);
            changeColorCompare(uc_FeddBack1.txt_Truong06, uc_FeddBack2.txt_Truong06, uc_FeddBack3.txt_Truong06);
            changeColorCompare(uc_FeddBack1.txt_Truong07, uc_FeddBack2.txt_Truong07, uc_FeddBack3.txt_Truong07);
            changeColorCompare(uc_FeddBack1.txt_Truong08, uc_FeddBack2.txt_Truong08, uc_FeddBack3.txt_Truong08);

        }
    }
    }
