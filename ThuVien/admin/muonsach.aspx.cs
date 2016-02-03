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
public partial class admin_muonsach : System.Web.UI.Page
{
    SachBUS sachBUS = new SachBUS();
    NhaXuatBanBUS nhaxuatbanBUS = new NhaXuatBanBUS();
    TacGiaBUS tacgiaBUS = new TacGiaBUS();
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    LoaiDocGiaBUS loaidocgiaBUS = new LoaiDocGiaBUS();
    PhieuMuonBUS phieumuonBUS = new PhieuMuonBUS();
    public void NapDuLieuVaoGrid()
    {
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = Session["SachMuon"] as ChiTietPhieuMuon_TraCollection;
        ChiTietGridView.DataSource = chitietphieuColl;
        ChiTietGridView.DataBind();
    }
    public void ResetSach()
    {
        MasachTextBox.Text = "";
        TenSachLabel.Text = "";
        MasachmuonLabel.Text = "";
        HinhAnhSachImage.ImageUrl = "";
        NhaxuatbanLabel.Text = "";
        LanxuatbanLabel.Text = "";
        NamXuatBanLabel.Text = "";
        TacGiaListBox.DataSource = null;
        TacGiaListBox.Items.Clear();
        TriGiaLabel.Text = "";
        MasachmuonLabel.Text = "";
        TienthechanTextbox.Text = "";
    }
    public void ResetDocGia()
    {
        MaDocGiaLabel.Text = "";
        TenDocGiaLabel.Text = "";
        LoaiDocgiaLabel.Text = "";
        HinhanhdocgiaImage.ImageUrl = "";
        GioiTinhLabel.Text = "";
        NgaysinhLabel.Text = "";
        DiaChiLabel.Text = "";
        NgayLapTheLabel.Text = "";
        NgayHetHanLabel.Text = "";
        MadocgiaTextBox.Text = "";
    }
    public void AnHienDocGia(bool var)
    {      
        Label2.Visible = var;
        Label3.Visible = var;
        Label4.Visible = var;
        Label5.Visible = var;
        Label6.Visible = var;
        Label7.Visible = var;
        Label8.Visible = var;
        Label25.Visible = var;      
    }
    public void AnHienSach(bool var)
    {
      
        Label17.Visible = var;
        Label18.Visible = var;
        Label19.Visible = var;
        Label20.Visible = var;
        Label21.Visible = var;
        Label22.Visible = var;
        TacGiaListBox.Visible = var;     
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        if (!IsPostBack)
        {
            ChiTietPhieuMuon_TraCollection ctpMT= new ChiTietPhieuMuon_TraCollection();
            Session["SachMuon"] = ctpMT;
            NapDuLieuVaoGrid();
            AnHienDocGia(false);
            AnHienSach(false);
            MadocgiaTextBox.Focus();
        }
    }
    protected void KiemtradocgiaButton_Click(object sender, EventArgs e)
    {
        DocGiaBO docgiaBO = new DocGiaBO();
        string madocgia = MadocgiaTextBox.Text;
        docgiaBO = docgiaBUS.Tim1DocGia(madocgia);
        string maluot = phieumuonBUS.KiemTraMaLuot(madocgia);
        ThongBaoDocGiaLabel.Text = "";
        if (docgiaBO != null && docgiaBO.TenDocGia != null && maluot != "")
        {
            //kiểm tra số sách mưon chua tra
            int kt1 = phieumuonBUS.DemsoSach_ChuaTra(madocgia);
            if (kt1 == 3)
            {
                ThongBaoDocGiaLabel.Text = "Độc giả đã mượn đủ số sách quy định";
                return;
            }
            else
                ThongBaoDocGiaLabel.Text = "Độc giả đã mượn " + kt1 + "/3 cuốn sách";
            ///////////////////////

            ViewState["maluot"] = maluot;
            MaDocGiaLabel.Text = docgiaBO.MaDocGia;
            TenDocGiaLabel.Text = docgiaBO.TenDocGia;
            HinhanhdocgiaImage.ImageUrl = docgiaBO.HinhAnh;
            LoaiDocgiaLabel.Text = loaidocgiaBUS.Tim1LoaiDocGia(docgiaBO.MaLoai).TenLoai;
            if (docgiaBO.GioiTinh == true)
                GioiTinhLabel.Text = "Nam";
            else
                GioiTinhLabel.Text = "Nữ";
            NgaysinhLabel.Text = docgiaBO.NgaySinh;
            DiaChiLabel.Text = docgiaBO.DiaChi;
            NgayLapTheLabel.Text = docgiaBO.NgayLapThe;
            NgayHetHanLabel.Text = docgiaBO.NgayHetHan;
            AnHienDocGia(true);
            MasachTextBox.Focus();
        }
        else
        {
            ThongBaoDocGiaLabel.Text = "Mã độc giả không hợp lệ";
            ResetDocGia();
            AnHienDocGia(false);
            MadocgiaTextBox.Focus();
        }
    }
    protected void KiemtrasachButton_Click(object sender, EventArgs e)
    {
        SachBO sachBO = new SachBO();
        sachBO = sachBUS.Tim1Sach(MasachTextBox.Text);
        if (sachBO != null && sachBO.TenSach != null)
        {
            ThongbaoSachLabel.Text = "";
            MasachmuonLabel.Text = MasachTextBox.Text;
            TenSachLabel.Text = sachBO.TenSach;
            HinhAnhSachImage.ImageUrl = sachBO.hinhanh;
            NhaxuatbanLabel.Text = nhaxuatbanBUS.Tim1NXB(sachBO.MaNXB).TenNXB;
            LanxuatbanLabel.Text = sachBO.lanxuatban.ToString();
            NamXuatBanLabel.Text = sachBO.namxuatban.ToString();
            TacGiaListBox.DataSource = sachBO.tacgiaColl;
            TacGiaListBox.DataTextField = "TenTG";
            TacGiaListBox.DataValueField = "MaTG";
            TacGiaListBox.DataBind();
            TriGiaLabel.Text = sachBO.trigia.ToString() + " vnđ";
            TienthechanTextbox.Text = sachBO.trigia.ToString();
            AnHienSach(true);
        }
        else
        {
            ThongbaoSachLabel.Text = "Mã sách không hợp lệ";
            ResetSach();
            AnHienSach(false);
        }
        MasachTextBox.Focus();
    }
    protected void LuuButton_Click(object sender, EventArgs e)
    {
        ThongbaoPhieuMuonLabel.Text = "";
        string madocgia = MaDocGiaLabel.Text;
        string masach = MasachmuonLabel.Text;
        //kiểm tra số lượng sáh độc giả đang muợn
        int kt1 = phieumuonBUS.DemsoSach_ChuaTra(madocgia);
        if (kt1 == 3)
        {
            ThongbaoPhieuMuonLabel.Text = "Độc giả đã mượn đủ số sách quy định";
            return;
        }
        else
            ThongbaoPhieuMuonLabel.Text = "Độc giả đã mượn " + kt1 + "/3 cuốn sách";
        //kiểm tra sách có đang đựơc mượn hay không
        string kt2 = phieumuonBUS.KiemTraSach_DangMuon(masach);
        if (kt2 != "")
        {
            ThongbaoPhieuMuonLabel.Text = "Sách đã đựơc mượn";
            return;
        }
        //kiểm tra tiền thế chân
        int kq = 0;
        if (int.TryParse(TienthechanTextbox.Text.Split('.')[0], out kq) == false || Convert.ToInt32(TienthechanTextbox.Text.Split('.')[0]) < Convert.ToInt32(TriGiaLabel.Text.Split('.')[0]))
        {
            ThongbaoPhieuMuonLabel.Text = "Tiền thế chân phải lớn hơn hoặc bằng giá trị của sách";
            return;
        }
        //kiểm tra sách có đang chuẩn bị lập phiếu không
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = Session["SachMuon"] as ChiTietPhieuMuon_TraCollection;
        foreach (ChiTietPhieuMuon_Tra ct in chitietphieuColl)
            if (MasachmuonLabel.Text == ct.MaSach)
            {
                ThongbaoPhieuMuonLabel.Text = "Sách đã đựơc thêm vào phiếu mượn";
                return;
            }
        //Kiểm tra có độc giả để lập phiếu chưa
        if (MaDocGiaLabel.Text == "")
        {
            ThongBaoDocGiaLabel.Text = "Bạn phải chọn độc giả để lập phiếu";
            return;
        }
        //Nếu qua hết thì thêm vào phiếu            
        ChiTietPhieuMuon_Tra ctphieu = new ChiTietPhieuMuon_Tra();
        ctphieu.MaSach = MasachmuonLabel.Text;
        ctphieu.TienTheChan = Convert.ToInt32(TienthechanTextbox.Text.Split('.')[0]);
        chitietphieuColl.Add(ctphieu);
        Session["SachMuon"] = chitietphieuColl;
        //Kiểm tra số sách tối đa add vào là 3
        if (kt1 + chitietphieuColl.Count > 3)
        {
            ThongbaoPhieuMuonLabel.Text = "Độc giả chỉ có thể mượn tối đa 3 sách";
            return;
        }
        NapDuLieuVaoGrid();
        ResetSach();
        AnHienSach(false);
        MasachTextBox.Text = "";
        MasachTextBox.Focus();
    }
    protected void ChiTietGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
            chitietphieuColl = Session["SachMuon"] as ChiTietPhieuMuon_TraCollection;
            chitietphieuColl.Remove(index);
            NapDuLieuVaoGrid();
        }
        else if(e.CommandName == "xem")
        {
            SachBO sachBO = new SachBO();
            string masach=e.CommandArgument.ToString();
            sachBO = sachBUS.Tim1Sach(masach);
            if (sachBO != null && sachBO.TenSach != null)
            {
                MaSachCTLabel.Text = masach;
                TenSachCTLabel.Text = sachBO.TenSach;
                HinhAnhSachCTImage.ImageUrl = sachBO.hinhanh;
                NhaXuatBanCTLabel.Text = nhaxuatbanBUS.Tim1NXB(sachBO.MaNXB).TenNXB;
                LanXuatBanCTLabel.Text = sachBO.lanxuatban.ToString();
                NamXuatBanCTLabel.Text = sachBO.namxuatban.ToString();
                TacGiaCTListBox.DataSource = sachBO.tacgiaColl;
                TacGiaCTListBox.DataTextField = "TenTG";
                TacGiaCTListBox.DataValueField = "MaTG";
                TacGiaCTListBox.DataBind();
                TriGiaCTLabel.Text = sachBO.trigia.ToString() + " vnđ";
            }
            SachPopup.Show();
        }
    }       
    public void Taoreport()
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection cnn = new SqlConnection(cnnstr);
        string query = "SELECT NhanVien.MaNV, NhanVien.TenNV, PhieuMuon.MaPhieuMuon, PhieuMuon.NgayMuon, PhieuMuon.NgayHetHan, DocGia.MaDocGia, DocGia.TenDocGia, ";
        query += " Sach.MaSach, Sach.TenSach, ChiTietPhieuMuon_Tra.TienTheChan";
        query += " FROM LuotVaoThuVien INNER JOIN";
        query += " DocGia ON LuotVaoThuVien.MaDocGia = DocGia.MaDocGia INNER JOIN ";
        query += " NhanVien ON LuotVaoThuVien.MaNV = NhanVien.MaNV INNER JOIN ";
        query += " PhieuMuon ON LuotVaoThuVien.MaLuot = PhieuMuon.MaLuot AND NhanVien.MaNV = PhieuMuon.MaNV INNER JOIN ";
        query += " ChiTietPhieuMuon_Tra ON PhieuMuon.MaPhieuMuon = ChiTietPhieuMuon_Tra.MaPhieuMuon INNER JOIN";
        query += " Sach ON ChiTietPhieuMuon_Tra.MaSach = Sach.MaSach";
        query += "  WHERE PhieuMuon.MaPhieuMuon = (SELECT top 1 MaPhieuMuon FROM PhieuMuon order by NgayMuon desc)";
        cnn.Open();
        SqlDataAdapter da = new SqlDataAdapter(query, cnn);
        PhieuMuonDS phieuthuDS = new PhieuMuonDS();
        da.Fill(phieuthuDS, "DataTable1");
        cnn.Close();
        ReportDocument rptDoc = new ReportDocument();
        rptDoc.Load(Server.MapPath("PhieuMuonReport.rpt"));
        rptDoc.SetDataSource(phieuthuDS.Tables["DataTable1"]);
        InPhieuReport.ReportSource = rptDoc;
        InPhieuReport.Width = 730;
        InPhieuReport.Height = 400;
        InPhieuReport.DataBind();
    }
    protected void LapPhieuButton_Click(object sender, EventArgs e)
    {
        string MaNV = Session["manv"].ToString();
        string NgayMuon=DateTime.Now.ToString();       
        string MaLuot = ViewState["maluot"].ToString();
        ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
        chitietphieuColl = Session["SachMuon"] as ChiTietPhieuMuon_TraCollection;
        if (chitietphieuColl.Count <= 0)
        {
            ThongbaoPhieuMuonLabel.Text = "Không có sách để lập phiếu mượn";
            return;
        }
        bool kq=phieumuonBUS.LuuPhieuMuon(MaNV, NgayMuon, MaLuot,chitietphieuColl);
        if (kq == true)
        {
            chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
            Session["SachMuon"] = chitietphieuColl;
            ChiTietGridView.DataSource = chitietphieuColl;
            ChiTietGridView.DataBind();
            ResetDocGia();
            ResetSach();
            AnHienDocGia(false);
            AnHienSach(false);
            ThongBaoDocGiaLabel.Text = "";
            ThongbaoLapPhieuLabel.Text = "Đã lưu phiếu mượn thành công";
            ThongbaoPhieuMuonLabel.Text = "";
            ThongbaoSachLabel.Text = "";
        }
            /////thêm
        else
        {
            return;
        }
        /////In////////
        Taoreport();
        BaoCaoPanel.Visible = true;
        ThoatButton.Visible = true;
    }
    protected void ThoatButton_Click(object sender, EventArgs e)
    {
        BaoCaoPanel.Visible = false;
        ThoatButton.Visible = false;
    }
    protected void MasachTextBox_TextChanged(object sender, EventArgs e)
    {
        SachBO sachBO = new SachBO();
        sachBO = sachBUS.Tim1Sach(MasachTextBox.Text);
        if (sachBO != null && sachBO.TenSach != null)
        {
            ThongbaoSachLabel.Text = "";
            MasachmuonLabel.Text = MasachTextBox.Text;
            TenSachLabel.Text = sachBO.TenSach;
            HinhAnhSachImage.ImageUrl = sachBO.hinhanh;
            NhaxuatbanLabel.Text = nhaxuatbanBUS.Tim1NXB(sachBO.MaNXB).TenNXB;
            LanxuatbanLabel.Text = sachBO.lanxuatban.ToString();
            NamXuatBanLabel.Text = sachBO.namxuatban.ToString();
            TacGiaListBox.DataSource = sachBO.tacgiaColl;
            TacGiaListBox.DataTextField = "TenTG";
            TacGiaListBox.DataValueField = "MaTG";
            TacGiaListBox.DataBind();
            TriGiaLabel.Text = sachBO.trigia.ToString() + " vnđ";
            TienthechanTextbox.Text = sachBO.trigia.ToString();
            AnHienSach(true);
            LuuButton.Focus();
        }
        else
        {
            ThongbaoSachLabel.Text = "Mã sách không hợp lệ";
            ResetSach();
            AnHienSach(false);
            MasachTextBox.Focus();
        }
        
    }
}