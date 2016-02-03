using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_sachhumat : System.Web.UI.Page
{
    SachBUS sachBUS = new SachBUS();
    TacGiaBUS tacgiaBUS = new TacGiaBUS();
    NhaXuatBanBUS nhaxuatbanBUS = new NhaXuatBanBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    public void NapDuLieu()
    {       
        int cachtim = Convert.ToInt32(CachTimDropdown.SelectedValue);
        SachGridView.DataSource = sachBUS.TimSachChuaTra(TenSachTextBox.Text, cachtim);
        SachGridView.DataBind();
    }
    public void NapDuLieuPhucHoi()
    {
        int cachtim = Convert.ToInt32(CachTim2Dropdown.SelectedValue.ToString());
        string tensach = TenSach2TextBox.Text;
        Sach2GridView.DataSource = sachBUS.TimSachDaMat(tensach,cachtim);
        Sach2GridView.DataBind();        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
    }
    protected void SachGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SachGridView.PageIndex = e.NewPageIndex;
        NapDuLieu();
    }
    protected void SachGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "mat")
        {
            string masach=e.CommandArgument.ToString();
            sachBUS.ThayDoiTrangThai(masach, false);
            NapDuLieu();
            NapDuLieuPhucHoi();
        }
    }
    protected void SachGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hiển thị chức vụ
            Label nhaxuatban;
            nhaxuatban = (Label)e.Row.FindControl("NhaxuatbanLabel");
            nhaxuatban.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "manxb") != null)
            {
                nhaxuatban.Text = (string)DataBinder.Eval(e.Row.DataItem, "manxb");
                string tennxb = nhaxuatbanBUS.Tim1NXB(nhaxuatban.Text).TenNXB;
                nhaxuatban.Text = tennxb;
            }
            Label songayhethan = (Label)e.Row.FindControl("SoNgayHetHanLabel");
          //  songayhethan=phieu
            nhaxuatban.DataBind();
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
        if (SachGridView.Rows.Count == 0)
            ThonBaoLabel.Text = "Không tìm ra bất kỳ sách nào";
    }
    /// <summary>
    /// //////////////phục hồi
    /// </summary>
    protected void Tim2Button_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieuPhucHoi();
        if (Sach2GridView.Rows.Count == 0)
            ThonBaoLabel0.Text = "Không tìm ra bất kỳ sách nào";
    }
    protected void Sach2GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Sach2GridView.PageIndex = e.NewPageIndex;
        NapDuLieuPhucHoi();
    }
    protected void Sach2GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "phuchoi")
        {
            string masach = e.CommandArgument.ToString();
            sachBUS.ThayDoiTrangThai(masach, true);
            NapDuLieu();
            NapDuLieuPhucHoi();
        }
    }
    protected void Sach2GridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hiển thị chức vụ
            Label nhaxuatban;
            nhaxuatban = (Label)e.Row.FindControl("NhaxuatbanLabel0");
            nhaxuatban.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "manxb") != null)
            {
                nhaxuatban.Text = (string)DataBinder.Eval(e.Row.DataItem, "manxb");
                string tennxb = nhaxuatbanBUS.Tim1NXB(nhaxuatban.Text).TenNXB;
                nhaxuatban.Text = tennxb;
            }
            Label songayhethan = (Label)e.Row.FindControl("SoNgayHetHanLabel0");
            //  songayhethan=phieu
            nhaxuatban.DataBind();
        }
    }
}