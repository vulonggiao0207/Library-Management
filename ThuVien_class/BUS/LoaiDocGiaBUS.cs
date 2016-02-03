using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;

namespace BUS
{
    public class LoaiDocGiaBUS
    {
        LoaiDocGiaDAO loaidocgiaDAO = new LoaiDocGiaDAO();
        public LoaiDocGiaCollection TimDSLoaiDocGia(string tenloaidocgia)
        {
            try
            {
                return loaidocgiaDAO.TimDSLoaiDocGia(tenloaidocgia);
            }
            catch
            {
                return null;
            }
        }
        public bool XoaLoaiDocGia(string maloaidocgia)
        {
            try
            {
                loaidocgiaDAO.XoaLoaiDocGia(maloaidocgia);
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool ThemLoaiDocGia(string tenloaidocgia)
        {
            try
            {
                loaidocgiaDAO.ThemLoaiDocGia(tenloaidocgia);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaLoaiDocGia(string maloaidocgia, string tenloaidocgia)
        {
            try
            {
                LoaiDocGiaBO loaidocgiaBO = new LoaiDocGiaBO();
                loaidocgiaBO.MaLoai = maloaidocgia;
                loaidocgiaBO.TenLoai = tenloaidocgia;
                loaidocgiaDAO.SuaLoaiDocGia(loaidocgiaBO);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public LoaiDocGiaBO Tim1LoaiDocGia(string maloai)
        {
            try
            {
                return loaidocgiaDAO.Tim1LoaiDocGia(maloai);
            }
            catch
            {
                return null;
            }
        }
    }
}
