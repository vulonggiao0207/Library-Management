using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class NhaXuatBanBO
    {
        public string MaNXB {get;set; }
        public string TenNXB { get; set; }
    }
    public class NhaXuatBanCollection : System.Collections.CollectionBase
    {
        public void Add(NhaXuatBanBO nhaxuatbanBO)
        {
            List.Add(nhaxuatbanBO);
        }
        public NhaXuatBanBO Index(int index)
        {
            return (NhaXuatBanBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
