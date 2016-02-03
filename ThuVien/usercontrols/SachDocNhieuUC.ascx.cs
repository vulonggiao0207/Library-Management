using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;
public partial class usercontrols_SachDocNhieuUC : System.Web.UI.UserControl
{
    SachBUS sachBUS = new SachBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        SachCollection sachColl = new SachCollection();
        sachColl = sachBUS.TimDSSachDocNhieu();
        int soluong = 16;
        if (sachColl.Count <= 16)
            soluong = sachColl.Count;
        SachCollection _sachColl = new SachCollection();
        for (int i = 0; i < soluong; i++)
        {
            _sachColl.Add(sachColl.Index(i));
        }
        SachListView.DataSource = _sachColl;
        SachListView.DataBind();
    }
}