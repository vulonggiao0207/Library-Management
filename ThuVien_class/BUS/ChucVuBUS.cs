using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAO;
namespace BUS
{
    public class ChucVuBUS
    {
        ChucVuDAO chucvuDAO = new ChucVuDAO();
        public ChucVuCollection TimDSChucVu(string tencv)
        {
            try
            {
                return chucvuDAO.TimDSChucVu(tencv);
            }
            catch
            {
                return null;
            }
        }
        public bool ThemChucVu(string tencv)
        {
            try
            {
                chucvuDAO.ThemChucVu(tencv);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaChucVu(string macv)
        {
            try
            {
                chucvuDAO.XoaChucVu(macv);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaChucVu(string macv, string tencv)
        {
            try
            {
                ChucVuBO chucvuBO = new ChucVuBO();
                chucvuBO.MaCV = macv;
                chucvuBO.TenCV = tencv;
                chucvuDAO.SuaChucVu(chucvuBO);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ChucVuBO Tim1ChucVu(string macv)
        {
            try
            {
                return chucvuDAO.Tim1ChucVu(macv);
            }
            catch
            {
                return null;
            }
        }
    }

}
