using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAO;
namespace BUS
{
    public class PhieuThuBUS
    {
        PhieuThuDAO phieuthuDAO = new PhieuThuDAO();
        public ChiTietPhieuMuon_TraCollection TimSachViPham(string madocgia)
        {
            try
            {
                return phieuthuDAO.TimSachViPham(madocgia);
            }
            catch
            {
                return null;
            }
        }
        public bool LuuPhieu(ChiTietPhieuMuon_TraCollection chitietphieuColl, string manv,decimal tongtien)
        {
            try
            {
                PhieuThuBO phieuthuBO = new PhieuThuBO();
                phieuthuBO.MaNV = manv;
                phieuthuBO.TongTien = tongtien;
                phieuthuBO.ChiTietPhieuThu = chitietphieuColl;
                phieuthuDAO.LuuPhieu(phieuthuBO);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PhieuThuCollection TimPhieuThu(string madocgia)
        {
            try
            {
                return phieuthuDAO.TimPhieuThu(madocgia);
            }
            catch
            {
                return null;
            }
        }
        public ChiTietPhieuMuon_TraCollection TimChitietPhieuThu(string maphieuthu)
        {
            try
            {
                return phieuthuDAO.TimChitietPhieuThu(maphieuthu);
            }
            catch
            {
                return null; 
            }
        }
    }
}
