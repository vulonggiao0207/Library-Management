using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;

public partial class admin_baocaosachnhap : System.Web.UI.Page
{
    BaoCaoThongKeBUS baocaothongkeBUS = new BaoCaoThongKeBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {

        }
        
    }

    void GridBinding(string tungay, string denngay)
    {
        ThongKeNhapSachGridView.DataSource = baocaothongkeBUS.BaoCaoNhapSach(tungay, denngay);
        ThongKeNhapSachGridView.DataBind();
        
    }
    protected void BaoCaoButton_Click(object sender, EventArgs e)
    {
        ThongKeNhapSachGridView.Visible = false;
        ThongBaoLabel.Text = "";
        string tungay = TuNgayTextBox.Text;
        string denngay = DenNgayTextBox.Text;
        
        if (Convert.ToDateTime(tungay) < Convert.ToDateTime(denngay))
        {
            ThongKeNhapSachGridView.Visible = true;
            GridBinding(tungay, denngay);
           
        }
        else
            ThongBaoLabel.Text = "Bạn phải chọn ngày bắt đầu lớn hơn ngày kết thúc ";
       
    }
}