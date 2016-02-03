using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.Data.SqlClient;
using System.Configuration;
namespace DAO
{
    public class QuyenDAO
    {
        public string cnnstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public QuyenBO Tim1Quyen(string maquyen)
        {
            QuyenBO quyenBO = new QuyenBO();
            CTQuyenCollection ctquyenColl = new CTQuyenCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("select * from ChiTietQuyen a,Quyen b where a.MaQuyen=b.MaQuyen AND a.MaQuyen=@maquyen order by TenCTQuyen", cnn);
            cmd.Parameters.AddWithValue("@maquyen", maquyen);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //lấy thông tin của quyền
                quyenBO.MaQuyen = dr["MaQuyen"].ToString();
                quyenBO.TenQuyen = dr["TenQuyen"].ToString();
                //lấy chi tiết quyền
                CTQuyen ctquyen = new CTQuyen();
                ctquyen.MaCTQuyen = dr["MaCTQuyen"].ToString();
                ctquyen.TenCTQuyen = dr["TenCTQuyen"].ToString();
                ctquyen.LienKet = dr["LienKet"].ToString();
                ctquyenColl.Add(ctquyen);
            }
            //gán chi tiết phân lọai
            quyenBO.ChiTietQuyen = ctquyenColl;
            cnn.Close();
            return quyenBO;
        }
        public QuyenCollection TimDSQuyen()
        {
            QuyenCollection quyenColl = new QuyenCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "SELECT * FROM Quyen order by tenquyen";
            //    string query = "select distinct quyen.maquyen,tenquyen from Quyen,chitietquyen,nhanvien_quyen,nhanvien";
            //  query += " where Quyen.MaQuyen=ChiTietQuyen.MaQuyen and ChiTietQuyen.MaCTQuyen=NhanVien_Quyen.MaCTQuyen and Nhanvien_Quyen.MaNV=NhanVien.MaNV";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                QuyenBO quyenBO = new QuyenBO();
                string maquyen = dr["MaQuyen"].ToString();
                quyenBO = Tim1Quyen(maquyen);
                if (quyenBO.ChiTietQuyen.Count != 0)
                    quyenColl.Add(quyenBO);
            }
            cnn.Close();
            return quyenColl;
        }
        public QuyenBO Tim1Quyen_NhanVien(string maquyen, string manv)
        {
            QuyenBO quyenBO = new QuyenBO();
            CTQuyenCollection ctquyenColl = new CTQuyenCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            SqlCommand cmd = new SqlCommand("select * from ChiTietQuyen a,Quyen b, NhanVien_Quyen c where a.MaQuyen=b.MaQuyen AND c.MaCTQuyen=a.MaCTQuyen AND a.MaQuyen=@maquyen AND c.MaNV=@manv ", cnn);
            cmd.Parameters.AddWithValue("@maquyen", maquyen);
            cmd.Parameters.AddWithValue("@manv", manv);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //lấy thông tin của quyền
                quyenBO.MaQuyen = dr["MaQuyen"].ToString();
                quyenBO.TenQuyen = dr["TenQuyen"].ToString();
                //lấy chi tiết quyền
                CTQuyen ctquyen = new CTQuyen();
                ctquyen.MaCTQuyen = dr["MaCTQuyen"].ToString();
                ctquyen.TenCTQuyen = dr["TenCTQuyen"].ToString();
                ctquyen.LienKet = dr["LienKet"].ToString();
                ctquyenColl.Add(ctquyen);
            }
            //gán chi tiết phân lọai
            quyenBO.ChiTietQuyen = ctquyenColl;
            cnn.Close();
            return quyenBO;
        }
        public QuyenCollection TimDSQuyen_NhanVien(string manv)
        {
            QuyenCollection quyenColl = new QuyenCollection();
            SqlConnection cnn = new SqlConnection(cnnstr);
            string query = "select distinct quyen.maquyen,tenquyen from Quyen,chitietquyen,nhanvien_quyen,nhanvien";
            query += " where Quyen.MaQuyen=ChiTietQuyen.MaQuyen and ChiTietQuyen.MaCTQuyen=NhanVien_Quyen.MaCTQuyen and Nhanvien_Quyen.MaNV=NhanVien.MaNV";
            query += " and nhanvien.manv=@manv";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@manv", manv);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                QuyenBO quyenBO = new QuyenBO();
                string maquyen = dr["MaQuyen"].ToString();
                quyenBO = Tim1Quyen_NhanVien(maquyen, manv);
                if (quyenBO.ChiTietQuyen.Count != 0)
                    quyenColl.Add(quyenBO);
            }
            cnn.Close();
            return quyenColl;
        }
        public void CapNhatQuyen_NhanVien(string manv, CTQuyenCollection ctquyenColl)
        {
            if (ctquyenColl != null && ctquyenColl.Count != 0)
            {
                //xóa hết
                SqlConnection cnn = new SqlConnection(cnnstr);
                SqlCommand cmdXoa = new SqlCommand("DELETE from Nhanvien_Quyen where manv=@manv ", cnn);
                cmdXoa.Parameters.AddWithValue("@manv", manv);
                cnn.Open();
                cmdXoa.ExecuteNonQuery();
                cnn.Close();
                //thêm lại từ đầu
                for (int i = 0; i < ctquyenColl.Count; i++)
                {
                    SqlCommand cmdLuu = new SqlCommand("INSERT into Nhanvien_Quyen VALUES(@manv,@mactquyen)", cnn);
                    cmdLuu.Parameters.AddWithValue("@manv", manv);
                    cmdLuu.Parameters.AddWithValue("@mactquyen", ctquyenColl.Index(i).MaCTQuyen);
                    cnn.Open();
                    cmdLuu.ExecuteNonQuery();
                    cnn.Close();
                }
            }

        }

    }
}
