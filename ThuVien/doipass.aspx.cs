using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class doipass : System.Web.UI.Page
{
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["madocgia"] == null)
            Response.Redirect("trangchu.aspx");
    }
    protected void DoiButton_Click(object sender, EventArgs e)
    {
        if (Session["madocgia"] != null)
        {
            string madocgia = Session["madocgia"].ToString();
            if (docgiaBUS.DangNhap(madocgia, MatkhaucuTextBox.Text) == "")
            {
                ThongBaoLabel.Text = "Mật khẩu cũ sai";
                return;
            }
            if (MatkhaumoiTextBox.Text.Trim() == "")
            {
                ThongBaoLabel.Text = "Mật khẩu mới không đựơc bỏ trống";
                return;
            }
            if (MatkhaumoiTextBox.Text != XacNhanTextBox.Text)
            {
                ThongBaoLabel.Text = "Xác nhận mật khẩu sai";
                return;
            }
            bool kq = docgiaBUS.DoiMatKhau(madocgia, MatkhaumoiTextBox.Text);
            if (kq == true)
            {
                ThongBaoLabel.Text = "Đổi mật khẩu thành công!";
            }
            else
            {
                ThongBaoLabel.Text = "Đã có sự cố! Không thể đổi mật khẩu, mời thử lại sau";
            }
        }


    }
}