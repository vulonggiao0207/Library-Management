using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;

public partial class admin_trasach : System.Web.UI.Page
{
    DocTaiChoBUS doctaichoBUS = new DocTaiChoBUS();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool kq = doctaichoBUS.TraSach(MaSachTextBox.Text);
        if (kq == true)
            ThongBaoLabel.Text = "Bạn đã trả sách thành công";
        else
            ThongBaoLabel.Text = "Bạn thất bại khi trả sách";
    }
}