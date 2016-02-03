using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;

public partial class admin_capnhatloaidocgia : System.Web.UI.Page
{
    LoaiDocGiaBUS loaidocgiaBUS = new LoaiDocGiaBUS();

    public void NapDuLieu()
    {
        string tendocgia = TimTextbox.Text;
        LoaidocgiaGridView.DataSource= loaidocgiaBUS.TimDSLoaiDocGia(tendocgia);
        LoaidocgiaGridView.DataBind();
 
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
    protected void  LoaidocgiaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            string maloai = (e.CommandArgument).ToString();
            loaidocgiaBUS.XoaLoaiDocGia(maloai);
            NapDuLieu();
        }
        else if (e.CommandName == "sua")
        {
            LoaiDocGiaCollection loaidocgiacoll = new LoaiDocGiaCollection();
            loaidocgiacoll = loaidocgiaBUS.TimDSLoaiDocGia(TimTextbox.Text);

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["MaLoai"] = loaidocgiacoll.Index(index).MaLoai;
            string tenloai = loaidocgiacoll.Index(index).TenLoai;
            SuaPopup.Show();
            SuaTextBox.Text = tenloai;
        }
    }


   
    protected void ThemLoaiButton_Click(object sender, EventArgs e)
    {
        string tendocgia = ThemLoaiTextBox.Text;
        loaidocgiaBUS.ThemLoaiDocGia(tendocgia);
        NapDuLieu();
        ThemLoaiTextBox.Text = " ";
        

    }
    protected void SuaLoaiButton_Click(object sender, EventArgs e)
    {
        loaidocgiaBUS.SuaLoaiDocGia(ViewState["MaLoai"].ToString(), SuaTextBox.Text);
        NapDuLieu();  
    }

}