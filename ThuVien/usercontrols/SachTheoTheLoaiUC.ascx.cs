using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BUS;
public partial class usercontrols_SachTheoTheLoai : System.Web.UI.UserControl
{
    PhanLoaiBUS plBUS = new PhanLoaiBUS();
    protected void Page_Load(object sender, EventArgs e)
    {      
        TheLoaiSachListView.DataSource = plBUS.TimDSPhanLoai();
        TheLoaiSachListView.DataBind();        
    }
}