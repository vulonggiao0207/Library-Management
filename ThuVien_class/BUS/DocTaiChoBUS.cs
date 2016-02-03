using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;


namespace BUS
{
    public class DocTaiChoBUS
    {
        DocTaiChoDAO doctaichoDAO = new DocTaiChoDAO();
        public bool VaoRaThuVien(string manv, string madocgia)
        {
            int n = doctaichoDAO.VaoRaThuVien(manv, madocgia);
            if (n>=0)
                return true;
            else
                return false;
        }
        public string KiemTraDocGia(string madocgia)
        {
            try
            {
                string n = doctaichoDAO.KiemTraDocGia(madocgia);
                return n;
            }

            catch
            {
                return string.Empty;
            }
        }
        public string KiemTraSachTrung(string masach)
        {
            try
            {
                string n = doctaichoDAO.KiemTraSachTrung(masach);
                return n;
            }

            catch
            {
                return string.Empty;
            }
        }

        public string KTSachChuaTra(string madocgia)
        {
            try {
                string n = doctaichoDAO.KtSachTra(madocgia);
                return n;
            }
            catch
            {
                return string.Empty;
            }
        }

        ////muon sach
        public string KiemTraDocGiaTrongThuVien(string madocgia)
        {
            try
            {
                string n = doctaichoDAO.KiemTraDocGiaTrongThuVien(madocgia);
                return n;
            }

            catch
            {
                return string.Empty;
            }
        }

        public bool Muonsach(string masach, string madocgia)
        {
            int n = doctaichoDAO.MuonSach(masach, madocgia);
            if (n >= 0)
                return true;
            else
                return false;
        }

        public string KiemTraSoSachMuon(string madocgia)
        {
            try
            {
                string n = doctaichoDAO.KiemTraSoSachMuon(madocgia);
                return n;
            }

            catch
            {
                return string.Empty;
            }
        }

     //tra sach
        public bool TraSach(string masach)
        {
            int n = doctaichoDAO.TraSach(masach);
            if (n >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ////////////////////////////////////////////////
        public string Tim1DocGia_Luot(string maluot)
        {
            try
            {
                return doctaichoDAO.Tim1DocGia_Luot(maluot);
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
