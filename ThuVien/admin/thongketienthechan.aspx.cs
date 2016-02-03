using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;

public partial class admin_baocao_thongketienthechan : System.Web.UI.Page
{
    BaoCaoThongKeBUS baocaothongkeBUS = new BaoCaoThongKeBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            GridBinding();
        }
    }
    void GridBinding()
    {
        BaoCaoGridView.DataSource = baocaothongkeBUS.ThongKeTienTheChan();
        BaoCaoGridView.DataBind();
    }
}