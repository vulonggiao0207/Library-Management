using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BO;
using System.Configuration;
namespace DAO
{
    public class ChucVuDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public ChucVuCollection TimDSChucVu(string tencv)
        {
            ChucVuCollection cvColl = new ChucVuCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from ChucVu where tencv <> '' ";
            query += "order by tencv";
            SqlCommand cmd = new SqlCommand(query, cnn);
            if (tencv != "")
            {
                query = "select * from ChucVu where tencv like @tencv and tencv <>''";
                query += "order by tencv";
                cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@tencv", "%" + tencv + "%");
            }
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ChucVuBO cvBO = new ChucVuBO();
                cvBO.MaCV = dr["macv"].ToString();
                cvBO.TenCV = dr["tencv"].ToString();
                cvColl.Add(cvBO);
            }
            cnn.Close();
            return cvColl;
        }
        public void XoaChucVu(string macv)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "delete ChucVu where macv=@macv ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@macv", macv);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ThemChucVu(string tencv)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into ChucVu(tencv) values(@tencv) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tencv", tencv);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaChucVu(ChucVuBO ChucVuBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update ChucVu set tencv=@tencv where macv=@macv ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tencv", ChucVuBO.TenCV);
            cmd.Parameters.AddWithValue("@macv", ChucVuBO.MaCV);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
       
        public ChucVuBO Tim1ChucVu(string macv)
        {
            ChucVuBO chucvuBO = new ChucVuBO();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select * from ChucVu where tencv <> '' and MaCV=@macv ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@macv", macv);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chucvuBO.MaCV = dr["macv"].ToString();
                chucvuBO.TenCV = dr["tencv"].ToString();
                break;
            }
            return chucvuBO;
        }
    }

}
