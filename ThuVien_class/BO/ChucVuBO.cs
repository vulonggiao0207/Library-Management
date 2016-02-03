using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
        public class ChucVuBO
        {
            public string MaCV { get; set; }
            public string TenCV { get; set; }
        }
        public class ChucVuCollection : System.Collections.CollectionBase
        {
            public void Add(ChucVuBO chucvuBO)
            {
                List.Add(chucvuBO);
            }
            public ChucVuBO Index(int index)
            {
                return (ChucVuBO)List[index];
            }
            public void Remove(int index)
            {
                List.RemoveAt(index);
            }
        }
    
}
