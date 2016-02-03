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
public partial class admin_xemlaiphieuphat : System.Web.UI.Page
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
        PhieuThuGridView.DataSource = phieuthuBUS.TimPhieuThu(madocgia);
        PhieuThuGridView.DataBind();
    }
  /*  public void NapChiTiet(string maphieuthu)
    {
         ChiTietPhieuMuon_TraCollection phieumuontraColl = new ChiTietPhieuMuon_TraCollection();
         phieumuontraColl = phieuthuBUS.TimChitietPhieuThu(maphieuthu);
         decimal tongtien = 0;
         for (int i = 0; i < phieumuontraColl.Count; i++)
         {
             tongtien = tongtien + phieumuontraColl.Index(i).SoTienPhat;
         }
         TongtienphatLabel.Text = tongtien.ToString();
         XemphieuGridview.DataSource = phieumuontraColl;
         XemphieuGridview.DataBind();
    }*/
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        ThongbaoLabel.Text = "";
        NapDuLieu();
        if (PhieuThuGridView.Rows.Count == 0)
        {
            ThongbaoLabel.Text = "Không tìm đụơc bất kì phiếu thu nào";
        }
    }
    public void Taoreport(string maphieuthu)
    {       
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection cnn = new SqlConnection(cnnstr);
        string query = "SELECT (sach.masach) masach,tensach,(phieuthu.maphieuthu) maphieuthu,tongtien,ngaylap, (nhanvien.maNV) manv,tenNV,";
        query+=" lydophat,sotienphat,(docgia.madocgia) madocgia,tendocgia";
        query+="  FROM LuotVaoThuVien INNER JOIN DocGia ";
        query+=" ON LuotVaoThuVien.MaDocGia = DocGia.MaDocGia INNER JOIN NhanVien ON LuotVaoThuVien.MaNV = NhanVien.MaNV INNER JOIN ";
        query+=" PhieuThu ON NhanVien.MaNV = PhieuThu.MaNV INNER JOIN ChiTietPhieuMuon_Tra ON PhieuThu.MaPhieuThu = ChiTietPhieuMuon_Tra.MaPhieuThu INNER JOIN ";
        query+=" PhieuMuon ON LuotVaoThuVien.MaLuot = PhieuMuon.MaLuot AND NhanVien.MaNV = PhieuMuon.MaNV AND  ChiTietPhieuMuon_Tra.MaPhieuMuon = PhieuMuon.MaPhieuMuon ";
        query+=" INNER JOIN Sach ON ChiTietPhieuMuon_Tra.MaSach = Sach.MaSach WHERE phieuthu.maphieuthu='"+maphieuthu+"'";
        cnn.Open();
        SqlDataAdapter da = new SqlDataAdapter(query,cnn);
        PhieuThuDS phieuthuDS = new PhieuThuDS();
        da.Fill(phieuthuDS, "DataTable1");
        cnn.Close();
        ReportDocument rptDoc = new ReportDocument();
        rptDoc.Load(Server.MapPath("PhieuThuReport.rpt")); 
        rptDoc.SetDataSource(phieuthuDS.Tables["DataTable1"]);
        InPhieuReport.ReportSource = rptDoc;
        InPhieuReport.Width = 730;
        InPhieuReport.Height=400;
        InPhieuReport.DataBind();
    }
    protected void PhieuThuGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PhieuThuGridView.PageIndex = e.NewPageIndex;
        NapDuLieu();
    }
    protected void PhieuThuGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      /*  if (e.CommandName == "chitiet")
        {
            string maphieuthu = e.CommandArgument.ToString();
            NapChiTiet(maphieuthu);
            NapDuLieu();
       //     XemPopup.Show();
        }*/
        if (e.CommandName == "in")
        {
            string maphieuthu = e.CommandArgument.ToString();
            NapDuLieu();
            Taoreport(maphieuthu);
            BaoCaoPanel.Visible = true;
            ThoatButton.Visible = true;
       //     InPopup.Show();
        }
    }
    protected void PhieuThuGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow&& DataBinder.Eval(e.Row.DataItem, "manv")!=null)
        {
            string manv = DataBinder.Eval(e.Row.DataItem, "manv").ToString();
            Label TenNhanVienLabel = (Label)e.Row.FindControl("TenNhanVienLabel");
            TenNhanVienLabel.Text = nhanvienBUS.Tim1Nhanvien(manv).TenNV;
        }

    }
  /*  protected void XemphieuGridview_RowCreated(object sender, GridViewRowEventArgs e)
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
    }*/
    protected void ThoatButton_Click(object sender, EventArgs e)
    {
        BaoCaoPanel.Visible = false;
        ThoatButton.Visible = false;
    }
   
}