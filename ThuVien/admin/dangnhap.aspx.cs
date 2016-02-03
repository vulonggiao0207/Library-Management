using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
public partial class admin_dangnhap : System.Web.UI.Page
{
    NhanVienBUS nvBUS = new NhanVienBUS();
    QuyenBUS quyenBUS = new QuyenBUS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DangNhapButton_Click(object sender, EventArgs e)
    {
        string manv = string.Empty;
        
        string tennv = nvBUS.DangNhap(TaiKhoanTextBox.Text, MatKhauTextBox.Text, ref manv);
        if (tennv != string.Empty)
        {
            Session["manv"] = manv;
            Session["tennv"] = tennv;
            //Session["tendangnhap"] = tendangnhap;
            if (Session["manv"] != null && Session["tennv"] != null)
                Session["Quyen"] = quyenBUS.TimDSQuyen_NhanVien(Session["manv"].ToString());
            Response.Redirect("trangchu.aspx");
        }
        else
        {
            ThongBaoLabel.Text = "Mật khẩu không hợp lệ";
        }
    }
}