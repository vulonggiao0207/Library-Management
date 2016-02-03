using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BUS;
public partial class admin_capnhatnhanvien : System.Web.UI.Page
{
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    ChucVuBUS chucvuBUS = new ChucVuBUS();
    public void NapDuLieu()
    {
        string tennv = TimTextbox.Text;
        NhanVienGridView.DataSource = nhanvienBUS.TimDSNhanVien(tennv);
        NhanVienGridView.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            NgaySinhMoiTextBox.Text =nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString());
            NapDuLieu();
            ChucVuMoiDropdown.DataSource = chucvuBUS.TimDSChucVu("");
            ChucVuMoiDropdown.DataValueField = "MaCV";
            ChucVuMoiDropdown.DataTextField = "TenCV";
            ChucVuMoiDropdown.DataBind();

            ChucVuSuaDropdown.DataSource = chucvuBUS.TimDSChucVu("");
            ChucVuSuaDropdown.DataValueField = "MaCV";
            ChucVuSuaDropdown.DataTextField = "TenCV";
            ChucVuSuaDropdown.DataBind();
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    protected void NhanVienGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hiển thị chức vụ
            Label chucvu;
            chucvu = (Label)e.Row.FindControl("ChucVuLabel");            
            chucvu.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "macv") != null)
            {
                chucvu.Text = (string)DataBinder.Eval(e.Row.DataItem, "macv");
                string tencv = chucvuBUS.Tim1ChucVu(chucvu.Text).TenCV;
                chucvu.Text = tencv;
            }
            //hiển thị giới tính
            Label gioitinh;
            gioitinh = (Label)e.Row.FindControl("GioiTinhLabel");
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
    protected void NhanVienGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "xoa")
        {
            nhanvienBUS.XoaNhanVien(e.CommandArgument.ToString());
            NapDuLieu();
        }
        else if (e.CommandName == "sua")
        {
            NapDuLieu();
            NhanVienBO nhanvienBO = new NhanVienBO();
            nhanvienBO = nhanvienBUS.Tim1Nhanvien(e.CommandArgument.ToString());
            SuaPopup.Show();
            ViewState["manv"] = e.CommandArgument.ToString();
            TenNVSuaTextBox.Text = nhanvienBO.TenNV;
            ChucVuSuaDropdown.SelectedValue = nhanvienBO.MaCV;
            GioiTinhSuaDropdown.SelectedValue = nhanvienBO.GioiTinh.ToString();
            NgaySinhSuaTextBox.Text = nhanvienBO.NgaySinh;
            DiaChiSuaTextBox.Text = nhanvienBO.DiaChi;
            DienThoaiSuaTextBox.Text = nhanvienBO.DienThoai;
            TaiKhoanSuaTextBox.Text = nhanvienBO.TaiKhoan;
            MatKhauSuaTextBox.Text = nhanvienBO.MatKhau;
        }
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
    protected void ThemNVButton_Click(object sender, EventArgs e)
    {
        string tennv=TenNVMoiTextBox.Text;
        string chucvu=ChucVuMoiDropdown.SelectedValue;
        bool gioitinh=Convert.ToBoolean(GioiTinhMoiDropdown.SelectedValue);
        string ngaysinh=NgaySinhMoiTextBox.Text;
        string diachi=DiaChiMoiTextBox.Text;
        string dienthoai=DienThoaiMoiTextBox.Text;
        string hinhanh = ""; // biến chứa đường giẫn+tên file
        string taikhoan=TaiKhoanMoiTextBox.Text;
        string matkhau=MatKhauMoiTextBox.Text;
        //Upload và lưu đường dẫn hình vào CSDL       
        bool hasimage = true; // biến kiểm tra đã có file đựơc upload chưa      
        if (HinhAnhMoiFileUpLoad.PostedFile != null && HinhAnhMoiFileUpLoad.PostedFile.FileName != "")//kiểm tra đã chọn file nào để upload chưa
            hinhanh = "~/images/nhanvien/" + GetFileName(HinhAnhMoiFileUpLoad.PostedFile.FileName);
        else
        {
            hinhanh = "~/images/nhanvien/questionface.jpg";
            hasimage = false;
        }
        bool kq = nhanvienBUS.ThemNhanVien(tennv, chucvu, diachi, gioitinh, ngaysinh, dienthoai, hinhanh, taikhoan, matkhau);
        if (kq == true)//Nếu lưu thành công
        {
            //Lưu hình ảnh vô thư mục ../images/nhanvien
            if (hasimage == true)
                HinhAnhMoiFileUpLoad.SaveAs(Server.MapPath("..\\images\\nhanvien\\") + System.IO.Path.GetFileName(hinhanh));
            //Nạp lại trang web
            NapDuLieu();
        }    
        //reset lại Popup thêm nhân viên
        TenNVMoiTextBox.Text = "";
        NgaySinhMoiTextBox.Text = NgaySinhMoiTextBox.Text = nhanvienBUS.ChuyenNgayThang(DateTime.Now.Date.ToShortDateString()); ;
        DiaChiMoiTextBox.Text = "";
        DienThoaiMoiTextBox.Text = "";
       // HinhAnhMoiFileUpLoad.PostedFile.FileName = "";
        TaiKhoanMoiTextBox.Text = "";
        MatKhauMoiTextBox.Text = "";
    }
    protected void LuuButton_Click(object sender, EventArgs e)
    {
        //lấy dữ liệu cần cập nhật (UPDATE)    
        string manv=ViewState["manv"].ToString();
        string tennv = TenNVSuaTextBox.Text;
        string chucvu = ChucVuSuaDropdown.SelectedValue;
        bool gioitinh = Convert.ToBoolean(GioiTinhSuaDropdown.SelectedValue);
        string ngaysinh = NgaySinhSuaTextBox.Text;
        string diachi = DiaChiSuaTextBox.Text;
        string dienthoai = DienThoaiSuaTextBox.Text;
        string hinhanh = ""; // biến chứa đường giẫn+tên file
        string taikhoan = TaiKhoanSuaTextBox.Text;
        string matkhau = MatKhauSuaTextBox.Text;
        //Lấy thông tin hình cần upload và đánh dấu có hình hay không
        bool hasimage = true;//biến cho biết là có hình mới đựơc upload không        
        if (HinhAnhSuaFileUpload .PostedFile != null && HinhAnhSuaFileUpload.PostedFile.FileName != "")
            hinhanh = "~/images/nhanvien/" + HinhAnhSuaFileUpload.PostedFile.FileName;
        else
        {
            hinhanh = "";
            hasimage = false;
        }
        //Thực hiện lưu vào CSDL
        bool kq = nhanvienBUS.SuaNhanVien(manv,tennv, chucvu, diachi, gioitinh, ngaysinh, dienthoai, hinhanh, hasimage, taikhoan, matkhau);
        if (kq == true)
        {
            //Lưu hình vào thư mục ../images/nhanvien
            if (hasimage == true)
            {
                if (System.IO.File.Exists(hinhanh))//nếu file tồn tại
                    System.IO.File.Delete(hinhanh);//thì xóa file đi
                HinhAnhSuaFileUpload.SaveAs(Server.MapPath("..\\images\\nhanvien\\") + System.IO.Path.GetFileName(hinhanh));
            }
            NapDuLieu();
        }
      
    }
}