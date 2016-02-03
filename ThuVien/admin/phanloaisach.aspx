<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phanloaisach.aspx.cs" Inherits="admin_phanloaisach" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
          <table style="width:690px" bgcolor="#E8F3FF">
              <tr>
                  <td>
                      <asp:DropDownList ID="LoaiSachDropdown" runat="server" AutoPostBack="True" 
                          Height="25px" onselectedindexchanged="LoaiSachDropdown_SelectedIndexChanged" 
                          Width="150px">
                          <asp:ListItem Value="0">Tất cả sách</asp:ListItem>
                          <asp:ListItem Value="1">Sách chưa phân loại</asp:ListItem>
                      </asp:DropDownList>
                  <asp:TextBox ID="TimTextbox" runat="server" 
                          Width="490px" Height="20px"></asp:TextBox>  </td>
                  <td><asp:ImageButton ID="TimButton" runat="server" 
                          Text="Thêm mới" Width="25px" 
                          Height="25px" ImageUrl="~/images/search_tool.jpg" 
                          onclick="TimButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">  
                      
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
                                      <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Ngày nhập sách: "></asp:Label>
                                      <asp:Label ID="NgaynhapLabel" runat="server" Text='<%# Eval("ngaynhap") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" 
                                          CommandArgument='<%# Eval("madausach") %>' CommandName="phanloai" 
                                          Height="25px" ImageUrl="~/images/rights.jpg" ToolTip="Phân lọai sách" 
                                          Width="25px" Style="margin:0 0 5px 5px"/>
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
              </table>  
          <%--popup chi tiết sách--%>
              <asp:HiddenField ID="ChiTietSachHid" runat="server" />        
          <asp:ModalPopupExtender ID="ChiTietPopup" runat="server"
              PopupControlID="ChiTietSachPanel" TargetControlID="ChiTietSachHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyChiTietButton"
              DropShadow="true">
          </asp:ModalPopupExtender>      
          <%--------%>
           <asp:Panel ID="ChiTietSachPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Phân lọai sách</div>
                <div class="popup_content">
                     <table width="380">
                       <tr>  <td style="width:125px">                                
                           
                             <asp:Image ID="HinhanhdausachImage" runat="server" Height="160px" 
                                 Width="120px" />                           
                             </td>
                             
                           <td>
                               <asp:Label ID="TenDauSachLabel" runat="server" Font-Bold="False" 
                                   Font-Size="14pt" ForeColor="Blue"></asp:Label>
                               <br />
                               <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                               <asp:Label ID="ChiTietDauSachLanXuatBanLabel" runat="server"></asp:Label>
                               <br />
                               <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Trị giá: "></asp:Label>
                               <asp:Label ID="ChiTietDauSachTriGiaLabel" runat="server"></asp:Label>
                               <asp:Label ID="Label33" runat="server" Text=" vnđ"></asp:Label>
                               <br />
                               <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="Ngày nhập: "></asp:Label>
                               <asp:Label ID="ChiTietDauSachNgayNhapLabel" runat="server"></asp:Label>
                           </td>
                             
                         </tr> 
                         <tr>
                             <td>                                
                           
                                 <asp:Label ID="Label34" runat="server" Text="Lọai sách:" Font-Bold="True" 
                                     Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="LoaiSachLuuDropdown" runat="server" Width="200px">
                                 </asp:DropDownList>
                             </td>
                         </tr> 
                         <tr>
                             <td>
                                 <asp:Label ID="Label35" runat="server" Font-Bold="True" Height="25px" 
                                     Text="Phân lọai sách:"></asp:Label>
                             </td>
                             <td>
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                 <ContentTemplate>
                                  <asp:DropDownList ID="PhanLoaiDropDown" runat="server" Width="200px" 
                                     Style="margin-bottom:5px" AutoPostBack="True" 
                                     onselectedindexchanged="PhanLoaiDropDown_SelectedIndexChanged">
                                 </asp:DropDownList>
                                 <br />
                                 <asp:DropDownList ID="CTPhanLoaiDropdown" runat="server" Width="200px">
                                 </asp:DropDownList>
                                 </ContentTemplate>
                                 </asp:UpdatePanel>
                                
                             </td>
                         </tr>
                          <tr>
                             <td>
                                 <asp:Label ID="Label36" runat="server" Font-Bold="True" Height="25px" 
                                     Text="Khu vực:"></asp:Label>
                              </td>
                             <td>
                                 <asp:DropDownList ID="KhuvucDropdown" runat="server" Width="200px">
                                 </asp:DropDownList>
                              </td>
                         </tr>
                          <tr>
                             <td>
                                 <asp:Label ID="Label37" runat="server" Font-Bold="True" Height="25px" 
                                     Text="Kệ:"></asp:Label>
                              </td>
                             <td>
                                 <asp:TextBox ID="KeTextbox" runat="server"></asp:TextBox>
                              </td>
                         </tr>
                          <tr>
                             <td>
                                 <asp:Label ID="Label38" runat="server" Font-Bold="True" Height="25px" 
                                     Text="Ngăn:"></asp:Label>
                              </td>
                             <td>
                                 <asp:TextBox ID="NganTextbox" runat="server"></asp:TextBox>
                              </td>
                         </tr>
                          <tr>
                             <td>
                                 <asp:Label ID="Label39" runat="server" Font-Bold="True" Height="25px" 
                                     Text="Mượn đem về:"></asp:Label>
                              </td>
                             <td>
                                 <asp:CheckBox ID="MuondemveCheckbox" runat="server" />
                              </td>
                         </tr>
                         <tr>
                         <td>
                                
                             </td>
                             <td>
                                 <asp:Button ID="LuuButton" runat="server" Text="Lưu" 
                                     Style="margin-left:70px" Width="75px" onclick="LuuButton_Click"/>
                                 <asp:Button ID="HuyChiTietButton" runat="server" Text="Hủy" 
                                     Style="margin-left:20px" Width="75px"/>
                             </td>                             
                         </tr>
                     </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%------%>
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>