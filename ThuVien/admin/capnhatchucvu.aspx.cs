using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_capnhatchucvu : System.Web.UI.Page
{
    ChucVuBUS chucvuBUS = new ChucVuBUS();
    public void NapDuLieu()
    {
        string tencv = TimTextbox.Text;
        ChucVuGridView.DataSource = chucvuBUS.TimDSChucVu(tencv);
        ChucVuGridView.DataBind();
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
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    protected void ThemChucVuButton_Click(object sender, EventArgs e)
    {
        chucvuBUS.ThemChucVu(ThemChucVuTextBox.Text);
        NapDuLieu();
        ThemChucVuTextBox.Text = "";
    }
    protected void ChucVuGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //nếu bấm nút xóa ==>xóa ngay
        if (e.CommandName == "xoa")
        {
            string macv = (e.CommandArgument).ToString();
            if (chucvuBUS.XoaChucVu(macv) == true)
            {
                chucvuBUS.XoaChucVu(macv);
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
            ChucVuCollection cvColl = new ChucVuCollection();
            cvColl = chucvuBUS.TimDSChucVu(TimTextbox.Text);
            //Lấy index dòng đang chọn
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["macv"] = cvColl.Index(index).MaCV;
            string tencv = cvColl.Index(index).TenCV;
            SuaPopup.Show();
            SuaTextBox.Text = tencv;
        }
    }
    protected void SuaChucVuButton_Click(object sender, EventArgs e)
    {
        chucvuBUS.SuaChucVu(ViewState["macv"].ToString(), SuaTextBox.Text);
        NapDuLieu();
    }
   
}