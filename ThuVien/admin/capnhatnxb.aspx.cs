using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_capnhatnxb : System.Web.UI.Page
{
    NhaXuatBanBUS nxbBUS = new NhaXuatBanBUS();
    public void NapDuLieu()
    {
        string tennxb = TimTextbox.Text;
        NhaxuatbanGridView.DataSource = nxbBUS.TimDSNhaXuatBan(tennxb);
        NhaxuatbanGridView.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["manv"] == null || Session["tennv"] == null)
        //    Response.Redirect("dangnhap.aspx");    
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
    protected void NhaxuatbanGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       //nếu bấm nút xóa ==>xóa ngay
        if (e.CommandName == "xoa")
        {
            string manxb= (e.CommandArgument).ToString();
            nxbBUS.XoaNhaXuatBan(manxb);
            NapDuLieu();    
        }
       //nếu bấm nút sửa ==>bật popup sửa
        else if (e.CommandName == "sua")
        {
            //lấy source hiện tại của NhaXuatBanGridView
            NhaXuatBanCollection nxbColl= new NhaXuatBanCollection();
            nxbColl = nxbBUS.TimDSNhaXuatBan(TimTextbox.Text);
            //Lấy index dòng đang chọn
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["manxb"] = nxbColl.Index(index).MaNXB;
            string tennxb= nxbColl.Index(index).TenNXB;
            SuaPopup.Show();
            SuaTextBox.Text = tennxb;                 
        }
    }
    protected void ThemNXBButton_Click(object sender, EventArgs e)
    {
        nxbBUS.ThemNhaXuatBan(ThemNXBTextBox.Text);
        NapDuLieu();
        ThemNXBTextBox.Text = "";
    }


    protected void SuaNXBButton_Click(object sender, EventArgs e)
    {
        nxbBUS.SuaNhaXuatBan(ViewState["manxb"].ToString(),SuaTextBox.Text);
        NapDuLieu();  
    }

    /*   protected void NhaxuatbanGridView_RowDataBound(object sender, GridViewRowEventArgs e)
   {
       if (e.Row.RowType == DataControlRowType.DataRow)// kiểm tra dòng này phải dòng dữ liệu không (không phải header và footer)
       {
           ImageButton btn = e.Row.FindControl("SuaButton") as ImageButton;           
           ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btn);
       }
   }*/
}