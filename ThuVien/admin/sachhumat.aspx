<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sachhumat.aspx.cs" Inherits="admin_sachhumat" %>


<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
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
		<div id="container_head">Cập nhật sách hư - mất</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>          
          <table class="style1">
              <tr>
                  <td>
                      <asp:DropDownList ID="CachTimDropdown" runat="server" Width="100px">
                          <asp:ListItem Value="0">Tên sách: </asp:ListItem>
                          <asp:ListItem Value="1">Mã sách:</asp:ListItem>
                      </asp:DropDownList>
                      <asp:TextBox ID="TenSachTextBox" runat="server" Width="550px"></asp:TextBox>
                      <asp:ImageButton ID="TimButton" runat="server" Height="25px" 
                          ImageUrl="~/images/search_tool.jpg" onclick="TimButton_Click" Width="25px" />
                  </td>
              </tr>
              <tr>
                  <td>
                      
                      <asp:GridView ID="SachGridView" runat="server" AutoGenerateColumns="False" 
                          Width="690px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                          AllowPaging="True" onpageindexchanging="SachGridView_PageIndexChanging" 
                          onrowcreated="SachGridView_RowCreated" 
                          onrowcommand="SachGridView_RowCommand" PageSize="8">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Image ID="Image1" runat="server" Height="120px" Width="90px" 
                                          Style="margin:5px" ImageUrl='<%# Eval("HinhAnh") %>' />
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle Width="100px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Tên - tác giả">
                                  <ItemTemplate>
                                      <asp:Label ID="Label26" runat="server" Text='<%# Eval("Masach") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="TenSachLabel" runat="server" Text='<%# Eval("TenSach") %>' 
                                          Width="200px" Font-Bold="True" Font-Size="13pt" ForeColor="#0000CC"></asp:Label>
                                     <br />
                                      <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tác giả:"></asp:Label>
                                      <br />
                                      <asp:ListBox ID="TacGiaListBox" runat="server" Width="200px" 
                                          DataSource='<%# Eval("tacgiaColl") %>' DataTextField="TenTG" DataValueField="MaTG" ></asp:ListBox>
                                  </ItemTemplate>
                                  <HeaderStyle Width="280px" />
                                  <ItemStyle Width="280px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin">
                                  <ItemTemplate>
                                      <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Nhà xuất bản: "></asp:Label>
                                      <asp:Label ID="NhaxuatbanLabel" runat="server" Text=""></asp:Label>
                                      <br />
                                      <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Năm xuất bản: "></asp:Label>
                                      <asp:Label ID="NamxuatbanLabel" runat="server" Text='<%# Eval("namxuatban") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                                      <asp:Label ID="LanxuatbanLabel" runat="server" Text='<%# Eval("lanxuatban") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Trị giá: "></asp:Label>
                                      <asp:Label ID="TriGiaLabel" runat="server" Text='<%# Eval("trigia") %>'></asp:Label>
                                      <asp:Label ID="Label25" runat="server" Text=" vnđ"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Ngày nhập: "></asp:Label>
                                      <asp:Label ID="SoNgayHetHanLabel" runat="server" Text='<%# Eval("NgayNhap") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                          <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("MaSach") %>' 
                                              CommandName="mat" Text="Sách mất" Width="80px" />
                                          <br />
                                          <br />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
                              </asp:TemplateField>
                          </Columns>
                          <EditRowStyle BackColor="#2461BF" />
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#EFF3FB" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F5F7FB" />
                          <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                          <SortedDescendingCellStyle BackColor="#E9EBEF" />
                          <SortedDescendingHeaderStyle BackColor="#4870BE" />
                      </asp:GridView>
                  </td>
              </tr>
              <tr>
                  <td>
                      
                      <asp:Label ID="ThonBaoLabel" runat="server" ForeColor="Red" 
                          Width="690px" Style="text-align:center"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td bgcolor="#999999">
                      <asp:Label ID="Label34" runat="server" Font-Bold="True" ForeColor="White" 
                          Height="23px" Text="Phục hồi lại sách"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:DropDownList ID="CachTim2Dropdown" runat="server" Width="100px">
                          <asp:ListItem Value="0">Tên sách: </asp:ListItem>
                          <asp:ListItem Value="1">Mã sách:</asp:ListItem>
                      </asp:DropDownList>
                      <asp:TextBox ID="TenSach2TextBox" runat="server" Width="550px"></asp:TextBox>
                      <asp:ImageButton ID="Tim2Button" runat="server" Height="25px" 
                          ImageUrl="~/images/search_tool.jpg" onclick="Tim2Button_Click" 
                          Width="25px" />
                  </td>
              </tr>
              <tr>
                  <td>
                      
                      <asp:GridView ID="Sach2GridView" runat="server" AutoGenerateColumns="False" 
                          Width="690px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                          AllowPaging="True" onpageindexchanging="Sach2GridView_PageIndexChanging" 
                          onrowcreated="Sach2GridView_RowCreated" 
                          onrowcommand="Sach2GridView_RowCommand" PageSize="8">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Image ID="Image2" runat="server" Height="120px" Width="90px" 
                                          Style="margin:5px" ImageUrl='<%# Eval("HinhAnh") %>' />
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle Width="100px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Tên - tác giả">
                                  <ItemTemplate>
                                      <asp:Label ID="Label35" runat="server" Text='<%# Eval("Masach") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="TenSachLabel0" runat="server" Text='<%# Eval("TenSach") %>' 
                                          Width="200px" Font-Bold="True" Font-Size="13pt" ForeColor="#0000CC"></asp:Label>
                                     <br />
                                      <asp:Label ID="Label36" runat="server" Font-Bold="True" Text="Tác giả:"></asp:Label>
                                      <br />
                                      <asp:ListBox ID="TacGiaListBox0" runat="server" Width="200px" 
                                          DataSource='<%# Eval("tacgiaColl") %>' DataTextField="TenTG" 
                                          DataValueField="MaTG" ></asp:ListBox>
                                  </ItemTemplate>
                                  <HeaderStyle Width="280px" />
                                  <ItemStyle Width="280px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin">
                                  <ItemTemplate>
                                      <asp:Label ID="Label37" runat="server" Font-Bold="True" Text="Nhà xuất bản: "></asp:Label>
                                      <asp:Label ID="NhaxuatbanLabel0" runat="server" Text=""></asp:Label>
                                      <br />
                                      <asp:Label ID="Label38" runat="server" Font-Bold="True" Text="Năm xuất bản: "></asp:Label>
                                      <asp:Label ID="NamxuatbanLabel0" runat="server" 
                                          Text='<%# Eval("namxuatban") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label39" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                                      <asp:Label ID="LanxuatbanLabel0" runat="server" 
                                          Text='<%# Eval("lanxuatban") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label40" runat="server" Font-Bold="True" Text="Trị giá: "></asp:Label>
                                      <asp:Label ID="TriGiaLabel0" runat="server" Text='<%# Eval("trigia") %>'></asp:Label>
                                      <asp:Label ID="Label41" runat="server" Text=" vnđ"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label42" runat="server" Font-Bold="True" Text="Ngày nhập: "></asp:Label>
                                      <asp:Label ID="SoNgayHetHanLabel0" runat="server" 
                                          Text='<%# Eval("NgayNhap") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                          <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("MaSach") %>' 
                                              CommandName="phuchoi" Text="Phục hồi" Width="80px" />
                                          <br />
                                          <br />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
                              </asp:TemplateField>
                          </Columns>
                          <EditRowStyle BackColor="#2461BF" />
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#EFF3FB" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F5F7FB" />
                          <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                          <SortedDescendingCellStyle BackColor="#E9EBEF" />
                          <SortedDescendingHeaderStyle BackColor="#4870BE" />
                      </asp:GridView>
                  </td>
              </tr>
              <tr>
                  <td>
                      
                      <asp:Label ID="ThonBaoLabel0" runat="server" ForeColor="Red" 
                          Width="690px" Style="text-align:center"></asp:Label>
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