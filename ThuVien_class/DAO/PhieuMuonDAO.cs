using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using BO;
namespace DAO
{
    public class PhieuMuonDAO
    {
        public string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public PhieuMuonBO Tim1PhieuMuon(string maphieumuon)
        {
            PhieuMuonBO phieumuonBO = new PhieuMuonBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT maphieumuon,maluot,manv,convert(nvarchar(10),ngaymuon,103) ngaymuon,convert(nvarchar(10),ngayhethan,103)";
            query+=" ngayhethan FROM Phieumuon WHERE maphieumuon=@maphieumuon";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@maphieumuon", maphieumuon);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                phieumuonBO.MaPhieuMuon = dr["maphieumuon"].ToString();
                phieumuonBO.MaLuot = dr["maluot"].ToString();
                phieumuonBO.MaNV = dr["manv"].ToString();
                phieumuonBO.NgayMuon = dr["ngaymuon"].ToString();
                phieumuonBO.NgayHetHan = dr["ngayhethan"].ToString();
            }
            cnn.Close();
            return phieumuonBO;
        }
        public string KiemTraSach_DangMuon(string masach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT maphieumuon FROM chitietphieumuon_tra WHERE (NgayTra IS NULL AND MaPhieuThu IS NULL )";
            query += " AND masach=@masach";
            query += " AND MaSach in (SELECT MaSach from Sach where TrangThai=1)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach", masach);
            cnn.Open();
            string maphieumuon = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return maphieumuon;
        }
        public int DemsoSach_ChuaTra(string madocgia)
        {
            int dem;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT Count(*) FROM Luotvaothuvien a,Phieumuon b,Chitietphieumuon_tra c";
            query += " WHERE a.MaLuot=b.MaLuot AND b.MaPhieuMuon=c.MaPhieuMuon";
            query += " AND madocgia=@madocgia";
            query += " AND(c.NgayTra is NULL AND MaPhieuThu is NULL)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            dem =Convert.ToInt32(cmd.ExecuteScalar().ToString());
            cnn.Close();        
            return dem;
        }
        public ChiTietPhieuMuon_TraCollection Sach_ChuaTra(string madocgia_sach, bool cachtim)
        {
            ChiTietPhieuMuon_TraCollection chitietphieuColl = new ChiTietPhieuMuon_TraCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM Luotvaothuvien a,Phieumuon b,Chitietphieumuon_tra c";
            query += " WHERE a.MaLuot=b.MaLuot AND b.MaPhieuMuon=c.MaPhieuMuon";
            if(cachtim==true)
                query += " AND madocgia=@madocgia";
            else
                query += " AND masach=@masach";
            query += " AND(c.NgayTra is NULL AND MaPhieuThu is NULL)";
            SqlCommand cmd = new SqlCommand(query,cnn);
            if (cachtim == true)
                cmd.Parameters.AddWithValue("@madocgia", madocgia_sach);
            else
                cmd.Parameters.AddWithValue("@masach", madocgia_sach);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ChiTietPhieuMuon_Tra chitietphieu = new ChiTietPhieuMuon_Tra();
                chitietphieu.GiaHan = dr["giahan"].ToString();
                chitietphieu.LyDoPhat = dr["lydophat"].ToString();
                chitietphieu.MaPhieuMuon=dr["maphieumuon"].ToString();
                chitietphieu.MaPhieuThu = dr["maphieuthu"].ToString();
                chitietphieu.MaSach = dr["masach"].ToString();
                chitietphieu.NgayTra = dr["ngaytra"].ToString();
                //chitietphieu.SoTienPhat=Convert.ToDecimal(dr["sotienphat"].ToString());
                chitietphieu.TienTheChan=Convert.ToDecimal(dr["tienthechan"].ToString());
                chitietphieuColl.Add(chitietphieu);
            }
            cnn.Close();
            return chitietphieuColl;
        }
        public string KiemTraMaLuot(string madocgia)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT maluot FROM Luotvaothuvien WHERE madocgia=@madocgia AND Thoigianra IS NULL";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            string maluot = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return maluot;            
        }
        public void LuuPhieuMuon(PhieuMuonBO phieumuonBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            //Thêm phiếu mượn
            string query = "INSERT INTO PHIEUMUON(Manv,ngaymuon,ngayhethan,maluot)";
            query += " VALUES(@manv,@ngaymuon,@ngayhethan,@maluot)";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@manv",phieumuonBO.MaNV);
            cmd.Parameters.AddWithValue("@ngaymuon",phieumuonBO.NgayMuon);
            cmd.Parameters.AddWithValue("@ngayhethan",phieumuonBO.NgayHetHan);
            cmd.Parameters.AddWithValue("@maluot",phieumuonBO.MaLuot);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            //Thêm chi tiết phiếu mượn
            query="INSERT INTO CHITIETPHIEUMUON_TRA(Maphieumuon,masach,tienthechan)";
            query += " VALUES((SELECT top 1 Maphieumuon FROM PhieuMuon Order by NgayMuon desc),@masach,@tienthechan)";
            for(int i=0;i<phieumuonBO.ChitietPhieuMuon.Count;i++)
            {
                SqlCommand chitietcmd= new SqlCommand(query,cnn);
             //   chitietcmd.Parameters.AddWithValue("@maphieumuon",phieumuonBO.ChitietPhieuMuon.Index(i).MaPhieuMuon);
                chitietcmd.Parameters.AddWithValue("@masach",phieumuonBO.ChitietPhieuMuon.Index(i).MaSach);
                chitietcmd.Parameters.AddWithValue("@tienthechan",phieumuonBO.ChitietPhieuMuon.Index(i).TienTheChan);
                cnn.Open();
                chitietcmd.ExecuteNonQuery();
                cnn.Close();
            }


        }
        public string KiemTraSach_DaMat(string masach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT masach FROM Sach WHERE masach=@masach AND Trangthai=0";           
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach", masach);
            cnn.Open();
            if (cmd.ExecuteScalar() == null)
                return "";
            string kq = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return kq;     
      
        }
        public void TraSach(string maphieumuon,string masach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE Chitietphieumuon_tra Set NgayTra=Getdate() WHERE maphieumuon=@maphieumuon AND masach=@masach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maphieumuon", maphieumuon);
            cmd.Parameters.AddWithValue("@masach", masach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();   
        }
        public string TimGiaHan(string maphieumuon, string masach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT convert(nvarchar(10),giahan,103) FROM chitietphieumuon_tra where masach=@masach AND maphieumuon=@maphieumuon";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach", masach);
            cmd.Parameters.AddWithValue("@maphieumuon", maphieumuon);
            cnn.Open();
            object kq = cmd.ExecuteScalar();
            cnn.Close();
            if (kq != null)
                return kq.ToString();
            return string.Empty;
        }
        public void GiaHan(string maphieumuon,string masach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE Chitietphieumuon_tra SET giahan=";
            query += "DATEADD(wk,1,(SELECT ngayhethan FROM Phieumuon WHERE maphieumuon=@maphieumuon))";
            query+=" WHERE masach=@masach AND maphieumuon=@maphieumuon";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach", masach);
            cmd.Parameters.AddWithValue("@maphieumuon", maphieumuon);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //TimPhieuMuon
        public PhieuMuonCollection TimPhieuMuon(string madocgia)
        {
            PhieuMuonCollection phieumuonColl = new PhieuMuonCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select convert(nvarchar(10),ngaymuon,103) ngaymuon,maphieumuon,maNV from phieumuon where MaLuot in";
            query += " (select MaLuot from LuotVaoThuVien where MaDocGia='10LD11004') order by ngaymuon desc";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PhieuMuonBO phieumuonBO = new PhieuMuonBO();
                phieumuonBO.MaPhieuMuon = dr["maphieumuon"].ToString();
                phieumuonBO.MaNV = dr["MaNV"].ToString();
                phieumuonBO.NgayMuon = dr["ngaymuon"].ToString();
                phieumuonColl.Add(phieumuonBO);
            }
            cnn.Close();
            return phieumuonColl;
        }
    }
}
