using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_capnhatdocgia : System.Web.UI.Page
{
    LoaiDocGiaBUS loaidocgiaBUS = new LoaiDocGiaBUS();
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    NhanVienBUS nhanvienBUS = new NhanVienBUS();    
    public void NapDuLieu()
    {
        string tendocgia=TimTextbox.Text;
        DocGiaGridView.DataSource = docgiaBUS.TimDSDocGia(tendocgia);
        DocGiaGridView.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            NgaySinhThemTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
            NgayLapTheThemTxt.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
            NgayHetHanThemTxt.Text = NgayLapTheThemTxt.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
         /*   NgaySinhSuaTxt.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());        
            NgayLapTheSuaTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
            NgayHetHanSuaTextbox.Text = NgayLapTheThemTxt.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());*/
            NapDuLieu();
            LoaiDocGiaThemDropdown.DataSource = loaidocgiaBUS.TimDSLoaiDocGia("");
            LoaiDocGiaThemDropdown.DataValueField = "MaLoai";
            LoaiDocGiaThemDropdown.DataTextField = "TenLoai";
            LoaiDocGiaThemDropdown.DataBind();

            LoaiDocGiaSuaDropdown.DataSource = loaidocgiaBUS.TimDSLoaiDocGia("");
            LoaiDocGiaSuaDropdown.DataValueField = "MaLoai";
            LoaiDocGiaSuaDropdown.DataTextField = "TenLoai";
            LoaiDocGiaSuaDropdown.DataBind();

            NapDuLieu();
        }
    }
    protected void DocGiaGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DocGiaGridView.PageIndex = e.NewPageIndex;
        NapDuLieu();
    }
    protected void DocGiaGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        DocGiaGridView.SelectedIndex = e.NewSelectedIndex;
        NapDuLieu();
    }  
    protected void DocGiaGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hiển thị chức vụ
            Label loaiDG;
            loaiDG = (Label)e.Row.FindControl("LoaidocgiaLabel");
            loaiDG.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "maloai") != null)
            {
                loaiDG.Text = (string)DataBinder.Eval(e.Row.DataItem, "maloai");
                string tencv = loaidocgiaBUS.Tim1LoaiDocGia(loaiDG.Text).TenLoai;
                loaiDG.Text = tencv;
            }
            //hiển thị giới tính
            Label gioitinh;
            gioitinh = (Label)e.Row.FindControl("GioitinhLabel");
            gioitinh.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "gioitinh") != null)
            {
                gioitinh.Text = DataBinder.Eval(e.Row.DataItem, "gioitinh").ToString();
                string gioitinhtxt = "Nam";
                if (gioitinh.Text == "False")
                    gioitinhtxt = "Nữ";
                gioitinh.Text = gioitinhtxt;
            }

        }
    }
    protected void DocGiaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["madocgia"] = "";
        if (e.CommandName == "xoa")
        {
            ThongBaoLabel.Text = "";
            bool kq=docgiaBUS.XoaDocGia(e.CommandArgument.ToString());
            if(kq==false)
                ThongBaoLabel.Text = "Không xóa đựơc độc giả này";
            NapDuLieu();
        }
        if (e.CommandName == "sua")
        {
            ThongBaoLabel.Text = "";
            NapDuLieu();       
            DocGiaBO docgiaBO = new DocGiaBO();
            docgiaBO = docgiaBUS.Tim1DocGia(e.CommandArgument.ToString());
            ViewState["madocgia"] = e.CommandArgument.ToString();
            SuaPopup.Show();
            MaDocGiaSuaTextBox.Text = docgiaBO.MaDocGia;
            TenDocGiaSuaTextBox.Text = docgiaBO.TenDocGia;
            LoaiDocGiaSuaDropdown.SelectedValue = docgiaBO.MaLoai;
            if(docgiaBO.GioiTinh==true)
                GioiTinhSuaDropdown.SelectedValue = "True";
            else
                GioiTinhSuaDropdown.SelectedValue = "False";
            NgaySinhSuaTxt.Text = docgiaBO.NgaySinh;
            DiaChiSuaTextBox.Text = docgiaBO.DiaChi;
            NgayLapTheSuaTextBox.Text = docgiaBO.NgayLapThe;
            NgayHetHanSuaTextbox.Text = docgiaBO.NgayHetHan;
            
        }
    }   
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    public string GetFileName(string Image)
    {
        try
        {
            string duongdan = Server.MapPath("..\\images\\nhanvien\\");
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
    protected void ThemLoaiButton_Click(object sender, EventArgs e)
    {
        ThongBaoLabel.Text = "";
        string madocgia=MaDocGiaThemTextBox.Text;
        string tendocgia=TenDocGiaThemTextBox.Text;
        string maloai=LoaiDocGiaThemDropdown.SelectedValue;
        bool gioitinh=Convert.ToBoolean(GioiTinhThemDropdown.SelectedValue);
        string ngaysinh = nhanvienBUS.ChuyenNgayThang(NgaySinhThemTextBox.Text);
        string diachi=DiaChiThemTextBox.Text;
        string ngaylapthe=nhanvienBUS.ChuyenNgayThang(NgayLapTheThemTxt.Text);
        string ngayhethan=nhanvienBUS.ChuyenNgayThang(NgayHetHanThemTxt.Text);
        string hinhanh="";
        string matkhau=MatKhauthemTxt.Text;
        //Upload và lưu đường dẫn hình vào CSDL       
        bool hasimage = true; // biến kiểm tra đã có file đựơc upload chưa      
        if (HinhAnhThemUpload.PostedFile != null && HinhAnhThemUpload.PostedFile.FileName != "")//kiểm tra đã chọn file nào để upload chưa
            hinhanh = "~/images/docgia/" + GetFileName(HinhAnhThemUpload.PostedFile.FileName);
        else
        {
            hinhanh = "~/images/docgia/questionface.jpg";
            hasimage = false;
        }
        //THÊM VÀO CSDL
        bool kq=docgiaBUS.ThemDocGia(madocgia, maloai, tendocgia, gioitinh, ngaysinh, diachi, ngaylapthe, ngayhethan, hinhanh, matkhau);
        if (kq == true)//Nếu lưu thành công
        {
            //Lưu hình ảnh vô thư mục ../images/docgia
            if (hasimage == true)
                HinhAnhThemUpload.SaveAs(Server.MapPath("..\\images\\docgia\\") + System.IO.Path.GetFileName(hinhanh));
        }
        else
        {
            ThongBaoThemLabel.Text = "Không thể thêm! Mã độc giả đã tồn tại";
            ThemPopup.Show();
            NapDuLieu();
            return;
        }
        //Nạp lại trang web
        NapDuLieu();
        //reset các control
        MaDocGiaThemTextBox.Text="";
        TenDocGiaThemTextBox.Text="";
        NgaySinhThemTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString()); ;
        DiaChiThemTextBox.Text="";
        NgayLapTheThemTxt.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString()); ;
        NgayHetHanThemTxt.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString()); ;
        MatKhauthemTxt.Text="";
    }
    protected void SuaLoaiButton_Click(object sender, EventArgs e)
    {
        string madocgiaUp=ViewState["madocgia"].ToString();
        string madocgia = MaDocGiaSuaTextBox.Text;
        string tendocgia = TenDocGiaSuaTextBox.Text;
        string maloai = LoaiDocGiaSuaDropdown.SelectedValue;
        bool gioitinh = Convert.ToBoolean(GioiTinhSuaDropdown.SelectedValue);
        string ngaysinh = nhanvienBUS.ChuyenNgayThang(NgaySinhSuaTxt.Text);
        string diachi = DiaChiSuaTextBox.Text;
        string ngaylapthe = nhanvienBUS.ChuyenNgayThang(NgayLapTheSuaTextBox.Text);
        string ngayhethan = nhanvienBUS.ChuyenNgayThang(NgayHetHanSuaTextbox.Text);
        string hinhanh = "";
        string matkhau = MatKhauSuaTextBox.Text;
        //Lấy thông tin hình cần upload và đánh dấu có hình hay không
        bool hasimage = true;//biến cho biết là có hình mới đựơc upload không        
        if (HinhAnhSuaUpload.PostedFile != null && HinhAnhSuaUpload.PostedFile.FileName != "")
            hinhanh = "~/images/docgia/" + HinhAnhSuaUpload.PostedFile.FileName;
        else
        {
            hinhanh = "";
            hasimage = false;
        }
        //Thực hiện lưu vào CSDL
        bool kq = docgiaBUS.SuaDocGia(madocgia,maloai,tendocgia,gioitinh,ngaysinh,diachi,ngaylapthe,ngayhethan,hinhanh,matkhau,hasimage,madocgiaUp);
        if (kq == true)
        {
            //Lưu hình vào thư mục ../images/nhanvien
            if (hasimage == true)
            {
                if (System.IO.File.Exists(hinhanh))//nếu file tồn tại
                    System.IO.File.Delete(hinhanh);//thì xóa file đi
                HinhAnhSuaUpload.SaveAs(Server.MapPath("..\\images\\docgia\\") + System.IO.Path.GetFileName(hinhanh));
            }
        }
        NapDuLieu();
    } 
}