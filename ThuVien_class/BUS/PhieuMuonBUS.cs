using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using BO;
namespace BUS
{   
    public class PhieuMuonBUS
    {
        PhieuMuonDAO phieumuonDAO = new PhieuMuonDAO();
        public string KiemTraMaLuot(string madocgia)
        {
            try
            {
                //kiểm tra độc giả có vào thư viện chưa
                return phieumuonDAO.KiemTraMaLuot(madocgia);
            }
            catch
            {
                return "";
            }
        }
        public int DemsoSach_ChuaTra(string madocgia)
        {
            try
            {
                return phieumuonDAO.DemsoSach_ChuaTra(madocgia);
            }
            catch
            {
                return -1;
            }
        }
        public string KiemTraSach_DangMuon(string masach)
        {
            try
            {
                //kiểm tra sách có ai mượn chưa
                return phieumuonDAO.KiemTraSach_DangMuon(masach);                   
            }
            catch
            {
                return "";
            }
        }
        public bool LuuPhieuMuon(string MaNV, string NgayMuon,string MaLuot,ChiTietPhieuMuon_TraCollection chitietphieuColl)
        {
            try
            {
                PhieuMuonBO phieumuonBO = new PhieuMuonBO();
                phieumuonBO.MaPhieuMuon = MaLuot;
                phieumuonBO.MaNV = MaNV;
                phieumuonBO.NgayMuon = NgayMuon;
                TimeSpan ts = new TimeSpan(7, 0, 0, 0);
                phieumuonBO.NgayHetHan =(Convert.ToDateTime(NgayMuon)+ts).ToString();
                phieumuonBO.MaLuot = MaLuot;
                phieumuonBO.ChitietPhieuMuon = chitietphieuColl;
                phieumuonDAO.LuuPhieuMuon(phieumuonBO);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KiemTraSach_DaMat(string masach)
        {
            try
            {
                string kq = phieumuonDAO.KiemTraSach_DaMat(masach);
                if(kq!="")
                    return true;
                return false;
            }
            catch
            {
                return true;
            }
        }
        public PhieuMuonBO Tim1PhieuMuon(string maphieumuon)
        {
            try
            {
                return phieumuonDAO.Tim1PhieuMuon(maphieumuon);
            }
            catch
            {
                return null;
            }
        }
        public bool TraSach(string maphieumuon,string masach)
        {
            try
            {
                phieumuonDAO.TraSach(maphieumuon, masach);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ChiTietPhieuMuon_TraCollection Sach_ChuaTra(string madocgia_sach, bool cachtim)
        {
            try
            {
                return phieumuonDAO.Sach_ChuaTra(madocgia_sach, cachtim);
            }
            catch
            {
                return null;
            }
        }
        public string TimGiaHan(string maphieumuon, string masach)
        {
            try
            {
                return phieumuonDAO.TimGiaHan(maphieumuon, masach);
            }
            catch
            {
                return string.Empty;
            }
        }
        public bool GiaHan(string maphieumuon, string masach)
        {
            try
            {
                phieumuonDAO.GiaHan(maphieumuon, masach);
                return true;
            }
            catch            
            {
                return false;            
            }
        }
        //thêm
        public PhieuMuonCollection TimPhieuMuon(string madocgia)
        {
            try
            {
                return phieumuonDAO.TimPhieuMuon(madocgia);
            }
            catch
            {
                return null;
            }
        }
    }
}
