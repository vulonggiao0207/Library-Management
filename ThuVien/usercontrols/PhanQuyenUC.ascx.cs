using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
public partial class usercontrols_PhanQuyenUC : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Quyen"] != null && !IsPostBack)
        {
            QuyenCollection quyencoll = new QuyenCollection();
            quyencoll =(QuyenCollection) Session["Quyen"];
            PhanQuyenListView.DataSource = quyencoll;
            PhanQuyenListView.DataBind();         
        }

    }
}