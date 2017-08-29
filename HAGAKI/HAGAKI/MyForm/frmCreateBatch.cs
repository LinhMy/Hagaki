using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HAGAKI.MyClass;

namespace HAGAKI.MyForm
{
    public partial class FrmCreateBatch : XtraForm
    {
        private string[] _lFileNames;
        private int _soluonghinh;
        private bool _multi;

        public FrmCreateBatch()
        {
            InitializeComponent();
        }

        private void frmCreateBatch_Load(object sender, EventArgs e)
        {
            txt_UserCreate.Text = Global.StrUsername;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + @"  -  " + DateTime.Now.ToShortTimeString();
        }

        private void btn_BrowserImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BatchName.Text))
            {
                MessageBox.Show(@"Please enter a batch name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = @"All Types Image|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _lFileNames = dlg.FileNames;
                txt_ImagePath.Text = Path.GetDirectoryName(dlg.FileName);
            }
            _soluonghinh = 0;
            _soluonghinh = dlg.FileNames.Length;
            lb_SoLuongHinh.Text = dlg.FileNames.Length + @" files ";
        }

        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void UpLoadSingle()
        {
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = _lFileNames.Length;
            progressBarControl1.Properties.Minimum = 0;
            var batch = (from w in Global.Db.tbl_Batches.Where(w => w.fBatchName == txt_BatchName.Text) select w.fBatchName).FirstOrDefault();
            if (!string.IsNullOrEmpty(txt_ImagePath.Text))
            {
                if (string.IsNullOrEmpty(batch))
                {
                    var fBatch = new tbl_Batch
                    {
                        fBatchName = txt_BatchName.Text,
                        fUserCreate = txt_UserCreate.Text,
                        fDateCreate = DateTime.Now,
                        fPathPicture = txt_ImagePath.Text,
                        fLocation = txt_Location.Text+"\\"+txt_BatchName.Text+"\\",
                        fSoLuongAnh = _soluonghinh.ToString(),
                        LoaiBatch = "Getsu",
                        CongKhaiBatch = false
                        //LoaiBatch = rg_LoaiBatch.Properties.Items[rg_LoaiBatch.SelectedIndex].Description
                    };
                    Global.Db.tbl_Batches.InsertOnSubmit(fBatch);
                    Global.Db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show(@"Batch exists please enter another batch name!");
                    return;
                }
            }
            else
            {
                MessageBox.Show(@"You have not selected an image yet!");
                return;
            }
            string temp = Global.StrPath + "\\" + txt_BatchName.Text;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            else
            {
                MessageBox.Show(@"Batch named batch!");
                return;
            }
            foreach (string i in _lFileNames)
            {
                FileInfo fi = new FileInfo(i);

                if (ck_ChiaUser.Checked)
                {
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDEJP = "Hình chưa nhập"
                    };
                    Global.Db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.Db.SubmitChanges();
                }
                else
                {
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = txt_BatchName.Text,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDEJP = "Hình chưa nhập"
                    };
                    Global.Db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.Db.SubmitChanges();
                }

                string des = temp + @"\" + Path.GetFileName(fi.ToString());
                fi.CopyTo(des);
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }
            MessageBox.Show(@"Create a new batch successfully!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";
        }
        private void UpLoadMulti()
        {
            List<string> lStrBath = new List<string>();
            lStrBath.AddRange(Directory.GetDirectories(txt_PathFolder.Text));
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = lStrBath.Count;
            progressBarControl1.Properties.Minimum = 0;
            foreach (string item in lStrBath)
            {
                string batchName = new DirectoryInfo(item).Name;
                var fBatch = new tbl_Batch
                {

                    fBatchName = batchName,
                    fUserCreate = txt_UserCreate.Text,
                    fDateCreate = DateTime.Now,
                    fPathPicture = item,
                    fLocation = txt_Location.Text + "\\" + batchName + "\\",
                    fSoLuongAnh = Directory.GetFiles(item).Length.ToString(),
                    LoaiBatch = "Getsu"
                };
                Global.Db.tbl_Batches.InsertOnSubmit(fBatch);
                Global.Db.SubmitChanges();

                string searchFolder = txt_PathFolder.Text + "\\" + new DirectoryInfo(item).Name;
                var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
                string[] tmp = GetFilesFrom(searchFolder, filters, false);
                string temp = Global.StrPath + "\\" + batchName;
                Directory.CreateDirectory(temp);
                string imageJPG = "";
                foreach (string i in tmp)
                {
                    FileInfo fi = new FileInfo(i);
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = batchName,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDEJP= "Hình chưa nhập"
                    };
                    Global.Db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.Db.SubmitChanges();
                    string des = temp + @"\" + Path.GetFileName(fi.ToString());
                    fi.CopyTo(des);
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();
                }
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }
            MessageBox.Show(@"Create a new batch successfully!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";
        }
        private void UpLoadMulti_5Folder()
        {
            List<string> lStrBath1 = new List<string>();
            List<string> lStrBath2 = new List<string>();
            List<string> lStrBath3 = new List<string>();
            List<string> lStrBath4 = new List<string>();
            lStrBath1.AddRange(Directory.GetDirectories(txt_PathFolder.Text));

            int k = 0;
            int total = lStrBath1.Count;
            string pathexcel = @"X:\" + new DirectoryInfo(txt_PathFolder.Text).Name;
            string s = new DirectoryInfo(txt_PathFolder.Text).Name;
            createFolder(s);
            foreach (string item1 in lStrBath1)
            {
                lbl_SoFolder.Text = k + @"/" + total;
                string pathexcel1 = pathexcel + @"\" + new DirectoryInfo(item1).Name;
                string litem1 = s + @"\" + new DirectoryInfo(item1).Name;
                createFolder(litem1);

                lStrBath2.Clear();
                lStrBath2.AddRange(Directory.GetDirectories(item1));
                if (lStrBath2.Count > 0)
                {
                    foreach (string item2 in lStrBath2)
                    {

                        string litem2 = litem1 + @"\" + new DirectoryInfo(item2).Name;
                        createFolder(litem2);

                        lStrBath3.Clear();
                        lStrBath3.AddRange(Directory.GetDirectories(item2));
                        if (lStrBath3.Count > 0)
                        {
                            foreach (string item3 in lStrBath3)
                            {
                                string pathexcel2 = pathexcel1 + @"\" + new DirectoryInfo(item3).Name;
                                string litem3 = litem2 + @"\" + new DirectoryInfo(item3).Name;
                                createFolder(litem3);

                                lStrBath4.Clear();
                                lStrBath4.AddRange(Directory.GetDirectories(item3));
                                if (lStrBath4.Count > 0)
                                {
                                    foreach (string item4 in lStrBath4)
                                    {
                                        string temp = new DirectoryInfo(item4).Name;
                                        if (temp.Substring(0, 7) == "2225000")
                                        {
                                            string pathexcel3 = pathexcel2 + @"\" + new DirectoryInfo(item4).Name + @"\";
                                            string litem4 = litem3 + @"\" + new DirectoryInfo(item4).Name;
                                            createFolder(litem4);

                                            createBatch(item4, Global.StrPath + @"\" + litem4, litem4, pathexcel3);
                                            
                                        }

                                    }
                                    
                                }
                            }
                           
                        }
                    }
                    
                }
                k++;
            }
            MessageBox.Show(@"Create a new batch successfully!");
            progressBarControl1.EditValue = 0;
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";
        }

        public void createBatch(string location, string server, string batch, string excellocation)
        {
            string batchName = new DirectoryInfo(location).Name;
            var fBatch = new tbl_Batch
            {

                fBatchName = batch,
                fDateCreate = DateTime.Now,
                fUserCreate = txt_UserCreate.Text,
                fPathPicture = location,
                fLocation = excellocation,
                fSoLuongAnh = Directory.GetFiles(location).Length.ToString(),
                LoaiBatch = "Getsu",
                CongKhaiBatch = false
            };
            Global.Db.tbl_Batches.InsertOnSubmit(fBatch);
            Global.Db.SubmitChanges();
            string imageJPG = "";

            var filters1 = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            string[] tmp1 = GetFilesFrom(location, filters1, false);
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Maximum = tmp1.Length;
            progressBarControl1.Properties.Minimum = 0;
            foreach (string s in tmp1)
            {
                FileInfo fi = new FileInfo(s);
                if (ck_ChiaUser.Checked)
                {
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = batch,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDEJP = "Hình chưa nhập"
                    };
                    Global.Db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.Db.SubmitChanges();
                }
                else
                {
                    tbl_Image tempImage = new tbl_Image
                    {
                        fbatchname = batch,
                        idimage = Path.GetFileName(fi.ToString()),
                        ReadImageDEJP = 0,
                        CheckedDEJP = 0,
                        TienDoDEJP  = "Hình chưa nhập"
                    };
                    Global.Db.tbl_Images.InsertOnSubmit(tempImage);
                    Global.Db.SubmitChanges();
                }
                string des = server + @"\" + Path.GetFileName(fi.ToString());
                fi.CopyTo(des);
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }
        }

        public void createFolder(string nameFolder)
        {
            string temp = Global.StrPath + "\\" + nameFolder;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
        }
        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastSelectedFolder))
            {
                folderBrowserDialog1.SelectedPath = Properties.Settings.Default.LastSelectedFolder;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_PathFolder.Text = folderBrowserDialog1.SelectedPath;
                if (!string.IsNullOrEmpty(txt_PathFolder.Text))
                {
                    Properties.Settings.Default.LastSelectedFolder = txt_PathFolder.Text;
                    Properties.Settings.Default.Save();
                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_multi)
            {
                UpLoadMulti_5Folder();
            }
            else
            {
                UpLoadSingle();
            }
        }

        private void txt_PathFolder_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PathFolder.Text))
            {
                _multi = true;
                txt_BatchName.Enabled = false;
                txt_ImagePath.Enabled = false;
                btn_BrowserImage.Enabled = false;
            }
            else
            {
                txt_BatchName.Enabled = true;
                txt_ImagePath.Enabled = true;
                btn_BrowserImage.Enabled = true;
            }
        }

        private void txt_BatchName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BatchName.Text))
            {
                _multi = false;
                txt_PathFolder.Enabled = false;
                btn_Browser.Enabled = false;
            }
            else
            {
                txt_PathFolder.Enabled = true;
                btn_Browser.Enabled = true;
            }
        }
    }
}