using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace BO
{
    public class NhanVienBO
    {
        public string MaNV { get; set; }
        public string MaCV { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
      //  public DateTime NgaySinh { get; set; }
        public string NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string HinhAnh { get; set; }
        public bool NgungHoatDong { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
    public class NhanVienCollection : System.Collections.CollectionBase
    {
        public void Add(NhanVienBO nhanvienBO)
        {
            List.Add(nhanvienBO);
        }
        public NhanVienBO Index(int index)
        {
            return (NhanVienBO)List[index];
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
    }
}
