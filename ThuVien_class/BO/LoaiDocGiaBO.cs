using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace BO
{
    public class LoaiDocGiaBO
    {
        public string MaLoai {get; set;}
        public string TenLoai { get; set; }
    }
    public class LoaiDocGiaCollection:System.Collections.CollectionBase
    {
        public void Add (LoaiDocGiaBO loaidocgiaBO)
        {
            List.Add(loaidocgiaBO);
        }
        public void Remove (int index)
        {
            List.RemoveAt(index);
        }
        public LoaiDocGiaBO Index (int index)
        {
            return (LoaiDocGiaBO)List[index];
        }
          
    }
}
