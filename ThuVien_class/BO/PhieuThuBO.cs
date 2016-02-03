using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace BO
{
    public class PhieuThuBO
    {
        public string MaPhieuThu{get;set;}
        public string MaNV { get; set; }
        public decimal TongTien { get; set; }
        public string NgayLap { get; set; }
        public ChiTietPhieuMuon_TraCollection ChiTietPhieuThu;
    }
    public class PhieuThuCollection : System.Collections.CollectionBase
    {
        public void Add(PhieuThuBO phieuthuBO)
        {
            List.Add(phieuthuBO);
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
        public PhieuThuBO Index(int index)
        {
            return (PhieuThuBO)List[index];
        }
    }
}
