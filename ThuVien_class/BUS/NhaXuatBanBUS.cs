using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;
namespace BUS
{
    public class NhaXuatBanBUS
    {
        NhaXuatBanDAO nxbDAO = new NhaXuatBanDAO();
        public NhaXuatBanCollection TimDSNhaXuatBan(string tennxb)
        {
            try
            {
                return nxbDAO.TimDSNhaXuatBan(tennxb);
            }
            catch
            {
                return null;
            }
        }
        public bool XoaNhaXuatBan(string manxb)
        {
            try 
            {
                nxbDAO.XoaNXB(manxb);
                return true;
            }
            catch 
            {
                return false;

            }
        }
        public bool ThemNhaXuatBan(string tennxb)
        {
            try
            {
                nxbDAO.ThemNXB(tennxb);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool SuaNhaXuatBan(string manxb, string tennxb)
        {
            try
            {
                NhaXuatBanBO nxbBO = new NhaXuatBanBO();
                nxbBO.MaNXB = manxb;
                nxbBO.TenNXB = tennxb;
                nxbDAO.SuaNXB(nxbBO);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public NhaXuatBanBO Tim1NXB(string manxb)
        {
            try
            {
                return nxbDAO.Tim1NXB(manxb);
            }
            catch
            {
                return null;
            }
        }
    }
}
