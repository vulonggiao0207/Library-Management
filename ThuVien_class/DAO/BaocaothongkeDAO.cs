using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class BaocaothongkeDAO

    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public DataTable DsSachPhanLoai(string tenphanloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select tensach, tennxb, namxuatban,lanxuatban,COUNT(sach.masach)as soluong,trigia from Sach,ChiTietPhanLoai,PhanLoai,nhaxuatban where Sach.MaCTPhanLoai=ChiTietPhanLoai.MaCTPhanLoai and ChiTietPhanLoai.MaPhanLoai=PhanLoai.MaPhanLoai and NhaXuatBan.MaNXB=Sach.MaNXB and PhanLoai.TenPhanLoai=N'" + tenphanloai +"' group by sach.TenSach,tennxb, namxuatban,lanxuatban,trigia";
            SqlCommand cmd = new SqlCommand(query, cnn);
            //SqlParameter ptenphanloai = new SqlParameter("@tenphanloai", SqlDbType.Char, 30);
            //ptenphanloai.Value = tenphanloai;
            //cmd.Parameters.Add(ptenphanloai);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DSSachPhanLoai");
            return dset.Tables["DSSachPhanLoai"];            
        }



        public DataTable DsNhapSach(string tungay, string denngay)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select tensach, TenNXB, namxuatban,lanxuatban,trigia, COUNT(sach.masach)as soluong, TriGia* COUNT(Sach.MaSach) as thanhtien from Sach, NhaXuatBan where NhaXuatBan.MaNXB=Sach.MaNXB and convert(date,NgayNhap) >= '"+tungay+"' and convert(date,NgayNhap) <='"+denngay+"' group by sach.TenSach,TenNXB, namxuatban,lanxuatban,trigia";
            SqlCommand cmd = new SqlCommand(query, cnn);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DSNhapSach");
            return dset.Tables["DSNhapSach"];
        }

        public DataTable DsChuaTraSach()
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select docgia.MaDocGia,TenDocGia,TenSach,convert(varchar(20),NgayMuon,103) as ngaymuon,convert(varchar(20),GiaHan,103) as ngaygiahan from DocGia, PhieuMuon, LuotVaoThuVien , ChiTietPhieuMuon_Tra, Sach where ChiTietPhieuMuon_Tra.MaPhieuMuon=PhieuMuon.MaPhieuMuon and PhieuMuon.MaLuot=LuotVaoThuVien.MaLuot and LuotVaoThuVien.MaDocGia=DocGia.MaDocGia and ChiTietPhieuMuon_Tra.MaSach=Sach.MaSach and ChiTietPhieuMuon_Tra.NgayTra is null";
            SqlCommand cmd = new SqlCommand(query, cnn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DSChuaTraSach");
            return dset.Tables["DSChuaTraSach"];
        }


        public DataTable DsTienTheChan()
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select docgia.MaDocGia,TenDocGia,TenSach, tienthechan from DocGia, PhieuMuon, LuotVaoThuVien , ChiTietPhieuMuon_Tra, Sach where ChiTietPhieuMuon_Tra.MaPhieuMuon=PhieuMuon.MaPhieuMuon and PhieuMuon.MaLuot=LuotVaoThuVien.MaLuot and LuotVaoThuVien.MaDocGia=DocGia.MaDocGia and ChiTietPhieuMuon_Tra.MaSach=Sach.MaSach and ChiTietPhieuMuon_Tra.NgayTra is null";
            SqlCommand cmd = new SqlCommand(query, cnn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DSTienTheChan");
            return dset.Tables["DSTienTheChan"];
        }


        public DataTable DsSachMat()
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select MaSach,TenSach,TenNXB,NamXuatBan,TriGia from Sach,NhaXuatBan where sach.manxb=NhaXuatBan.MaNXB and TrangThai=0";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DSsachMat");
            return dset.Tables["DSSachMat"];
        } 
    }

}
