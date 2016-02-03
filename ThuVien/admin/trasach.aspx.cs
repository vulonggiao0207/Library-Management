using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_trasach : System.Web.UI.Page
{
    PhieuMuonBUS phieumuonBUS = new PhieuMuonBUS();
    SachBUS sachBUS = new SachBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    PhieuThuBUS phieuthuBUS = new PhieuThuBUS();
    DocTaiChoBUS doctaichoBUS = new DocTaiChoBUS();
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    public void AnhienSach(bool var)
    {
        Label2.Visible = var;
        Label3.Visible = var;
        Label6.Visible = var;
        Label7.Visible = var;
        Label8.Visible = var;
        Label9.Visible = var;
        Label23.Visible = var;
        Label14.Visible = var;
        Label24.Visible = var;
        Label25.Visible = var;
        TraSachButton.Visible = var;     
    }   
    public void ResetSach()
    {
        DocGiaLabel.Text = "";
        MaDocGiaLabel.Text = "";
        MaSachLabel.Text = "";
        TenSachLabel.Text = "";       
        MaPhieuMuonLabel.Text = "";
        NgayMuonLabel.Text = "";
        NgayHetHanLabel.Text ="";
        GiaHanLabel.Text = "";
        TenNhanVienLabel.Text ="";
        MaNhanVienLabel.Text = "";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        if (!IsPostBack)
        {
            AnhienSach(false);           
            ChiTietPhieuMuon_TraCollection CTPMuon_TraColl = new ChiTietPhieuMuon_TraCollection();
            Session["PhieuThu"]=CTPMuon_TraColl;   
        }
    }
    protected void KiemTraButton_Click(object sender, EventArgs e)
    {
        string masach = MaSachKiemTraTextbox.Text;
        //Kiểm tra sách đã bị báo là mất chưa
        bool kt1 = phieumuonBUS.KiemTraSach_DaMat(masach);
        if (kt1 == true)
        {
            ThongbaoSachLabel.Text = "Mã sách sai hoặc đã là mất! Xin kiểm tra lại";
            AnhienSach(false);
            ResetSach();
            return;
        }
        //Kiểm tra sách có thuộc phiếu mượn (chưa đựơc trả) nào không
        string maphieumuon = phieumuonBUS.KiemTraSach_DangMuon(masach);
        if(maphieumuon=="")
        {
            ThongbaoSachLabel.Text = "Sách này chưa đựơc mượn";
            AnhienSach(false);
            ResetSach();
            return;
        }
        AnhienSach(true);
        //nạp thông tin sách
        SachBO sachBO = new SachBO();
        sachBO = sachBUS.Tim1Sach(masach);
        MaSachLabel.Text = sachBO.MaSach;
        TenSachLabel.Text = sachBO.TenSach;
        //nạp thông tin phiếu mượn
        PhieuMuonBO phieumuonBO= new PhieuMuonBO();
        phieumuonBO=phieumuonBUS.Tim1PhieuMuon(maphieumuon);
        MaPhieuMuonLabel.Text = phieumuonBO.MaPhieuMuon;
        NgayMuonLabel.Text = phieumuonBO.NgayMuon;
        NgayHetHanLabel.Text = phieumuonBO.NgayHetHan;
  //      GiaHanLabel.Text = phieumuonBO.GiaHan;
        //nạp thông tin nhân viên
        NhanVienBO nhanvienBO = new NhanVienBO();
        nhanvienBO = nhanvienBUS.Tim1Nhanvien(phieumuonBO.MaNV);
        TenNhanVienLabel.Text=nhanvienBO.TenNV;
        MaNhanVienLabel.Text=nhanvienBO.MaNV;
        //nạp thông tin độc giả
        string madg = doctaichoBUS.Tim1DocGia_Luot(phieumuonBO.MaLuot);
        DocGiaBO docgiaBO = new DocGiaBO();
        docgiaBO = docgiaBUS.Tim1DocGia(madg);
        DocGiaLabel.Text = docgiaBO.TenDocGia;
        MaDocGiaLabel.Text = docgiaBO.MaDocGia;
        //Kiểm tra sách đã hết hạn hay chưa
        DateTime dt = new DateTime();
        dt = DateTime.Now;
        int hethan=0;
        if (NgayHetHanLabel.Text != "")
        {
            DateTime ngayhethan=Convert.ToDateTime(nhanvienBUS.ChuyenNgayThang(NgayHetHanLabel.Text));
            hethan =Convert.ToInt32((dt-ngayhethan).Days);
        }
        if (GiaHanLabel.Text != "")
        {
            DateTime ngaygiahan=Convert.ToDateTime(nhanvienBUS.ChuyenNgayThang(GiaHanLabel.Text));
            hethan = Convert.ToInt32((dt-ngaygiahan).Days);
        }
        if(hethan>0)
            ThongbaoSachLabel.Text="Sách đã hết hạn "+hethan+" ngày!";
    }
    protected void TraSachButton_Click(object sender, EventArgs e)
    {
        string maphieumuon=MaPhieuMuonLabel.Text;
        string masach=MaSachLabel.Text;
        bool kq = phieumuonBUS.TraSach(maphieumuon, masach);
        if (kq == true)
        {
            ThongbaoLapPhieuPhatLabel.Text = "Trả sách thành công";
            ResetSach();
            AnhienSach(false);
        }
        MaSachKiemTraTextbox.Text="";
        MaSachKiemTraTextbox.Focus();
        
    }
}