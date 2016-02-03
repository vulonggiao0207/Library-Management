using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class tracuu : System.Web.UI.Page
{
    SachBUS sachBUS = new SachBUS();
    TacGiaBUS tacgiaBUS = new TacGiaBUS();
    NhaXuatBanBUS nhaxuatbanBUS = new NhaXuatBanBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    PhanLoaiBUS phanloaiBUS = new PhanLoaiBUS();
    LoaiSachBUS loaisachBUS = new LoaiSachBUS();
    KhuVucBUS khuvucBUS = new KhuVucBUS();
    public void NapLoaiSach()
    {
        LoaisachDropdown.Items.Clear();
        LoaiSachCollection source = new LoaiSachCollection();
        LoaiSachBO loaisachBO= new LoaiSachBO();
        loaisachBO.TenLoai = "Tất cả";
        loaisachBO.MaLoai = "";
        source.Add(loaisachBO);
        //add
        LoaiSachCollection temp = new LoaiSachCollection();
        temp = loaisachBUS.TimDSLoaiSach("");
        for (int i = 0; i < temp.Count; i++)
        {
            source.Add(temp.Index(i));
        }
        LoaisachDropdown.DataSource =source;
        LoaisachDropdown.DataTextField = "TenLoai";
        LoaisachDropdown.DataValueField = "Maloai";
        LoaisachDropdown.DataBind();
    }
    public void NapTheLoai()
    {
        TheLoaiDropdown.Items.Clear();
        PhanLoaiCollection source = new PhanLoaiCollection();      
        PhanLoaiBO phanloaiBO = new PhanLoaiBO();
        phanloaiBO.TenPhanLoai = "Tất cả";
        phanloaiBO.MaPhanLoai = "";
        source.Add(phanloaiBO);
        //add
        PhanLoaiCollection temp = new PhanLoaiCollection();
        temp=phanloaiBUS.TimDSPhanLoai();
        for (int i = 0; i < temp.Count; i++)
        {
            source.Add(temp.Index(i));
        }
        TheLoaiDropdown.DataSource = source;
        TheLoaiDropdown.DataTextField = "Tenphanloai";
        TheLoaiDropdown.DataValueField = "Maphanloai";
        TheLoaiDropdown.DataBind();
    }
    public void NapChuDe(string maphanloai)
    {
        ChudeDropdown.Items.Clear();
        CTPhanLoaiCollection source = new CTPhanLoaiCollection();
        CTPhanLoai ctphanloai = new CTPhanLoai();
        ctphanloai.TenCTPhanLoai="Tất cả";
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
        ChudeDropdown.DataSource = source;
        ChudeDropdown.DataTextField = "TenCTphanloai";
        ChudeDropdown.DataValueField = "MaCtphanloai";
        ChudeDropdown.DataBind();
    }
    public void NapDuLieu(string tensach,string maloai,string maphanloai,string mactphanloai)
    {
        SachGridview.DataSource= sachBUS.TimSach(tensach, maloai,maphanloai, mactphanloai);
        SachGridview.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NapLoaiSach();
            NapTheLoai();
            string matheloai = TheLoaiDropdown.SelectedValue;
            NapChuDe(matheloai);
        /////////////////////////////
            string ten = "";
            string maphanloai = "";
            if (Request.QueryString["ten"] != null)
            {
                ten = Request.QueryString["ten"].ToString();
                TenSachTextBox.Text = ten;
            }
            if (Request.QueryString["maphanloai"] != null)
            {
                maphanloai = Request.QueryString["maphanloai"].ToString();
                TheLoaiDropdown.SelectedValue = maphanloai;
                NapChuDe(maphanloai);
            }
            NapDuLieu(ten, "", maphanloai,"");
            if (SachGridview.Rows.Count == 0)
                ThongBaoLabel.Text = "Không tìm đựơc sách nào";
        }
    }
    protected void TìmButton_Click(object sender, EventArgs e)
    {
        ThongBaoLabel.Text = "";
        string ten= TenSachTextBox.Text;
        string maloai=LoaisachDropdown.SelectedValue;
        string maphanloai = TheLoaiDropdown.SelectedValue;
        string ctphanloai= ChudeDropdown.SelectedValue;
        NapDuLieu(ten, maloai,maphanloai, ctphanloai);
        if (SachGridview.Rows.Count == 0)
            ThongBaoLabel.Text = "Không tìm đựơc sách nào";
    //    Response.Redirect("tracuu?ten="+ten+"&&maloai="+maloai+"&&mactphanloai="+ctphanloai);
    }
    protected void SachGridview_RowCreated(object sender, GridViewRowEventArgs e)
    {
       /* if (e.Row.RowType == DataControlRowType.DataRow && DataBinder.Eval(e.Row.DataItem, "masach") != null)
        {
            int index = e.Row.RowIndex;
            string _ten = TenSachTextBox.Text;
            string _maloai = LoaisachDropdown.SelectedValue;
            string _ctphanloai = TheLoaiDropdown.SelectedValue;
            SachCollection sachColl = new SachCollection();
            sachColl= sachBUS.TimSach(_ten, _maloai, _ctphanloai);
            //gấn dữ liệu
            Label LoaiSachLabel = (Label)e.Row.FindControl("LoaiSachLabel");
            Label TheLoaiLabel = (Label)e.Row.FindControl("TheLoaiLabel");
            Label ChuDeLabel = (Label)e.Row.FindControl("ChuDeLabel");
            Label KhuVucLabel = (Label)e.Row.FindControl("KhuVucLabel");
            string maloai = sachColl.Index(index).MaLoai;
            string mactphanloai = sachColl.Index(index).MaCTPhanLoai;
            string makhuvuc = sachColl.Index(index).khuvuc;
            if (maloai != "")
                LoaiSachLabel.Text = loaisachBUS.Tim1LoaiSach(maloai).TenLoai;
            if (mactphanloai != "")
            {
                TheLoaiLabel.Text = phanloaiBUS.Tim1CTPhanLoai(mactphanloai).TenCTPhanLoai;
                ChuDeLabel.Text = phanloaiBUS.Tim1PhanLoai_CT(mactphanloai).TenPhanLoai;
            }
            if (makhuvuc != "")
                KhuVucLabel.Text = khuvucBUS.Tim1KhuVuc(makhuvuc).TenKhuVuc;
        }*/
    }
    protected void SachGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SachGridview.PageIndex = e.NewPageIndex;
        string ten = TenSachTextBox.Text;
        string maloai = LoaisachDropdown.SelectedValue;
        string maphanloai = TheLoaiDropdown.SelectedValue;
        string mactphanloai = ChudeDropdown.SelectedValue;   
        NapDuLieu(ten, maloai,maphanloai, mactphanloai);
    }
    protected void TheLoaiDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        string matheloai = TheLoaiDropdown.SelectedValue;
        NapChuDe(matheloai);
    }
}