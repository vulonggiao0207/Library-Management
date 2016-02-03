using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class sachdangmuon : System.Web.UI.Page
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
            DocGiaLabel.Text = "Bạn chưa mượn cuốn sách nào";
            return;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["madocgia"] == null)
            Response.Redirect("trangchu.aspx");
        string madocgia = Session["madocgia"].ToString();
        NapSach(madocgia);
    }
    protected void SachGridview_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "masach") != null)
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
                phieumuonBO = phieumuonBUS.Tim1PhieuMuon(maphieumuon);
                ngaymuon.Text = phieumuonBO.NgayMuon;
                ngayhethan.Text = phieumuonBO.NgayHetHan;
                DateTime _ngayhethan = Convert.ToDateTime(nhanvienBUS.ChuyenNgayThang(phieumuonBO.NgayHetHan));
                TimeSpan dt = DateTime.Now - _ngayhethan;
                DateTime _giahan = new DateTime();
                if (DataBinder.Eval(e.Row.DataItem, "giahan")!=null&&DataBinder.Eval(e.Row.DataItem, "giahan").ToString() != "")
                {
                    _giahan = Convert.ToDateTime(nhanvienBUS.ChuyenNgayThang(DataBinder.Eval(e.Row.DataItem, "giahan").ToString()));
                    ngaygiahan.Text = _giahan.ToString();
                    dt = DateTime.Now - _giahan;
                }
                int _ngaytrehan = Convert.ToInt32(dt.Days);
                if (_ngaytrehan > 0)
                    ngaytrehan.Text = _ngaytrehan.ToString();
            }
        }
    }
}