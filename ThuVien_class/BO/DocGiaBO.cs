using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BO
{
    public class DocGiaBO
    {
        public string MaDocGia { get; set; }
        public string MaLoai { get; set; }
        public string TenDocGia { get; set; }
        public bool GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string NgayLapThe { get; set; }
        public string NgayHetHan { get; set; }
        public string MatKhau { get; set; }
        public string HinhAnh { get; set; }
        public bool SoSanh(DocGiaBO docgiaBO)
        {
            int dem = 0;
            if (this.MaDocGia == docgiaBO.MaDocGia)
                return true;
            if (this.MaLoai == docgiaBO.MaLoai)
                dem++;
            if (this.TenDocGia == docgiaBO.TenDocGia)
                dem++;
            if (this.GioiTinh == docgiaBO.GioiTinh)
                dem++;
            if (this.NgaySinh == docgiaBO.NgaySinh)
                dem++;
            if (this.DiaChi == docgiaBO.DiaChi)
                dem++;
            if (this.HinhAnh == docgiaBO.HinhAnh)
                dem++;
            if (dem == 6)
                return true;
            return false;
        }
    }
    public class DocGiaCollection:System.Collections.CollectionBase
    {
        public void Add(DocGiaBO docgiaBO)
        {
            List.Add(docgiaBO);
        }
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
        public DocGiaBO Index(int index)
        {
            return (DocGiaBO)List[index];
        }
        public bool KiemTraTonTai(DocGiaBO docgiaBO)
        {
            foreach (DocGiaBO docgia in this)
            {
                if (docgia.SoSanh(docgiaBO) == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
