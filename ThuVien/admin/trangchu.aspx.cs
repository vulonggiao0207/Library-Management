using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_dangnhap : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        ChaoLabel.Text = "Chào mừng "+Session["tennv"].ToString()+" đến với trang quản trị thư viện";
     
    }
}