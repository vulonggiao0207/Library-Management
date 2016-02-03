using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BO;
namespace DAO
{
    public class SachDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        TacGiaDAO tgDAO = new TacGiaDAO();
        NhanVienDAO nhanvienDAO = new NhanVienDAO();
        public int TaoMaDauSach()
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select MAX(madausach) from sach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            object res= cmd.ExecuteScalar();
            cnn.Close();
            if (res.ToString()=="")
                return 1;
            return Convert.ToInt32(res)+1;
        }
        //XỬ LÝ ĐẦU SÁCH
        public SachCollection TimDSSach(string tensach)
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT distinct MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query+=" FROM Sach WHERE";
            query += " trangthai=1 AND tensach like N'%"+tensach+"%' order by ngaynhap desc";        
            SqlCommand cmd = new SqlCommand(query,cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SachBO sachBO = new SachBO();
             //   sachBO.MaSach=dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban =Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban =Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia =Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve =Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan =dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                string masach = TimDSSach(sachBO.Madausach).Index(0).MaSach;
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(masach);// tất cả các tác giả
                sachColl.Add(sachBO);
            }
            cnn.Close();
            return sachColl;
        }
        public SachCollection TimDSSach(int madausach)
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT MaSach, MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query += " FROM Sach WHERE";
            query += " trangthai=1 AND madausach = @madausach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madausach", madausach);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SachBO sachBO = new SachBO();
                sachBO.MaSach=dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan = dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(sachBO.MaSach);// tất cả các tác giả
                sachColl.Add(sachBO);
            }
            cnn.Close();
            return sachColl;
        }
        public void ThemSach(SachBO sachBO, int soluong)
        {
            //Thêm sách
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "";
            int madausach = TaoMaDauSach();
            for (int i = 0; i < soluong; i++)
            {
                query = "insert into Sach(MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,HinhAnh,NgayNhap,TrangThai,Madausach)";
                query += " values(@MaNXB,@TenSach,@NamXuatBan,@LanXuatBan,@TriGia,@HinhAnh,@NgayNhap,1,@madausach) ";
                SqlCommand cmd = new SqlCommand(query, cnn);
                if (sachBO.MaNXB != "")
                    cmd.Parameters.AddWithValue("@MaNXB", sachBO.MaNXB);
                else
                    cmd.Parameters.AddWithValue("@MaNXB", DBNull.Value);
                cmd.Parameters.AddWithValue("@TenSach", sachBO.TenSach);
                cmd.Parameters.AddWithValue("@NamXuatBan", sachBO.namxuatban);
                cmd.Parameters.AddWithValue("@LanXuatBan", sachBO.lanxuatban);
                cmd.Parameters.AddWithValue("@TriGia", sachBO.trigia);
                cmd.Parameters.AddWithValue("@HinhAnh", sachBO.hinhanh);
                cmd.Parameters.AddWithValue("@NgayNhap",sachBO.ngaynhap);
                cmd.Parameters.AddWithValue("@madausach", madausach);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            //thêm ds tác giả của sách
            SachCollection sachColl = new SachCollection();
            sachColl=TimDSSach(madausach);
            query = "INSERT into Sach_TacGia(masach,matg) VALUES(@masach,@matg)";
            for (int i = 0; i < sachColl.Count; i++)
            {
                for (int j = 0; j < sachBO.tacgiaColl.Count; j++)
                {
                    SqlCommand cmdTG = new SqlCommand(query, cnn);
                 
                    cmdTG.Parameters.AddWithValue("@masach", sachColl.Index(i).MaSach);
                    cmdTG.Parameters.AddWithValue("@matg", sachBO.tacgiaColl.Index(j).MaTG);
                    cnn.Open();
                    cmdTG.ExecuteNonQuery();
                    cnn.Close();
                }
            }

        }    
        public void XoaSach(int madausach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "DELETE FROM Sach_TacGia WHERE masach IN(SELECT masach FROM Sach where madausach=@madausachdel)";
            query += " DELETE from Sach WHERE madausach=@madausach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madausachdel", madausach);
            cmd.Parameters.AddWithValue("@madausach", madausach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaSach(SachBO sachBO, bool hasimage)
        {
            //cập nhật lại sách
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "";
            query = "Update Sach Set MaNXB=@MaNXB,TenSach=@TenSach,NamXuatBan=@NamXuatBan";
            query += ",LanXuatBan=@LanXuatBan,TriGia=@TriGia,NgayNhap=@NgayNhap";
            if (hasimage == true)
                query += ",hinhanh=@HinhAnh";
            query += " WHERE Madausach=@madausach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if(sachBO.MaNXB!="")
                cmd.Parameters.AddWithValue("@MaNXB", sachBO.MaNXB);
            else
                cmd.Parameters.AddWithValue("@MaNXB", DBNull.Value);
            cmd.Parameters.AddWithValue("@TenSach", sachBO.TenSach);
            cmd.Parameters.AddWithValue("@NamXuatBan", sachBO.namxuatban);
            cmd.Parameters.AddWithValue("@LanXuatBan", sachBO.lanxuatban);
            cmd.Parameters.AddWithValue("@TriGia", sachBO.trigia);
            if(hasimage==true)
                cmd.Parameters.AddWithValue("@HinhAnh", sachBO.hinhanh);
            cmd.Parameters.AddWithValue("@NgayNhap", sachBO.ngaynhap);
            cmd.Parameters.AddWithValue("@madausach",sachBO.Madausach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            //cập nhật lại ds tác giả của sách
            //dell all
            query = "DELETE FROM Sach_TacGia WHERE masach in (SELECT masach FROM sach WHERE madausach=@masachdel)";
            SqlCommand  cmdDel = new SqlCommand(query, cnn);
            cmdDel.Parameters.AddWithValue("@masachdel", sachBO.Madausach);
            cnn.Open();
            cmdDel.ExecuteNonQuery();
            cnn.Close();
            //insert
            SachCollection sachColl = new SachCollection();
            sachColl = TimDSSach(sachBO.Madausach);
            for (int i = 0; i < sachColl.Count; i++)
            {
                query = " INSERT into Sach_TacGia(masach,matg) VALUES(@masach,@matg)";
                for (int j = 0; j < sachBO.tacgiaColl.Count; j++)
                {
                    SqlCommand cmdTG = new SqlCommand(query, cnn);
                    cmdTG.Parameters.AddWithValue("@masach", sachColl.Index(i).MaSach);
                    cmdTG.Parameters.AddWithValue("@matg", sachBO.tacgiaColl.Index(j).MaTG);
                    cnn.Open();
                    cmdTG.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }
        //PHÂN LỌAI
        public SachCollection TimDSSachPhanLoai(string tensach)
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT distinct MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query += " FROM Sach WHERE mactphanloai is null OR maloai is null OR khuvuc is null OR ke is null OR ngan is null";
            query += " AND trangthai=1 AND tensach like  N'%" + tensach + "%'  order by ngaynhap desc";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SachBO sachBO = new SachBO();
                //   sachBO.MaSach=dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan = dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                string masach = TimDSSach(sachBO.Madausach).Index(0).MaSach;
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(masach);// tất cả các tác giả
                sachColl.Add(sachBO);
            }
            cnn.Close();
            return sachColl;
        }
        public void PhanLoai(SachBO sachBO)
        {
            //cập nhật lại sách
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query ="Update Sach Set maloai=@maloai, mactphanloai=@mactphanloai";
            query += " ,khuvuc=@khuvuc, ke=@ke,ngan=@ngan, muondemve=@muondemve";
            query += " WHERE madausach=@madausach"; 
            SqlCommand cmd = new SqlCommand(query, cnn);
            if(sachBO.MaLoai!="")
                cmd.Parameters.AddWithValue("@maloai", sachBO.MaLoai);
            else
                cmd.Parameters.AddWithValue("@maloai", DBNull.Value);
            if(sachBO.MaCTPhanLoai!="")
                cmd.Parameters.AddWithValue("@mactphanloai", sachBO.MaCTPhanLoai);
            else
                cmd.Parameters.AddWithValue("@mactphanloai", DBNull.Value);
            if(sachBO.khuvuc!="")
                cmd.Parameters.AddWithValue("@khuvuc", sachBO.khuvuc);
            else
                cmd.Parameters.AddWithValue("@khuvuc", DBNull.Value);
            cmd.Parameters.AddWithValue("@ke", sachBO.ke);
            cmd.Parameters.AddWithValue("@ngan", sachBO.ngan);
            cmd.Parameters.AddWithValue("@muondemve", sachBO.muondemve);
            cmd.Parameters.AddWithValue("@madausach", sachBO.Madausach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //XỬ LÝ SÁCH
        public SachBO Tim1Sach(string masach)
        {
            SachBO sachBO = new SachBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT top 1 * from sach where masach=@masach AND trangthai=1";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach", masach);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sachBO.MaSach = dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan = dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(masach);// tất cả các tác giả
            }
            cnn.Close();
            return sachBO;
        }
        public SachBO Tim1Sach(int madausach)
        {

            SachBO sachBO = new SachBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT top 1 MaSach, MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query+=" FROM sach WHERE trangthai=1 AND madausach=@madausach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madausach", madausach);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sachBO.MaSach = dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan = dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(sachBO.MaSach);// tất cả các tác giả
            }
            cnn.Close();
            return sachBO;
        }
        public void ThemSach(int madausach)
        {
            SachBO sachBO = new SachBO();
            sachBO = Tim1Sach(madausach);
            //Thêm sách
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "";
            query = "insert into Sach(MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,HinhAnh,NgayNhap,TrangThai,Madausach)";
            query += " values(@MaNXB,@TenSach,@NamXuatBan,@LanXuatBan,@TriGia,@HinhAnh,Getdate(),1,@madausach) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@MaNXB", sachBO.MaNXB);
            cmd.Parameters.AddWithValue("@TenSach", sachBO.TenSach);
            cmd.Parameters.AddWithValue("@NamXuatBan", sachBO.namxuatban);
            cmd.Parameters.AddWithValue("@LanXuatBan", sachBO.lanxuatban);
            cmd.Parameters.AddWithValue("@TriGia", sachBO.trigia);
            cmd.Parameters.AddWithValue("@HinhAnh", sachBO.hinhanh);
            cmd.Parameters.AddWithValue("@madausach", madausach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            //thêm ds tác giả của sách
            SachCollection sachColl = new SachCollection();
            sachColl = TimDSSach(madausach);
            query =" IF @check not in (SELECT masach FROM Sach_TacGia)";
            query += " INSERT INTO Sach_TacGia(masach,matg) VALUES(@masach,@matg)";
            for (int i = 0; i < sachColl.Count; i++)
            {
                for (int j = 0; j < sachBO.tacgiaColl.Count; j++)
                {
                    SqlCommand cmdTG = new SqlCommand(query, cnn);
                    cmdTG.Parameters.AddWithValue("@check", sachColl.Index(i).MaSach);
                    cmdTG.Parameters.AddWithValue("@masach", sachColl.Index(i).MaSach);
                    cmdTG.Parameters.AddWithValue("@matg", sachBO.tacgiaColl.Index(j).MaTG);
                    cnn.Open();
                    cmdTG.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            
        }
        public void XoaSach(string masach)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query= "DELETE FROM Sach_TacGia WHERE masach=@masachdel";
            query+= " DELETE from Sach WHERE masach=@masach";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@masachdel", masach);
            cmd.Parameters.AddWithValue("@masach", masach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Xử lý tìm sáhc
        public SachCollection TimDSSachDocNhieu()
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT distinct Top 30 MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query += " FROM Sach WHERE";
            query += "  trangthai=1 AND masach in (select top 30 masach from ChiTietPhieuMuon_Tra group by masach order by COUNT(*) desc)";
          
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SachBO sachBO = new SachBO();
                //   sachBO.MaSach=dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan = dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                string masach = TimDSSach(sachBO.Madausach).Index(0).MaSach;
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(masach);// tất cả các tác giả
                sachColl.Add(sachBO);
            }
            cnn.Close();
            return sachColl;
        }
        public SachCollection TimSach(string tensach,string maloaisach,string maphanloai,string mactphanloai)
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT distinct MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query += " FROM Sach WHERE";
            query += " tensach like N'%"+tensach+"%'";
            if (maloaisach != "")
                query += " AND maloai=@maloaisach";
            if(mactphanloai!="")
                query += " AND mactphanloai=@mactphanloai";
            if (maphanloai != "")
                query += " AND MaCTphanloai in (SELECT maCTphanloai FrOM chitietphanloai WHERE maphanloai=@maphanloai)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (maloaisach != "")
                cmd.Parameters.AddWithValue("@maloaisach", maloaisach );
            if (mactphanloai != "")
                cmd.Parameters.AddWithValue("@mactphanloai",mactphanloai);
            if(maphanloai!="")
                cmd.Parameters.AddWithValue("@maphanloai", maphanloai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SachBO sachBO = new SachBO();
                //   sachBO.MaSach=dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan = dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                string masach = TimDSSach(sachBO.Madausach).Index(0).MaSach;
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(masach);// tất cả các tác giả
                sachColl.Add(sachBO);
            }
            cnn.Close();
            return sachColl;
        }
        //xử lý sách mất
        public SachCollection TimSachChuaTra(string thongtintim, int cachtim)
        {
            SachCollection sachColl = new SachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT masach,MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
            query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
            query+=" FROM Sach WHERE";
            if(cachtim==0)
                query += " trangthai=1 AND tensach like N'%"+thongtintim+"%' ";    
            else
                query += " trangthai=1 AND masach='"+thongtintim+"'";  
            query+= " AND masach in (SELECT masach FROM chitietphieumuon_tra)";
            query += " order by ngaynhap desc";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SachBO sachBO = new SachBO();
                sachBO.MaSach=dr["masach"].ToString();
                sachBO.MaNXB = dr["manxb"].ToString();
                sachBO.MaLoai = dr["maloai"].ToString();
                sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                sachBO.TenSach = dr["tensach"].ToString();
                sachBO.namxuatban =Convert.ToInt32(dr["namxuatban"].ToString());
                sachBO.lanxuatban =Convert.ToInt32(dr["lanxuatban"].ToString());
                sachBO.trigia =Convert.ToDecimal(dr["trigia"].ToString());
                sachBO.hinhanh = dr["hinhanh"].ToString();
                sachBO.muondemve =Convert.ToBoolean(dr["muondemve"].ToString());
                sachBO.ngaynhap = dr["ngaynhap"].ToString();
                sachBO.khuvuc = dr["khuvuc"].ToString();
                sachBO.ke = dr["ke"].ToString();
                sachBO.ngan =dr["ngan"].ToString();
                sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                sachBO.lydothanhly = dr["lydothanhly"].ToString();
                sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                string masach = TimDSSach(sachBO.Madausach).Index(0).MaSach;
                sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(masach);// tất cả các tác giả
                sachColl.Add(sachBO);
            }
            cnn.Close();
            return sachColl;        
        }
        public SachCollection TimSachDaMat(string thongtintim, int cachtim)
        {
            SachCollection sachColl = new SachCollection();
            if (cachtim == 0)
            {                
                SqlConnection cnn = new SqlConnection(cnnstr);
                string query = "SELECT masach,MaLoai,MaCTPhanLoai,MaNXB,TenSach,NamXuatBan,LanXuatBan,TriGia,TrangThai,MuonDemVe,HinhAnh,KhuVuc,Ke,Ngan";
                query += ",convert(nvarchar(10),NgayNhap,103) ngaynhap,MaPhieuThanhLy, cast(LydoThanhLy as nvarchar(max)) lydothanhly,Madausach";
                query += " FROM Sach WHERE";
                query += " trangthai=0 AND tensach like N'%" + thongtintim + "%' order by ngaynhap desc";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SachBO sachBO = new SachBO();
                    sachBO.MaSach=dr["masach"].ToString();
                    sachBO.MaNXB = dr["manxb"].ToString();
                    sachBO.MaLoai = dr["maloai"].ToString();
                    sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                    sachBO.TenSach = dr["tensach"].ToString();
                    sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                    sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                    sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                    sachBO.hinhanh = dr["hinhanh"].ToString();
                    sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                    sachBO.ngaynhap = dr["ngaynhap"].ToString();
                    sachBO.khuvuc = dr["khuvuc"].ToString();
                    sachBO.ke = dr["ke"].ToString();
                    sachBO.ngan = dr["ngan"].ToString();
                    sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                    sachBO.lydothanhly = dr["lydothanhly"].ToString();
                    sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                    sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(thongtintim);// tất cả các tác giả
                    sachColl.Add(sachBO);
                }
                cnn.Close();                
            }
            else
            {
                SachBO sachBO = new SachBO();
                SqlConnection cnn = new SqlConnection(cnnstr);
                string query = "SELECT top 1 convert(nvarchar(10),NgayNhap, * from sach where masach=@masach AND trangthai=0";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@masach", thongtintim);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sachBO.MaSach = dr["masach"].ToString();
                    sachBO.MaNXB = dr["manxb"].ToString();
                    sachBO.MaLoai = dr["maloai"].ToString();
                    sachBO.MaCTPhanLoai = dr["mactphanloai"].ToString();
                    sachBO.TenSach = dr["tensach"].ToString();
                    sachBO.namxuatban = Convert.ToInt32(dr["namxuatban"].ToString());
                    sachBO.lanxuatban = Convert.ToInt32(dr["lanxuatban"].ToString());
                    sachBO.trigia = Convert.ToDecimal(dr["trigia"].ToString());
                    sachBO.hinhanh = dr["hinhanh"].ToString();
                    sachBO.muondemve = Convert.ToBoolean(dr["muondemve"].ToString());
                    sachBO.ngaynhap = dr["ngaynhap"].ToString();
                    sachBO.khuvuc = dr["khuvuc"].ToString();
                    sachBO.ke = dr["ke"].ToString();
                    sachBO.ngan = dr["ngan"].ToString();
                    sachBO.maphieuthanhly = dr["maphieuthanhly"].ToString();
                    sachBO.lydothanhly = dr["lydothanhly"].ToString();
                    sachBO.Madausach = Convert.ToInt32(dr["madausach"].ToString());
                    sachBO.tacgiaColl = tgDAO.TimDSTacGia_Sach(thongtintim);// tất cả các tác giả
                }
                cnn.Close();
                sachColl.Add(sachBO);
            }
            return sachColl;
        }
        public void ThayDoiTrangThai(string masach,bool trangthai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE Sach Set trangthai=@trangthai WHERE masach=@masach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@trangthai", trangthai);
            cmd.Parameters.AddWithValue("@masach", masach);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
