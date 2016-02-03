using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAO;
using System.Configuration;
using System.Data.SqlClient;

namespace DAO
{
    public class KhuVucDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public KhuVucCollection TimDSKhuVuc(string tenkhuvuc)
        {
            KhuVucCollection khuvuccoll = new KhuVucCollection();

            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from KhuVuc where tenkhuvuc <> '' ";
            query += "order by tenkhuvuc";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tenkhuvuc != "")
            {
                query = "select * from KhuVuc where tenkhuvuc like @tenkhuvuc and tenkhuvuc <>''";
                query += "order by tenkhuvuc";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tenkhuvuc", "%" + tenkhuvuc + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KhuVucBO khuvucBO = new KhuVucBO();
                khuvucBO.MaKhuVuc = dr["MaKhuVuc"].ToString();
                khuvucBO.TenKhuVuc = dr["TenKhuVuc"].ToString();
                khuvuccoll.Add(khuvucBO);
                
            }
            cnn.Close();
            return khuvuccoll;
        }
        public void XoaKhuVuc(string makhuvuc)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update KhuVuc set tenkhuvuc='' where makhuvuc=@makhuvuc ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@makhuvuc", makhuvuc);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ThemKhuVuc(string tenkhuvuc)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into KhuVuc(tenkhuvuc) values(@tenkhuvuc) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenkhuvuc", tenkhuvuc);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaKhuVuc(KhuVucBO khuvucBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update KhuVuc set tenkhuvuc=@tenkhuvuc where makhuvuc=@makhuvuc ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tenkhuvuc", khuvucBO.TenKhuVuc);
            cmd.Parameters.AddWithValue("@makhuvuc", khuvucBO.MaKhuVuc);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public KhuVucBO Tim1KhuVuc(string makhuvuc)
        {
            KhuVucBO nxbBO = new KhuVucBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from KhuVuc where tenkhuvuc <> '' ";
            query += " AND makhuvuc=@makhuvuc";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@makhuvuc", makhuvuc);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nxbBO.MaKhuVuc = dr["makhuvuc"].ToString();
                nxbBO.TenKhuVuc = dr["tenkhuvuc"].ToString();
                break;
            }
            cnn.Close();
            return nxbBO;
        }


    }
}
