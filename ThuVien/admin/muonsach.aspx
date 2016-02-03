<%@ Page Language="C#" AutoEventWireup="true" CodeFile="muonsach.aspx.cs" Inherits="admin_muonsach" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
    <style type="text/css">
        .PopupBackground
        {
            background-color:#333333;
            filter:alpha(opacity=70);
            opacity:0.5;    
            overflow:scroll;    
        }        
    </style>
</head>
<body>
<form id="mainform" runat="server">
<div id="Wrapper">
	<div id="Header">
		<div id="Banner">
		<div id="name">Thư Viện Huflit</div>
		<div id="name2">Đại Học Ngọai Ngữ - Tin Học Thành Phố Hồ Chí Minh</div>
		</div>
		<div id="Navigator">	
            <uc3:admin_navigatorUC ID="admin_navigatorUC1" runat="server" />
   </div>
	</div>
   
	<div id="Content">
     <div id="Sidebar">	
        <div class="box">
            <uc1:PhanQuyenUC ID="PhanQuyenUC1" runat="server" />       
		</div>               
    </div>
		<div id="container_head">Lập phiếu mượn sách</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel runat="server" ID="udp1">
          <ContentTemplate>
           <table style="width:500px;margin-left:100px" bgcolor="#E8F2FF">
              <tr>
                  <td colspan="2" bgcolor="#999999" >
                      <asp:Label ID="Label34" runat="server" Font-Bold="True" ForeColor="White" 
                          Height="23px" Text="Thông tin sách muốn mượn"></asp:Label>
                  </td>
              </tr>
               <tr>
                   <td colspan="2">
                       <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="25px" 
                           Style="margin:5px 0 0 5px" Text="Mã độc giả: "></asp:Label>
                       <asp:TextBox ID="MadocgiaTextBox" runat="server" Width="200px"></asp:TextBox>
                       <asp:Button ID="KiemtradocgiaButton" runat="server" Height="25px" 
                           onclick="KiemtradocgiaButton_Click" Text="Kiểm tra" />
                   </td>
               </tr>
              <tr>
                  <td rowspan="8" class="style1">
                      <asp:Image ID="HinhanhdocgiaImage" runat="server" Height="180px" 
                          Width="135px" Style="margin-left:5px;margin-right:5px"/>
                  </td>
                  <td>
                      <asp:Label ID="Label25" runat="server" Text="Mã độc giả: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="MaDocGiaLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Tên độc giả:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="TenDocGiaLabel" runat="server" Height="25px" Width="260px" 
                          Font-Size="14pt" ForeColor="Blue"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label4" runat="server" Text="Lọai độc giả:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="LoaiDocgiaLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label3" runat="server" Text="Giới tính:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="GioiTinhLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label6" runat="server" Text="Ngày sinh:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="NgaysinhLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label5" runat="server" Text="Địa chỉ:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="DiaChiLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label7" runat="server" Text="Ngày lập thẻ:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="NgayLapTheLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label8" runat="server" Text="Ngày hết hạn:" Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="NgayHetHanLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
              <td colspan="2">
                  <asp:Label ID="ThongBaoDocGiaLabel" runat="server" ForeColor="Red" 
                      Style="text-align:center" Width="490px" Font-Size="12pt"></asp:Label>
                  </td>
              </tr>
              <%--     </table>
          <br />
          <table style="width:500px;margin-left:100px" bgcolor="#E9E9E9">--%>
              <tr style="height:3px">
              <td colspan="2" bgcolor="#999999">
                  <asp:Label ID="Label33" runat="server" Font-Bold="True" ForeColor="White" 
                      Height="23px" Text="Thông tin sách muốn mượn"></asp:Label>
              </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label23" runat="server" Text="Mã sách: " Font-Bold="True" 
                          Height="25px" Style="margin:5px 0 0 5px"></asp:Label>
                      <asp:TextBox ID="MasachTextBox" runat="server" Width="300px" 
                          ontextchanged="MasachTextBox_TextChanged"></asp:TextBox>
                      <asp:Button ID="KiemtrasachButton" runat="server" Text="Kiểm tra" 
                          Height="25px" onclick="KiemtrasachButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td rowspan="6">
                      <asp:Image ID="HinhAnhSachImage" runat="server" Height="180px" Width="135px"  Style="margin-left:5px;margin-right:5px"/>
                  </td>
                  <td>
                      <asp:Label ID="Label17" runat="server" Text="Tên sách: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="TenSachLabel" runat="server" Height="25px" Width="250px" 
                          Font-Bold="False" Font-Size="14pt" ForeColor="Blue"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label18" runat="server" Text="Nhà xuất bản: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="NhaxuatbanLabel" runat="server" Height="25px" Width="220px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label19" runat="server" Text="Lần xuất bản: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="LanxuatbanLabel" runat="server" Height="25px" Width="220px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label20" runat="server" Text="Năm xuất bản: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="NamXuatBanLabel" runat="server" Height="25px" Width="220px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label21" runat="server" Text="Tác giả: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <br />
                      <asp:ListBox ID="TacGiaListBox" runat="server" Height="80px" Width="250px" 
                          BackColor="#F0F0F0">
                      </asp:ListBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label22" runat="server" Text="Trị giá: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="TriGiaLabel" runat="server" Height="25px" Width="250px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                  <asp:Label ID="ThongbaoSachLabel" runat="server" ForeColor="Red" 
                          Style="text-align:center" Width="490px" Font-Size="12pt"></asp:Label>
                  </td>
              </tr>
              <%-- </table>
          <br />
          <table style="width:500px;margin-left:100px" bgcolor="#e9e9e9">--%>
               <tr style="height:3px">
                   <td colspan="2" bgcolor="#999999">
                       <asp:Label ID="Label35" runat="server" Font-Bold="True" ForeColor="White" 
                           Height="23px" Text="Thông tin lập phiếu mượn"></asp:Label>
                   </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label24" runat="server" Text="Thế chân: " Font-Bold="True"></asp:Label>
                      <asp:Label ID="MasachmuonLabel" runat="server" Width="300px" Font-Size="11pt"></asp:Label>
                      <asp:TextBox ID="TienthechanTextbox" runat="server" Width="60px"></asp:TextBox>
                      <asp:Button ID="LuuButton" runat="server" onclick="LuuButton_Click" 
                          Text="Thêm" Width="50px" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                  <asp:Label ID="ThongbaoPhieuMuonLabel" runat="server" ForeColor="Red" 
                          Style="text-align:center" Width="490px" Font-Size="12pt"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:GridView ID="ChiTietGridView" runat="server" AutoGenerateColumns="False" 
                          BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                          CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
                          onrowcommand="ChiTietGridView_RowCommand" Width="490px">
                          <Columns>
                              <asp:TemplateField HeaderText="Mã sách">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="SachLink" runat="server" Text='<%# Eval("MaSach") %>' 
                                          CommandArgument='<%# Eval("MaSach") %>' CommandName="xem"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Thế chân">
                                  <ItemTemplate>
                                      <asp:TextBox ID="ThechanTextBox" runat="server" Width="60px" 
                                          Text='<%# Eval("TienTheChan") %>'></asp:TextBox>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="XoaButton" runat="server" 
                                          CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' 
                                          CommandName="xoa" Height="25px" ImageUrl="~/images/delete.jpg" Width="25px" />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
                              </asp:TemplateField>
                          </Columns>
                          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                          <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                          <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F7F7F7" />
                          <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                          <SortedDescendingCellStyle BackColor="#E5E5E5" />
                          <SortedDescendingHeaderStyle BackColor="#242121" />
                      </asp:GridView>
                  </td>
              </tr>
              <tr>
                  <td width="90">
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td colspan="2">
                  <asp:Label ID="ThongbaoLapPhieuLabel" runat="server" ForeColor="Red" 
                          Style="text-align:center" Width="490px" Font-Size="12pt"></asp:Label>
                  </td>
              </tr>
          </table>
          <%--popup xem lại chi tiết sách--%>
          <asp:HiddenField ID="ChitietHid" runat="server" />
          <asp:ModalPopupExtender ID="SachPopup" runat="server"
              PopupControlID="SachPanel" TargetControlID="ChitietHid"
              BackgroundCssClass="PopupBackground" CancelControlID="DongButton"
              DropShadow="true">
          </asp:ModalPopupExtender>
          <%------%>
        <asp:Panel ID="SachPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Chi tiết sách</div>
                <div class="popup_content">
                   
                    <table class="style1">
                        <tr>
                            <td colspan="2">
                                <asp:Image ID="HinhAnhSachCTImage" runat="server" Height="180px" 
                                    Style="margin-left:5px;margin-right:5px" Width="135px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Mã sách: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="MaSachCTLabel" runat="server" Text="Label" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label27" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Tên sách: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TenSachCTLabel" runat="server" Text="Label" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label28" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Nhà xuất bản: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="NhaXuatBanCTLabel" runat="server" Text="Label" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label32" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Lần xuất bản: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LanXuatBanCTLabel" runat="server" Text="Label" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label29" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Năm xuất bản: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="NamXuatBanCTLabel" runat="server" Text="Label" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label30" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Tác giả: "></asp:Label>
                                <br />
                                <asp:ListBox ID="TacGiaCTListBox" runat="server" Height="80px" Width="250px">
                                </asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label31" runat="server" Font-Bold="True" Height="25px" 
                                    Text="Trị giá: "></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TriGiaCTLabel" runat="server" Text="Label" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="DongButton" runat="server" Text="Đóng" Style="margin-left:100px"/>
                            </td>
                        </tr>
                    </table>
                   
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
        </ContentTemplate>
          </asp:UpdatePanel>
             <table style="width:500px;margin-left:100px" bgcolor="#E8F2FF">
              <tr>
                  <td>
                      <asp:Button ID="LapPhieuButton" runat="server" Text="Lưu và in phiếu mượn" 
                          Style="margin-left:320px" Width="150px" onclick="LapPhieuButton_Click" />
                  </td>
              </tr>
          </table>
      </div>
		<div id="container_bottom"></div>
		</div> 
          <asp:Panel ID="BaoCaoPanel" runat="server" Visible="false">  
                <asp:Button ID="ThoatButton" runat="server" Text="X" Style="margin-left:705px" onclick="ThoatButton_Click" Visible="false" />
              <CR:CrystalReportViewer ID="InPhieuReport" runat="server" BestFitPage="False" ToolPanelView="None"/>
           </asp:Panel>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>