using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using BO;
namespace DAO
{
    public class TacGiaDAO
    {
        string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public TacGiaCollection TimDSTacGia(string tentacgia)
        {
            TacGiaCollection tacgiaColl = new TacGiaCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM Tacgia WHERE tentg like @tentacgia AND tentg <> '' order by tentg";
            SqlCommand cmd = new SqlCommand(query,cnn);
            cmd.Parameters.AddWithValue("@tentacgia", "%" + tentacgia + "%");
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TacGiaBO tgBO = new TacGiaBO();
                tgBO.MaTG=dr["matg"].ToString();
                tgBO.TenTG=dr["tentg"].ToString();
                tacgiaColl.Add(tgBO);
            }
            cnn.Close();
            return tacgiaColl;
        }
        public void XoaTg(string matg)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "DELETE TacGia WHERE matg=@matg ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@matg", matg);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
        public void ThemTg(string tentg)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "insert into TacGia(tentg) values(@tentg) ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tentg", tentg);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public void SuaLoaiSach(TacGiaBO tacgiaBO)
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "update TacGia set tentg=@tentg where matg=@matg ";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@tentg", tacgiaBO.TenTG);
            cmd.Parameters.AddWithValue("@matg", tacgiaBO.MaTG);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public TacGiaCollection TimDSTacGia_Sach(string masach)
        {
            TacGiaCollection tacgiaColl = new TacGiaCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM TacGia,Sach_TacGia WHERE TacGia.MaTG=Sach_TacGia.MaTG AND masach like @masach AND tentg <> '' order by tentg";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@masach", "%" + masach + "%");
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TacGiaBO tgBO = new TacGiaBO();
                tgBO.MaTG = dr["matg"].ToString();
                tgBO.TenTG = dr["tentg"].ToString();
                tacgiaColl.Add(tgBO);
            }
            cnn.Close();
            return tacgiaColl;
        }
        
    }
}
