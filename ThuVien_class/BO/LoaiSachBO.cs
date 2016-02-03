using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class LoaiSachBO
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
    public class LoaiSachCollection : System.Collections.CollectionBase
    {
        public void Add(LoaiSachBO loaisachBO)
        {
            List.Add(loaisachBO);
        }
        public LoaiSachBO Index(int index)
        {
            return (LoaiSachBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
