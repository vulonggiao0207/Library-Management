using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class usercontrols_TimSachUC : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TimButton_Click(object sender, EventArgs e)
    {
        string tensach = TimSachTextBox.Text;
        Response.Redirect("tracuu.aspx?ten="+tensach);
    }
}