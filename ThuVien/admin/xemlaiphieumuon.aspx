<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xemlaiphieumuon.aspx.cs" Inherits="admin_xemlaiphieumuon" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
    <style type="text/css">
    
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
		<div id="container_head">Xem lại phiếu mượn</div>
	  <div id="Container">
          <table width="690">
              <tr>
                  <td>
                              <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Mã độc giả: "></asp:Label>
                              <asp:TextBox ID="TimTextBox" runat="server" Width="200px"></asp:TextBox>
                              <asp:ImageButton ID="TimButton" runat="server" Height="25px" 
                                  ImageUrl="~/images/search_tool.jpg" Width="25px" 
                                  onclick="TimButton_Click" />
                          </td>
              </tr>
              <tr>
                  <td>
                              <asp:Label ID="ThongbaoLabel" runat="server" ForeColor="Red" Width="690px" Style="text-align:center"></asp:Label>
                          </td>
              </tr>
              <tr>
                  <td>
                              <asp:GridView ID="PhieuMuonGridView" runat="server" AutoGenerateColumns="False" 
                                  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                  CellPadding="4" ForeColor="Black" GridLines="Horizontal" ShowHeader="False" 
                                  Width="690px" onrowcommand="PhieuMuonGridView_RowCommand" 
                                  onrowcreated="PhieuMuonGridView_RowCreated" AllowPaging="True" 
                                  onpageindexchanging="PhieuMuonGridView_PageIndexChanging" 
                          PageSize="8">
                                  <Columns>
                                      <asp:TemplateField>
                                          <ItemTemplate>
                                              <table width="690">
                                                  <tr>
                                                      <td>
                                                          <asp:Label ID="Label2" runat="server" Text="Mã phiếu mượn: " Font-Bold="True"></asp:Label>
                                                          <asp:Label ID="MaPhieuLabel" runat="server" Text='<%# Eval("MaPhieuMuon") %>'></asp:Label>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td>
                                                          <asp:Label ID="Label3" runat="server" Text="Nhân viên lập phiếu: " 
                                                              Font-Bold="True"></asp:Label>
                                                          <asp:Label ID="TenNhanVienLabel" runat="server" Text="Label"></asp:Label>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td>
                                                          <asp:Label ID="Label5" runat="server" Text="Mã nhân viên: " Font-Bold="True"></asp:Label>
                                                          <asp:Label ID="MaNhanVienLabel" runat="server" Text='<%# Eval("MaNV") %>'></asp:Label>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td>
                                                          <asp:Label ID="Label4" runat="server" Text="Ngày lập phiếu: " Font-Bold="True"></asp:Label>
                                                          <asp:Label ID="NgayLapLabel" runat="server" Text='<%# Eval("NgayMuon") %>'></asp:Label>
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td>
                                                          <asp:Button ID="Button1" runat="server" 
                                                              CommandArgument='<%# Eval("MaPhieuMuon") %>' 
                                                              CommandName="in" Text="In phiếu" Style="margin-left:100px"/>
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
      </div>
		<div id="container_bottom"></div>
		</div> 
          <asp:Panel ID="BaoCaoPanel" runat="server" Visible="false">  
                <asp:Button ID="ThoatButton" runat="server" Text="X" Style="margin-left:705px" onclick="ThoatButton_Click" Visible="false" />
              <CR:CrystalReportViewer  ID="InPhieuReport" runat="server" BestFitPage="False" ToolPanelView="None" />
          </asp:Panel>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>
