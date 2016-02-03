using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;
public partial class admin_capnhatphanloai : System.Web.UI.Page
{
    PhanLoaiBUS phanloaiBUS = new PhanLoaiBUS();
    public void NapDuLieu()
    {
        string tenphanloai = TimTextbox.Text;
        
        PhanLoaiGridView.DataSource = phanloaiBUS.TimDSCapNhatPhanLoai(tenphanloai);
        PhanLoaiGridView.DataBind();
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
          if (Session["manv"] == null || Session["tennv"] == null)
               Response.Redirect("dangnhap.aspx");    
           //nạp dữ liệu
        if (!IsPostBack)//IMPORTANT
        {
            NapDuLieu();
        }

    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }    
    protected void PhanLoaiGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            string maphanloai = (e.CommandArgument).ToString();
            phanloaiBUS.XoaPhanLoai(maphanloai);
            NapDuLieu();
           
        }
        else if (e.CommandName == "sua")
        {
            PhanLoaiCollection phanloaicoll = new PhanLoaiCollection();
            phanloaicoll = phanloaiBUS.TimDSCapNhatPhanLoai(TimTextbox.Text);
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["MaPhanLoai"] = phanloaicoll.Index(index).MaPhanLoai;
            string tenphanloai = phanloaicoll.Index(index).TenPhanLoai;
            SuaPopup.Show();
            SuaTextBox.Text = tenphanloai;
            
        }
        else if (e.CommandName == "chitiet")
        {
            PhanLoaiCollection phanloaicoll = new PhanLoaiCollection();
            phanloaicoll = phanloaiBUS.TimDSCapNhatPhanLoai(TimTextbox.Text);
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["MaPhanLoai"] = phanloaicoll.Index(index).MaPhanLoai;
            string tenchitiet = phanloaicoll.Index(index).TenPhanLoai;
            ChiTietPopup.Show();
            NapChiTiet();
            TenPhanLoaiLabel.Text = tenchitiet;
        }
    }
    protected void SuaPhanLoaiButton_Click(object sender, EventArgs e)
    {
        phanloaiBUS.SuaPhanLoai(ViewState["MaPhanLoai"].ToString(), SuaTextBox.Text);
        NapDuLieu();
    }
    protected void ThemPhanLoaiButton_Click(object sender, EventArgs e)
    {
        string tenphanloai = ThemPhanLoaiTextBox.Text;
        phanloaiBUS.ThemPhanLoai(tenphanloai);
        NapDuLieu();
        ThemPhanLoaiTextBox.Text = " ";

        
    }
    ////////////////////////////////////////////////////////
    public void NapChiTiet()
    {
        string maphanloai = ViewState["MaPhanLoai"].ToString();
        ChiTietGridView.DataSource = phanloaiBUS.TimDSCTPhanLoai(maphanloai);
        ChiTietGridView.DataBind();
    }
    protected void ThemChitiet_Click(object sender, EventArgs e)
    {
        string tenpl = TenPhanLoaiThemTextBox.Text;
        string mapl = ViewState["MaPhanLoai"].ToString();
        bool kq = phanloaiBUS.ThemCTPhanLoai(mapl, tenpl);
        TenPhanLoaiThemTextBox.Text="";
        ChiTietPopup.Show();
        NapChiTiet();
    }
    protected void ChiTietGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            bool kq=phanloaiBUS.XoaCTPhanLoai(e.CommandArgument.ToString());
        }
        else if (e.CommandName == "sua")
        {
            ChiTietGridView.EditIndex = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["index"]=e.CommandArgument.ToString();
        }
        else if (e.CommandName == "luu")
        {
            string mact = e.CommandArgument.ToString();
            TextBox ctloai;
            int index=Convert.ToInt32(ViewState["index"].ToString());
            ctloai = (TextBox)ChiTietGridView.Rows[index].FindControl("TenChiTietTextBox");
            string tenct = ctloai.Text;
            bool kq = phanloaiBUS.SuaCTPhanLoai(mact, tenct);
            ChiTietGridView.EditIndex = -1;
        }
        else if (e.CommandName == "huy")
        {
            ChiTietGridView.EditIndex = -1;
        }
        NapChiTiet();
        ChiTietPopup.Show();
    }
}