using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
public partial class admin_doipass : System.Web.UI.Page
{
    NhanVienBUS nvBUS = new NhanVienBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");  

    }
    protected void DoiButton_Click(object sender, EventArgs e)
    {
        string manv = Convert.ToString(Session["manv"]);
        string mkhaumoi = MatKhauMoiTextBox.Text;
        string mkhaucu = MatKhauCuTextBox.Text;
     
        string ktmatkhau = nvBUS.Ktmatkhau(manv);
        if (MatKhauCuTextBox.Text == "")
        {
            ThongBaoLabel.Text = "Mat khẩu cũ không được rỗng";
            return;
        }
        else if (ktmatkhau == MatKhauCuTextBox.Text)
        {
            if (MatKhauMoiTextBox.Text == "" || MatKhauXacThucTextBox.Text == "")
            {
                ThongBaoLabel.Text = "Mật khẩu mới và nhập lại mật khẩu mới không được rỗng";
                return;
            }
            if (MatKhauMoiTextBox.Text == MatKhauXacThucTextBox.Text)
            {
                bool kq = nvBUS.DoiMatKhau(manv, mkhaumoi, mkhaucu);
                if (kq == true)
                    ThongBaoLabel.Text = "Bạn đã đổi mật khẩu thành công";
            }
            else
            {
                ThongBaoLabel.Text="Nhập lại mật khẩu không trùng với mật khẩu mới";
                return;
            }
        }
        else
        {
            ThongBaoLabel.Text = "Bạn đã sai mật khẩu cũ";
            return;
        }
    }
}