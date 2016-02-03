using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class KhuVucBO
    {
        public string MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }
    }
    public class KhuVucCollection : System.Collections.CollectionBase
    {
        public void Add(KhuVucBO khuvucBO)
        {
            List.Add(khuvucBO);
        }
        public KhuVucBO Index(int index)
        {
            return (KhuVucBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
