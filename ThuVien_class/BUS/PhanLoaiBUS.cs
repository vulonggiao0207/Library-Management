using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;
namespace BUS
{
    public class PhanLoaiBUS
    {
        PhanLoaiDAO phanloaiDAO = new PhanLoaiDAO();

        

        public PhanLoaiCollection TimDSCapNhatPhanLoai(string tenphanloai)
        {
            try
            {
                return phanloaiDAO.TimDSCapNhatPhanLoai(tenphanloai);
               
            }
            catch
            {
                return null;
            }
        }
        public PhanLoaiCollection TimDSPhanLoai()
        {
            try
            {
                return phanloaiDAO.TimDSPhanLoai();
            }
            catch
            {
                return null;
            }
        }
        public bool XoaPhanLoai(string maphanloai)
        {
            try
            {
                phanloaiDAO.XoaPhanLoai(maphanloai);
                
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool ThemPhanLoai(string tenphanloai)
        {
            try
            {
                phanloaiDAO.ThemPhanLoai(tenphanloai);
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaPhanLoai(string maphanloai, string tenphanloai)
        {
            try
            {
                PhanLoaiBO phanloaiBO = new PhanLoaiBO();
                phanloaiBO.MaPhanLoai = maphanloai;
                phanloaiBO.TenPhanLoai = tenphanloai;

                phanloaiDAO.SuaPhanLoai(phanloaiBO);
                

                return true;
            }
            catch
            {
                return false;
            }

        }

        public CTPhanLoaiCollection TimDSCTPhanLoai(string maphanloai)
        {
            try
            {
                return phanloaiDAO.TimDSCTPhanLoai(maphanloai);
            }
            catch
            {
                return null;
            }
        }
        public bool ThemCTPhanLoai(string maphanloai, string tenctphanloai)
        {
            try
            {
                phanloaiDAO.ThemCTPhanLoai(maphanloai, tenctphanloai);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaCTPhanLoai(string mactphanloai)
        {
            try
            {
                phanloaiDAO.XoaCTPhanLoai(mactphanloai);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaCTPhanLoai(string mactphanloai, string tenctphanloai)
        {
            try
            {
                phanloaiDAO.SuaCTPhanLoai(mactphanloai, tenctphanloai);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public CTPhanLoai Tim1CTPhanLoai(string mactphanloai)
        {
            try
            {
                return phanloaiDAO.Tim1CTPhanLoai(mactphanloai);
            }
            catch
            {
                return null;
            }
        }
        public PhanLoaiBO Tim1PhanLoai_CT(string mactphanloai)
        {
            try
            {
                return phanloaiDAO.Tim1PhanLoai_CT(mactphanloai);
            }
            catch
            {
                return null;
            }
        }
    }
}
