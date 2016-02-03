using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DAO;
using BO;

public partial class admin_capnhatloaisach : System.Web.UI.Page
{
    
    LoaiSachBUS loaisachBUS = new LoaiSachBUS();
    

    public void NapDuLieu()
    {
        
        string tensach = TimTextbox.Text;
        LoaisachGridView.DataSource = loaisachBUS.TimDSLoaiSach(tensach);
        LoaisachGridView.DataBind();
        

    }
    protected void Page_Load(object sender, EventArgs e)
    {
          if (Session["manv"] == null || Session["tennv"] == null)
              Response.Redirect("dangnhap.aspx");    
         // nạp dữ liệu
        if (!IsPostBack)//IMPORTANT
        {
            NapDuLieu();
        }


    }


    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }

    protected void LoaisachGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            string maloai = (e.CommandArgument).ToString();
            loaisachBUS.XoaLoaiSach(maloai);
            NapDuLieu();
        }
        else if (e.CommandName == "sua")
        {
            
            LoaiSachCollection loaisachcoll = new LoaiSachCollection();
            
            
            loaisachcoll = loaisachBUS.TimDSLoaiSach(TimTextbox.Text);

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["MaLoai"] = loaisachcoll.Index(index).MaLoai;
            string tenloai = loaisachcoll.Index(index).TenLoai;
            SuaPopup.Show();
            SuaTextBox.Text = tenloai;
        }
    }



    protected void ThemLoaiButton_Click(object sender, EventArgs e)
    {
        string tensach = ThemLoaiTextBox.Text;
        loaisachBUS.ThemLoaiSach(tensach);
        
        NapDuLieu();
        ThemLoaiTextBox.Text = " ";


    }
    protected void SuaLoaiButton_Click(object sender, EventArgs e)
    {
        loaisachBUS.SuaLoaiSach(ViewState["MaLoai"].ToString(), SuaTextBox.Text);
        NapDuLieu();
    }
   
}