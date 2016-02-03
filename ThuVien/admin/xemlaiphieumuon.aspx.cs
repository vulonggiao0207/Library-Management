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
public partial class admin_xemlaiphieumuon : System.Web.UI.Page
{
    PhieuMuonBUS phieumuonBUS = new PhieuMuonBUS();
    PhieuThuBUS phieuthuBUS = new PhieuThuBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    SachBUS sachBUS = new SachBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
    }
    public void NapDuLieu()
    {
        string madocgia = TimTextBox.Text;
        PhieuMuonGridView.DataSource = phieumuonBUS.TimPhieuMuon(madocgia);
        PhieuMuonGridView.DataBind();
    }
    protected void PhieuMuonGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PhieuMuonGridView.PageIndex = e.NewPageIndex;
        NapDuLieu();
    }
    protected void PhieuMuonGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "manv") != null)
        {
            string manv = DataBinder.Eval(e.Row.DataItem, "manv").ToString();
            Label TenNhanVienLabel = (Label)e.Row.FindControl("TenNhanVienLabel");
            TenNhanVienLabel.Text = nhanvienBUS.Tim1Nhanvien(manv).TenNV;
        }
    }
    public void Taoreport(string maphieumuon)
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
        query += "  WHERE PhieuMuon.MaPhieuMuon = '"+maphieumuon+"'";
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
    protected void PhieuMuonGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "in")
        {
            string maphieumuon = e.CommandArgument.ToString();
            Taoreport(maphieumuon);
            BaoCaoPanel.Visible = true;
            ThoatButton.Visible = true;
            NapDuLieu();
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    protected void ThoatButton_Click(object sender, EventArgs e)
    {
        BaoCaoPanel.Visible = false;
        ThoatButton.Visible = false;
    }
}