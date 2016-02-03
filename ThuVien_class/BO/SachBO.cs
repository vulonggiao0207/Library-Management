using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class SachBO
    {
        public string MaSach { get; set; }
        public string MaNXB { get; set; }
        public string MaLoai { get; set; }
        public string MaCTPhanLoai { get; set; }
        public string TenSach { get; set; }
        public int namxuatban { get; set; }
        public int lanxuatban { get; set; }
        public decimal trigia { get; set; }
        public string hinhanh { get; set; }
        public bool muondemve { get; set; }
        public string ngaynhap { get; set; }
        public string khuvuc { get; set; }
        public string ke { get; set; }
        public string ngan { get; set; }
        public bool trangthai { get; set; }
        public string maphieuthanhly { get; set; }
        public string lydothanhly { get; set; }
        public int Madausach { get; set; }
        public TacGiaCollection tacgiaColl { get; set; }
    }

    public class SachCollection : System.Collections.CollectionBase
    {
        public void Add(SachBO sachBO)
        {
            List.Add(sachBO);
        }
        public SachBO Index(int index)
        {
            return (SachBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
