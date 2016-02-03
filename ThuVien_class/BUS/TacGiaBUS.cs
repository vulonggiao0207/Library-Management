using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;
namespace BUS
{
    public class TacGiaBUS
    {
        TacGiaDAO tgDAO= new TacGiaDAO();

        public TacGiaCollection TimDSTacGia(string tentg)
        {
            try
            {
                return tgDAO.TimDSTacGia(tentg);
            }
            catch
            {
                return null;
            }
        }

        public bool XoaTg(string matg)
        {
            try
            {
                tgDAO.XoaTg(matg);
                return true;
            }
            catch
            {
                return false;

            }
        }
        public bool ThemTg(string tentg)
        {
            try
            {
                tgDAO.ThemTg(tentg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaTg(string matg, string tentg)
        {
            try
            {
                TacGiaBO tacgiaBO = new TacGiaBO();
                tacgiaBO.MaTG = matg;
                tacgiaBO.TenTG = tentg;
                tgDAO.SuaLoaiSach(tacgiaBO);

                
                return true;
            }
            catch
            {
                return false;
            }

        }


    }
}
