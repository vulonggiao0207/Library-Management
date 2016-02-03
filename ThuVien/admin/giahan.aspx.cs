using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;
public partial class admin_giahan : System.Web.UI.Page
{
    PhieuMuonBUS phieumuonBUS = new PhieuMuonBUS();
    SachBUS sachBUS = new SachBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    PhieuThuBUS phieuthuBUS = new PhieuThuBUS();
    DocTaiChoBUS doctaichoBUS = new DocTaiChoBUS();
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    public void NapDuLieu()
    {
        string madocgia_sach = TimTextBox.Text;
        bool cachtim=false;
        if(TimDropdown.SelectedValue.ToString()=="1")
            cachtim=true;
        SachGridview.DataSource = phieumuonBUS.Sach_ChuaTra(madocgia_sach, cachtim);
        SachGridview.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");    
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        ThongbaoLabel.Text = "";
        NapDuLieu();
        if (SachGridview.Rows.Count == 0)
        {
            ThongbaoLabel.Text = "Không tìm được bất kì sách nào";
        }
    }  
    protected void SachGridview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "masach") != null)
        {
            //Lấy các con trol
            Label MaSachLabel = (Label)e.Row.FindControl("MaSachLabel");
            Label TenSachLabel = (Label)e.Row.FindControl("TenSachLabel");
            Label MaPhieuMuonLabel = (Label)e.Row.FindControl("MaPhieuMuonLabel");
            Label NgayMuonLabel = (Label)e.Row.FindControl("NgayMuonLabel");
            Label NgayHetHanLabel = (Label)e.Row.FindControl("NgayHetHanLabel");
            Label TenNhanVienLabel = (Label)e.Row.FindControl("TenNhanVienLabel");
            Label MaNhanVienLabel = (Label)e.Row.FindControl("MaNhanVienLabel");
            Label DocGiaLabel = (Label)e.Row.FindControl("DocGiaLabel");
            Label MaDocGiaLabel = (Label)e.Row.FindControl("MaDocGiaLabel");
            Label GiaHanLabel = (Label)e.Row.FindControl("GiaHanLabel");
            Button GiaHanButton= (Button)e.Row.FindControl("GiaHanButton");
            string masach = DataBinder.Eval(e.Row.DataItem, "masach").ToString();
            //nạp thông tin sách
            SachBO sachBO = new SachBO();
            sachBO = sachBUS.Tim1Sach(masach);
            MaSachLabel.Text = sachBO.MaSach;
            TenSachLabel.Text = sachBO.TenSach;
            //nạp thông tin phiếu mượn
            string maphieumuon = DataBinder.Eval(e.Row.DataItem, "maphieumuon").ToString();
            PhieuMuonBO phieumuonBO = new PhieuMuonBO();
            phieumuonBO = phieumuonBUS.Tim1PhieuMuon(maphieumuon);
            MaPhieuMuonLabel.Text = phieumuonBO.MaPhieuMuon;
            NgayMuonLabel.Text = phieumuonBO.NgayMuon;
            NgayHetHanLabel.Text = phieumuonBO.NgayHetHan;
            GiaHanLabel.Text = phieumuonBUS.TimGiaHan(maphieumuon, masach);
            if (GiaHanLabel.Text != "")
                GiaHanButton.Visible = false;
            //nạp thông tin nhân viên
            NhanVienBO nhanvienBO = new NhanVienBO();
            nhanvienBO = nhanvienBUS.Tim1Nhanvien(phieumuonBO.MaNV);
            TenNhanVienLabel.Text = nhanvienBO.TenNV;
            MaNhanVienLabel.Text = nhanvienBO.MaNV;
            //nạp thông tin độc giả
            string madg = doctaichoBUS.Tim1DocGia_Luot(phieumuonBO.MaLuot);
            DocGiaBO docgiaBO = new DocGiaBO();
            docgiaBO = docgiaBUS.Tim1DocGia(madg);
            DocGiaLabel.Text = docgiaBO.TenDocGia;
            MaDocGiaLabel.Text = docgiaBO.MaDocGia;
        }
        
    }
    protected void SachGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "giahan")
        {
            int stt=Convert.ToInt32(e.CommandArgument.ToString());
            ChiTietPhieuMuon_TraCollection chitietColl= new ChiTietPhieuMuon_TraCollection();
            //tìm
            string madocgia_sach = TimTextBox.Text;
            bool cachtim=false;
            if(TimDropdown.SelectedValue.ToString()=="1")
            cachtim=true;
            chitietColl=phieumuonBUS.Sach_ChuaTra(madocgia_sach, cachtim);
            if (phieumuonBUS.GiaHan(chitietColl.Index(stt).MaPhieuMuon, chitietColl.Index(stt).MaSach) == true)
            {
                //có thể xử lý thêm ở đây
            }
            NapDuLieu();
        }
    }
}