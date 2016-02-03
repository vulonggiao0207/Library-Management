using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class sach : System.Web.UI.Page
{
    SachBUS sachBUS = new SachBUS();
    TacGiaBUS tacgiaBUS = new TacGiaBUS();
    NhaXuatBanBUS nhaxuatbanBUS = new NhaXuatBanBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    PhanLoaiBUS phanloaiBUS = new PhanLoaiBUS();
    LoaiSachBUS loaisachBUS = new LoaiSachBUS();
    KhuVucBUS khuvucBUS = new KhuVucBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sachid"] != null)
        {
            try
            {
                string madausach = Request.QueryString["sachid"].ToString();
                SachBO sachBO = new SachBO();
                sachBO = sachBUS.Tim1Sach(Convert.ToInt32(madausach));
                HinhAnhImage.ImageUrl = sachBO.hinhanh;
                TenSachLabel.Text = sachBO.TenSach;
                NhaXuatBanLabel.Text = nhaxuatbanBUS.Tim1NXB(sachBO.MaNXB).TenNXB;
                NamXuatBanLabel.Text = sachBO.namxuatban.ToString();
                LanXuatBanLabel.Text = sachBO.lanxuatban.ToString();
                TacGiaListBox.DataSource = sachBO.tacgiaColl;
                TacGiaListBox.DataTextField = "TenTG";
                TacGiaListBox.DataBind();
                if(sachBO.MaLoai!="")
                    LoaiSachLabel.Text = loaisachBUS.Tim1LoaiSach(sachBO.MaLoai).TenLoai;
                if (sachBO.MaCTPhanLoai != "")
                {
                    TheLoaiLabel.Text = phanloaiBUS.Tim1CTPhanLoai(sachBO.MaCTPhanLoai).TenCTPhanLoai;
                    ChuDeLabel.Text = phanloaiBUS.Tim1PhanLoai_CT(sachBO.MaCTPhanLoai).TenPhanLoai;
                }
                if(sachBO.khuvuc!="")
                    KhuVucLabel.Text =khuvucBUS.Tim1KhuVuc(sachBO.khuvuc).TenKhuVuc;
                KeLabel.Text = sachBO.ke;
                NganLabel.Text = sachBO.ngan;
                TriGiaLabel.Text = sachBO.trigia.ToString();
            }
            catch
            { 
            }

        }
    }
}