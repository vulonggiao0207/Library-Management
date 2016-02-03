using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BO;
namespace DAO
{
    public class PhanLoaiDAO
    {
        public string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public void ThemPhanLoai(string TenPhanLoai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into PhanLoai(tenphanloai) values(@tenphanloai) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenphanloai", TenPhanLoai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void XoaPhanLoai(string MaPhanLoai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update PhanLoai set tenphanloai='' where maphanloai=@maphanloai ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maphanloai", MaPhanLoai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaPhanLoai(PhanLoaiBO phanloaiBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update PhanLoai set tenphanloai=@TenPhanLoai where maphanloai=@MaPhanLoai ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@TenPhanLoai", phanloaiBO.TenPhanLoai);
            cmd.Parameters.AddWithValue("@MaPhanLoai", phanloaiBO.MaPhanLoai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public PhanLoaiBO Tim1PhanLoai(string MaPhanLoai)
        {
            PhanLoaiBO plBO = new PhanLoaiBO();
            CTPhanLoaiCollection ctPhanLoaiColl = new CTPhanLoaiCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("select * from chitietPhanLoai where MaPhanLoai=@maphanloai", cnn);
            cmd.Parameters.AddWithValue("@maphanloai", MaPhanLoai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //lấy thông tin của phân loại
                plBO.MaPhanLoai = dr["MaPhanLoai"].ToString();
                plBO.TenPhanLoai = dr["TenPhanLoai"].ToString();
                //lấy chi tiết phân lọai
                CTPhanLoai ctphanloai = new CTPhanLoai();
                ctphanloai.MaCTPhanLoai = dr["MaCTPhanLoai"].ToString();
                ctphanloai.TenCTPhanLoai=dr["TenCTPhanLoai"].ToString();
                ctPhanLoaiColl.Add(ctphanloai);
            }
            //gán chi tiết phân lọai
            plBO.chitietphanloaiColl = ctPhanLoaiColl;
            cnn.Close();
            return plBO;
        }
        public PhanLoaiCollection TimDSPhanLoai()
        {
            PhanLoaiCollection plColl = new PhanLoaiCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("select * from PhanLoai order by TenPhanLoai", cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PhanLoaiBO plBO = new PhanLoaiBO();
                plBO.MaPhanLoai = dr["MaPhanLoai"].ToString();
                plBO.TenPhanLoai=dr["TenPhanLoai"].ToString();
                plColl.Add(plBO);
              //  string mapl = dr["maphanloai"].ToString();
              //  plColl.Add(Tim1PhanLoai(mapl));
            }
            cnn.Close();
            return plColl;
        }
        public PhanLoaiCollection TimDSCapNhatPhanLoai(string tenphanloai)
        {
            PhanLoaiCollection phanloaicoll = new PhanLoaiCollection();
            
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from PhanLoai where tenphanloai <> '' ";
            query += "order by tenphanloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tenphanloai != "")
            {
                query = "select * from PhanLoai where tenphanloai like @tenphanloai and tenphanloai <>''";
                query += "order by tenphanloai";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tenphanloai", "%" + tenphanloai + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PhanLoaiBO phanloaiBO = new PhanLoaiBO();
                phanloaiBO.MaPhanLoai = dr["maphanloai"].ToString();
                phanloaiBO.TenPhanLoai = dr["tenphanloai"].ToString();
                phanloaicoll.Add(phanloaiBO);
                
            }
            cnn.Close();
            return phanloaicoll;
        }
        public PhanLoaiBO Tim1PhanLoai_CT(string mactphanloai)
        {
            PhanLoaiBO phanloaiBO = new PhanLoaiBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT phanloai.maphanloai maphanloai,tenphanloai FROM phanloai,chitietphanloai where phanloai.maphanloai =chitietphanloai.maphanloai AND mactphanloai=@mactphanloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@mactphanloai", mactphanloai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                phanloaiBO.MaPhanLoai = dr["maphanloai"].ToString();
                phanloaiBO.TenPhanLoai = dr["tenphanloai"].ToString();
                break;
            }
            cnn.Close();
            return phanloaiBO;
        }
        ////////////////////////////////////////
        public CTPhanLoaiCollection TimDSCTPhanLoai(string maphanloai)
        {
            CTPhanLoaiCollection ctphanloaiColl= new CTPhanLoaiCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM chitietphanloai where maphanloai=@maphanloai order by tenctphanloai";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@maphanloai",maphanloai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CTPhanLoai ctphanloai = new CTPhanLoai();
                ctphanloai.MaCTPhanLoai = dr["mactphanloai"].ToString();
                ctphanloai.TenCTPhanLoai=dr["tenctphanloai"].ToString();
                ctphanloaiColl.Add(ctphanloai);
            }
            cnn.Close();
            return ctphanloaiColl; 
        }
        public void ThemCTPhanLoai(string maphanloai,string tenctphanloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "INSERT into ChiTietPhanLoai(maphanloai,tenctphanloai) VALUES(@maphanloai,@tenctphanloai)";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maphanloai",maphanloai);
            cmd.Parameters.AddWithValue("@tenctphanloai",tenctphanloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void XoaCTPhanLoai(string mactphanloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "DELETE FROM chitietphanloai WHERE mactphanloai=@mactphanloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@mactphanloai", mactphanloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaCTPhanLoai(string mactphanloai, string tenctphanloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "UPDATE chitietphanloai set tenctphanloai=@tenctphanloai WHERE mactphanloai=@mactphanloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@mactphanloai", mactphanloai);
            cmd.Parameters.AddWithValue("@tenctphanloai", tenctphanloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public CTPhanLoai Tim1CTPhanLoai(string mactphanloai)
        {
            CTPhanLoai ctphanloai = new CTPhanLoai();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM chitietphanloai where mactphanloai=@mactphanloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@mactphanloai", mactphanloai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ctphanloai.MaCTPhanLoai=dr["mactphanloai"].ToString();
                ctphanloai.TenCTPhanLoai=dr["tenctphanloai"].ToString();
                break;
            }
            cnn.Close();
            return ctphanloai;
        }

    }
}
