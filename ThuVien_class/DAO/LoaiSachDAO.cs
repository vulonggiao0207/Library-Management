using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Configuration;
using System.Data.SqlClient;

namespace DAO
{
    public class LoaiSachDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public LoaiSachCollection TimDSLoaiSach(string tenloai)
        {

            LoaiSachCollection loaicoll = new LoaiSachCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from LoaiSach where tenloai <> '' ";
            query += "order by tenloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tenloai != "")
            {
                query = "select * from LoaiSach where tenloai like @tenloai and tenloai <>''";
                query += "order by tenloai";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tenloai", "%" + tenloai + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LoaiSachBO loaiBO = new LoaiSachBO();
                loaiBO.MaLoai = dr["maloai"].ToString();
                loaiBO.TenLoai = dr["tenloai"].ToString();
                loaicoll.Add(loaiBO);
            }
            cnn.Close();
            return loaicoll;
        }
        public void XoaLoaiSach(string maloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update LoaiSach set tenloai='' where maloai=@maloai ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maloai", maloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ThemLoaiSach(string tenloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into LoaiSach(tenloai) values(@tenloai) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenloai", tenloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaLoaiSach(LoaiSachBO loaisachBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update LoaiSach set tenloai=@tenloai where maloai=@maloai ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenloai", loaisachBO.TenLoai);
            cmd.Parameters.AddWithValue("@maloai", loaisachBO.MaLoai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public LoaiSachBO Tim1LoaiSach(string maloai)
        {
            LoaiSachBO nxbBO = new LoaiSachBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from LoaiSach where tenloai <> '' ";
            query += " AND maloai=@maloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maloai", maloai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nxbBO.MaLoai = dr["maloai"].ToString();
                nxbBO.TenLoai = dr["tenloai"].ToString();
                break;
            }
            cnn.Close();
            return nxbBO;
        }

    }
}
