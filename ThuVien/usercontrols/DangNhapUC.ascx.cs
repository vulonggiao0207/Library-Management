using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class user_controls_DangNhapUC : System.Web.UI.UserControl
{
    DocGiaBUS docgiaBUS= new DocGiaBUS();
    public void AnHien(bool var)
    {
        bool _var = var;
        if (var == true) _var = false;
        else _var = true;
        SachDanMuonButton.Visible = _var;
        DoimatkhauButton.Visible = _var;
        ThoatButton.Visible = _var;
        Panel1.Visible = _var;
        taikhoanLabel.Visible = var;
        MatkhauLabel.Visible = var;
        TaiKhoanTextBox.Visible = var;
        MatKhauTextBox.Visible = var;
        DangNhapButton.Visible = var;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["madocgia"] != null)
        {
            AnHien(false);

        }
        else
        {
            AnHien(true);

        }
    }
    protected void DangNhapButton_Click(object sender, EventArgs e)
    {
        ThongbaoLabel.Text = "";
        if (MatKhauTextBox.Text.Trim() == "")
            ThongbaoLabel.Text = "Chưa nhập mật khẩu";
        string madocgia = docgiaBUS.DangNhap(TaiKhoanTextBox.Text, MatKhauTextBox.Text);
        if (madocgia != "")
        {
            Session["madocgia"] = madocgia;
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            ThongbaoLabel.Text = "Sai mật khẩu!";
        }
    }
    protected void SachDanMuonButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("sachdangmuon.aspx");
    }
    protected void DoimatkhauButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("doipass.aspx");
    }
    protected void ThoatButton_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect(Request.RawUrl);          
    }
}