using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using System.Data;

namespace BUS
{
    public class BaoCaoThongKeBUS
    {
        BaocaothongkeDAO baocaothongkeDAO = new BaocaothongkeDAO();
        public DataTable BaoCaoPhanLoai(string tenphanloai)
        {
            try
            {
                return baocaothongkeDAO.DsSachPhanLoai(tenphanloai);
            }
            catch
            {
                return null;
            }
        }

        public DataTable BaoCaoNhapSach(string tungay, string denngay)
        {
            try
            {
                return baocaothongkeDAO.DsNhapSach(tungay,denngay);
            }
            catch
            {
                return null;
            }
        }


        public DataTable BaoCaoChuaTraSach()
        {
            try
            {
                return baocaothongkeDAO.DsChuaTraSach();
            }
            catch
            {
                return null;
            }
        
        }

        public DataTable ThongKeTienTheChan()
        {
            try
            {
                return baocaothongkeDAO.DsTienTheChan();
            }
            catch
            {
                return null;
            }

        }

        public DataTable DSSachMat()
        {
            try
            {
                return baocaothongkeDAO.DsSachMat();
            }
            catch
            {
                return null;
            }

        }
    }
}
