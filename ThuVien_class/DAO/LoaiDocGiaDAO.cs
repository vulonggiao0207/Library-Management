using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class LoaiDocGiaDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public LoaiDocGiaBO Tim1LoaiDocGia(string maloai)
        {
            LoaiDocGiaBO loaidocgiaBO = new LoaiDocGiaBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select top 1 * from LoaiDocGia WHERE maloai=@maloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maloai", maloai);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                loaidocgiaBO.MaLoai = dr["maloai"].ToString();
                loaidocgiaBO.TenLoai = dr["tenloai"].ToString();
            }
            cnn.Close();
            return loaidocgiaBO;
        }
        public LoaiDocGiaCollection TimDSLoaiDocGia(string tenloai)
        {
            LoaiDocGiaCollection loaiColl = new LoaiDocGiaCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from LoaiDocGia where tenloai <> '' ";
            query += "order by tenloai";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tenloai != "")
            {
                query = "select * from LoaiDocGia where tenloai like @tenloai and tenloai <>''";
                query += "order by tenloai";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tenloai", "%" + tenloai + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LoaiDocGiaBO loaiBO = new LoaiDocGiaBO();
                loaiBO.MaLoai = dr["maloai"].ToString();
                loaiBO.TenLoai = dr["tenloai"].ToString();
                loaiColl.Add(loaiBO);
            }
            cnn.Close();
            return loaiColl;
        }
        public void XoaLoaiDocGia(string maloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update LoaiDocGia set tenloai='' where maloai=@maloai ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@maloai", maloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ThemLoaiDocGia(string tenloai)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into LoaiDocGia(tenloai) values(@tenloai) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenloai", tenloai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaLoaiDocGia(LoaiDocGiaBO loaidocgiaBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update LoaiDocGia set tenloai=@tenloai where maloai=@maloai ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenloai", loaidocgiaBO.TenLoai);
            cmd.Parameters.AddWithValue("@maloai", loaidocgiaBO.MaLoai);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
