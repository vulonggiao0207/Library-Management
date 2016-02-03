using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class PhanLoaiBO
    {
        public string MaPhanLoai { get; set; }
        public string TenPhanLoai { get; set; }
        public CTPhanLoaiCollection chitietphanloaiColl { get; set; }
        public bool Compare(PhanLoaiBO phanloaiBO)
        {
            if (this.MaPhanLoai != phanloaiBO.MaPhanLoai)
                return false;
            if (this.TenPhanLoai != phanloaiBO.TenPhanLoai)
                return false;
            if (this.chitietphanloaiColl.Count != phanloaiBO.chitietphanloaiColl.Count)
                return false;
            for (int i = 0; i < this.chitietphanloaiColl.Count; i++)
            {
                if (this.chitietphanloaiColl.Index(i) != phanloaiBO.chitietphanloaiColl.Index(i))
                    return false;
            }
            return true;
        }
   /*     public bool AddCTPhanLoai(CTPhanLoaiCollection ctPhanLoaiColl)
        {
            for
        }*/

    }
    public class CTPhanLoai
    {
        public string MaCTPhanLoai { get; set; }
        public string TenCTPhanLoai { get; set; }
    }
    public class CTPhanLoaiCollection : System.Collections.CollectionBase
    {
        public void Add(CTPhanLoai ctphanloai)
        {
            List.Add(ctphanloai);
        }
        public CTPhanLoai Index(int index)
        { 
            return (CTPhanLoai)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }      
    }
    public class PhanLoaiCollection : System.Collections.CollectionBase
    {
        public void Add(PhanLoaiBO phanloaiBO)
        {
            List.Add(phanloaiBO);
        }
        public PhanLoaiBO Index(int index)
        {
            return (PhanLoaiBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
