using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using BO;
namespace DAO
{
    public class NhaXuatBanDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public NhaXuatBanCollection TimDSNhaXuatBan(string tennxb)
        {
            NhaXuatBanCollection nxbColl = new NhaXuatBanCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from nhaxuatban where tennxb <> '' ";
            query += "order by tennxb";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tennxb != "")
            {
                query = "select * from nhaxuatban where tennxb like @tennxb and tennxb <>''";
                query += "order by tennxb";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tennxb", "%" + tennxb + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhaXuatBanBO nxbBO = new NhaXuatBanBO();
                nxbBO.MaNXB = dr["manxb"].ToString();
                nxbBO.TenNXB = dr["tennxb"].ToString();
                nxbColl.Add(nxbBO);
            }
            cnn.Close();
            return nxbColl;
        }
        public void XoaNXB(string manxb)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update nhaxuatban set tennxb='' where manxb=@manxb ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manxb", manxb);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ThemNXB(string tennxb)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into nhaxuatban(tennxb) values(@tennxb) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tennxb", tennxb);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaNXB(NhaXuatBanBO nhaxuatbanBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update nhaxuatban set tennxb=@tennxb where manxb=@manxb ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tennxb", nhaxuatbanBO.TenNXB);
            cmd.Parameters.AddWithValue("@manxb", nhaxuatbanBO.MaNXB);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public NhaXuatBanBO Tim1NXB(string manxb)
        {
            NhaXuatBanBO nxbBO = new NhaXuatBanBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from nhaxuatban where tennxb <> '' ";
            query += " AND manxb=@manxb order by tennxb";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manxb", manxb);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nxbBO.MaNXB = dr["manxb"].ToString();
                nxbBO.TenNXB = dr["tennxb"].ToString();
                break;
            }
            cnn.Close();
            return nxbBO;
        }
    }
}
