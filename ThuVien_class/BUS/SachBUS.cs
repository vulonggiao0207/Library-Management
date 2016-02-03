using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;
namespace BUS
{
    public class SachBUS
    {
        SachDAO sachDAO = new SachDAO();
        //Xử lý đầu sách
        public SachBO Tim1Sach(string masach)
        {
            try
            {
                return sachDAO.Tim1Sach(masach);
            }
            catch
            {
                return null;
            }
        }
        public SachBO Tim1Sach(int madausach)
        {
            try
            {
                return sachDAO.Tim1Sach(madausach);
            }
            catch
            {
                return null;
            }
        }
        public SachCollection TimDSSach(string tensach)
        {
            try
            {
                return sachDAO.TimDSSach(tensach);
            }
            catch 
            {
                return null; 
            }
        }
        public bool ThemSach(string manxb,string tensach, int namxuatban,int lanxuatban,decimal trigia,string hinhanh, TacGiaCollection tacgiaColl,string ngaynhap, int soluong)
        {
            try
            {
                SachBO sachBO = new SachBO();
                sachBO.MaNXB = manxb;
                sachBO.TenSach = tensach;
                sachBO.namxuatban = namxuatban;
                sachBO.lanxuatban = lanxuatban;
                sachBO.trigia = trigia;
                sachBO.hinhanh = hinhanh;
                sachBO.ngaynhap = ngaynhap;
                sachBO.tacgiaColl = tacgiaColl;
                sachDAO.ThemSach(sachBO,soluong);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaSach(int madausach)
        {
            try
            {
                sachDAO.XoaSach(madausach);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaSach(int madausach, string manxb, string tensach, int namxuatban, int lanxuatban, decimal trigia, string hinhanh, TacGiaCollection tacgiaColl, string ngaynhap,bool hasimage)
        {
            try
            {
                SachBO sachBO= new SachBO();
                sachBO.Madausach = madausach;
                sachBO.MaNXB = manxb;
                sachBO.TenSach = tensach;                
                sachBO.namxuatban = namxuatban;
                sachBO.lanxuatban = lanxuatban;
                sachBO.trigia = trigia;
                sachBO.hinhanh = hinhanh;
                sachBO.tacgiaColl = tacgiaColl;
                sachBO.ngaynhap = ngaynhap;
                sachDAO.SuaSach(sachBO,hasimage);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xử lý phân lọai
        public SachCollection TimDSSachPhanLoai(string tensach)
        {
            try
            {
                return sachDAO.TimDSSachPhanLoai(tensach);
            }
            catch
            {
                return null;
            }
        }
        public bool PhanLoai(int madausach,string maloai,string mactphanloai,string khuvuc,string ke,string ngan,bool muondemve)
        {
            try
            {
                SachBO sachBO = new SachBO();
                sachBO.Madausach = madausach;
                sachBO.MaLoai = maloai;
                sachBO.MaCTPhanLoai = mactphanloai;
                sachBO.khuvuc = khuvuc;
                sachBO.ke = ke;
                sachBO.ngan = ngan;
                sachBO.muondemve = muondemve;
                sachDAO.PhanLoai(sachBO);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xử lý chi tiết sách
        public SachCollection TimDSSach(int madausach)
        {
            try
            {
                return sachDAO.TimDSSach(madausach);
            }
            catch
            {
                return null;
            }
        }
        public bool ThemSach(int madausach)
        {
            try
            {
                sachDAO.ThemSach(madausach);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaSach(string masach)
        {
            try
            {
                sachDAO.XoaSach(masach);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xử lý tìm sách
        public SachCollection TimDSSachDocNhieu()
        {
            try
            {
                return sachDAO.TimDSSachDocNhieu();
            }
            catch
            {
                return null;
            }
        }
        public SachCollection TimSach(string tensach, string maloaisach,string maphanloai, string mactphanloai)
        {
            try
            {
                return sachDAO.TimSach(tensach, maloaisach,maphanloai, mactphanloai);
            }
            catch
            {
                return null;
            }
        }

        //xử lý sách mất
        public SachCollection TimSachChuaTra(string thongtintim, int cachtim)
        {
            try
            {
                return sachDAO.TimSachChuaTra(thongtintim, cachtim);
            }
            catch
            {
                return null;
            }
        }
        public bool ThayDoiTrangThai(string masach, bool trangthai)
        {
            try
            {
                sachDAO.ThayDoiTrangThai(masach, trangthai);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public SachCollection TimSachDaMat(string thongtintim, int cachtim)
        {
            try
            {
                return sachDAO.TimSachDaMat(thongtintim, cachtim);
            }
            catch
            {
                return null;
            }
        }
    }
}
