<%@ Page Language="C#" AutoEventWireup="true" CodeFile="giahan.aspx.cs" Inherits="admin_giahan" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
		<div id="container_head"></div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          </ContentTemplate>
          </asp:UpdatePanel>
          <table>
              <tr>
                  <td>
                      <asp:Label ID="Label1" runat="server" Text="Tìm theo: "></asp:Label>
                      <asp:DropDownList ID="TimDropdown" runat="server" Width="100px">
                          <asp:ListItem Value="0">Mã sách</asp:ListItem>
                          <asp:ListItem Value="1">Mã độc giả</asp:ListItem>
                      </asp:DropDownList>
                      <asp:TextBox ID="TimTextBox" runat="server" Width="400px"></asp:TextBox>
                      <asp:ImageButton ID="TimButton" runat="server" Height="25px" 
                          ImageUrl="~/images/search_tool.jpg" Width="25px" 
                          onclick="TimButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="ThongbaoLabel" runat="server" ForeColor="Red" 
                          Width="680px" Style="text-align:center"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:GridView ID="SachGridview" runat="server" Width="690px" 
                          AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                          BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                          GridLines="Horizontal" ShowHeader="False" 
                          onrowcreated="SachGridview_RowCreated" 
                          onrowcommand="SachGridview_RowCommand">
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <table width="690">
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label2" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Độc giả: "></asp:Label>
                                                  <asp:Label ID="DocGiaLabel" runat="server" Font-Size="14pt" ForeColor="Blue" 
                                                      Height="25px" Width="250px"></asp:Label>
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label3" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Mã độc giả:"></asp:Label>
                                                  <asp:Label ID="MaDocGiaLabel" runat="server" Height="25px" Width="100px"></asp:Label>
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="Label6" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Mượn sách: "></asp:Label>
                                                  <asp:Label ID="TenSachLabel" runat="server" Font-Size="14pt" ForeColor="Blue" 
                                                      Height="25px" Width="400px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label7" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Mã sách: "></asp:Label>
                                                  <asp:Label ID="MaSachLabel" runat="server" Height="25px" Width="350px" 
                                                      Text='<%# Eval("masach") %>'></asp:Label>
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label8" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Ngày mượn: "></asp:Label>
                                                  <asp:Label ID="NgayMuonLabel" runat="server" Height="25px" Width="100px"></asp:Label>
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label9" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Ngày hết hạn:"></asp:Label>
                                                  <asp:Label ID="NgayHetHanLabel" runat="server" Height="25px" Width="100px"></asp:Label>
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label23" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Gia hạn: "></asp:Label>
                                                  <asp:Label ID="GiaHanLabel" runat="server" Height="25px" Width="100px"></asp:Label>
                                               
                                                  <asp:Button ID="GiaHanButton" runat="server" 
                                                      CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' 
                                                      CommandName="giahan" Text="Gia hạn" />
                                               
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="Label14" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Trong phiếu mượn: "></asp:Label>
                                                  <asp:Label ID="MaPhieuMuonLabel" runat="server" Height="25px" Width="350px" 
                                                      Text='<%# Eval("Maphieumuon") %>'></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="Label24" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Lập bởi nhân viên: "></asp:Label>
                                                  <asp:Label ID="TenNhanVienLabel" runat="server" Height="25px" Width="350px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="Label25" runat="server" Font-Bold="True" Height="25px" 
                                                      Text="Mã nhân viên: "></asp:Label>
                                                  <asp:Label ID="MaNhanVienLabel" runat="server" Height="25px" Width="350px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="ThongbaoLabel" runat="server" ForeColor="Red" 
                                                      Style="text-align:center" Width="680px"></asp:Label>
                                              </td>
                                          </tr>
                                      </table>
                                  </ItemTemplate>
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
          </table>
          </ContentTemplate>
          </asp:UpdatePanel>
      
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>