using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using BUS;
using BO;

public partial class admin_muonsach : System.Web.UI.Page
{
    DocTaiChoBUS doctaichoBUS = new DocTaiChoBUS();
    DocTaiChoDAO doctaichoDAO = new DocTaiChoDAO();
    DocGiaBUS docgiaBUS = new DocGiaBUS();
    DocGiaBO docgiaBO = new DocGiaBO();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["manv"] == null || Session["tennv"] == null)
        {
            Response.Redirect("dangnhap.aspx");
        }
        //nạp dữ liệu
        if (!IsPostBack)
        {
            TenNVlabel.Text = Session["tennv"].ToString();
        }
    }
    void GridBinding(string madocgia)
    {
        DSMuonSachGridView.DataSource = doctaichoDAO.DsSachMuon(madocgia);
        DSMuonSachGridView.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MaDGLabel.Text = MaDocGiaTextBox.Text;
        GridBinding(MaDGLabel.Text);
        MaDocGiaTextBox.Text = "";
        ThongBaoLabel.Text = "";
        
    }
    protected void MuonButton_Click(object sender, EventArgs e)
    {
        string masach = MaSachTextBox.Text;
        string madocgia = MaDGLabel.Text;

        string Ktdg = doctaichoBUS.KiemTraDocGiaTrongThuVien(madocgia);
        if (Ktdg.Trim() == madocgia.Trim() )
        {
            string solanmuon = doctaichoBUS.KiemTraSoSachMuon(madocgia);
            int dem=Convert.ToInt16(solanmuon);
            if (dem <3)
            {
                string ktsachtrung = doctaichoBUS.KiemTraSachTrung(masach);
                if (ktsachtrung.Trim() == masach.Trim())
                {
                    ThongBaoLabel.Text = "Sach này đã được mượn";
                }
                else
                {
                    bool kq = doctaichoBUS.Muonsach(masach, madocgia);
                    if (kq == true)
                    {
                        ThongBaoLabel.Text = "Bạn mượn được sách";
                    }
                    else
                    {
                        ThongBaoLabel.Text = "";
                    }
                }
            }
            else
            {
                ThongBaoLabel.Text = "Hiện tại bạn đang mượn 3 quyển sách";
                
            }
        }
        else
            ThongBaoLabel.Text = "Hiện Không có đọc giả này thư viện";

        GridBinding(MaDGLabel.Text);
        MaSachTextBox.Text = "";
        MaSachTextBox.Focus();
    }
}