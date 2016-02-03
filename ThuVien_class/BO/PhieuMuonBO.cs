using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace BO
{
    public class PhieuMuonBO
    {
        public string MaPhieuMuon { get; set; }
        public string MaNV { get; set; }
        public string NgayMuon { get; set; }
        public string NgayHetHan { get; set; }
        public string MaLuot { get; set; }
        public ChiTietPhieuMuon_TraCollection ChitietPhieuMuon;
    }
    public class PhieuMuonCollection : System.Collections.CollectionBase
    {
        public void Add(PhieuMuonBO phieumuonBO)
        {
            List.Add(phieumuonBO);
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
        public PhieuMuonBO Index(int index)
        {
            return (PhieuMuonBO)List[index];
        }
    }
    public class ChiTietPhieuMuon_Tra
    {
        public string MaPhieuMuon { get; set;}
        public string MaPhieuThu { get; set;}
        public string MaSach { get; set;}
        public string NgayTra { get; set;}
        public decimal TienTheChan { get;set;}
        public string LyDoPhat { get;set; }
        public decimal SoTienPhat { get;set;}
        public string GiaHan { get; set;}
    }
    public class ChiTietPhieuMuon_TraCollection : System.Collections.CollectionBase
    {
        public void Add(ChiTietPhieuMuon_Tra chitietphieumuon_traBO)
        {
            List.Add(chitietphieumuon_traBO);
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
        public ChiTietPhieuMuon_Tra Index(int index)
        {
            return (ChiTietPhieuMuon_Tra)List[index];
        }
    }

}
