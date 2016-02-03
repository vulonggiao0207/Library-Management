using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BO;
namespace DAO
{
    public class DocGiaDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public DocGiaCollection TimDSDocGia(string tendocgia)
        {
            DocGiaCollection docgiaColl = new DocGiaCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT MaDocGia,MaLoai,TenDocGia,Gioitinh,Convert(nvarchar(10),Ngaysinh,103) ngaysinh,DiaChi,";
            query += "Convert(nvarchar(10),NgayLapThe,103) ngaylapthe,Convert(nvarchar(10),NgayHetHan,103) ngayhethan,MatKhau,HinhAnh FROM DocGia";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tendocgia != "")
            {
                query = "SELECT MaDocGia,MaLoai,TenDocGia,Gioitinh,Convert(nvarchar(10),Ngaysinh,103) ngaysinh,DiaChi,";
                query += "Convert(nvarchar(10),NgayLapThe,103) ngaylapthe,Convert(nvarchar(10),NgayHetHan,103) ngayhethan,MatKhau,HinhAnh FROM DocGia";
                query+=" WHERE TenDocGia like @tendocgia";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tendocgia", "%" + tendocgia + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DocGiaBO docgiaBO = new DocGiaBO();
                docgiaBO.MaDocGia=dr["MaDocGia"].ToString();
                docgiaBO.MaLoai=dr["MaLoai"].ToString();
                docgiaBO.TenDocGia=dr["TenDocGia"].ToString();
                docgiaBO.GioiTinh=Convert.ToBoolean(dr["GioiTinh"].ToString());
                docgiaBO.NgaySinh=dr["NgaySinh"].ToString();
                docgiaBO.DiaChi=dr["Diachi"].ToString();
                docgiaBO.NgayLapThe=dr["NgayLapThe"].ToString();
                docgiaBO.NgayHetHan=dr["NgayHetHan"].ToString();
                docgiaBO.MatKhau=dr["MatKhau"].ToString();
                docgiaBO.HinhAnh = dr["HinhAnh"].ToString();
                docgiaColl.Add(docgiaBO);                
            }
            cnn.Close();
            return docgiaColl;
        }
        public DocGiaBO Tim1DocGia(string madocgia)
        {
            DocGiaBO docgiaBO = new DocGiaBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT top 1 MaDocGia,MaLoai,TenDocGia,Gioitinh,Convert(nvarchar(10),Ngaysinh,103) ngaysinh,DiaChi,";
            query += "Convert(nvarchar(10),NgayLapThe,103) ngaylapthe,Convert(nvarchar(10),NgayHetHan,103) ngayhethan,MatKhau,HinhAnh FROM DocGia";
            query += " WHERE MaDocGia = @madocgia";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia",madocgia);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                docgiaBO.MaDocGia = dr["MaDocGia"].ToString();
                docgiaBO.MaLoai = dr["MaLoai"].ToString();
                docgiaBO.TenDocGia = dr["TenDocGia"].ToString();
                docgiaBO.GioiTinh = Convert.ToBoolean(dr["GioiTinh"].ToString());
                docgiaBO.NgaySinh = dr["NgaySinh"].ToString();
                docgiaBO.DiaChi = dr["Diachi"].ToString();
                docgiaBO.NgayLapThe = dr["NgayLapThe"].ToString();
                docgiaBO.NgayHetHan = dr["NgayHetHan"].ToString();
                docgiaBO.MatKhau = dr["MatKhau"].ToString();
                docgiaBO.HinhAnh = dr["HinhAnh"].ToString();
            }
            cnn.Close();
            return docgiaBO;
        }
        public void ThemDocGia(DocGiaBO docgiaBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "INSERT INTO DocGia(MaDocGia,MaLoai,TenDocGia,Gioitinh,Ngaysinh,DiaChi,NgayLapThe,NgayHetHan,MatKhau,HinhAnh) ";
            query += " VALUES(@MaDocGia,@MaLoai,@TenDocGia,@Gioitinh,@Ngaysinh,@DiaChi,@NgayLapThe,@NgayHetHan,@MatKhau,@HinhAnh)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@MaDocGia", docgiaBO.MaDocGia);
            cmd.Parameters.AddWithValue("@MaLoai", docgiaBO.MaLoai);
            cmd.Parameters.AddWithValue("@TenDocGia", docgiaBO.TenDocGia);
            cmd.Parameters.AddWithValue("@GioiTinh", docgiaBO.GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", docgiaBO.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", docgiaBO.DiaChi);
            cmd.Parameters.AddWithValue("@NgayLapThe", docgiaBO.NgayLapThe);
            cmd.Parameters.AddWithValue("@NgayHetHan", docgiaBO.NgayHetHan);
            cmd.Parameters.AddWithValue("@MatKhau", docgiaBO.MatKhau);
            cmd.Parameters.AddWithValue("@HinhAnh", docgiaBO.HinhAnh);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void XoaDocGia(string madocgia)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "DELETE FROM DocGia WHERE MaDocgia=@madocgia ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void SuaDocGia(DocGiaBO docgiaBO, bool hasimage,string madocgiaUp)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE DocGia SET MaDocGia=@MaDocGia,MaLoai=@MaLoai,TenDocGia=@TenDocGia,Gioitinh=@Gioitinh,Ngaysinh=@NgaySinh ";
            query += " ,DiaChi=@DiaChi,NgayLapThe=@NgayLapThe,NgayHetHan=@NgayHetHan";
            if (docgiaBO.MatKhau != "")
            {
                query += ",MatKhau=@MatKhau";
            }
            if (hasimage == true)
                query += ",HinhAnh=@Hinhanh";
            query += " WHERE MaDocGia=@MaDocGiaUp";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@MaDocGia", docgiaBO.MaDocGia);
            cmd.Parameters.AddWithValue("@MaLoai", docgiaBO.MaLoai);
            cmd.Parameters.AddWithValue("@TenDocGia", docgiaBO.TenDocGia);
            cmd.Parameters.AddWithValue("@GioiTinh", docgiaBO.GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", docgiaBO.NgaySinh);
            cmd.Parameters.AddWithValue("@DiaChi", docgiaBO.DiaChi);
            cmd.Parameters.AddWithValue("@NgayLapThe", docgiaBO.NgayLapThe);
            cmd.Parameters.AddWithValue("@NgayHetHan", docgiaBO.NgayHetHan);
            if (docgiaBO.MatKhau != "")
                cmd.Parameters.AddWithValue("@MatKhau", docgiaBO.MatKhau);
            if (hasimage == true)
                cmd.Parameters.AddWithValue("@HinhAnh", docgiaBO.HinhAnh);
            cmd.Parameters.AddWithValue("@MaDocGiaUp", madocgiaUp);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public string DangNhap(string taikhoan, string matkhau)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("Select madocgia FROM docgia WHERE madocgia=@taikhoan AND matkhau=@matkhau",cnn);
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
            cmd.Parameters.AddWithValue("@matkhau", matkhau);
            cnn.Open();
            object temp = cmd.ExecuteScalar();
            cnn.Close();
            if (temp != null)
                return temp.ToString();
            return string.Empty;
        }
        public void DoiMatKhau(string madocgia, string pass)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("UPDATE Docgia SET Matkhau=@matkhau WHERE madocgia=@madocgia", cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cmd.Parameters.AddWithValue("@matkhau", pass);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
