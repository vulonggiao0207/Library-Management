using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAO;
namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAO nvDAO = new NhanVienDAO();
        public string DangNhap(string taikhoan, string matkhau,ref string manv)
        {
            try
            {
                manv = "";               
                string kq = nvDAO.DangNhap(taikhoan, matkhau, ref manv);
                
                if (kq != "")
                    return kq;
                else
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Ktmatkhau(string manv)
        {
            try
            {
                string mk= nvDAO.Ktmatkhau(manv);
                return mk;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool DoiMatKhau(string manv, string matkhaumoi, string matkhaucu)
        {
            try
            {
                nvDAO.DoiMatKhau(manv,matkhaumoi,matkhaucu);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public NhanVienBO Tim1Nhanvien(string manv)
        {
            try
            {
                NhanVienBO nvBO = new NhanVienBO();
                nvBO = nvDAO.Tim1Nhanvien(manv);
                return nvBO;
            }
            catch
            {
                return null;
            }
        }
        public NhanVienCollection TimDSNhanVien(string tennv)
        {
            try
            {
                return nvDAO.TimDSNhanVien(tennv);
            }
            catch
            {
                return null;
            }
        }
        public string ChuyenNgayThang(string thangngay)
        {
            string[] temp = thangngay.Split('/');
            for (int i = 0; i < 2; i++)
                if (temp[i].Length < 2)
                    temp[i] = "0"+temp[i];
             return temp[1]+"/"+temp[0]+"/"+temp[2];
        }
        public bool ThemNhanVien(string tennv,string chucvu,string diachi,bool gioitinh,string ngaysinh,string dienthoai,string hinhanh,string taikhoan,string matkhau)
        {
            try
            {
                NhanVienBO nhanvienBO = new NhanVienBO();
                nhanvienBO.TenNV = tennv;
                nhanvienBO.MaCV = chucvu;
                nhanvienBO.DiaChi = diachi;
                nhanvienBO.GioiTinh = gioitinh;
                //chuyển dd/mm/yyyy thành mm/dd/yyyy để đưa vào CSDL
                ngaysinh = ChuyenNgayThang(ngaysinh);
                //thêm ngày sinh
                nhanvienBO.NgaySinh = ngaysinh;
                nhanvienBO.DienThoai = dienthoai;
                nhanvienBO.HinhAnh = hinhanh;
                nhanvienBO.TaiKhoan = taikhoan;
                nhanvienBO.MatKhau = matkhau;
                nvDAO.ThemNhanVien(nhanvienBO);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNhanVien(string manv)
        {
            try
            {
                nvDAO.XoaNhanVien(manv);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool PhucHoiNhanVien(string manv)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaNhanVien(string manv, string tennv, string chucvu, string diachi, bool gioitinh, string ngaysinh, string dienthoai, string hinhanh,bool hasimage, string taikhoan, string matkhau)
        {
            try
            {
                NhanVienBO nhanvienBO = new NhanVienBO();
                nhanvienBO.MaNV = manv;
                nhanvienBO.TenNV = tennv;
                nhanvienBO.MaCV = chucvu;
                nhanvienBO.DiaChi = diachi;
                nhanvienBO.GioiTinh = gioitinh;
                //chuyền dd/mm/yyyy thành mm/dd/yyyy để đưa vào CSDL
                ngaysinh = ChuyenNgayThang(ngaysinh);
                //thêm ngày sinh
                nhanvienBO.NgaySinh = ngaysinh;
                nhanvienBO.DienThoai = dienthoai;
                nhanvienBO.HinhAnh = hinhanh;
                nhanvienBO.TaiKhoan = taikhoan;
                nhanvienBO.MatKhau = matkhau;
                nvDAO.SuaNhanVien(nhanvienBO,hasimage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
