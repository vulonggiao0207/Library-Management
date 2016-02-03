using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Configuration;
namespace DAO
{
    public class PhieuThuDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public ChiTietPhieuMuon_TraCollection TimSachViPham(string madocgia)
        {
            ChiTietPhieuMuon_TraCollection chitietColl = new ChiTietPhieuMuon_TraCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT Convert(nvarchar(10),GiaHan,103) GiaHan,* FROM (SELECT a.MaPhieuMuon,MaSach,Ngaymuon,NgayHetHan,GiaHan,NgayTra,LydoPhat,SoTienPhat,TienTheChan,MaPhieuThu ";
            query += "FROM ChiTietphieumuon_tra a,PhieuMuon b WHERE a.MaPhieuMuon=b.MaPhieuMuon ";
            query += "AND b.MaPhieuMuon in(SELECT distinct MaPhieuMuon FROM PhieuMuon,LuotVaoThuVien ";
            query += "WHERE PhieuMuon.maluot=Luotvaothuvien.maluot AND madocgia=@madocgia) ";
            query += "AND MaSach in (SELECT masach FROM Sach WHERE trangthai=1)) SachViPham ";
            query += "WHERE (NgayTra IS NULL AND(NgayHetHan<GETDATE()) AND MaPhieuThu IS NULL) ";
            query += "OR (NgayTra IS NULL AND(GiaHan<GETDATE()) AND MaPhieuThu IS NULL) ";
            query += "OR (NgayTra IS NOT NULL AND (NgayHetHan<NgayTra) AND MaPhieuThu IS NULL) ";
            query += "OR (NgayTra IS NOT NULL AND (GiaHan<NgayTra) AND MaPhieuThu IS NULL) ";
            query += "OR (NgayTra IS NULL AND MaPhieuThu IS NULL)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ChiTietPhieuMuon_Tra ctphieu = new ChiTietPhieuMuon_Tra();
                ctphieu.GiaHan = dr["Giahan"].ToString();
                ctphieu.LyDoPhat = dr["lydophat"].ToString();
                ctphieu.MaPhieuMuon = dr["maphieumuon"].ToString();
                ctphieu.MaPhieuThu = dr["maphieuthu"].ToString();
                ctphieu.MaSach = dr["masach"].ToString();
                ctphieu.TienTheChan = Convert.ToDecimal(dr["tienthechan"].ToString());
                ctphieu.NgayTra = dr["ngaytra"].ToString();
                if (dr["sotienphat"].ToString() != "")
                    ctphieu.SoTienPhat = Convert.ToDecimal(dr["sotienphat"].ToString());
                /*     if(dr["tienthechan"].ToString()!="")
                         ctphieu.TienTheChan = Convert.ToDecimal(dr["tienthechan"].ToString());*/
                chitietColl.Add(ctphieu);
            }
            cnn.Close();
            return chitietColl;
        }
        public ChiTietPhieuMuon_TraCollection TimChitietPhieuThu(string maphieuthu)
        {
            ChiTietPhieuMuon_TraCollection chitietColl = new ChiTietPhieuMuon_TraCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT Convert(nvarchar(10),GiaHan,103) GiaHan,* FROM Chitietphieumuon_tra WHERE maphieuthu=@maphieuthu ";       
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maphieuthu", maphieuthu);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ChiTietPhieuMuon_Tra ctphieu = new ChiTietPhieuMuon_Tra();
              //  ctphieu.GiaHan = dr["Giahan"].ToString();
                ctphieu.LyDoPhat = dr["lydophat"].ToString();
                ctphieu.MaPhieuMuon = dr["maphieumuon"].ToString();
                ctphieu.MaPhieuThu = dr["maphieuthu"].ToString();
                ctphieu.MaSach = dr["masach"].ToString();
                ctphieu.TienTheChan = Convert.ToDecimal(dr["tienthechan"].ToString());
                ctphieu.NgayTra = dr["ngaytra"].ToString();
                if (dr["sotienphat"].ToString() != "")
                    ctphieu.SoTienPhat = Convert.ToDecimal(dr["sotienphat"].ToString());
                /*     if(dr["tienthechan"].ToString()!="")
                         ctphieu.TienTheChan = Convert.ToDecimal(dr["tienthechan"].ToString());*/
                chitietColl.Add(ctphieu);
            }
            cnn.Close();
            return chitietColl;
        }
        public void LuuPhieu(PhieuThuBO phieuthuBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            //Thêm phiếu mượn
            string query = "INSERT INTO PHIEUTHU(Manv,Tongtien,Ngaylap)";
            query += " VALUES(@manv,@tongtien,getdate())";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manv",phieuthuBO.MaNV);
            cmd.Parameters.AddWithValue("@tongtien",phieuthuBO.TongTien);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            //Thêm chi tiết phiếu mượn
            query = "UPDATE CHITIETPHIEUMUON_TRA";
            query += " SET maphieuthu=(SELECT top 1 Maphieuthu FROM Phieuthu Order by Ngaylap desc) ";
            query+=", sotienphat=@sotienphat,lydophat=@lydophat WHERE maphieumuon=@maphieumuon AND masach=@masach";
            for (int i = 0; i <phieuthuBO.ChiTietPhieuThu.Count; i++)
            {
                SqlCommand chitietcmd = new SqlCommand(query, cnn);
                chitietcmd.Parameters.AddWithValue("@sotienphat",phieuthuBO.ChiTietPhieuThu.Index(i).SoTienPhat);
                chitietcmd.Parameters.AddWithValue("@lydophat",phieuthuBO.ChiTietPhieuThu.Index(i).LyDoPhat);
                chitietcmd.Parameters.AddWithValue("@maphieumuon",phieuthuBO.ChiTietPhieuThu.Index(i).MaPhieuMuon);
                chitietcmd.Parameters.AddWithValue("@masach", phieuthuBO.ChiTietPhieuThu.Index(i).MaSach);
                cnn.Open();
                chitietcmd.ExecuteNonQuery();
                cnn.Close();
            }

        }
        public PhieuThuCollection TimPhieuThu(string madocgia)
        {
            PhieuThuCollection phieuthuColl = new PhieuThuCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query="SELECT convert(nvarchar(10),ngaylap,103) NgayLap, * FROM Phieuthu a, ChiTietPhieuMuon_Tra b, Phieumuon c, luotvaothuvien d";
            query += " WHERE a.maphieuthu=b.maphieuthu AND c.maphieumuon=b.maphieumuon AND c.maluot=d.maluot";
            query += " AND madocgia=@madocgia";
            query += " Order by a.Ngaylap desc";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PhieuThuBO phieuthuBO = new PhieuThuBO();
                phieuthuBO.MaNV = dr["manv"].ToString();
                phieuthuBO.MaPhieuThu = dr["maphieuthu"].ToString();
                phieuthuBO.NgayLap=dr["Ngaylap"].ToString();
                phieuthuBO.TongTien=Convert.ToDecimal(dr["tongtien"].ToString());
                phieuthuColl.Add(phieuthuBO);
            }
            cnn.Close();
            return phieuthuColl;
        }        
    }
}
