using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Configuration;
namespace DAO
{
    public class NhanVienDAO
    {
        string cnnstr=ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public string DangNhap(string taikhoan, string matkhau,ref string manv)
        {
            if (taikhoan == "" || matkhau == "")
            {
                return null;
            }
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("select tenNV,manv,taikhoan from nhanvien where taikhoan=@taikhoan AND matkhau=@matkhau AND ngunghoatdong=0", cnn);
            cmd.Parameters.AddWithValue("taikhoan", taikhoan);
            cmd.Parameters.AddWithValue("matkhau", matkhau);
            string kq = string.Empty;
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kq = dr["tennv"].ToString();
                manv = dr["manv"].ToString();
                
            }
            cnn.Close();
            return kq;
          
        }
        public NhanVienBO Tim1Nhanvien(string manv)
        {
            NhanVienBO nvBO = new NhanVienBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT Manv,macv,tennv,diachi,gioitinh,convert(varchar(10),ngaysinh,103) ngaysinh,dienthoai,hinhanh,taikhoan FROM NhanVien WHERE manv=@manv";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manv",manv);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nvBO.MaNV = dr["MaNV"].ToString();
                nvBO.MaCV = dr["MaCV"].ToString();
                nvBO.TenNV = dr["TenNV"].ToString();
                nvBO.DiaChi = dr["Diachi"].ToString();
                nvBO.GioiTinh = Convert.ToBoolean(dr["GioiTinh"]);
              //  nvBO.NgaySinh = Convert.ToDateTime(dr["Ngaysinh"]);
                nvBO.NgaySinh = dr["Ngaysinh"].ToString();
                nvBO.DienThoai = dr["DienThoai"].ToString();
                nvBO.HinhAnh = dr["HinhAnh"].ToString();
                nvBO.TaiKhoan = dr["TaiKhoan"].ToString();
                break;
            }
            cnn.Close();
            return nvBO;
        }
        public NhanVienCollection TimDSNhanVien(string tennv)
        {
            NhanVienCollection nhanvienColl = new NhanVienCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT Manv,macv,tennv,diachi,gioitinh,convert(varchar(10),ngaysinh,103) ngaysinh,dienthoai,hinhanh,taikhoan FROM NhanVien WHERE Ngunghoatdong=0";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if(tennv!="")
            {
                query = "SELECT Manv,macv,tennv,diachi,gioitinh,convert(varchar(10),ngaysinh,103) ngaysinh,dienthoai,hinhanh,taikhoan FROM NhanVien WHERE tennv like @tennv AND Ngunghoatdong=0";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tennv", "%"+tennv+"%");
            }
            cnn.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            while(dr.Read())
            {
                NhanVienBO nvBO = new NhanVienBO();
                nvBO.MaNV =dr["MaNV"].ToString();
                nvBO.MaCV = dr["MaCV"].ToString();
                nvBO.TenNV = dr["TenNV"].ToString();
                nvBO.DiaChi = dr["Diachi"].ToString();
                nvBO.GioiTinh =Convert.ToBoolean(dr["GioiTinh"]);
            //    nvBO.NgaySinh = DateTime.ParseExact(dr["Ngaysinh"].ToString(),"ddMMyyyy",System.Globalization.CultureInfo.CurrentCulture);
                nvBO.NgaySinh = dr["ngaysinh"].ToString();
                nvBO.DienThoai = dr["DienThoai"].ToString();
                nvBO.HinhAnh = dr["HinhAnh"].ToString();
                nvBO.TaiKhoan = dr["TaiKhoan"].ToString();
              //  nvBO.MatKhau = dr["MatKhau"].ToString();
                nhanvienColl.Add(nvBO);
            }
            cnn.Close();
            return nhanvienColl;
        }
        public NhanVienCollection TimDSNhanVien_NgungHoatDong(string tennv)
        {
            NhanVienCollection nhanvienColl = new NhanVienCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM NhanVien WHERE Ngunghoatdong=1";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tennv != "")
            {
                query = "SELECT * FROM NhanVien WHERE tennv like @tennv AND Ngunghoatdong=1";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tennv", "%" + tennv + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhanVienBO nvBO = new NhanVienBO();
                nvBO.MaNV = dr["MaNV"].ToString();
                nvBO.MaCV = dr["MaCV"].ToString();
                nvBO.TenNV = dr["TenNV"].ToString();
                nvBO.DiaChi = dr["Diachi"].ToString();
                nvBO.GioiTinh = Convert.ToBoolean(dr["GioiTinh"]);
               // nvBO.NgaySinh = Convert.ToDateTime(dr["Ngaysinh"]);
                nvBO.NgaySinh =dr["Ngaysinh"].ToString();
                nvBO.DienThoai = dr["DienThoai"].ToString();
                nvBO.HinhAnh = dr["HinhAnh"].ToString();
                if (nvBO.HinhAnh == "")//nếu hình ảnh bằng rỗng
                    nvBO.HinhAnh = "../images/nhanvien/questionface.jpg";
                nvBO.TaiKhoan = dr["TaiKhoan"].ToString();
                //  nvBO.MatKhau = dr["MatKhau"].ToString();
                nhanvienColl.Add(nvBO);
            }
            cnn.Close();
            return nhanvienColl;
        }
        public void ThemNhanVien(NhanVienBO nhanvienBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "INSERT INTO NhanVien(TenNV,MaCV,DiaChi,GioiTinh,NgaySinh,DienThoai,HinhAnh,TaiKhoan,MatKhau,ngunghoatdong) ";
            query += " VALUES(@tennv,@chucvu,@diachi,@gioitinh,@ngaysinh,@dienthoai,@hinhanh,@taikhoan,@matkhau,0)";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@tennv", nhanvienBO.TenNV);
            cmd.Parameters.AddWithValue("@chucvu", nhanvienBO.MaCV);
            cmd.Parameters.AddWithValue("@diachi", nhanvienBO.DiaChi);
            cmd.Parameters.AddWithValue("@gioitinh", nhanvienBO.GioiTinh);
            cmd.Parameters.AddWithValue("@ngaysinh",Convert.ToDateTime(nhanvienBO.NgaySinh));
            cmd.Parameters.AddWithValue("@dienthoai", nhanvienBO.DienThoai);
            cmd.Parameters.AddWithValue("@hinhanh", nhanvienBO.HinhAnh);
            cmd.Parameters.AddWithValue("@taikhoan", nhanvienBO.TaiKhoan);
            cmd.Parameters.AddWithValue("@matkhau", nhanvienBO.MatKhau);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void XoaNhanVien(string manv)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE NhanVien Set NgungHoatDong=1,macv=null WHERE MaNV=@manv";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manv", manv);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void PhucHoiNhanVien(string manv)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE NhanVien Set NgungHoatDong=false WHERE MaNV=@manv";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manv", manv);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaNhanVien(NhanVienBO nhanvienBO,bool hasimage)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE NhanVien ";
            query += "SET tennv=@tennv,diachi=@diachi,gioitinh=@gioitinh,ngaysinh=@ngaysinh,dienthoai=@dienthoai";
            query += ",taikhoan=@taikhoan ";
            if (nhanvienBO.MatKhau != "")
                query += ",matkhau=@matkhau";
            if (hasimage != false)
                query += ",hinhanh=@hinhanh";
            query+= " WHERE manv=@manv";          
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tennv", nhanvienBO.TenNV);
            cmd.Parameters.AddWithValue("@diachi", nhanvienBO.DiaChi);
            cmd.Parameters.AddWithValue("@gioitinh", nhanvienBO.GioiTinh);
            cmd.Parameters.AddWithValue("@ngaysinh", nhanvienBO.NgaySinh);
            cmd.Parameters.AddWithValue("@dienthoai", nhanvienBO.DienThoai);
            if (hasimage != false)
                cmd.Parameters.AddWithValue("@hinhanh", nhanvienBO.HinhAnh);
            cmd.Parameters.AddWithValue("@taikhoan", nhanvienBO.TaiKhoan);
            if (nhanvienBO.MatKhau != "")
                cmd.Parameters.AddWithValue("@matkhau", nhanvienBO.MatKhau);
            cmd.Parameters.AddWithValue("@manv", nhanvienBO.MaNV);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public string Ktmatkhau(string manv)
        {
            string mk;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select matkhau from NhanVien WHERE manv=@manv";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manv", manv);
            cnn.Open();
            mk=cmd.ExecuteScalar().ToString();
            cnn.Close();
            return mk;
            
            
        }
        public void DoiMatKhau(string manv, string matkhaumoi, string matkhaucu)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE NhanVien SET matkhau=@matkhaumoi WHERE manv=@manv and matkhau=@matkhaucu ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            
            cmd.Parameters.AddWithValue("@matkhaumoi",matkhaumoi);
            cmd.Parameters.AddWithValue("@manv", manv);
            cmd.Parameters.AddWithValue("@matkhaucu",matkhaucu);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            
        }
    }
}
