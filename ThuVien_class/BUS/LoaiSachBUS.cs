using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;
namespace BUS
{
    public class LoaiSachBUS
    {

        LoaiSachDAO loaisachDAO = new LoaiSachDAO();

        public LoaiSachCollection TimDSLoaiSach(string tenloai)
        {
            try
            {
                return loaisachDAO.TimDSLoaiSach(tenloai);
            }
            catch
            {
                return null;
            }
        }
        public bool XoaLoaiSach(string maloai)
        {
            try
            {
                loaisachDAO.XoaLoaiSach(maloai);
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool ThemLoaiSach(string tenloai)
        {
            try
            {
                loaisachDAO.ThemLoaiSach(tenloai);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaLoaiSach(string maloai, string tenloai)
        {
            try
            {

                LoaiSachBO loaisachBO = new LoaiSachBO();
                loaisachBO.MaLoai = maloai;
                loaisachBO.TenLoai = tenloai;
                loaisachDAO.SuaLoaiSach(loaisachBO);

                return true;
            }
            catch
            {
                return false;
            }

        }
        public LoaiSachBO Tim1LoaiSach(string maloai)
        {
            try
            {
                return loaisachDAO.Tim1LoaiSach(maloai);
            }
            catch
            {
                return null;
            }
        }
    }

}
