using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;

public partial class admin_capnhatkhuvuc : System.Web.UI.Page
{
    KhuVucBUS khuvucBUS = new KhuVucBUS();
    public void NapDuLieu()
    {
        string tenkhuvuc = TimTextbox.Text;
        KhuVucGridView.DataSource = khuvucBUS.TimDSKhuVuc(tenkhuvuc);
        KhuVucGridView.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            NapDuLieu();
        }
    }
    protected void KhuVucGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //nếu bấm nút xóa ==>xóa ngay
        if (e.CommandName == "xoa")
        {
            string makhuvuc = (e.CommandArgument).ToString();
            if (khuvucBUS.XoaKhuVuc(makhuvuc) == true)
            {
                khuvucBUS.XoaKhuVuc(makhuvuc);
                NapDuLieu();
            }
            else
            {
                ThongBaoPopup.Show();
            }
        }
        //nếu bấm nút sửa ==>bật popup sửa
        else if (e.CommandName == "sua")
        {
            //lấy danh sach ChucVu
            KhuVucCollection kvColl = new KhuVucCollection();
            kvColl = khuvucBUS.TimDSKhuVuc(TimTextbox.Text);
            //Lấy index dòng đang chọn
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["makhuvuc"] = kvColl.Index(index).MaKhuVuc;
            string tenkhuvuc = kvColl.Index(index).TenKhuVuc;
            SuaPopup.Show();
            SuaTextBox.Text = tenkhuvuc;
        }

    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();

    }
    protected void ThemKhuVucButton_Click(object sender, EventArgs e)
    {
        khuvucBUS.ThemKhuVuc(ThemKhuVucTextBox.Text);
        NapDuLieu();
        ThemKhuVucTextBox.Text = " ";

    }
    protected void SuaKhuVucButton_Click(object sender, EventArgs e)
    {
        khuvucBUS.SuaKhuVuc(ViewState["makhuvuc"].ToString(), SuaTextBox.Text);
        
        NapDuLieu();
    }
}