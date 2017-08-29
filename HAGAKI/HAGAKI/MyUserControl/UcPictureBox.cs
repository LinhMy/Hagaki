using System;
using System.Drawing;
using System.Windows.Forms;
using HAGAKI.Properties;

namespace HAGAKI.MyUserControl
{
    public delegate void FocusPictureBox(object sender, EventArgs e);
    public partial class UcPictureBox : System.Windows.Forms.UserControl
    {
        public event FocusPictureBox FocusPicture;
        public event FocusPictureBox FocusPictureLeave;
        private Image _temp;
        public int ZoomMinimum = 10;
        public int ZoomMax = 500;

        public UcPictureBox()
        {
            InitializeComponent();
        }

        public void AllowZoom(bool b)
        {
            imageBox1.AllowZoom = b;
        }

        public string LoadImage(string strUrl, string strFileName, int iZoomValue)
        {
            try
            {
                PictureBox temp = new PictureBox();
                temp.Load(strUrl);
                imageBox1.Image = temp.Image;
                temp.Dispose();
                imageBox1.SizeMode = ImageGlass.ImageBoxSizeMode.Normal;
                imageBox1.Image.Tag = strFileName;

                Bitmap bmap = new Bitmap(imageBox1.Image, new Size(Settings.Default.Zoom_Doc, Settings.Default.Zoom_Ngang));
                Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                bmap.Dispose();
                imageBox1.Image = null;
                imageBox1.Image = _temp = newmap;
                imageBox1.Zoom = iZoomValue;
                imageBox1.ZoomChanged += imageBox1_ZoomChanged;
            }
            catch (Exception)
            {
                return "Error";
            }
            return "Ok";
        }

        public void SetMinMaxValue(int min, int max)
        {
            ZoomMinimum = min;
            ZoomMax = max;
        }

        private void imageBox1_ZoomChanged(object sender, EventArgs e)
        {
            if (imageBox1.Zoom < ZoomMinimum)
                imageBox1.Zoom = ZoomMinimum;
            if (imageBox1.Zoom > ZoomMax)
                imageBox1.Zoom = ZoomMax;
        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            imageBox1.SizeMode = ImageGlass.ImageBoxSizeMode.Normal;
        }

        private void imageBox1_MouseHover(object sender, EventArgs e)
        {
            imageBox1.AllowZoom = true;
            FocusPicture?.Invoke(sender,e);
        }

        private void imageBox1_MouseLeave(object sender, EventArgs e)
        {
            imageBox1.AllowZoom = false;
            FocusPictureLeave?.Invoke(sender,e);
        }

        public void btn_Xoaytrai_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(trackBar_Ngang.Value.ToString() + "/" + trackBar_Doc.Value.ToString());
            if (imageBox1.Image != null)
            {
                trackBar_Ngang.Value = imageBox1.Image.Height;
                trackBar_Doc.Value = imageBox1.Image.Width;

                Bitmap bmp = new Bitmap(imageBox1.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipXY);
                imageBox1.Image = _temp = bmp;
            }
        }

        public void btn_xoayphai_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                trackBar_Ngang.Value = imageBox1.Image.Height;
                trackBar_Doc.Value = imageBox1.Image.Width;

                Bitmap bmp = new Bitmap(imageBox1.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                imageBox1.Image = _temp = bmp;
            }
        }

        private void trackBar_Ngang_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(trackBar_Ngang.Value) < 500)
                    return;
                Settings.Default.Zoom_Ngang = Convert.ToInt32(trackBar_Ngang.Value);
                Settings.Default.Save();

                Bitmap bmap = new Bitmap(_temp, new Size(Convert.ToInt32(trackBar_Ngang.Value), Convert.ToInt32(trackBar_Doc.Value)));
                Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                bmap.Dispose();
                imageBox1.Image = null;
                imageBox1.Image = newmap;
            }
            catch (Exception i) { MessageBox.Show(@"You have not loaded the image yet. Load the image before zooming! \n Error " + i.Message); }
        }

        private void uc_PictureBox_Load(object sender, EventArgs e)
        {
            trackBar_Ngang.Value = Settings.Default.Zoom_Ngang;
            trackBar_Doc.Value = Settings.Default.Zoom_Doc;
        }

        private void trackBar_Doc_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(trackBar_Doc.Value) < 500)
                    return;
                Settings.Default.Zoom_Doc = Convert.ToInt32(trackBar_Doc.Value);
                Settings.Default.Save();
                Bitmap bmap = new Bitmap(_temp, new Size(Convert.ToInt32(trackBar_Ngang.Value), Convert.ToInt32(trackBar_Doc.Value)));
                Bitmap newmap = bmap.Clone(new Rectangle(0, 0, bmap.Width, bmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                bmap.Dispose();
                imageBox1.Image = null;
                imageBox1.Image = newmap;
            }
            catch (Exception i) { MessageBox.Show(@"You have not loaded the image yet. Load the image before zooming! \n Error " + i.Message); }
        }
    }
}