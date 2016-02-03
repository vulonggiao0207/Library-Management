using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAO;
namespace BUS
{
    public class QuyenBUS
    {
        QuyenDAO quyenDAO = new QuyenDAO();
        public QuyenCollection TimDSQuyen()
        {
            try {
                return quyenDAO.TimDSQuyen();
            }
            catch {
                return null;
            }
        }
        public QuyenCollection TimDSQuyen_NhanVien(string manv)
        {
            try
            {
                return quyenDAO.TimDSQuyen_NhanVien(manv);
            }
            catch
            {
                return null;
            }
        }
        public bool CapNhatQuyen_NhanVien(string manv, CTQuyenCollection quyenBO)
        {
            try
            {
                quyenDAO.CapNhatQuyen_NhanVien(manv, quyenBO);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
