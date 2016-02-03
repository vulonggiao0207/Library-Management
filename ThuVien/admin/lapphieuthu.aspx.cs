using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BO;
using BUS;
public partial class admin_lapphieuphat : System.Web.UI.Page
{
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    PhieuThuBUS phieuthuBUS = new PhieuThuBUS();
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    SachBUS sachBUS = new SachBUS();
    NhaXuatBanBUS nxbBUS = new NhaXuatBanBUS();
    PhieuMuonBUS phieumuonBUS = new PhieuMuonBUS();
    public void NapSach(string madocgia)
    {
        SachGridview.DataSource = phieuthuBUS.TimSachViPham(madocgia);
        SachGridview.DataBind();
        if (SachGridview.Rows.Count == 0)
        {
            DocGiaLabel.Text = "Độc giả không có sách vi phạm";
            return;
        }
    }
    public void NapPhieuPhat()
    {
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = (ChiTietPhieuMuon_TraCollection)Session["PhieuPhat"];
        PhieuPhatGridview.DataSource = chitietphieuColl;
        PhieuPhatGridview.DataBind();
    }
  /*  public void NapPhieuXemTruoc()
    {   
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = (ChiTietPhieuMuon_TraCollection)Session["PhieuPhat"];
        XemphieuGridview.DataSource = chitietphieuColl;
        XemphieuGridview.DataBind();
    }*/  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");    
        if (!IsPostBack)
        {
            ChiTietPhieuMuon_TraCollection chitietphieuColl= new ChiTietPhieuMuon_TraCollection();
            Session["PhieuPhat"] = chitietphieuColl;
        }
    }
    protected void TimButton_Click(object sender, EventArgs e)
    {
        DocGiaLabel.Text = "";
        string madocgia = MadocgiaTextbox.Text;
        if (docgiaBUS.Tim1DocGia(madocgia).MaDocGia==null)
        {
            DocGiaLabel.Text = "Mã độc giả không hợp lệ";
            return;
        }       
        NapSach(madocgia);
    }
    protected void SachGridview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "masach")!=null)
        {
            //Mã sách
            string masach = DataBinder.Eval(e.Row.DataItem, "masach").ToString();
            if (masach != "")
            {
                Image hinhanh = (Image)e.Row.FindControl("HinhAnhImage");
                Label tensach = (Label)e.Row.FindControl("TenSachLabel");
                Label nhaxuatban = (Label)e.Row.FindControl("NhaxuatbanLabel");
                Label namxuatban = (Label)e.Row.FindControl("NamxuatbanLabel");
                Label lanxuatban = (Label)e.Row.FindControl("LanxuatbanLabel");
                ListBox tacgia = (ListBox)e.Row.FindControl("TacGiaListbox");
                Label trigia = (Label)e.Row.FindControl("TriGiaLabel");
                Label ngaymuon = (Label)e.Row.FindControl("NgaymuonLabel");
                Label ngayhethan = (Label)e.Row.FindControl("HethanLabel");
                Label ngaygiahan = (Label)e.Row.FindControl("GiahanLabel");
                Label ngaytrehan = (Label)e.Row.FindControl("NgaytrehanLabel");
                //Gán dữ liệu
                SachBO sachBO = new SachBO();
                sachBO = sachBUS.Tim1Sach(masach);
                hinhanh.ImageUrl = sachBO.hinhanh;
                tensach.Text = sachBO.TenSach;
                nhaxuatban.Text = nxbBUS.Tim1NXB(sachBO.MaNXB).TenNXB;
                namxuatban.Text = sachBO.namxuatban.ToString();
                lanxuatban.Text = sachBO.lanxuatban.ToString();
                tacgia.DataSource = sachBO.tacgiaColl;
                tacgia.DataTextField = "TenTG";
                trigia.Text = sachBO.trigia.ToString();
                string maphieumuon = DataBinder.Eval(e.Row.DataItem, "maphieumuon").ToString();
                PhieuMuonBO phieumuonBO = new PhieuMuonBO();
                phieumuonBO= phieumuonBUS.Tim1PhieuMuon(maphieumuon);
                ngaymuon.Text = phieumuonBO.NgayMuon;
                ngayhethan.Text = phieumuonBO.NgayHetHan;
                DateTime _ngayhethan = Convert.ToDateTime(nhanvienBUS.ChuyenNgayThang(phieumuonBO.NgayHetHan));
                TimeSpan dt = DateTime.Now - _ngayhethan;
                DateTime _giahan = new DateTime();
                if (DataBinder.Eval(e.Row.DataItem, "giahan").ToString() != "")
                {
                    _giahan = Convert.ToDateTime(nhanvienBUS.ChuyenNgayThang(DataBinder.Eval(e.Row.DataItem, "giahan").ToString()));
                    ngaygiahan.Text = _giahan.ToString();
                    dt = DateTime.Now - _giahan;
                }
                int _ngaytrehan =Convert.ToInt32(dt.Days);
                if (_ngaytrehan > 0)
                    ngaytrehan.Text = _ngaytrehan.ToString();
            }
        }
    }
    public bool KiemTraTrung(string maphieumuon,string masach)
    {
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = (ChiTietPhieuMuon_TraCollection)Session["PhieuPhat"];
        for (int i = 0; i < chitietphieuColl.Count; i++)
        {
            if (chitietphieuColl.Index(i).MaPhieuMuon == maphieumuon && chitietphieuColl.Index(i).MaSach == masach)
                return true;
        }
        return false;
    }
    protected void SachGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Them")
        {
            ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
            chitietphieuColl = (ChiTietPhieuMuon_TraCollection) Session["PhieuPhat"];
            //add thêm chitietphieu
            ChiTietPhieuMuon_Tra chitietphieu = new ChiTietPhieuMuon_Tra();
            int stt =Convert.ToInt32(e.CommandArgument.ToString());
            string maphieumuon =((HiddenField)SachGridview.Rows[stt].FindControl("maphieuhid")).Value.ToString();
            string masach = ((Label)SachGridview.Rows[stt].FindControl("MasachLabel")).Text;
            //nạp lại
            string madocgia = MadocgiaTextbox.Text;
            NapSach(madocgia);
            //xử lý tiếp
            Label thongbao = ((Label)SachGridview.Rows[stt].FindControl("SachLabel"));
            thongbao.Text = "";
            bool kt = KiemTraTrung(maphieumuon, masach);
            if (kt == true)
            {
                thongbao.Text = "Sách đã được cho vào phiếu phạt";
            }
            else
            {
                chitietphieu.MaPhieuMuon = maphieumuon;
                chitietphieu.MaSach = masach;
                chitietphieuColl.Add(chitietphieu);
                Session["PhieuPhat"] = chitietphieuColl;                
            }
            NapPhieuPhat();
        }
       
    }
    protected void PhieuPhatGridview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "masach") != null)
        {
            //Mã sách
            string masach = DataBinder.Eval(e.Row.DataItem, "masach").ToString();
            if (masach != "")
            {
                Label tensach = (Label)e.Row.FindControl("TensachLabel");
                tensach.Text = sachBUS.Tim1Sach(masach).TenSach;
                Image hinhanh = (Image)e.Row.FindControl("HinhanhImage");
                hinhanh.ImageUrl = sachBUS.Tim1Sach(masach).hinhanh;
            }
        }
    }
    protected void PhieuPhatGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
            chitietphieuColl = (ChiTietPhieuMuon_TraCollection)Session["PhieuPhat"];
            //remove thêm chitietphieu
            int delnum=Convert.ToInt32(e.CommandArgument);
            chitietphieuColl.Remove(delnum);
            Session["PhieuPhat"] = chitietphieuColl;
            DocGiaLabel.Text = "";
            string madocgia = MadocgiaTextbox.Text;
            NapSach(madocgia);
            NapPhieuPhat();
        }
    }  
    protected void InphieuGridview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "masach") != null)
        {
            //Mã sách
            string masach = DataBinder.Eval(e.Row.DataItem, "masach").ToString();
            if (masach != "")
            {
                Label tensach = (Label)e.Row.FindControl("TensachLabel");
                tensach.Text = sachBUS.Tim1Sach(masach).TenSach;
            }
        }
    }
    public bool KiemTra(ChiTietPhieuMuon_TraCollection chitietphieuColl)
    {
        string madocgia = MadocgiaTextbox.Text;
        //add thông tin phiếu thu       
        decimal tongtien = 0;
        decimal temp;
        for (int i = 0; i < chitietphieuColl.Count; i++)
        {
            TextBox sotienphat = (TextBox)PhieuPhatGridview.Rows[i].FindControl("SoTienPhatTextBox");
            TextBox lydophat = (TextBox)PhieuPhatGridview.Rows[i].FindControl("LyDoPhatTextbox");
            if (decimal.TryParse(sotienphat.Text, out temp) != true || sotienphat.Text.Trim() == "" ||Convert.ToDecimal(sotienphat.Text)<0)
            {
                InphieuLabel.Text = "Số tiền phạt phải là số dương và không đựơc bỏ trống";
                NapSach(madocgia);
                NapPhieuPhat();
                return false;
            }
            if (lydophat.Text.Trim() == "")
            {
                InphieuLabel.Text = "Lý do phạt không đựơc bỏ trống";
                NapSach(madocgia);
                NapPhieuPhat();
                return false;
            }
            chitietphieuColl.Index(i).SoTienPhat = Convert.ToDecimal(sotienphat.Text);
            chitietphieuColl.Index(i).LyDoPhat = lydophat.Text;
            //đồng thời cộng tổng tìên
            if (chitietphieuColl.Index(i).SoTienPhat.ToString() != "" && decimal.TryParse(chitietphieuColl.Index(i).SoTienPhat.ToString(), out temp) == true)
                tongtien = tongtien + Convert.ToDecimal(chitietphieuColl.Index(i).SoTienPhat.ToString());
        }
        ViewState["TongTien"] = tongtien;
        return true;
    }
    public void Taoreport()
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection cnn = new SqlConnection(cnnstr);
        string query = "SELECT (sach.masach) masach,tensach,(phieuthu.maphieuthu) maphieuthu,tongtien,ngaylap, (nhanvien.maNV) manv,tenNV,";
        query += " lydophat,sotienphat,(docgia.madocgia) madocgia,tendocgia";
        query += "  FROM LuotVaoThuVien INNER JOIN DocGia ";
        query += " ON LuotVaoThuVien.MaDocGia = DocGia.MaDocGia INNER JOIN NhanVien ON LuotVaoThuVien.MaNV = NhanVien.MaNV INNER JOIN ";
        query += " PhieuThu ON NhanVien.MaNV = PhieuThu.MaNV INNER JOIN ChiTietPhieuMuon_Tra ON PhieuThu.MaPhieuThu = ChiTietPhieuMuon_Tra.MaPhieuThu INNER JOIN ";
        query += " PhieuMuon ON LuotVaoThuVien.MaLuot = PhieuMuon.MaLuot AND NhanVien.MaNV = PhieuMuon.MaNV AND  ChiTietPhieuMuon_Tra.MaPhieuMuon = PhieuMuon.MaPhieuMuon ";
        query += " INNER JOIN Sach ON ChiTietPhieuMuon_Tra.MaSach = Sach.MaSach WHERE phieuthu.maphieuthu= (SELECT Top 1 MaPhieuThu FROM PhieuThu order by ngaylap desc) ";
        cnn.Open();
        SqlDataAdapter da = new SqlDataAdapter(query, cnn);
        PhieuThuDS phieuthuDS = new PhieuThuDS();
        da.Fill(phieuthuDS, "DataTable1");
        cnn.Close();
        ReportDocument rptDoc = new ReportDocument();
        rptDoc.Load(Server.MapPath("PhieuThuReport.rpt"));
        rptDoc.SetDataSource(phieuthuDS.Tables["DataTable1"]);
        InPhieuReport.ReportSource = rptDoc;
        InPhieuReport.Width = 730;
        InPhieuReport.Height = 400;
        InPhieuReport.DataBind();
        BaoCaoPanel.Visible = true;
    }
    protected void LuuPhieuThuButton_Click(object sender, EventArgs e)
    {
        ///////Lưu///////
        string madocgia = MadocgiaTextbox.Text;
        if (PhieuPhatGridview.Rows.Count == 0)
        {
            InphieuLabel.Text = "Phải có ít nhất 1 sách để lập phiếu thu";
            return;
        }
        string manv = Session["manv"].ToString();
          //lấy chi tiết phiếu thu
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = (ChiTietPhieuMuon_TraCollection)Session["PhieuPhat"];
        if (KiemTra(chitietphieuColl) == false)
        {
            NapSach(madocgia);
            NapPhieuPhat();
            return;
        }
        string tongtien = ViewState["TongTien"].ToString();// TongtienphatLabel.Text;
        if (phieuthuBUS.LuuPhieu(chitietphieuColl, manv, Convert.ToDecimal(tongtien)) == true)
        {
            InphieuLabel.Text = "Đã lưu phiếu phạt";
            chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
            Session["PhieuPhat"] = chitietphieuColl;
        }
        else
        {
            InphieuLabel.Text = "Đã có sự cố khi lưu phiếu phạt! Mời thử lại sau";
            NapSach(madocgia);
            NapPhieuPhat();
            return;
        }
        /////In////////
        Taoreport();
        DocGiaLabel.Text = "";    
        NapSach(madocgia);
        NapPhieuPhat();
    }  
    protected void ThoatButton_Click(object sender, EventArgs e)
    {
        BaoCaoPanel.Visible = false;
        ThoatButton.Visible = false;
    }
}