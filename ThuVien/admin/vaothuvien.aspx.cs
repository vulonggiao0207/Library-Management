using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DAO;

public partial class admin_vaothuvien : System.Web.UI.Page
{
    DocTaiChoBUS doctaichoBUS = new DocTaiChoBUS();
    DocTaiChoDAO doctaichoDAO = new DocTaiChoDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            TenNVlabel.Text = Session["tennv"].ToString();
            MaDocGiaTextBox.Text = "";
            GridBinding();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ThongBaoLabel.Text = "";
        string manv = Session["manv"].ToString();
        string madocgia = MaDocGiaTextBox.Text;
        string kt = doctaichoBUS.KiemTraDocGia(madocgia);
        if (kt == MaDocGiaTextBox.Text)
        {
            string trasach = doctaichoBUS.KTSachChuaTra(madocgia);
            if (trasach == string.Empty)
            {
                bool kq = doctaichoBUS.VaoRaThuVien(manv, madocgia);
                if (kq == true)
                {
                    ThongBaoLabel.Text = "Hệ Thống chấp nhận";
                }
            }
            else
            {
               
                ThongBaoLabel.Text = "Đọc giả chưa trả sách đọc tại thư viện";
            }
        
        }
        else
        {
            //Response.Write("<script language='javascript'>");
            //Response.Write("alert('Đọc giả chưa đăng ký vào hệ thống');");
            //Response.Write("</script>");
            ThongBaoPopup.Show();
        }
        GridBinding();
        MaDocGiaTextBox.Text = "";
        MaDocGiaTextBox.Focus();
    }

    void GridBinding()
    {
        DsDocGiaGridView.DataSource = doctaichoDAO.DsDocGia();
        DsDocGiaGridView.DataBind();
       
    }


    
}