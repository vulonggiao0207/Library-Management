using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class TacGiaBO
    {
        public string MaTG { get; set; }
        public string TenTG { get; set; }
    }
    public class TacGiaCollection : System.Collections.CollectionBase
    {
        public void Add(TacGiaBO tacgiaBO)
        {
            List.Add(tacgiaBO);
        }
        public TacGiaBO Index(int index)
        {
            return (TacGiaBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
    /*Quan hệ sách - tác giả*/
    public class TacGia_Sach
    {
        public string MaTG { get; set; }
        public string MaSach { get; set; }
    }
    public class TacGia_SachCollection : System.Collections.CollectionBase
    {
        public void Add(TacGia_Sach tacgia_sach)
        {
            List.Add(tacgia_sach);
        }
        public TacGia_Sach Index(int index)
        {
            return (TacGia_Sach)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
