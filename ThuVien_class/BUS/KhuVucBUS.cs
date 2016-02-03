using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;

namespace BUS
{
    public class KhuVucBUS
    {
       
        KhuVucDAO khuvucDAO = new KhuVucDAO();

        public KhuVucCollection TimDSKhuVuc (string tenkhuvuc)
        {
            try
            {
                return khuvucDAO.TimDSKhuVuc(tenkhuvuc);

            }
            catch
            {
                return null;
            }
        }
        public bool XoaKhuVuc(string makhuvuc)
        {
            try
            {
                khuvucDAO.XoaKhuVuc(makhuvuc);
                
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool ThemKhuVuc(string tenkhuvuc)
        {
            try
            {
                khuvucDAO.ThemKhuVuc(tenkhuvuc);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaKhuVuc(string makhuvuc, string tenkhuvuc)
        {
            try
            {
                KhuVucBO khuvucBO = new KhuVucBO();
                khuvucBO.MaKhuVuc = makhuvuc;
                khuvucBO.TenKhuVuc = tenkhuvuc;
                khuvucDAO.SuaKhuVuc(khuvucBO);
              
                return true;
            }
            catch
            {
                return false;
            }

        }
        public KhuVucBO Tim1KhuVuc(string makhuvuc)
        {
            try
            {
                return khuvucDAO.Tim1KhuVuc(makhuvuc);
            }
            catch
            {
                return null;
            }
        }

    }
}
