using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HAGAKI.MyUserControl
{
    public partial class uc_FeddBack : UserControl
    {
        public uc_FeddBack()
        {
            InitializeComponent();
        }
        public void LoadData(tbl_DEJP_Backup data)
        {
            txt_Truong01.Text = data.Truong_01;
            txt_Truong02.Text = data.Truong_02;
            txt_Truong03.Text = data.Truong_03;
            txt_Truong04.Text = data.Truong_04;
            txt_Truong05.Text = data.Truong_05;
            txt_Truong06.Text = data.Truong_06;
            txt_Truong07.Text = data.Truong_07;
            txt_Truong08.Text = data.Truong_08;
        }

        public void LoadDataChecker(tbl_DEJP data)
        {
            txt_Truong01.Text = data.Truong_01;
            txt_Truong02.Text = data.Truong_02;
            txt_Truong03.Text = data.Truong_03;
            txt_Truong04.Text = data.Truong_04;
            txt_Truong05.Text = data.Truong_05;
            txt_Truong06.Text = data.Truong_06;
            txt_Truong07.Text = data.Truong_07;
            txt_Truong08.Text = data.Truong_08;
        }
    }
}
