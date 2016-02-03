using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAO;
namespace BUS
{
    public class DocGiaBUS
    {
        DocGiaDAO docgiaDAO = new DocGiaDAO();
        public bool ThemDocGia(string madocgia, string maloai, string tendocgia, bool gioitinh, string ngaysinh, string diachi, string ngaylapthe, string ngayhethan, string hinhanh, string matkhau)
        {
            try
            {
                DocGiaBO docgiaBO = new DocGiaBO();
                docgiaBO.MaDocGia = madocgia;
                docgiaBO.MaLoai = maloai;
                docgiaBO.TenDocGia = tendocgia;
                docgiaBO.GioiTinh = gioitinh;
                docgiaBO.NgaySinh = ngaysinh;
                docgiaBO.DiaChi = diachi;
                docgiaBO.NgayLapThe = ngaylapthe;
                docgiaBO.NgayHetHan = ngayhethan;
                docgiaBO.MatKhau = matkhau;
                docgiaBO.HinhAnh = hinhanh;
                docgiaDAO.ThemDocGia(docgiaBO);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DocGiaCollection TimDSDocGia(string tendocgia)
        {
            try
            {
                return docgiaDAO.TimDSDocGia(tendocgia);
            }
            catch
            {
                return null;
            }
        }
        public DocGiaBO Tim1DocGia(string madocgia)
        {
            try
            {
                return docgiaDAO.Tim1DocGia(madocgia);
            }
            catch
            {
                return null;
            }
        }
        public bool XoaDocGia(string madocgia)
        {
            try
            {
                docgiaDAO.XoaDocGia(madocgia);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaDocGia(string madocgia,string maloai,string tendocgia,bool gioitinh,string ngaysinh,string diachi,string ngaylapthe,string ngayhethan,string hinhanh,string matkhau, bool hasimage, string madocgiaUp)
        {
            try
            {
                DocGiaBO docgiaBO= new DocGiaBO();
                docgiaBO.MaDocGia =madocgia;
                docgiaBO.MaLoai =maloai;
                docgiaBO.TenDocGia = tendocgia;
                docgiaBO.GioiTinh = gioitinh;
                docgiaBO.NgaySinh = ngaysinh;
                docgiaBO.DiaChi = diachi;
                docgiaBO.NgayLapThe = ngaylapthe;
                docgiaBO.NgayHetHan = ngayhethan;
                docgiaBO.MatKhau =matkhau;
                docgiaBO.HinhAnh = hinhanh;
                docgiaDAO.SuaDocGia(docgiaBO,hasimage,madocgiaUp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string DangNhap(string taikhoan, string matkhau)
        {
            try
            {
                return docgiaDAO.DangNhap(taikhoan, matkhau);
            }
            catch
            {
                return string.Empty;
 
            }
        }
        public bool DoiMatKhau(string taikhoan, string matkhau)
        {
            try
            {
                docgiaDAO.DoiMatKhau(taikhoan, matkhau);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
