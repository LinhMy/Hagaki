using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HAGAKI.MyClass;

namespace HAGAKI.MyForm
{
    public partial class FrmChiTietTienDo : DevExpress.XtraEditors.XtraForm
    {
        public FrmChiTietTienDo()
        {
            InitializeComponent();
        }

        private void frm_ChiTietTienDo_Load(object sender, EventArgs e)
        {
            if (lb_fBatchName.Text == "All")
            {
                lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images select w.idimage).Count().ToString();

                lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images where w.TienDoDEJP == "Hình chưa nhập" select w.idimage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images where w.TienDoDEJP == "Hình đang nhập" select w.idimage).Count().ToString();
                lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images where w.TienDoDEJP == "Hình chờ check" select w.idimage).Count().ToString();
                lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images where w.TienDoDEJP == "Hình đang check" select w.idimage).Count().ToString();
                lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images where w.TienDoDEJP == "Hình hoàn thành" select w.idimage).Count().ToString();

                gridControl1.DataSource = null;
                gridControl1.DataSource = Global.Db.ChiTietTienDo_All();
            }
            else
            {
                lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images where w.fbatchname == lb_fBatchName.Text select w.idimage).Count().ToString();

                lb_SoHinhChuaNhap.Text = (from w in Global.Db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Hình chưa nhập" select w.idimage).Count().ToString();
                lb_SoHinhDangNhap.Text = (from w in Global.Db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Hình đang nhập" select w.idimage).Count().ToString();
                lb_SoHinhChoCheck.Text = (from w in Global.Db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Hình chờ check" select w.idimage).Count().ToString();
                lb_SoHinhDangCheck.Text = (from w in Global.Db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP  == "Hình đang check" select w.idimage).Count().ToString();
                lb_SoHinhHoanThanh.Text = (from w in Global.Db.tbl_Images where w.fbatchname == lb_fBatchName.Text && w.TienDoDEJP == "Hình hoàn thành" select w.idimage).Count().ToString();

                gridControl1.DataSource = null;
                gridControl1.DataSource = Global.Db.ChiTietTienDo(lb_fBatchName.Text);
            }
            gridView1.RowCellStyle += GridView1_RowCellStyle;
        }

        private void GridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "ThongTin")
            {
                if (view != null)
                {
                    string category = view.GetRowCellDisplayText(e.RowHandle, view.Columns["ThongTin"]);
                    if (category == "Hình đang nhập")
                        e.Appearance.BackColor = Color.HotPink;
                    else if (category == "Hình chờ check")
                    {
                        e.Appearance.BackColor = Color.OrangeRed;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (category == "Hình đang check")
                    {
                        e.Appearance.BackColor = Color.Purple;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (category == "Hình hoàn thành")
                    {
                        e.Appearance.BackColor = Color.Green;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

     
        private void repositoryItemPopupContainerEdit1_Click(object sender, EventArgs e)
        {
            string idimage = gridView1.GetFocusedRowCellValue("idimage").ToString();
            gridControl2.DataSource = null;
            if(lb_fBatchName.Text == "All")
            {
                string fbatchName1= gridView1.GetFocusedRowCellValue("fbatchname").ToString();
                gridControl2.DataSource = Global.Db.ChiTietUserDeSo(fbatchName1,  idimage);
            }
            else
                gridControl2.DataSource = Global.Db.ChiTietUserDeSo(lb_fBatchName.Text, idimage);
        }
       
    }
}