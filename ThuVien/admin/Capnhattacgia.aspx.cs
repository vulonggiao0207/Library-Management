using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;

public partial class admin_Capnhattacgia : System.Web.UI.Page
{
    TacGiaBUS tacgiaBUS = new TacGiaBUS();

    public void NapDuLieu()
    {
        string tentg = TimTextbox.Text;
        LoaitacgiaGridView.DataSource = tacgiaBUS.TimDSTacGia(tentg);
        LoaitacgiaGridView.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NapDuLieu();
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
   
 
   
   
   
   
   
 
    protected void LoaitacgiaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            string matg = (e.CommandArgument).ToString();
            tacgiaBUS.XoaTg(matg);
            NapDuLieu();
        }

        else if (e.CommandName == "sua")
        {
            TacGiaCollection tacgiacoll = new TacGiaCollection();
            tacgiacoll = tacgiaBUS.TimDSTacGia(TimTextbox.Text);

            int index = Convert.ToInt32(e.CommandArgument.ToString());
            ViewState["MaTg"] = tacgiacoll.Index(index).MaTG;

            string tentg = tacgiacoll.Index(index).TenTG;
            SuaPopup.Show();
            SuaTextBox.Text = tentg;
        }

    }

    protected void SuatgButton_Click(object sender, EventArgs e)
    {
        tacgiaBUS.SuaTg(ViewState["MaTg"].ToString(), SuaTextBox.Text);
        NapDuLieu();
    }
    protected void ThemtgButton_Click(object sender, EventArgs e)
    {
        string tentg = ThemtgTextBox.Text;
        tacgiaBUS.ThemTg(tentg);

        NapDuLieu();
        ThemtgTextBox.Text = " ";
    }
}