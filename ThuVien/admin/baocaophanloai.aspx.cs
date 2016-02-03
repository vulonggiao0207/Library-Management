using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;


public partial class admin_thongke : System.Web.UI.Page
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

    void GridBinding(string tenphanloai)
    {
        DSPhanLoaiGridView.DataSource = baocaothongkeBUS.BaoCaoPhanLoai(tenphanloai);
        DSPhanLoaiGridView.DataBind();
    }
    protected void BaoCaoButton_Click(object sender, EventArgs e)
    {
        string tenphanloai = PhanLoaiDropDownList.SelectedValue.ToString();
        GridBinding(tenphanloai);
         
                 
    }

   
}