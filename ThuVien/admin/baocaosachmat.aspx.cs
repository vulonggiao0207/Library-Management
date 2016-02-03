using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class admin_baocaosachmat : System.Web.UI.Page
{
    BaoCaoThongKeBUS baocaothongkeBUS = new BaoCaoThongKeBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            
        }
    }
   
    protected void Baocaoreport_Click(object sender, EventArgs e)
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection cnn = new SqlConnection(cnnstr);
        string query = "select MaSach,TenSach,TenNXB,NamXuatBan,TriGia from Sach,NhaXuatBan where sach.manxb=NhaXuatBan.MaNXB and TrangThai=0 ";
        cnn.Open();
        SqlDataAdapter da = new SqlDataAdapter(query, cnn);
        SachMatDS sachmatDS = new SachMatDS();

        da.Fill(sachmatDS, "DataTable1");
        cnn.Close();
        ReportDocument rptDoc = new ReportDocument();
        rptDoc.Load(Server.MapPath("baocao/ReportSachMat.rpt"));
        rptDoc.SetDataSource(sachmatDS.Tables["DataTable1"]);
        ReportMatSach.ReportSource = rptDoc;
        ReportMatSach.DataBind();
        ReportMatSach.Width = 720;
        ReportMatSach.Height = 600;
    }

   
}