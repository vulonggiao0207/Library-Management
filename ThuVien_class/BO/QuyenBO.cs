using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using BO;
namespace BO
{
    public class QuyenBO
    {
        public string MaQuyen { get; set; }
        public string TenQuyen { get; set; }
        public CTQuyenCollection ChiTietQuyen { get; set; }
    }
    public class QuyenCollection : System.Collections.CollectionBase
    {
        public void Add(QuyenBO quyenBO)
        {
            List.Add(quyenBO);
        }
        public QuyenBO Index(int index)
        {
            return (QuyenBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }      
    }
    public class CTQuyen
    {
        public string MaCTQuyen { get; set; }
        public string TenCTQuyen { get; set; }
        public string LienKet { get; set; }
    }
    public class CTQuyenCollection : System.Collections.CollectionBase
    {
        public void Add(CTQuyen ctquyen)
        {
            List.Add(ctquyen);
        }
        public CTQuyen Index(int index)
        {
            return (CTQuyen)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }      
    }
}
