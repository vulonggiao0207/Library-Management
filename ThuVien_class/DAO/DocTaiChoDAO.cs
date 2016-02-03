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
    public class DocTaiChoDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //ĐỌC GIẢ VÀO RA THƯ VIỆN
        public string KiemTraDocGia(string madocgia)
        {
            string kt;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select madocgia from DocGia where madocgia=@madocgia ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            kt =cmd.ExecuteScalar().ToString();
            cnn.Close();
            return kt;
            
        }
        public int VaoRaThuVien (string manv, string madocgia)
        {
            SqlConnection sqlconn = new SqlConnection(cnnstr);                   
            SqlCommand cmd = new SqlCommand("sp_vaorathuvien1", sqlconn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pmanv = new SqlParameter("@manv", SqlDbType.UniqueIdentifier);
            pmanv.Value = new Guid(manv); 
            cmd.Parameters.Add(pmanv);
            SqlParameter pmadocgia = new SqlParameter("@madocgia", SqlDbType.Char, 30);
            pmadocgia.Value = madocgia;
            cmd.Parameters.Add(pmadocgia);             
            sqlconn.Open();
            int n= cmd.ExecuteNonQuery();          
            sqlconn.Close();
            return n;         
        }

        public string KtSachTra(string madocgia)
        {
            SqlConnection sqlconn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("sp_ktsachchuatra", sqlconn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pmadocgia = new SqlParameter("@madocgia", SqlDbType.Char, 30);
            pmadocgia.Value = madocgia;
            cmd.Parameters.Add(pmadocgia);
            sqlconn.Open();
            string kt = cmd.ExecuteScalar().ToString();
            sqlconn.Close();
            return kt;       
        }

        public DataTable DsDocGia()
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT docgia.madocgia, tendocgia, convert(nvarchar(20),thoigianvao,108) as thoigian from LuotVaoThuVien, docgia where docgia.madocgia=luotvaothuvien.madocgia and ThoiGianVao is not null and ThoiGianRa is null";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DSDocGia");
            return dset.Tables["DSDocGia"];
        } 

        // ĐỌC GIẢ MƯỢN SÁCH
        public DataTable DsSachMuon(string madocgia)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select Sach.MaSach,hinhanh, TenSach, Namxuatban from sach, LuotVaoThuVien, LuotDocSach where Sach.MaSach=LuotDocSach.MaSach and LuotDocSach.MaLuot=LuotVaoThuVien.MaLuot and MaDocGia=@madocgia and TraSach=0";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlParameter pmadocgia = new SqlParameter("@madocgia", SqlDbType.Char, 30);
            pmadocgia.Value = madocgia;
            cmd.Parameters.Add(pmadocgia);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dset = new DataSet();
            da.Fill(dset, "DsSachMuon");
            return dset.Tables["DsSachMuon"];
        }

        public string KiemTraDocGiaTrongThuVien(string madocgia)
        {
            string kt;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select madocgia from luotvaothuvien where madocgia=@madocgia and ThoiGianVao is not null and ThoiGianRa is null  ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            kt = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return kt;
        }

        public string KiemTraSachTrung(string masach)
        {
            string kt;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select masach from luotvaothuvien where masach=@masach ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach",new Guid(masach));
            cnn.Open();
            kt = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return kt;
        }

        public int MuonSach(string masach, string madocgia)
        {
            SqlConnection sqlconn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("sp_muonsach", sqlconn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pmasach = new SqlParameter("@masach", SqlDbType.UniqueIdentifier);
            pmasach.Value = new Guid(masach);
            cmd.Parameters.Add(pmasach);
            SqlParameter pmadocgia = new SqlParameter("@madocgia", SqlDbType.Char, 30);
            pmadocgia.Value = madocgia;
            cmd.Parameters.Add(pmadocgia);
            sqlconn.Open();
            int n = cmd.ExecuteNonQuery();
            sqlconn.Close();
            return n;
        }

        public string KiemTraSoSachMuon(string madocgia)
        {
            string kt;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select COUNT(*) from sach, LuotVaoThuVien, LuotDocSach where Sach.MaSach=LuotDocSach.MaSach and LuotDocSach.MaLuot=LuotVaoThuVien.MaLuot and MaDocGia=@madocgia and TraSach=0";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@madocgia", madocgia);
            cnn.Open();
            kt = cmd.ExecuteScalar().ToString();
            cnn.Close();
            return kt;
        }
        /// trả sach
        public int TraSach(string masach)
        {
            int kt;
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update Luotdocsach set trasach=1 where masach=@masach";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlParameter pmasach = new SqlParameter("@masach", SqlDbType.UniqueIdentifier);
            pmasach.Value = new Guid(masach);
            cmd.Parameters.Add(pmasach);
            cnn.Open();
            kt = cmd.ExecuteNonQuery();
            cnn.Close();
            return kt;
        }
        ////////////////////////////////////////////
        public string Tim1DocGia_Luot(string maluot)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT madocgia FROM Luotvaothuvien WHERE maluot=@maluot";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maluot", maluot);
            cnn.Open();
            object madocgia = cmd.ExecuteScalar();
            cnn.Close();
            if (madocgia != null)
                return madocgia.ToString();
            return string.Empty;
        }
    }
}
