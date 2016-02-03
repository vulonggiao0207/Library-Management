using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using BO;
public partial class admin_phanquyen : System.Web.UI.Page
{
    NhanVienBUS nhanvienBUS = new NhanVienBUS();
    QuyenBUS quyenBUS = new QuyenBUS();
    ChucVuBUS chucvuBUS = new ChucVuBUS();
    public void NapDuLieu()
    {
        string tennv = TimTextbox.Text;
        NhanVienGridView.DataSource = nhanvienBUS.TimDSNhanVien(tennv);
        NhanVienGridView.DataBind();
    } //Nạp danh sách nhân viên lên Gridview
    public void NapDSQuyen()
    {
        QuyenCollection quyenColl = new QuyenCollection();
        quyenColl = quyenBUS.TimDSQuyen();
        for (int i = 0; i < 6; i++)
        {
            CheckBoxList cblist = new CheckBoxList();
            cblist = QuyenTab.Tabs[i].FindControl("CheckBoxList"+(i+1).ToString()) as CheckBoxList;
            if (quyenColl.Index(i).ChiTietQuyen == null) 
                break;
            cblist.DataSource = quyenColl.Index(i).ChiTietQuyen;
            cblist.DataTextField = "TenCTQuyen";
            cblist.DataValueField = "MaCTQuyen";
            cblist.DataBind();
        }  
    }// nạp danh sách quyền cho TabControl
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["manv"] == null || Session["tennv"] == null)
            Response.Redirect("dangnhap.aspx");
        //nạp dữ liệu
        if (!IsPostBack)
        {
            NapDuLieu();
            NapDSQuyen();
        }
    }
    protected void NhanVienGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["manv"] = e.CommandArgument.ToString();
        NapDuLieu();
        NapDSQuyen();
        PhanQuyenPopup.Show();
        if (e.CommandName == "phanquyen") 
        {
            //Lấy quyền của nhân viên
            QuyenCollection quyenColl = new QuyenCollection();
            quyenColl = quyenBUS.TimDSQuyen_NhanVien(e.CommandArgument.ToString());
            if (quyenColl.Count == 0) return;//nếu nhân viên không có bất cứ quyền nào
            //Vòng lặp để Nạp những quyền hiện tại mà nhân viên đó có:
            for (int i = 0; i < QuyenTab.Tabs.Count; i++)//duyệt qua từng tab
            {
                //Lấy ra CheckboxList trong Tab đó
                CheckBoxList quyenList = QuyenTab.Tabs[i].FindControl("CheckBoxList" + (i + 1).ToString()) as CheckBoxList;
                if (quyenList.Items.Count == 0) break;//nếu CheckListBox không có Item nào ==> bỏ qua
                //Duyệt qua từng Item của CheckBoxList
                for (int j = 0; j < quyenList.Items.Count; j++)
                {
                    foreach (QuyenBO quyenbo in quyenColl)
                    {
                        for (int k = 0; k < quyenbo.ChiTietQuyen.Count; k++)
                        {
                            //Nếu giống nhau ==> check Item đó
                            if (quyenList.Items[j].Value == quyenbo.ChiTietQuyen.Index(k).MaCTQuyen)
                            {
                                quyenList.Items[j].Selected = true;
                                break;
                            }
                        }
                    }
                    
                }
            }
           
        }
      
    }
    protected void NhanVienGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //hiển thị chức vụ
            Label chucvu;
            chucvu = (Label)e.Row.FindControl("ChucVuLabel");
            chucvu.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "macv") != null)
            {
                chucvu.Text = (string)DataBinder.Eval(e.Row.DataItem, "macv");
                string tencv = chucvuBUS.Tim1ChucVu(chucvu.Text).TenCV;
                chucvu.Text = tencv;
            }
            //hiển thị giới tính
            Label gioitinh;
            gioitinh = (Label)e.Row.FindControl("GioiTinhLabel");
            gioitinh.DataBind();
            if (DataBinder.Eval(e.Row.DataItem, "gioitinh") != null)
            {
                gioitinh.Text = DataBinder.Eval(e.Row.DataItem, "gioitinh").ToString();
                string gioitinhtxt = "Nam";
                if (gioitinh.Text == "False")
                    gioitinhtxt = "Nữ";
                gioitinh.Text = gioitinhtxt;
            }
        }
    }
    protected void TimButton_Click(object sender, ImageClickEventArgs e)
    {
        NapDuLieu();
    }
    protected void LuuButton_Click(object sender, EventArgs e)
    {
  /*      NapDuLieu();
        NapDSQuyen();*/
        CTQuyenCollection ctQuyenColl = new CTQuyenCollection();
        //Vòng lặp để lấy những quyền hiện tại mà nhân viên vừa đựơc chỉnh sửa:
        for (int i = 0; i < QuyenTab.Tabs.Count; i++)//duyệt qua từng tab
        {
            //Lấy ra CheckboxList trong Tab đó
            CheckBoxList quyenList = QuyenTab.Tabs[i].FindControl("CheckBoxList" + (i + 1).ToString()) as CheckBoxList;
            //Duyệt qua từng Item của CheckBoxList
            for (int j = 0; j < quyenList.Items.Count; j++)
            {
              //Nếu quyền đựơc check ==>thêm vào ds các quyên (cho câu INSERT)
                if (quyenList.Items[j].Selected == true)
                {
                    CTQuyen ctQuyen= new CTQuyen();
                    ctQuyen.MaCTQuyen=quyenList.Items[j].Value;
                    ctQuyen.TenCTQuyen = "";
                    ctQuyen.LienKet = "";
                    ctQuyenColl.Add(ctQuyen);                    
                }               
            }
        }
        //tiến hành cập nhật quyền
        quyenBUS.CapNhatQuyen_NhanVien(ViewState["manv"].ToString(),ctQuyenColl);
    }
}