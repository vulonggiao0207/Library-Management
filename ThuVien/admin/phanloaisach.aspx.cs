using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;
public partial class admin_phanloaisach : System.Web.UI.Page
{
    NhaXuatBanBUS nhaxuatbanBUS = new NhaXuatBanBUS();
    SachBUS sachBUS = new SachBUS();
    TacGiaBUS tacgiaBUS = new TacGiaBUS();
    PhanLoaiBUS phanloaiBUS = new PhanLoaiBUS();
    LoaiSachBUS loaisachBUS = new LoaiSachBUS();
    KhuVucBUS khuvucBUS = new KhuVucBUS();
    public void NapDuLieu()
    {
        string tensach = TimTextbox.Text;
        SachGridView.DataSource = sachBUS.TimDSSach(tensach);
        SachGridView.DataBind();
    }  
    public void NapDuLieu2()
    {
        string tensach = TimTextbox.Text;
        SachGridView.DataSource = sachBUS.TimDSSachPhanLoai(tensach);
        SachGridView.DataBind();
    }
    public void NapLoaiSach()
    {
        ////lọai
        LoaiSachLuuDropdown.Items.Clear();
        LoaiSachCollection source = new LoaiSachCollection();
        LoaiSachBO loaisachBO = new LoaiSachBO();
        loaisachBO.TenLoai = "...";
        loaisachBO.MaLoai = "";
        source.Add(loaisachBO);
        //add
        LoaiSachCollection temp = new LoaiSachCollection();
        temp = loaisachBUS.TimDSLoaiSach("");
        for (int i = 0; i < temp.Count; i++)
        {
            source.Add(temp.Index(i));
        }
        LoaiSachLuuDropdown.DataSource = source;
        LoaiSachLuuDropdown.DataTextField = "TenLoai";
        LoaiSachLuuDropdown.DataValueField = "MaLoai";
        LoaiSachLuuDropdown.DataBind();
    }
    public void NapPhanLoai()
    {
        PhanLoaiDropDown.Items.Clear();
        PhanLoaiCollection source = new PhanLoaiCollection();
        PhanLoaiBO phanloaiBO = new PhanLoaiBO();
        phanloaiBO.TenPhanLoai = "...";
        phanloaiBO.MaPhanLoai = "";
        source.Add(phanloaiBO);
        //add
        PhanLoaiCollection temp = new PhanLoaiCollection();
        temp = phanloaiBUS.TimDSPhanLoai();
        for (int i = 0; i < temp.Count; i++)
        {
            source.Add(temp.Index(i));
        }
        ////phân lọai
        PhanLoaiDropDown.DataSource = source;
        PhanLoaiDropDown.DataTextField = "TenPhanLoai";
        PhanLoaiDropDown.DataValueField = "MaPhanLoai";
        PhanLoaiDropDown.DataBind();
    }
    public void NapCTPhanLoai(string maphanloai)
    {
        CTPhanLoaiDropdown.Items.Clear();
        CTPhanLoaiCollection source = new CTPhanLoaiCollection();
        CTPhanLoai ctphanloai = new CTPhanLoai();
        ctphanloai.TenCTPhanLoai = "...";
        ctphanloai.MaCTPhanLoai = "";
        source.Add(ctphanloai);
        //add
        if (maphanloai != "")
        {
            CTPhanLoaiCollection temp = new CTPhanLoaiCollection();
            temp = phanloaiBUS.TimDSCTPhanLoai(maphanloai);
            if (temp != null)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    source.Add(temp.Index(i));
                }
            }
        }
        CTPhanLoaiDropdown.DataSource = source;
        CTPhanLoaiDropdown.DataTextField = "TenCTphanloai";
        CTPhanLoaiDropdown.DataValueField = "MaCtphanloai";
        CTPhanLoaiDropdown.DataBind();
    }
    public void NapKhuVuc()
    {
        KhuVucCollection source = new KhuVucCollection();
        KhuVucCollection temp = khuvucBUS.TimDSKhuVuc("");
        KhuVucBO khuvucBO = new KhuVucBO();
        khuvucBO.MaKhuVuc = "";
        khuvucBO.TenKhuVuc = "...";
        source.Add(khuvucBO);
        for(int i=0;i<temp.Count;i++)
            source.Add(temp.Index(i));
        ////khu vực
        KhuvucDropdown.DataSource = source;
        KhuvucDropdown.DataTextField = "TenKhuVuc";
        KhuvucDropdown.DataValueField = "MaKhuVuc";
        KhuvucDropdown.DataBind();
    }
    public void NapPhanLoaiDropDown()
    {
        NapLoaiSach();
        NapPhanLoai();
        NapKhuVuc();
        string maphanloai = PhanLoaiDropDown.SelectedValue;
        NapCTPhanLoai(maphanloai);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            NapDuLieu();
            NapPhanLoaiDropDown();
            NapKhuVuc();
        }
    } 
    protected void SachGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SachGridView.PageIndex = e.NewPageIndex;
        NapDuLieu();
    }
    protected void SachGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hiển thị chức vụ
            Label nhaxuatban;
            nhaxuatban = (Label)e.Row.FindControl("NhaxuatbanLabel");
            nhaxuatban.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "manxb") != null)
            {
                nhaxuatban.Text = (string)DataBinder.Eval(e.Row.DataItem, "manxb");
                string tennxb = nhaxuatbanBUS.Tim1NXB(nhaxuatban.Text).TenNXB;
                nhaxuatban.Text = tennxb;
            }
        }
    }   
    protected void SachGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
        ViewState["madausach"] = "";
        if (e.CommandName == "phanloai")
        {
            ViewState["madausach"] = e.CommandArgument.ToString();
            ChiTietPopup.Show();
            //Nạp chitiết phân lọai
            string maphanloai = PhanLoaiDropDown.SelectedValue;
            CTPhanLoaiDropdown.DataSource = phanloaiBUS.TimDSCTPhanLoai(maphanloai);
            CTPhanLoaiDropdown.DataValueField = "MaCTPhanLoai";
            CTPhanLoaiDropdown.DataTextField = "TenCTPhanLoai";
            CTPhanLoaiDropdown.DataBind();
            //lấy tất cả sách có mã đầu sách là e.CommandArgument
            int madausach = Convert.ToInt32(e.CommandArgument);
            SachBO sachBO = new SachBO();
            sachBO = sachBUS.Tim1Sach(madausach);
            //gán dữ liệu đầu sách điểh hình vào
            HinhanhdausachImage.ImageUrl = sachBO.hinhanh;
            TenDauSachLabel.Text = sachBO.TenSach;
            ChiTietDauSachLanXuatBanLabel.Text = sachBO.lanxuatban.ToString();
            ChiTietDauSachNgayNhapLabel.Text = sachBO.ngaynhap.ToString();
            ChiTietDauSachTriGiaLabel.Text = sachBO.trigia.ToString();
            //gán dữ liệu phân lọai
            if (sachBO.MaLoai != null && sachBO.MaLoai.ToString() != "")
                LoaiSachLuuDropdown.SelectedValue = sachBO.MaLoai;
            else
                LoaiSachLuuDropdown.SelectedValue = "";
            if (sachBO.MaCTPhanLoai != null&&sachBO.MaCTPhanLoai.ToString()!="")
            {
                PhanLoaiDropDown.SelectedValue = phanloaiBUS.Tim1PhanLoai_CT(sachBO.MaCTPhanLoai).MaPhanLoai;
                string _maphanloai = PhanLoaiDropDown.SelectedValue;
                NapCTPhanLoai(_maphanloai);
                CTPhanLoaiDropdown.SelectedValue = sachBO.MaCTPhanLoai;
            }
            else
            {
                NapCTPhanLoai("");
                PhanLoaiDropDown.SelectedValue = "";
                CTPhanLoaiDropdown.SelectedValue = "";
            }
            if (sachBO.khuvuc != null && sachBO.khuvuc.ToString()!="")
                KhuvucDropdown.SelectedValue = sachBO.khuvuc;
            else
                KhuvucDropdown.SelectedValue = "";
       //     if (sachBO.ke.ToString() != "")
                KeTextbox.Text = sachBO.ke;
       //     if (sachBO.ngan.ToString() != "")
                NganTextbox.Text = sachBO.ngan;
            if (sachBO.muondemve == true)
                MuondemveCheckbox.Checked = true;
            else
                MuondemveCheckbox.Checked = false;
            NapDuLieu();
        }
    }
    protected void LoaiSachDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(LoaiSachDropdown.SelectedIndex==0)
        {
            NapDuLieu();
        }
        else
        {
            NapDuLieu2();
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    protected void LuuButton_Click(object sender, EventArgs e)
    {
        int madausach=Convert.ToInt32(ViewState["madausach"].ToString());
        string maphanloai = LoaiSachLuuDropdown.SelectedValue;
        string mactphanloai=CTPhanLoaiDropdown.SelectedValue;
        string khuvuc=KhuvucDropdown.SelectedValue;
        string ke=KeTextbox.Text;
        string ngan=NganTextbox.Text;
        bool muondemve=MuondemveCheckbox.Checked;
        bool kq = sachBUS.PhanLoai(madausach, maphanloai, mactphanloai, khuvuc, ke, ngan, muondemve);
        //reset
        LoaiSachDropdown.SelectedIndex = 0;
        NapPhanLoaiDropDown();
        KeTextbox.Text="";
        NganTextbox.Text="";
        NapDuLieu();
    }
    protected void PhanLoaiDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        string maphanloai = PhanLoaiDropDown.SelectedValue;
        NapCTPhanLoai(maphanloai);
      /*  string maphanloai = PhanLoaiDropDown.SelectedValue;
        CTPhanLoaiDropdown.Items.Clear();
        CTPhanLoaiCollection source = new CTPhanLoaiCollection();
        CTPhanLoai ctphanloai = new CTPhanLoai();
        ctphanloai.TenCTPhanLoai = "...";
        ctphanloai.MaCTPhanLoai = "";
        source.Add(ctphanloai);
        //add
        CTPhanLoaiCollection temp = new CTPhanLoaiCollection();
        temp = phanloaiBUS.TimDSCTPhanLoai(maphanloai);
        if (temp != null)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                source.Add(temp.Index(i));
            }
        }
        CTPhanLoaiDropdown.DataSource = source;
        CTPhanLoaiDropdown.DataTextField = "TenCTphanloai";
        CTPhanLoaiDropdown.DataValueField = "MaCtphanloai";
        CTPhanLoaiDropdown.DataBind();*/
    }
}