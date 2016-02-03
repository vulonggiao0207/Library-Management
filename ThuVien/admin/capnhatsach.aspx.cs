using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using BO;
using BUS;
public partial class admin_capnhatsach : System.Web.UI.Page
{
    SachBUS sachBUS = new SachBUS();
    TacGiaBUS tacgiaBUS = new TacGiaBUS();
    NhaXuatBanBUS nhaxuatbanBUS = new NhaXuatBanBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    public void NapDuLieu()
    {
        string tensach=TimTextbox.Text;
        SachGridView.DataSource = sachBUS.TimDSSach(tensach);
        SachGridView.DataBind();
    }
    public void NapDSTacGia()
    {
        TacgiaMoiList.DataSource = tacgiaBUS.TimDSTacGia("");
        TacgiaMoiList.DataTextField = "TenTG";
        TacgiaMoiList.DataValueField = "MaTG";
        TacgiaMoiList.DataBind();

        TacGiaSuaListBox.DataSource = tacgiaBUS.TimDSTacGia("");
        TacGiaSuaListBox.DataTextField = "TenTG";
        TacGiaSuaListBox.DataValueField = "MaTG";
        TacGiaSuaListBox.DataBind();
    }
    public void NapDSNXB()
    {
        NhaXuatBanCollection nxb1= new NhaXuatBanCollection();
        NhaXuatBanCollection nxb2 = new NhaXuatBanCollection();
        NhaXuatBanCollection temp = new NhaXuatBanCollection();
        temp = nhaxuatbanBUS.TimDSNhaXuatBan("");
        NhaXuatBanBO nhaxuatbanBO = new NhaXuatBanBO();
        nhaxuatbanBO.TenNXB = "...";
        nhaxuatbanBO.MaNXB = "";
        nxb1.Add(nhaxuatbanBO);
        nxb2.Add(nhaxuatbanBO);
        for (int i = 0; i < temp.Count; i++)
        {
            nxb1.Add(temp.Index(i));
            nxb2.Add(temp.Index(i));
        }
        NhaxuatbanMoiDropdown.DataSource = nxb1;
        NhaxuatbanMoiDropdown.DataTextField = "tennxb";
        NhaxuatbanMoiDropdown.DataValueField = "manxb";
        NhaxuatbanMoiDropdown.DataBind();

        NhaXuatBanSuaDropDown.DataSource = nxb2;
        NhaXuatBanSuaDropDown.DataTextField = "tennxb";
        NhaXuatBanSuaDropDown.DataValueField = "manxb";
        NhaXuatBanSuaDropDown.DataBind();
    }
    public void NapChiTietSach(int madausach)
    {
        SachCollection sachColl = new SachCollection();
        sachColl = sachBUS.TimDSSach(madausach);
        //nạp vào ChiTietDaugridview
        ChiTietDauSachGridView.DataSource = sachColl;
        ChiTietDauSachGridView.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            NgaynhapsachMoiTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
            NgayNhapSuaTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
            NapDuLieu();
            NapDSTacGia();
            NapDSNXB();
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    protected void SachGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SachGridView.PageIndex = e.NewPageIndex;
        NapDuLieu();
    }
    public string GetFileName(string Image)
    {
        try
        {
            string duongdan = Server.MapPath("..\\images\\sach\\");
            string tenfile = Image;
            if (System.IO.Path.GetFileName(tenfile).ToString() != "")
            {
                while (System.IO.File.Exists(duongdan + tenfile) == true)
                    tenfile = tenfile.Split('.')[0] + "1" + "." + tenfile.ToString().Split('.')[1];
            }
            return tenfile;
        }
        catch
        {
            return string.Empty;
        }
    } // hàm xử lý upload file
    public bool KiemTraHopLe(string namxuatban,string lanxuatban,string trigia,string soluong )
    {
        ThemSachThongBaolabel.Text = "";
        int temp=0;
        if (int.TryParse(namxuatban, out temp) != true || Convert.ToInt32(namxuatban) < 1900)
        {
            ThemSachThongBaolabel.Text = "Năm xuất bản không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
        if (int.TryParse(lanxuatban, out temp) != true || Convert.ToInt32(lanxuatban) < 1)
        {
            ThemSachThongBaolabel.Text = "Lần xuất bản không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
        if (int.TryParse(trigia, out temp) != true || Convert.ToInt32(trigia) < 1)
        {
            ThemSachThongBaolabel.Text = "Trị giá không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
        if (int.TryParse(soluong, out temp) != true || Convert.ToInt32(soluong) < 1)
        {
            ThemSachThongBaolabel.Text = "số lượng không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
        return true;
    }
    protected void ThemSachButton_Click(object sender, EventArgs e)
    {
        bool res = KiemTraHopLe(NamxuatbanMoiTextBox.Text, LanxuatbanMoiTextbox.Text, TrigiaMoiTextBox.Text, SoluongMoiTextBotx.Text);
        if (res == false)
        {
            ThemPopup.Show();
            return;
        }
        string manxb=NhaxuatbanMoiDropdown.SelectedValue;
        string tensach=TenSachMoiTextBox.Text;
        int namxuatban=Convert.ToInt32(NamxuatbanMoiTextBox.Text);
        int lanxuatban=Convert.ToInt32(LanxuatbanMoiTextbox.Text);
        decimal trigia=Convert.ToDecimal(TrigiaMoiTextBox.Text);
        string hinhanh="";
        //lấy ds các tác giả
        TacGiaCollection tgColl = new TacGiaCollection();
        for (int i = 0; i < TacgiaMoiList.Items.Count;i++ )
        {
            if (TacgiaMoiList.Items[i].Selected == true)
            {
                TacGiaBO tgBO = new TacGiaBO();
                tgBO.MaTG = TacgiaMoiList.Items[i].Value;
                tgColl.Add(tgBO);
            }
        }
        string ngaynhap =nhanvienBUS.ChuyenNgayThang(NgaynhapsachMoiTextBox.Text);
        int soluong=Convert.ToInt32(SoluongMoiTextBotx.Text);     
        //Upload và lưu đường dẫn hình vào CSDL       
        bool hasimage = true; // biến kiểm tra đã có file đựơc upload chưa      
        if (HinhAnhMoiFileUpLoad.PostedFile != null && HinhAnhMoiFileUpLoad.PostedFile.FileName != "")//kiểm tra đã chọn file nào để upload chưa
            hinhanh = "~/images/sach/" + GetFileName(HinhAnhMoiFileUpLoad.PostedFile.FileName);
        else
        {
            hinhanh = "~/images/sach/questionbook.jpg";
            hasimage = false;
        }
        //THÊM VÀO CSDL
        bool kq = sachBUS.ThemSach(manxb, tensach, namxuatban, lanxuatban, trigia, hinhanh, tgColl,ngaynhap, soluong);
        if (kq == true)//Nếu lưu thành công
        {
            //Lưu hình ảnh vô thư mục ../images/sach
            if (hasimage == true)
                HinhAnhMoiFileUpLoad.SaveAs(Server.MapPath("..\\images\\sach\\") + System.IO.Path.GetFileName(hinhanh));
            NapDuLieu();
        }
        //reset lại Popup thêm nhân viên           
        TenSachMoiTextBox.Text = "";
        NgaynhapsachMoiTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
        NamxuatbanMoiTextBox.Text = "";
        LanxuatbanMoiTextbox.Text = "";
        TrigiaMoiTextBox.Text = "";
        SoluongMoiTextBotx.Text = "";
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
                if ((string)DataBinder.Eval(e.Row.DataItem, "manxb") != "")
                {
                    string tennxb = nhaxuatbanBUS.Tim1NXB(nhaxuatban.Text).TenNXB;
                    nhaxuatban.Text = tennxb;
                }
            }
        }
    }
    protected void SachGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["madausach"] = "";
        if (e.CommandName == "chitiet")
        {
            ThongbaoLabel.Text = "";
            ViewState["madausach"] = e.CommandArgument.ToString();
            ChiTietPopup.Show();
            //lấy tất cả sách có mã đầu sách là e.CommandArgument
            int madausach = Convert.ToInt32(e.CommandArgument);
            SachCollection sachColl = new SachCollection();
            sachColl = sachBUS.TimDSSach(madausach);
            //nạp vào ChiTietDaugridview
            ChiTietDauSachGridView.DataSource = sachColl;
            ChiTietDauSachGridView.DataBind();
            //gán dữ liệu đầu sách điểh hình vào
            HinhanhdausachImage.ImageUrl = sachColl.Index(0).hinhanh ;
            TenDauSachLabel.Text = sachColl.Index(0).TenSach;
            ChiTietDauSachLanXuatBanLabel.Text = sachColl.Index(0).lanxuatban.ToString();
            ChiTietDauSachNgayNhapLabel.Text = sachColl.Index(0).ngaynhap.ToString();
            ChiTietDauSachTriGiaLabel.Text = sachColl.Index(0).trigia.ToString();
            NapDuLieu();
        }
        else if(e.CommandName=="xoa")
        {
            ThongbaoLabel.Text = "";
            bool kq=sachBUS.XoaSach(Convert.ToInt32(e.CommandArgument.ToString()));
            if(kq==false)
                ThongbaoLabel.Text = "Không thể xóa đầu sách này được";
            NapDuLieu();
        }
        else if (e.CommandName == "sua")
        {
            ThongbaoLabel.Text = "";
            NapDSNXB();
            NapDSTacGia();
            ViewState["madausach"] = e.CommandArgument.ToString();
            //nạp dữ liệu lên form sửa
            SachBO sachBO = new SachBO();
            sachBO = sachBUS.Tim1Sach(Convert.ToInt32(e.CommandArgument));
            TenSachSuaTextBox.Text = sachBO.TenSach;
            TacGiaCollection tacgiaColl = new TacGiaCollection();
            tacgiaColl = sachBO.tacgiaColl;
            if (tacgiaColl != null && tacgiaColl.Count != 0)
            {
                for (int i = 0; i < tacgiaColl.Count; i++)
                {
                    for (int j = 0; j < TacGiaSuaListBox.Items.Count; j++)
                    {
                        if (tacgiaColl.Index(i).MaTG == TacGiaSuaListBox.Items[j].Value)
                        {
                            TacGiaSuaListBox.Items[j].Selected = true;
                            break;
                        }
                    }
                }
            }
            NhaXuatBanSuaDropDown.SelectedValue = sachBO.MaNXB;
            NamXuatBanSuaTextBox.Text = sachBO.namxuatban.ToString() ;
            LanXuatBanSuaTextBox.Text = sachBO.lanxuatban.ToString();
            TriGiaSuaTextBox.Text = sachBO.trigia.ToString();
            NgayNhapSuaTextBox.Text = sachBO.ngaynhap.ToString();
            SuaPopup.Show();
            NapDuLieu();
        }
    }
    public bool KiemTraHopLe(string namxuatban, string lanxuatban, string trigia)
    {
        SuaThongBaoLabel.Text = "";
        int temp = 0;
        if (int.TryParse(namxuatban, out temp) != true || Convert.ToInt32(namxuatban) < 1900)
        {
            SuaThongBaoLabel.Text = "Năm xuất bản không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
        if (int.TryParse(lanxuatban, out temp) != true || Convert.ToInt32(lanxuatban) < 1)
        {
            SuaThongBaoLabel.Text = "Lần xuất bản không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
        decimal temp2 = 0;
        if (Decimal.TryParse(trigia, out temp2) != true || Convert.ToDecimal(trigia) < 1)
        {
            SuaThongBaoLabel.Text = "Trị giá không hợp lệ (phải là số lớn hơn 0)";
            return false;
        }
      
        return true;
    }
    protected void LuuButton_Click(object sender, EventArgs e)
    {
        bool res=KiemTraHopLe(NamXuatBanSuaTextBox.Text, LanXuatBanSuaTextBox.Text, TriGiaSuaTextBox.Text);
        if (res == false)
        {
            SuaPopup.Show();
            return;
        }
        SachBO sachBO = new SachBO();
        //lấy thông tim mới để sửa lại sách
        int madausach=Convert.ToInt32( ViewState["madausach"].ToString());
        sachBO = sachBUS.Tim1Sach(madausach);     
        string manxb=NhaXuatBanSuaDropDown.SelectedValue; 
        string tensach=TenSachSuaTextBox.Text; 
        int namxuatban=Convert.ToInt32(NamXuatBanSuaTextBox.Text); 
        int lanxuatban=Convert.ToInt32(LanXuatBanSuaTextBox.Text); 
        decimal trigia=Convert.ToDecimal(TriGiaSuaTextBox.Text); 
        string hinhanh=""; 
        TacGiaCollection tacgiaColl= new TacGiaCollection();
        for (int i = 0; i < TacGiaSuaListBox.Items.Count; i++)
        {
            if (TacGiaSuaListBox.Items[i].Selected == true)
            {
                TacGiaBO tgBO = new TacGiaBO();
                tgBO.MaTG = TacGiaSuaListBox.Items[i].Value;
                tacgiaColl.Add(tgBO);
            }
        }
        string ngaynhap = nhanvienBUS.ChuyenNgayThang(NgayNhapSuaTextBox.Text);
        //Lấy thông tin hình cần upload và đánh dấu có hình hay không
        bool hasimage = true;//biến cho biết là có hình mới đựơc upload không        
        if (HinhAnhSuaUpload.PostedFile != null && HinhAnhSuaUpload.PostedFile.FileName != "")
            hinhanh = "~/images/sach/" + HinhAnhSuaUpload.PostedFile.FileName;
        else
        {
            hinhanh = "";
            hasimage = false;
        }
        //Thực hiện lưu vào CSDL
        bool kq = sachBUS.SuaSach(madausach, manxb, tensach, namxuatban, lanxuatban, trigia, hinhanh, tacgiaColl, ngaynhap, hasimage);
        if (kq == true)
        {
            //Lưu hình vào thư mục ../images/sach
            if (hasimage == true)
            {
                if (System.IO.File.Exists(hinhanh))//nếu file tồn tại
                    System.IO.File.Delete(hinhanh);//thì xóa file đi
                HinhAnhSuaUpload.SaveAs(Server.MapPath("..\\images\\sach\\") + System.IO.Path.GetFileName(hinhanh));
            }
        }
        NapDuLieu();
        
    }
    //Xử lý chi tiết sách
    public void Xuatfile(StringBuilder str)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.txt");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.text";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        Response.Write(str.ToString());
        Response.End();
        ChiTietPopup.Show();
    }
    protected void ChiTietDauSachGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        XoaThongBaoLabel.Text = "";
        if (e.CommandName == "xoa")
        {
            bool kq=sachBUS.XoaSach(e.CommandArgument.ToString());
            NapChiTietSach(Convert.ToInt32(ViewState["madausach"].ToString()));
            if (kq == false)
                XoaThongBaoLabel.Text = "Sách không thể xóa được";
            if(ChiTietDauSachGridView.Rows.Count!=0)
                ChiTietPopup.Show();
        }
        if (e.CommandName == "in")
        {
            StringBuilder str = new StringBuilder();
            str.Append(e.CommandArgument.ToString());
            // Xuất file
            Xuatfile(str);
        }
    }
    protected void ThemChiTietSachButton_Click(object sender, EventArgs e)
    {
        ThongbaoLabel.Text = "";
        bool kq=sachBUS.ThemSach(Convert.ToInt32(ViewState["madausach"].ToString()));
        NapChiTietSach(Convert.ToInt32(ViewState["madausach"].ToString()));
        ChiTietPopup.Show();
    }
    protected void InToanBoButton_Click(object sender, EventArgs e)
    {
        int madausach = Convert.ToInt32(ViewState["madausach"].ToString());
        SachCollection sachColl = new SachCollection();
        sachColl = sachBUS.TimDSSach(madausach);
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < sachColl.Count; i++)
        {
            str.Append(sachColl.Index(i).MaSach);
            str.Append("\r\n");
        }
        Xuatfile(str);
    }
}