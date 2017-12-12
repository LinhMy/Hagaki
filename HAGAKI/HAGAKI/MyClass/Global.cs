using DevExpress.Office.Utils;
using DevExpress.XtraRichEdit.Model;
using System.Collections.Generic;

namespace HAGAKI.MyClass
{
    internal class Global
    {
        
        public static DataBPODataContext DbBpo = new DataBPODataContext();
        public static DataHagakiDataContext Db =new DataHagakiDataContext();
        public static string StrMachine = "";
        public static string StrUserWindow = "";
        public static string StrIpAddress = "";
        public static string StrUsername = "";
        public static string StrBatch = "";
        public static string StrRole = "";
        public static string StrToken = "";
        public static string StrIdimage = "";
        public static string StrCheck = "";
        public static string StrPath = @"\\10.10.10.248\Hagaki$";
        public static string Webservice="http://10.10.10.248:8888/Hagaki/";
        public static string StrIdProject = "Hagaki";
        public static string Version = "1.0.9";
        public static string UrlUpdateVersion = @"\\10.10.10.254\DE_Viet\2017\HAGAKI\Tools";
        public static int FreeTime = 0;
        public static bool FlagTong = false;
        public static string DanhSachDuLieuCam1 = "１２３４５６７８９０";
        public static string DanhSachDuLieuCam2 = "　";


    }
}